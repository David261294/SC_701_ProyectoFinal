using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.EF;

namespace DAL.Repository
{
    public class RepositoryFacturaPaciente : Repository<data.FacturaPaciente>, IRepositoryFacturaPaciente
    {
        public RepositoryFacturaPaciente(DBDentistaContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.FacturaPaciente>> GetAllAsync()
        {
            return await _db.FacturaPaciente
                .Include(m => m.IdPacienteNavigation)
                .ToListAsync();
        }

        public async Task<data.FacturaPaciente> GetOneByIdAsync(int id)
        {
            return await _db.FacturaPaciente
                .Include(m => m.IdPacienteNavigation)
                .SingleAsync(m => m.CodigoFactura == id);
        }

        private DBDentistaContext _db
        {
            get { return dbContext as DBDentistaContext; }
        }
    }
}
