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
    public class JiNengTable:INotifyPropertyChanging,INotifyPropertyChanged
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
        private int heroId;
        [Column]
        public int HeroId
        {
            get { return heroId; }
            set
            {
                OnPropertyChanging("HeroId");
                heroId = value;
                OnPropertyChanged("HeroId");
            }

        }
        private string name;
        [Column]
        public string Name
        {
            get { return name; }
            set
            {
                OnPropertyChanging("Name");
                name = value;
                OnPropertyChanged("Name");
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

        private string intro;
        [Column]
        public string Intro
        {
            get { return intro; }
            set
            {
                OnPropertyChanging("Intro");
                intro = value;
                OnPropertyChanged("Intro");
            }
        }

        private string detail;
        [Column]
        public string Detail
        {
            get { return detail; }
            set
            {
                OnPropertyChanging("Detail");
                detail = value;
                OnPropertyChanged("Detail");
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
