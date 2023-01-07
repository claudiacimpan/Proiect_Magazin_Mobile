using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_Magazin_Mobile.Models;

namespace Proiect_Magazin_Mobile.Data
{
    public class ShoppingCartDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ShoppingCartDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ShopCart>().Wait();
            _database.CreateTableAsync<Feature>().Wait();
            _database.CreateTableAsync<ListFeature>().Wait();
            _database.CreateTableAsync<Store>().Wait();

        }
        public Task<List<Store>> GetStoresAsync()
        {
            return _database.Table<Store>().ToListAsync();
        }
        public Task<int> SaveStoreAsync(Store store)
        {
            if (store.ID != 0)
            {
                return _database.UpdateAsync(store);
            }
            else
            {
                return _database.InsertAsync(store);
            }
        }

        public Task<int> SaveListFeatureAsync(ListFeature listf)
        {
            if (listf.ID != 0)
            {
                return _database.UpdateAsync(listf);
            }
            else
            {
                return _database.InsertAsync(listf);
            }
        }

        public Task<int> DeleteListFeatureAsync(ListFeature listf)
        {
            return _database.DeleteAsync(listf);
        }
        public Task<ListFeature> GetListFeatureAsync(int shopcartid, int cartid)
        {
            return _database.Table<ListFeature>().Where(i => (i.ShopCartID == shopcartid && i.FeatureID == cartid)).FirstOrDefaultAsync();

        }


        public Task<List<Feature>> GetListFeaturesAsync(int shopcartid)
        {
            return _database.QueryAsync<Feature>(
            "select F.ID, F.Description from Feature F"
            + " inner join ListFeature LF"
            + " on F.ID = LF.FeatureID where LF.ShopCartID = ?",
            shopcartid);
        }



        public Task<int> SaveFeatureAsync(Feature feature)
        {
            if (feature.ID != 0)
            {
                return _database.UpdateAsync(feature);
            }
            else
            {
                return _database.InsertAsync(feature);
            }
        }
        public Task<int> DeleteFeatureAsync(Feature feature)
        {
            return _database.DeleteAsync(feature);
        }
        public Task<List<Feature>> GetFeaturesAsync()
        {
            return _database.Table<Feature>().ToListAsync();
        }


        public Task<List<ShopCart>> GetShopCartsAsync()
        {
            return _database.Table<ShopCart>().ToListAsync();
        }
        public Task<ShopCart> GetShopCartAsync(int id)
        {
            return _database.Table<ShopCart>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopCartAsync(ShopCart slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopCartAsync(ShopCart slist)
        {
            return _database.DeleteAsync(slist);
        }
       
    }
}

