using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Dota攻略宝典.UserControls;
using Dota攻略宝典.DataBase;
using Dota攻略宝典.Httphelp;
using System.Windows.Media.Imaging;
namespace Dota攻略宝典.Views
{
    public partial class SingleHero : PhoneApplicationPage
    {
        int id;
        private Database db = new Database(Database.contectStr);
        private HtmlHelp htmlHelp = new HtmlHelp();
        private bool networkIsAvailable;
        public SingleHero()
        {
            InitializeComponent();
            networkIsAvailable = Microsoft.Phone.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (!networkIsAvailable)
            {
                MessageBoxResult result = MessageBox.Show("检测到当前没有网络,请联上网络重启程序", "提醒", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    this.Exit();
                }
            }
           // panorama1.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/background2.jpg", UriKind.Relative)) };
           
        }
        private void Exit()
        {
            while (NavigationService.BackStack.Any())
                NavigationService.RemoveBackEntry();
            this.IsHitTestVisible = this.IsEnabled = false;
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            id = Int32.Parse(NavigationContext.QueryString["id"]);
            List<HeroTable> list = db.heroTable.ToList();
            HeroTable hero = db.heroTable.First(c => c.Id == id);
            if (db.heroInfoTable.Any(c => c.ChineseName.Equals(hero.Name)))
            {
               // fillData(db.heroInfoTable.First(c => c.ChineseName.Equals(hero.Name)));
                SingleHeroInfo singleHeroInfo = new SingleHeroInfo(db.heroInfoTable.First(c => c.ChineseName.Equals(hero.Name)));
                lb_Info.Items.Add(singleHeroInfo);
                List<JiNengTable> list_JiNengTable = new List<JiNengTable>();
                list_JiNengTable = db.jinengTable.Where(c => c.HeroId == id).ToList();
                JiNengInfo jiNengInfo = new JiNengInfo(list_JiNengTable);
                grid_JiNeng.Children.Add(jiNengInfo);
                List<ChuZhuangTable> list_ChuZhuangTable = db.chuZhuangTable.Where(c => c.HeroId == id).ToList();
                ChuZhuangControl chuZhongControl = new ChuZhuangControl(list_ChuZhuangTable,db.heroInfoTable.First(c => c.ChineseName.Equals(hero.Name)));
                grid_ZhuangBei.Children.Add(chuZhongControl);
            }
            else
            {
                waiting.WaitingBegin();
                htmlHelp.DownloadPage(hero.Link, callback);
            }
          
            //JiNengInfo jiNengInfo = new JiNengInfo(id, singleHeroInfo.HtmlStr);
            // lb_Info.Items.Add(singleHeroInfo);
        }

        private void callback(string htmlStr)
        {
            if (htmlStr.Equals("NO"))
            {
                MessageBoxResult result = MessageBox.Show("提醒", "检测当前没有网络,请联上网络在重启程序", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    this.Exit();
                }
            }
            SingleHeroClass singHero = new SingleHeroClass(htmlStr);
            string gif = singHero.Image;
            int start = gif.LastIndexOf('/');
            int length = gif.Length - start;
            string name = gif.Substring(start + 1);
            string name1 = " /Avatars/" + name.Substring(0, name.Length - 4) + ".png";
            HeroInfoTable heroInfo = new HeroInfoTable()
            {
                AvatarUri = name1,
                ChineseName = singHero.Chinese,
                EnglishName = singHero.English,
                ShortKey = singHero.Kuaijie,
                JianChen = singHero.Short,
                Content = singHero.Body,
                Gank = singHero.Gank,
                ShuChu = singHero.Shuchu,
                TuiJin = singHero.Tuijin,
                FuZhu = singHero.Fuzhu,
                RouDun = singHero.Roudun,
                ChangGui = singHero.Changgui,
                ChuMen = singHero.Chumen,
                ZhongQi = singHero.Chumen,
                HuoQi = singHero.Houqi
            };
            db.heroInfoTable.InsertOnSubmit(heroInfo);
            SingleHeroInfo singleHeroInfo = new SingleHeroInfo(heroInfo);
            lb_Info.Items.Add(singleHeroInfo);
            List<JiNengTable> list_JiNengTable = new List<JiNengTable>();
            foreach (Jineng item in singHero.list_Jienng)
            {
                string gif1 = item.Image;
                int start1 = gif1.LastIndexOf('/');
                int length1 = gif1.Length - start1;
                string name2 = gif1.Substring(start1 + 1);
                string name3 = " /JiNengs/" + name2.Substring(0, name2.Length - 4) + ".png";
                JiNengTable jiNeng = new JiNengTable()
                {
                    AvatarUri = name3,
                    Name = item.Name,
                    Intro = item.Intro,
                    Detail = item.Detail,
                    ShortKey = item.Kuaijie,
                    HeroId = id
                };
                list_JiNengTable.Add(jiNeng);
                db.jinengTable.InsertOnSubmit(jiNeng);
            }
            JiNengInfo jiNengInfo = new JiNengInfo(list_JiNengTable);
            grid_JiNeng.Children.Add(jiNengInfo);
            dealWithChuZhuang(singHero, heroInfo);
            waiting.WaitingEnd();
            db.SubmitChanges();
        }

        private void dealWithChuZhuang(SingleHeroClass singHero,HeroInfoTable heroInfo)
        {
            List<ChuZhuangTable> list = new List<ChuZhuangTable>();
            if (singHero.HouqiImage != null)
            {
                foreach (string s in singHero.ChumenImage)
                {
                    ChuZhuangTable chuZhuang1 = new ChuZhuangTable();
                    chuZhuang1.HeroId = id;

                    int start1 = s.LastIndexOf('/');
                    int length1 = s.Length - start1;
                    string name2 = s.Substring(start1 + 1);
                    string name3 = " /Items/" + name2.Substring(0, name2.Length - 4) + ".png";
                    chuZhuang1.ItemUri = name3;
                    chuZhuang1.Index = 1;
                    db.chuZhuangTable.InsertOnSubmit(chuZhuang1);
                    list.Add(chuZhuang1);
                }
            }
            if (singHero.ZhongqiImage != null)
            {
                foreach (string s in singHero.ZhongqiImage)
                {
                    ChuZhuangTable chuZhuang1 = new ChuZhuangTable();
                    chuZhuang1.HeroId = id;
                    int start1 = s.LastIndexOf('/');
                    int length1 = s.Length - start1;
                    string name2 = s.Substring(start1 + 1);
                    string name3 = " /Items/" + name2.Substring(0, name2.Length - 4) + ".png";
                    chuZhuang1.ItemUri = name3;
                    chuZhuang1.Index = 2;
                    db.chuZhuangTable.InsertOnSubmit(chuZhuang1);
                    list.Add(chuZhuang1);
                }
            }
            if (singHero.HouqiImage != null)
            {
                foreach (string s in singHero.HouqiImage)
                {
                    ChuZhuangTable chuZhuang1 = new ChuZhuangTable();
                    chuZhuang1.HeroId = id;
                    int start1 = s.LastIndexOf('/');
                    int length1 = s.Length - start1;
                    string name2 = s.Substring(start1 + 1);
                    string name3 = " /Items/" + name2.Substring(0, name2.Length - 4) + ".png";
                    chuZhuang1.ItemUri = name3;
                    chuZhuang1.Index = 3;
                    db.chuZhuangTable.InsertOnSubmit(chuZhuang1);
                    list.Add(chuZhuang1);
                }
            }
            ChuZhuangControl chuZhongControl = new ChuZhuangControl(list, heroInfo);
            grid_ZhuangBei.Children.Add(chuZhongControl);
        }
        private void dealJiaDian(SingleHeroClass singHero)
        {
           
        }
    }
}