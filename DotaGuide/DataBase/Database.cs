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
using System.Data.Linq;
namespace Dota攻略宝典.DataBase
{
    public class Database:DataContext
    {
        public static string contectStr = "DataSource=isostore:/data.sdf";
        public Database(string str):base(str)
        {
               
        }
        public Table<HeroTable> heroTable;
        public Table<HeroInfoTable> heroInfoTable;
        public Table<JiNengTable> jinengTable;
        public Table<ItemsTable> itemsTable;
        public Table<ChuZhuangTable> chuZhuangTable;
    }
}
