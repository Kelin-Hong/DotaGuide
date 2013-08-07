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
using Dota攻略宝典.Httphelp;
using System.Text.RegularExpressions;
using ImageTools.Controls;
using ImageTools.IO.Gif;
using System.Windows.Media.Imaging;
using System.Text;
using Dota攻略宝典.Views;
namespace Dota攻略宝典.UserControls
{
    public partial class Items : UserControl
    {
        Database db = new Database(Database.contectStr);
        string link = "http://dota.sgamer.com/item/";
        HtmlHelp htmlhelp = new HtmlHelp();
        private bool networkIsAvailable;
     //   List<int> list_int = new List<int>() {2,4,7,9,10,12,15,19,20,21,38,39,45,47,49,53,57,60,65,67,68,69,73,75, };
        public Items()
        {
            //networkIsAvailable = Microsoft.Phone.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            //if (!networkIsAvailable)
            //{
            //    MessageBoxResult result = MessageBox.Show("检测当前没有网络,请联上网络重启程序", "提醒", MessageBoxButton.OK);
            //    if (result == MessageBoxResult.OK)
            //    {
            //        ((MainPage)this.Parent).Exit();
            //    }
            //}
            InitializeComponent();
            grid1.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/1.jpg", UriKind.Relative)) };
            grid2.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/2.jpg", UriKind.Relative)) };
            grid3.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/3.jpg", UriKind.Relative)) };
            grid4.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/4.jpg", UriKind.Relative)) };
            grid5.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/5.jpg", UriKind.Relative)) };
            grid6.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/6.jpg", UriKind.Relative)) };
            grid7.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/7.jpg", UriKind.Relative)) };
            grid8.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/8.jpg", UriKind.Relative)) };
            grid9.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/9.jpg", UriKind.Relative)) };
            grid10.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/10.jpg", UriKind.Relative)) };
            grid11.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/11.jpg", UriKind.Relative)) };
            grid12.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/12.jpg", UriKind.Relative)) };
            grid13.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/13.jpg", UriKind.Relative)) };
            
            if (db.itemsTable.Count()!=0)
            {
                int i=0;
                foreach (ItemsTable items in db.itemsTable)
                {
                    i++;
                    Image imgGif = new Image();
                    imgGif.Width = 55;
                    imgGif.Height = 55;
                    imgGif.Margin = new Thickness(3, 3, 3, 3);
                    imgGif.Tag = items.DetailId;
                    //imgGif.DoubleTap+=new EventHandler<GestureEventArgs>(image_DoubleTap);
                    //imgGif.Hold += new EventHandler<GestureEventArgs>(imgGif_Hold);
                    imgGif.Tap+=new EventHandler<GestureEventArgs>(image_Tap);
                    imgGif.Source=new BitmapImage(new Uri(items.AvatarUri,UriKind.Relative));
                    if(i<=8) wp_Items1.Children.Add(imgGif);
                    if(i>8&&i<=19) wp_Items2.Children.Add(imgGif);
                    if(i>19&&i<=31) wp_Items3.Children.Add(imgGif);
                    if (i > 31 && i <= 43) wp_Items4.Children.Add(imgGif);
                    if (i > 43 && i <= 55) wp_Items5.Children.Add(imgGif);
                    if (i > 55 && i <= 63) wp_Items6.Children.Add(imgGif);
                    if (i > 63 && i <= 74) wp_Items7.Children.Add(imgGif);
                    if (i > 74 && i <= 85) wp_Items8.Children.Add(imgGif);
                    if (i > 85 && i <= 97) wp_Items9.Children.Add(imgGif);
                    if (i > 97 && i <= 109) wp_Items10.Children.Add(imgGif);
                    if (i > 109 && i <= 121) wp_Items11.Children.Add(imgGif);
                    if (i > 121 && i <= 133) wp_Items12.Children.Add(imgGif);
                    if (i > 133) wp_Items13.Children.Add(imgGif);
                }
            }
            else
            {
                htmlhelp.DownloadPage(link, callback);
            }
           // web.Source = new Uri("http://dota.sgamer.com/item/");
          //  web.NavigateToString("\u003cdiv class=\"I_ItemName wrapfix\"\u003e\u003cdiv class=\"FL\"\u003e\u003cb\u003e加速手套\u003c/b\u003e\u003c/div\u003e\u003cdiv class=\"FR\"\u003e500\u003c/div\u003e\u003c/div\u003e\u003cdiv class=\"I_ItemIntro\"\u003e\u003cspan class=\"stxt4\"\u003e说明\u003c/span\u003e\u003cbr/\u003e+15% 的攻击速度。 \u003c/div\u003e\u003cdiv class=\"I_ItemComponents\"\u003e\u003ctable cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" border=\"0\"\u003e\u003ctr\u003e\u003ctd colspan=\"2\"\u003e\u003cspan class=\"stxt4\"\u003e可用于合成\u003c/span\u003e\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"I_ItemComponent\"\u003e\u003ctd class=\"TC\"\u003e\u003cimg src=\"http://webpic.sgamer.com/Wiki/DOTAItem/Power Treads.gif\" align=\"absmiddle\" /\u003e\u003c/td\u003e\u003ctd\u003e假腿   （圣物关口 处购买）\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"I_ItemComponent\"\u003e\u003ctd class=\"TC\"\u003e\u003cimg src=\"http://webpic.sgamer.com/Wiki/DOTAItem/Hand of Midas.gif\" align=\"absmiddle\" /\u003e\u003c/td\u003e\u003ctd\u003e迈达斯之手  （圣物关口 处购买）\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"I_ItemComponent\"\u003e\u003ctd class=\"TC\"\u003e\u003cimg src=\"http://webpic.sgamer.com/Wiki/DOTAItem/Maelstorm.gif\" align=\"absmiddle\" /\u003e\u003c/td\u003e\u003ctd\u003e漩涡  （魅惑遗物 处购买）\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"I_ItemComponent\"\u003e\u003ctd class=\"TC\"\u003e\u003cimg src=\"http://webpic.sgamer.com/Wiki/DOTAItem/Armlet of Mordiggian.gif\" align=\"absmiddle\" /\u003e\u003c/td\u003e\u003ctd\u003e食尸鬼王的臂章  （远古兵器 处购买）\u003c/td\u003e\u003c/tr\u003e\u003c/table\u003e\u003c/div\u003e");
        }
        string id;

       
        private void callback(string htmlStr)
        {
          //  ItemsClass items = new ItemsClass(htmlStr);
            if (htmlStr.Equals("NO"))
            {
                MessageBoxResult result = MessageBox.Show("检测到当前没有网络,请联上网络重启程序", "提醒", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    ((MainPage)this.Parent).Exit();
                }
            }
            string str = htmlhelp.GetUniqTag(htmlStr, "div", "Class=\"BG_Block\"");
            List<string> contents = htmlhelp.GetImgTagFromHtml1(str);
            int i = 0;
            foreach (string s in contents)
            {
                i++;
                ItemsTable item=new ItemsTable();
                string gif = GetContent(s, "src");
                int start = gif.LastIndexOf('/');
                int length = gif.Length - start;
                string name = gif.Substring(start + 1);
                string name1 = " /Items/" + name.Substring(0, name.Length - 4) + ".png";
                item.AvatarUri = name1;
                Regex regex = new Regex("[0-9]{2,6}");
                Match match = regex.Match(GetContent(s, "onmouseover"));
                if (match.Success)
                {
                    item.DetailId = match.Value;
                }
                //AnimatedImage imgGif = new AnimatedImage();
                //imgGif.Width = 50;
                //imgGif.Height = 50;
                //ImageTools.ExtendedImage image = new ImageTools.ExtendedImage();
                //image.UriSource = new Uri(item.AvatarUri);
                //imgGif.Source = image;
                Image image = new Image();
                //image.DoubleTap += new EventHandler<GestureEventArgs>(image_DoubleTap);
                //image.Hold+=new EventHandler<GestureEventArgs>(imgGif_Hold);
                
                image.Tap += new EventHandler<GestureEventArgs>(image_Tap);
                image.Tag = item.DetailId;
                image.Width = 60;
                image.Height = 60;
                image.Margin = new Thickness(3, 3, 3, 3);
                image.Source = new BitmapImage() { UriSource = new Uri(name1, UriKind.Relative) };
                if (i <= 8) wp_Items1.Children.Add(image);
                if (i > 8 && i <= 19) wp_Items2.Children.Add(image);
                if (i > 19 && i <= 31) wp_Items3.Children.Add(image);
                if (i > 31 && i <= 43) wp_Items4.Children.Add(image);
                if (i > 43 && i <= 55) wp_Items5.Children.Add(image);
                if (i > 55 && i <= 63) wp_Items6.Children.Add(image);
                if (i > 63 && i <= 74) wp_Items7.Children.Add(image);
                if (i > 74 && i <= 85) wp_Items8.Children.Add(image);
                if (i > 85 && i <= 97) wp_Items9.Children.Add(image);
                if (i > 97 && i <= 109) wp_Items10.Children.Add(image);
                if (i > 109 && i <= 121) wp_Items11.Children.Add(image);
                if (i > 121 && i <= 133) wp_Items12.Children.Add(image);
                if (i > 133) wp_Items13.Children.Add(image);
                db.itemsTable.InsertOnSubmit(item);
            }
            db.SubmitChanges();
        }

        void image_Tap(object sender, GestureEventArgs e)
        {
            Storyboard1.Begin();
            grid_Web.Visibility = Visibility.Visible;
            id = (string)((Image)sender).Tag;
            ItemsTable item = db.itemsTable.First(c => c.DetailId.Equals(id));
            if (item.Detail == null)
            {
                networkIsAvailable = Microsoft.Phone.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                if (!networkIsAvailable)
                {
                    MessageBoxResult result = MessageBox.Show("检测到当前没有网络,请联上网络重启程序", "提醒", MessageBoxButton.OK);
                    if (result == MessageBoxResult.OK)
                    {
                        ((MainPage)this.Parent).Exit();
                    }
                }
                htmlhelp.DownloadPage("http://cms1.sgamer.com/Ajax/DisplayDOTAItem?callback=?&itemID=" + id, callback1);
            }
            else
            {
                webBrowser.NavigateToString(item.Detail);
            }
        }
       
       
        
      

        private void callback1(string detail)
        {
            if (detail.Equals("NO"))
            {
                MessageBoxResult result = MessageBox.Show("检测到当前没有网络,请联上网络重启程序", "提醒", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    ((MainPage)this.Parent).Exit();
                }
            }
            string detail1 = detail.Substring(3, detail.Length - 5);
            System.Diagnostics.Debug.WriteLine(detail1);
            
            string detail2=detail1.Replace("\\u003c", "<");
            detail2 = detail2.Replace("\\u003e", ">");
            detail2 = detail2.Replace("\\\"", "\"");
            
            //webBrowser.NavigateToString("\u003cdiv class=\"I_ItemName wrapfix\"\u003e\u003cdiv class=\"FL\"\u003e\u003cb\u003e加速手套\u003c/b\u003e\u003c/div\u003e\u003cdiv class=\"FR\"\u003e500\u003c/div\u003e\u003c/div\u003e\u003cdiv class=\"I_ItemIntro\"\u003e\u003cspan class=\"stxt4\"\u003e说明\u003c/span\u003e\u003cbr/\u003e+15% 的攻击速度。 \u003c/div\u003e\u003cdiv class=\"I_ItemComponents\"\u003e\u003ctable cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" border=\"0\"\u003e\u003ctr\u003e\u003ctd colspan=\"2\"\u003e\u003cspan class=\"stxt4\"\u003e可用于合成\u003c/span\u003e\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"I_ItemComponent\"\u003e\u003ctd class=\"TC\"\u003e\u003cimg src=\"http://webpic.sgamer.com/Wiki/DOTAItem/Power Treads.gif\" align=\"absmiddle\" /\u003e\u003c/td\u003e\u003ctd\u003e假腿   （圣物关口 处购买）\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"I_ItemComponent\"\u003e\u003ctd class=\"TC\"\u003e\u003cimg src=\"http://webpic.sgamer.com/Wiki/DOTAItem/Hand of Midas.gif\" align=\"absmiddle\" /\u003e\u003c/td\u003e\u003ctd\u003e迈达斯之手  （圣物关口 处购买）\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"I_ItemComponent\"\u003e\u003ctd class=\"TC\"\u003e\u003cimg src=\"http://webpic.sgamer.com/Wiki/DOTAItem/Maelstorm.gif\" align=\"absmiddle\" /\u003e\u003c/td\u003e\u003ctd\u003e漩涡  （魅惑遗物 处购买）\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"I_ItemComponent\"\u003e\u003ctd class=\"TC\"\u003e\u003cimg src=\"http://webpic.sgamer.com/Wiki/DOTAItem/Armlet of Mordiggian.gif\" align=\"absmiddle\" /\u003e\u003c/td\u003e\u003ctd\u003e食尸鬼王的臂章  （远古兵器 处购买）\u003c/td\u003e\u003c/tr\u003e\u003c/table\u003e\u003c/div\u003e");
           // webBrowser.NavigateToString("\u003cdiv class=\"I_ItemName wrapfix\"\u003e\u003cdiv class=\"FL\"\u003e\u003cb\u003e无用挂件\u003c/b\u003e\u003c/div\u003e\u003cdiv class=\"FR\"\u003e170 + \u003cspan class=\"stxt8\"\u003e335\u003c/span\u003e = 505\u003c/div\u003e\u003c/div\u003e\u003cdiv class=\"I_ItemIntro\"\u003e\u003cspan class=\"stxt4\"\u003e说明\u003c/span\u003e\u003cbr/\u003e+3 点的所有属性，额外+3 点的智力，+3点攻击力。\u003c/div\u003e\u003cdiv class=\"I_ItemComponents\"\u003e\u003ctable cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" border=\"0\"\u003e\u003ctr\u003e\u003ctd colspan=\"4\"\u003e\u003cspan class=\"stxt4\"\u003e合成需要\u003c/span\u003e\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"I_ItemComponent\"\u003e\u003ctd colspan=\"2\" class=\"TC\"\u003e\u003cimg src=\"http://webpic.sgamer.com/Wiki/DOTAItem/Mantle of Intelligence.gif\" align=\"absmiddle\" /\u003e\u003c/td\u003e\u003ctd\u003e智力斗篷&nbsp;&nbsp;（饰品商人希娜 处购买）\u003c/td\u003e\u003ctd\u003e\u003c/td\u003e\u003ctd class=\"stxt8 TR\"\u003e150\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"I_ItemComponent\"\u003e\u003ctd colspan=\"2\" class=\"TC\"\u003e\u003cimg src=\"http://webpic.sgamer.com/Wiki/DOTAItem/Circlet of Nobility.gif\" align=\"absmiddle\" /\u003e\u003c/td\u003e\u003ctd\u003e贵族圆环&nbsp;&nbsp;（饰品商人希娜 处购买）\u003c/td\u003e\u003ctd\u003e\u003c/td\u003e\u003ctd class=\"stxt8 TR\"\u003e185\u003c/td\u003e\u003c/tr\u003e\u003c/table\u003e\u003c/div\u003e\u003cdiv class=\"I_ItemComponents\"\u003e\u003ctable cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" border=\"0\"\u003e\u003ctr\u003e\u003ctd colspan=\"2\"\u003e\u003cspan class=\"stxt4\"\u003e可用于合成\u003c/span\u003e\u003c/td\u003e\u003c/tr\u003e\u003ctr class=\"I_ItemComponent\"\u003e\u003ctd class=\"TC\"\u003e\u003cimg src=\"http://webpic.sgamer.com/Wiki/DOTAItem/Dagon.gif\" align=\"absmiddle\" /\u003e\u003c/td\u003e\u003ctd\u003eDagon之神力&nbsp;&nbsp;（秘法圣所 处购买）\u003c/td\u003e\u003c/tr\u003e\u003c/table\u003e\u003c/div\u003e");
            webBrowser.NavigateToString(ConvertExtendedAscii(detail2));
            
            ItemsTable item = db.itemsTable.First(c => c.DetailId.Equals(id));
            item.Detail = ConvertExtendedAscii(detail2);
            db.SubmitChanges();
        }

   private  string ConvertExtendedAscii(string html)  
    {  
      StringBuilder sb = new StringBuilder();  
       foreach (var c in html)  
      {  
        int charInt = Convert.ToInt32(c);  
        if (charInt > 127)  
           sb.AppendFormat("&#{0};", charInt);  
         else  
           sb.Append(c);  
      }  
        return sb.ToString();  
     }  
        public string GetContent(string source, string item)
        {
            int begin = item.Length;
            Regex regex = new Regex(item + "=\"[^\"]*" + "\"");
            Match match = regex.Match(source);

            if (match.Success)
            {
                return match.Value.Substring(begin + 2).Trim('"');
            }
            return string.Empty;
        }

        

        private void img_Cancle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           Storyboard2.Begin();
           grid_Web.Visibility = Visibility.Collapsed;
        }

        
    }
}
