using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using RunningApp.Models;

namespace RunningApp.Data
{
    public class HistoricoDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public HistoricoDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Historico>().Wait();
        }

        public Task<List<Historico>> GetNotesAsync()
        {
            return _database.Table<Historico>().ToListAsync();
        }

        public Task<Historico> GetNoteAsync(int id)
        {
            return _database.Table<Historico>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Historico historico)
        {
            if (historico.ID != 0)
            {
                return _database.UpdateAsync(historico);
            }
            else
            {
                return _database.InsertAsync(historico);
            }
        }

        public Task<int> DeleteNoteAsync(Historico historico)
        {
            return _database.DeleteAsync(historico);
        }
    }
}