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
using ImageTools.IO.Gif;
using System.Windows.Media.Imaging;
using Dota攻略宝典.DataBase;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Shell; 
namespace Dota攻略宝典.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        Database db = new Database(Database.contectStr);
        private bool networkIsAvailable;
        public MainPage()
        {
            networkIsAvailable = Microsoft.Phone.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (!networkIsAvailable)
            {
                MessageBoxResult result = MessageBox.Show("检测到当前没有网络,请按返回键退出程序联上网络并重启程序", "提醒", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    this.IsHitTestVisible = this.IsEnabled = false;
                    if (this.ApplicationBar != null)
                    {
                        foreach (var item in ApplicationBar.MenuItems.OfType<ApplicationBarMenuItem>())
                        {
                            item.IsEnabled = false;
                        }

                    }
                }
            }
            else
            {
                InitializeComponent();
            }
            
          
           
          // panorama.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("/Images/background.jpg", UriKind.Relative)) };
            //string gif = "http://webpic.sgamer.com/wiki/dotahero/windrunner.gif";
            //ImageTools.IO.Decoders.AddDecoder<GifDecoder>();
            //ImageTools.ExtendedImage image = new ImageTools.ExtendedImage();
            //image.UriSource = new Uri("/Avatar/gyrocopter.png", UriKind.Relative);
            //imgGif.Source = image;
             
        }

        public void Exit()
        {
            while (NavigationService.BackStack.Any())
                NavigationService.RemoveBackEntry();
            this.IsHitTestVisible = this.IsEnabled = false;
            if (this.ApplicationBar != null)
            {
                foreach(var item in ApplicationBar.MenuItems.OfType<ApplicationBarMenuItem>())
                {
                    item.IsEnabled = false;
                }

            }
        }
        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            if (db.DatabaseExists())
            {
                db.heroTable.DeleteAllOnSubmit(db.heroTable);
                db.heroInfoTable.DeleteAllOnSubmit(db.heroInfoTable);
                db.itemsTable.DeleteAllOnSubmit(db.itemsTable);
                db.jinengTable.DeleteAllOnSubmit(db.jinengTable);
                db.chuZhuangTable.DeleteAllOnSubmit(db.chuZhuangTable);
                
                db.SubmitChanges();
                  MessageBoxResult result= MessageBox.Show("处理完毕，请按确定退出程序并重新启动，便可获得最新数据", "更新", MessageBoxButton.OK);
                  if (result == MessageBoxResult.OK)
                  {
                      this.Exit();
                  }
                
            }
           
            
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (items.grid_Web.Visibility == Visibility.Visible)
            {
                items.Storyboard2.Begin();
                items.grid_Web.Visibility = Visibility.Collapsed;
                e.Cancel = true;
            }
        }
    }
}