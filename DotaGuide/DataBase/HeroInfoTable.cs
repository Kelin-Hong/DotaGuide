using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq.Mapping;
using System.ComponentModel;
namespace Dota攻略宝典.DataBase
{
    [Table]
    public class HeroInfoTable:INotifyPropertyChanged,INotifyPropertyChanging
    {
        private int id;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false, AutoSync = AutoSync.OnInsert, DbType = "INT NOT NULL Identity")]
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                OnPropertyChanging("Id");
                id = value;
                OnPropertyChanged("Id");
            }
        }
        private string avatarUri;
        [Column]
        public string AvatarUri
        {
            get { return avatarUri; }
            set
            {
                OnPropertyChanging("AvatarUri");
                avatarUri = value;
                OnPropertyChanged("AvatarUri");
            }
        }
        private string chineseName;
         [Column]
        public string ChineseName
        {
            get { return chineseName; }
            set
            {
                OnPropertyChanging("ChineseName");
                chineseName = value;
                OnPropertyChanged("ChineseName");
            }

        }

        private string englishName;
         [Column]
        public string EnglishName
        {
            get { return englishName; }
            set
            {
                OnPropertyChanging("EnglishName");
                englishName = value;
                OnPropertyChanged("EnglishName");
            }

        }
        private string shortKey;
         [Column]
        public string ShortKey
        {
            get { return shortKey; }
            set
            {
                OnPropertyChanging("ShortKey");
                shortKey = value;
                OnPropertyChanged("ShortKey");
            }
        }
         private string jianChen;
         [Column]
         public string JianChen
         {
             get { return jianChen; }
             set
             {
                 OnPropertyChanging("JianChen");
                 jianChen = value;
                 OnPropertyChanged("JianChen");
             }
         }
        private string content;
         [Column]
        public string Content
        {
            get { return content; }
            set
            {
                OnPropertyChanging("Content");
                content = value;
                OnPropertyChanged("Content");
            }
        }
        private int  gank;
         [Column]
        public int Gank
        {
            get { return gank; }
            set
            {
                OnPropertyChanging("Gank");
                gank = value;
                OnPropertyChanged("Gank");
            }
        }
        private int shuchu;
         [Column]
        public int ShuChu
        {
            get { return shuchu; }
            set
            {
                OnPropertyChanging("ShuChu");
                shuchu = value;
                OnPropertyChanged("ShuChu");
            }
        }
        private int fuZhu;
         [Column]
        public int FuZhu
        {
            get { return fuZhu; }
            set
            {
                OnPropertyChanging("FuZhu");
                fuZhu  = value;
                OnPropertyChanged("FuZhu");
            }
        }
        private int tuiJin;
         [Column]
        public int TuiJin
        {
            get { return tuiJin; }
            set
            {
                OnPropertyChanging("TuiJin");
                tuiJin  = value;
                OnPropertyChanged("TuiJin");
            }
        }
        private int rouDun;
         [Column]
        public int RouDun
        {
            get { return rouDun; }
            set
            {
                OnPropertyChanging("RouDun");
                rouDun = value;
                OnPropertyChanged("RouDun");
            }
        }
        private string changGui;
         [Column]
        public string  ChangGui
        {
            get { return changGui; }
            set
            {
                OnPropertyChanging("ChangGui");
                changGui = value;
                OnPropertyChanged("ChangGui");
            }
        }
        private string chuMen;
         [Column]
        public string ChuMen
        {
            get { return chuMen; }
            set
            {
                OnPropertyChanging("ChuMen");
               chuMen = value;
                OnPropertyChanged("ChuMen");
            }
        }
        private string zhongQi;
         [Column]
        public string ZhongQi
        {
            get { return zhongQi; }
            set
            {
                OnPropertyChanging("ZhongQi");
                zhongQi = value;
                OnPropertyChanged("ZhongQi");
            }
        }
        private string huoQi;
         [Column]
        public string HuoQi
        {
            get { return huoQi; }
            set
            {
                OnPropertyChanging("HuoQi");
                huoQi = value;
                OnPropertyChanged("HuoQi");
            }
        }

         private int jiNengId1;
         [Column]
         public int JiNengId1
         {
             get { return jiNengId1; }
             set
             {
                 OnPropertyChanging("JiNengId1");
                 jiNengId1 = value;
                 OnPropertyChanged("JiNengId1");
             }
         }

         private int jiNengId2;
         [Column]
         public int JiNengId2
         {
             get { return jiNengId2; }
             set
             {
                 OnPropertyChanging("JiNengId2");
                 jiNengId2 = value;
                 OnPropertyChanged("JiNengId2");
             }
         }

         private int jiNengId3;
         [Column]
         public int JiNengId3
         {
             get { return jiNengId3; }
             set
             {
                 OnPropertyChanging("JiNengId3");
                 jiNengId3 = value;
                 OnPropertyChanged("JiNengId3");
             }
         }

         private int jiNengId4;
         [Column]
         public int JiNengId4
         {
             get { return jiNengId4; }
             set
             {
                 OnPropertyChanging("JiNengId4");
                 jiNengId4 = value;
                 OnPropertyChanged("JiNengId4");
             }
         }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        private void OnPropertyChanging(string property)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(property));
            }
        }

    }
}
