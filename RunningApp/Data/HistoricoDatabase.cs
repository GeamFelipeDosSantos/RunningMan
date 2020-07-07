using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using RunningApp.Models;
using System.Reflection.Emit;
using System.ComponentModel;
using SQLiteNetExtensions.Extensions;

namespace RunningApp.Data
{
    public class HistoricoDatabase
    {
        readonly SQLiteConnection _database;

        public HistoricoDatabase(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Treino>();
            _database.CreateTable<Passo>();

        }

        public Treino salvarTreino(Treino treino, Passo passos){
            /*
             if (treino.ID != 0)
             {
                 return _database.UpdateAsync(treino);
             }
             else
             {
                 return _database.InsertAsync(historico);
             }
            */
            _database.Insert(treino);
            _database.Insert(passos);


            treino.passos = new List<Passo> { passos };

            _database.UpdateWithChildren(treino);

            // Get the object and the relationships
            var treinoArmazenado = _database.GetWithChildren<Treino>(treino.ID);

            return treinoArmazenado;
        }
        //public Task<List<Historico>> GetNotesAsync()
        //{
        //    return _database.Table<Historico>().ToListAsync();
        //}

        //public Task<Historico> GetNoteAsync(int id)
        //{
        //    return _database.Table<Historico>()
        //                    .Where(i => i.ID == id)
        //                    .FirstOrDefaultAsync();
        //}

        //public Task<int> SaveNoteAsync(Historico historico)
        //{
        //    if (historico.ID != 0)
        //    {
        //        return _database.UpdateAsync(historico);
        //    }
        //    else
        //    {
        //        return _database.InsertAsync(historico);
        //    }
        //}

        //public Task<int> DeleteNoteAsync(Historico historico)
        //{
        //    return _database.DeleteAsync(historico);
        //}
    }
}