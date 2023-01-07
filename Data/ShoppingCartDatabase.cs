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
        }
        public Task<List<ShopCart>> GetShopListsAsync()
        {
            return _database.Table<ShopCart>().ToListAsync();
        }
        public Task<ShopCart> GetShopListAsync(int id)
        {
            return _database.Table<ShopCart>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(ShopCart slist)
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
        public Task<int> DeleteShopListAsync(ShopCart slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
