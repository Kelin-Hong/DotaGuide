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
    public class ItemsTable:INotifyPropertyChanged,INotifyPropertyChanging
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

        private string detailid;
        [Column]
        public string DetailId
        {
            get { return detailid; }
            set
            {
                OnPropertyChanging("DetailId");
                detailid = value;
                OnPropertyChanged("DetailId");
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
