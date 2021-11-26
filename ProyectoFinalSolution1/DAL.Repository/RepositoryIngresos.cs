using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.EF;

namespace DAL.Repository
{
    public class RepositoryIngresos : Repository<data.Ingresos>, IRepositoryIngresos
    {
        public RepositoryIngresos(DBDentistaContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Ingresos>> GetAllAsync()
        {
            return await _db.Ingresos
                .Include(m => m.CodigoDetalleNavigation)
                .ToListAsync();
        }

        public async Task<data.Ingresos> GetOneByIdAsync(int id)
        {
            return await _db.Ingresos
                .Include(m => m.CodigoDetalleNavigation)
                .SingleAsync(m => m.IdIngreso == id);
        }

        private DBDentistaContext _db
        {
            get { return dbContext as DBDentistaContext; }
        }
    }
}
