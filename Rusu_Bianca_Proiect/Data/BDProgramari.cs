using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rusu_Bianca_Proiect.Models;

namespace Rusu_Bianca_Proiect.Data
{
    public class BDProgramari
    {
        readonly SQLiteAsyncConnection _database;
        public BDProgramari(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ProgramareExamen>().Wait();
            _database.CreateTableAsync<Examen>().Wait();
            _database.CreateTableAsync<ListExamen>().Wait();
        }

        public Task<int> SaveExamenAsync(Examen examen)
        {
            if (examen.ID != 0)
            {
                return _database.UpdateAsync(examen);
            }
            else
            {
                return _database.InsertAsync(examen);
            }
        }
        public Task<int> DeleteExamenAsync(Examen examen)
        {
            return _database.DeleteAsync(examen);
        }
        public Task<List<Examen>> GetExameneAsync()
        {
            return _database.Table<Examen>().ToListAsync();
        }
        public Task<List<ProgramareExamen>> GetProgramareAsync()
        {
            return _database.Table<ProgramareExamen>().ToListAsync();
        }
        public Task<ProgramareExamen> GetProgramareAsync(int id)
        {
            return _database.Table<ProgramareExamen>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveProgramareAsync(ProgramareExamen programare)
        {
            if (programare.ID != 0)
            {
                return _database.UpdateAsync(programare);
            }
            else
            {
                return _database.InsertAsync(programare);
            }
        }
        public Task<int> DeleteProgramareAsync(ProgramareExamen programare)
        {
            return _database.DeleteAsync(programare);
        }

        public Task<int> SaveListExamenAsync(ListExamen le)
        {
            if (le.ID != 0)
            {
                return _database.UpdateAsync(le);
            }
            else
            {
                return _database.InsertAsync(le);
            }
        }
        public Task<List<Examen>> GetListExameneAsync(int elid)
        {
            return _database.QueryAsync<Examen>(
            "select P.ID, P.Disciplina from Examen P"
            + " inner join ListExamen LE"
            + " on P.ID = LE.ExamenID where LE.ProgramareExamenID = ?",
            elid);
        }
    }
}
