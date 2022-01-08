using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bircoci_Alberto_Proiect.Salon;
 
namespace Bircoci_Alberto_Proiect.Data
{
   public class SalonDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public SalonDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Prenotari>().Wait();
            _database.CreateTableAsync<Servicii>().Wait();
            _database.CreateTableAsync<ListServicii>().Wait();
        }
        public Task<List<Prenotari>> GetPrenotarisAsync()
        {
            return _database.Table<Prenotari>().ToListAsync();
        }
        public Task<Prenotari> GetPrenotariAsync(int id)
        {
            return _database.Table<Prenotari>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SavePrenotariAsync(Prenotari slist)
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
        public Task<int> DeletePrenotariAsync(Prenotari slist)
        {
            return _database.DeleteAsync(slist);
        }

        public Task<int> SaveProductAsync(Servicii servicii)
        {
            if (servicii.ID != 0)
            {
                return _database.UpdateAsync(servicii);
            }
            else
            {
                return _database.InsertAsync(servicii);
            }
        }
        public Task<int> DeleteProductAsync(Servicii servicii)
        {
            return _database.DeleteAsync(servicii);
        }
        public Task<List<Servicii>> GetServiciisAsync()
        {
            return _database.Table<Servicii>().ToListAsync();
        }
        public Task<int> SaveListServiciiAsync(ListServicii listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Servicii>> GetListServiciisAsync(int prenotariid)
        {
            return _database.QueryAsync<Servicii>(
            "select P.ID, P.Description from Servicii P"
            + " inner join ListServicii LP"
            + " on P.ID = LP.ServiciiD where LP.PrenotariID = ?",
            prenotariid);
        }
    }
}
    

