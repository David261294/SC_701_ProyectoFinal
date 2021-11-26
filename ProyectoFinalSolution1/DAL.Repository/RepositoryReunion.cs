using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.EF;
using System.Linq;

namespace DAL.Repository
{
    public class RepositoryReunion : Repository<data.Reunion>, IRepositoryReunion
    {
        public RepositoryReunion(DBDentistaContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Reunion>> GetAllAsync()
        {
            return await _db.Reunion
                .Include(m => m.IdDentistaNavigation)
                .Include(m => m.IdRecepcionistaNavigation)
                .ToListAsync();
        }

        public async Task<data.Reunion> GetOneByIdAsync(int id, int IdDentista, int IdRecepcionista)
        {
            return await _db.Reunion
                .Include(m => m.IdDentistaNavigation)
                .Include(m => m.IdRecepcionistaNavigation)
                .SingleAsync(m => m.NumeroReunion== id && m.IdDentista == IdDentista && m.IdRecepcionista == IdRecepcionista);
        }

        public async void DeleteAsync(data.Reunion Reunion)
        {
            Reunion = _db.Reunion.Where(d => d.NumeroReunion == Reunion.NumeroReunion && d.IdDentista == Reunion.IdDentista && d.IdRecepcionista == Reunion.IdRecepcionista).First();
            _db.Reunion.Remove(Reunion);

        }

        //public async void UpdateAsync(data.Reunion Reunion)
        //{
        //    Reunion = _db.Reunion.Where(d => d.NumeroReunion == Reunion.NumeroReunion && d.IdDentista == Reunion.IdDentista && d.IdRecepcionista == Reunion.IdRecepcionista).First();
        //    _db.Reunion.Update(Reunion);

        //}
        private DBDentistaContext _db
        {
            get { return dbContext as DBDentistaContext; }
        }
    }
}
