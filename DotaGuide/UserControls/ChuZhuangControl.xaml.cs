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
using Dota攻略宝典.DataBase;
using System.Windows.Media.Imaging;
namespace Dota攻略宝典.UserControls
{
    public partial class ChuZhuangControl : UserControl
    {
        private Database db = new Database(Database.contectStr);
        public ChuZhuangControl(List<ChuZhuangTable> list,HeroInfoTable singHero)
        {
            InitializeComponent();
            this.tbl_Title.Text = "英雄出装路线";
            if (list != null||list.Count==0)
            {
                List<ChuZhuangTable> list1 = list.Where(c => c.Index == 1).ToList();
                List<ChuZhuangTable> list2 = list.Where(c => c.Index == 2).ToList();
                List<ChuZhuangTable> list3 = list.Where(c => c.Index == 3).ToList();
                foreach (ChuZhuangTable item in list1)
                {
                    Image image = new Image();
                    image.Width = 60;
                    image.Height = 60;
                    image.Margin = new Thickness(5, 5, 5, 5);
                    image.Source = new BitmapImage() { UriSource = new Uri(item.ItemUri, UriKind.Relative) };
                    wp_ChuMen.Children.Add(image);
                }
                tb1_ChuMenContent.Text = singHero.ChuMen;

                foreach (ChuZhuangTable item in list2)
                {
                    Image image = new Image();
                    image.Width = 60;
                    image.Height = 60;
                    image.Margin = new Thickness(5, 5, 5, 5);
                    image.Source = new BitmapImage() { UriSource = new Uri(item.ItemUri, UriKind.Relative) };
                    this.wp_ZhongQi.Children.Add(image);
                }
                tb1_ZhongQiContent.Text= singHero.ZhongQi;;
               

                foreach (ChuZhuangTable item in list3)
                {
                    Image image = new Image();
                    image.Width = 60;
                    image.Height = 60;
                    image.Margin = new Thickness(5, 5, 5, 5);
                    image.Source = new BitmapImage() { UriSource = new Uri(item.ItemUri, UriKind.Relative) };
                    wp_HouQi.Children.Add(image);
                }
               // tb1_ChuMenContent.Text = singHero.ChuMen;
                tb1_HouQiContent.Text = singHero.HuoQi;
            }
            else
            {
                this.tbl_Title.Text = "没有相关信息,请等待更新.....";

            }
        }
    }
}
