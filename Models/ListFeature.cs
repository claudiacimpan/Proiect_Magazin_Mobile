using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Magazin_Mobile.Models
{
    public class ListFeature
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(ShopCart))]
        public int ShopCartID { get; set; }
        public int FeatureID { get; set; }
    }
}

