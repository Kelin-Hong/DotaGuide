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
using ImageTools.IO.Gif;
using Dota攻略宝典.DataBase;
using Dota攻略宝典.Httphelp;
using System.Windows.Media.Imaging;
namespace Dota攻略宝典.UserControls
{
    
    public partial class SingleHeroInfo : UserControl
    {
        //public string HtmlStr;
        //private Database db = new Database(Database.contectStr);
        //private HtmlHelp htmlHelp = new HtmlHelp();
        public SingleHeroInfo(HeroInfoTable heroInfo)
        {
            InitializeComponent();
            //HeroTable hero = db.heroTable.First(c => c.Id == id);
            //if (db.heroInfoTable.Any(c => c.ChineseName.Equals(hero.Name)))
            //{
            //    fillData(db.heroInfoTable.First(c => c.ChineseName.Equals(hero.Name)));
            //}
            //else
            //{
            //    htmlHelp.DownloadPage(hero.Link, callback);
            //}
            fillData(heroInfo);
        }

       
        private void fillData(HeroInfoTable heroInfo)
        {

            tbl_chineseName.Text = heroInfo.ChineseName;
            tbl_englishName.Text = heroInfo.EnglishName;
            tbl_JianChen.Text += heroInfo.JianChen;
            tbl_content.Text = heroInfo.Content;
            
            tbl_ShortKey.Text += heroInfo.ShortKey;
            for (int i = 0; i < heroInfo.Gank; i++)
            {
                Image start = new Image { Source = new BitmapImage(new Uri("/Images/xx_liang.jpg", UriKind.Relative)) };
                start.Width = 50;
                start.Height = 50;
                wp_Grank.Children.Add(start);
            }
            for (int i = 0; i <5- heroInfo.Gank; i++)
            {
                Image start = new Image { Source = new BitmapImage(new Uri("/Images/xx_an.jpg", UriKind.Relative)) };
                start.Width = 50;
                start.Height = 50;
                wp_Grank.Children.Add(start);
            }


            for (int i = 0; i < heroInfo.ShuChu; i++)
            {
                Image start = new Image { Source = new BitmapImage(new Uri("/Images/xx_liang.jpg", UriKind.Relative)) };
                start.Width = 50;
                start.Height = 50;
                wp_ShuChu.Children.Add(start);
            }
            for (int i = 0; i <5-heroInfo.ShuChu; i++)
            {
                Image start = new Image { Source = new BitmapImage(new Uri("/Images/xx_an.jpg", UriKind.Relative)) };
                start.Width = 50;
                start.Height = 50;
                wp_ShuChu.Children.Add(start);
            }


            for (int i = 0; i < heroInfo.FuZhu; i++)
            {
                Image start = new Image { Source = new BitmapImage(new Uri("/Images/xx_liang.jpg", UriKind.Relative)) };
                start.Width = 50;
                start.Height = 50;
                wp_FuZhu.Children.Add(start);
            }
            for (int i = 0; i <5- heroInfo.FuZhu; i++)
            {
                Image start = new Image { Source = new BitmapImage(new Uri("/Images/xx_an.jpg", UriKind.Relative)) };
                start.Width = 50;
                start.Height = 50;
                wp_FuZhu.Children.Add(start);
            }


            for (int i = 0; i < heroInfo.TuiJin; i++)
            {
                Image start = new Image { Source = new BitmapImage(new Uri("/Images/xx_liang.jpg", UriKind.Relative)) };
                start.Width = 50;
                start.Height = 50;
                wp_TuiJin.Children.Add(start);
            }
            for (int i = 0; i <5- heroInfo.TuiJin; i++)
            {
                Image start = new Image { Source = new BitmapImage(new Uri("/Images/xx_an.jpg", UriKind.Relative)) };
                start.Width = 50;
                start.Height = 50;
                wp_TuiJin.Children.Add(start);
            }


            for (int i = 0; i < heroInfo.RouDun; i++)
            {
                Image start = new Image { Source = new BitmapImage(new Uri("/Images/xx_liang.jpg", UriKind.Relative)) };
                start.Width = 50;
                start.Height = 50;
                wp_RuoDun.Children.Add(start);
            }
            for (int i = 0; i <5- heroInfo.RouDun; i++)
            {
                Image start = new Image { Source = new BitmapImage(new Uri("/Images/xx_an.jpg", UriKind.Relative)) };
                start.Width = 50;
                start.Height = 50;
                wp_RuoDun.Children.Add(start);
            }
            //ImageTools.IO.Decoders.AddDecoder<GifDecoder>();
            //ImageTools.ExtendedImage image = new ImageTools.ExtendedImage();
            //image.UriSource = new Uri(heroInfo.AvatarUri);
            //Avatar.Source = image;
            Avatar.Source = new BitmapImage(new Uri(heroInfo.AvatarUri, UriKind.Relative));
        }
    }
}
