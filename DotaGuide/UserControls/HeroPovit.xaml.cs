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
using ImageTools.Controls;
using Dota攻略宝典.DataBase;
using Dota攻略宝典.Httphelp;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows.Interactivity;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Phone.Controls;
using Dota攻略宝典.Views;
namespace Dota攻略宝典.UserControls
{
    public partial class HeroPovit : UserControl
    {
        Database db = new Database(Database.contectStr);
        string link= "http://dota.sgamer.com/hero/";
       // List<int> intList = new List<int>() {12, 13 ,14 ,15 , 18 ,26 ,30 ,38, 50 ,60 ,61, 80 ,81, 83, 85, 86, 93, 94 ,95, 96 };
        int i = 0;
        HtmlHelp htmlhelp = new HtmlHelp();
        public HeroPovit()
        {
            InitializeComponent();
            if (db.heroTable.Count<HeroTable>() == 0)
            {
                waiting.WaitingBegin();
                htmlhelp.DownloadPage(link, callback);
            }
            else
            {
               
               getDataFromDataBase();
               
            }
            
        }
        private void callback(string htmlStr)
        {
           if(htmlStr.Equals("NO"))
           {
               MessageBoxResult result = MessageBox.Show("检测到当前没有网络,请联上网络重启程序", "提醒", MessageBoxButton.OK);
               if (result==MessageBoxResult.OK)
               {
                   ((MainPage)this.Parent).Exit();
               }
          }

            string heropart = htmlhelp.GetUniqTag(htmlStr, "div", "class=\"BG_Block\"");
            List<string> allheros = htmlhelp.GetTagCollectByCharacter(heropart, "li", "");

            foreach (var item in allheros)
            {
                i++;
                Hero hero = new Hero(item);
                string gif = hero.Src;
                int start = gif.LastIndexOf('/');
                  int length = gif.Length - start;
                  string name = gif.Substring(start + 1);
                  string name1 = " /Heros/" + name.Substring(0, name.Length - 4) + ".png";
                  Image image = new Image();
                  image.Width = 60;
                  image.Height = 60;
                  image.Margin = new Thickness(5, 5, 5, 5);
                  image.Source = new BitmapImage() { UriSource = new Uri(name1, UriKind.Relative) };
                  System.Windows.Interactivity.EventTrigger ev = new System.Windows.Interactivity.EventTrigger("Tap");
                  NavigateToPageAction action = new NavigateToPageAction();
                
                  ev.Actions.Add(action);
                    Interaction.GetTriggers(image).Add(ev);
                    if (i <= 38)
                    {
                        heroPanel1.Children.Add(image);
                    }
                    if (i > 38 && i <= 72)
                    {
                        heroPanel2.Children.Add(image);
                    }
                    if (i > 72)
                    {
                        heroPanel3.Children.Add(image);
                    }
                    HeroTable heroItem = new HeroTable()
                    {
                        AvatarUri = name1,
                        Name = hero.Alt,
                        Link = hero.Href
                    };
                    db.heroTable.InsertOnSubmit(heroItem);
                    db.SubmitChanges();
                    action.TargetPage = "/Views/SingleHero.xaml?id=" + heroItem.Id;
                  }
            waiting.WaitingEnd();
           
        }
       
        private void getDataFromDataBase()
        {
            i=0;
            foreach (HeroTable item in db.heroTable)
            {
                i++;
                    Image image = new Image();
                    image.Width = 60;
                    image.Height = 60;
                    image.Margin = new Thickness(5, 5, 5, 5);
                    image.Source = new BitmapImage() { UriSource = new Uri(item.AvatarUri, UriKind.Relative) };
                    System.Windows.Interactivity.EventTrigger ev = new System.Windows.Interactivity.EventTrigger("Tap");
                    NavigateToPageAction action = new NavigateToPageAction();
                    action.TargetPage = "/Views/SingleHero.xaml?id=" + item.Id;
                    ev.Actions.Add(action);
                    Interaction.GetTriggers(image).Add(ev);
                    
                    if (i <= 38)
                    {
                        heroPanel1.Children.Add(image);
                    }
                    if (i > 38 && i <= 72)
                    {
                        heroPanel2.Children.Add(image);
                    }
                    if (i > 72)
                    {
                        heroPanel3.Children.Add(image);
                    }  
            }
        }

    

       

       

        
    }
}
