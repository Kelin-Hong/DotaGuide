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
using System.Diagnostics;
using ImageTools.IO;
using ImageTools.IO.Gif;
namespace Dota攻略宝典.UserControls
{
    public partial class JiNengInfo : UserControl
    {
        public List<JiNengVm> vm = new List<JiNengVm>();
        
        public JiNengInfo(List<JiNengTable> list_jiNengTable)
        {
            InitializeComponent();
            int i = 0;
            foreach (JiNengTable item in list_jiNengTable)
            {
                i++;
               string[] s= item.Detail.Split("等级".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
              // Debug.WriteLine("");
               JiNengVm jinengVm = new JiNengVm();
               jinengVm.NameAndShort = item.Name + "(" + item.ShortKey + ")";
               jinengVm.Intro = item.Intro;
               jinengVm.Src = item.AvatarUri;
               jinengVm.Gread1 = s[0];
               jinengVm.Gread2 = s[1];
               jinengVm.Gread3 = s[2];
               if (i != 4)
               {
                   jinengVm.Gread4 = s[3];
               }
               else
                   jinengVm.Gread4 = "";
               vm.Add(jinengVm);
            }
            lb_Jineng.ItemsSource = vm;
        }
    }
  public class JiNengVm
    {
        public string NameAndShort { set; get; }
        public string Intro { set; get; }
        public string Src { set; get; }
        public string Gread1 { set; get; }
        public string Gread2 { set; get; }
        public string Gread3 { set; get; }
        public string Gread4 { set; get; }
    }

}
