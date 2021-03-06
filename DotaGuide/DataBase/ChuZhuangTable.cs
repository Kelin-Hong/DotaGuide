﻿using System;
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
    public class ChuZhuangTable
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
        private string itemUri;
        [Column]
        public string ItemUri
        {
            get { return itemUri; }
            set
            {
                OnPropertyChanging("ItemUri");
                itemUri = value;
                OnPropertyChanged("ItemUri");
            }
        }
        private int index;
        [Column]
        public int Index
        {
            get { return index; }
            set
            {
                OnPropertyChanging("Index");
                index = value;
                OnPropertyChanged("Index");
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
