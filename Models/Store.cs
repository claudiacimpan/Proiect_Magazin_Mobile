using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Magazin_Mobile.Models
{
    public class Store
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string StoreName { get; set; }
        public string Adress { get; set; }
        public string StoreDetails
        {
            get
            {
                return StoreName + " "+Adress;} }
        [OneToMany]
 public List<ShopCart> ShopCarts { get; set; }
    }
}
