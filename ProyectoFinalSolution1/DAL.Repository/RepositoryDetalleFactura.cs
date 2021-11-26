using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.EF;

namespace DAL.Repository
{
    public class RepositoryDetalleFactura : Repository<data.DetalleFactura>, IRepositoryDetalleFactura
    {
        public RepositoryDetalleFactura(DBDentistaContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.DetalleFactura>> GetAllAsync()
        {
            return await _db.DetalleFactura
                .Include(m => m.CodigoFacturaNavigation)
                .Include(m => m.IdTratamientoNavigation)
                .Include(m => m.IdProductoNavigation)
                .ToListAsync();
        }

        public async Task<data.DetalleFactura> GetOneByIdAsync(int id, int codigoFactura, int IdTratamiento, int IdProducto)
        {
            return await _db.DetalleFactura
                .Include(m => m.CodigoFacturaNavigation)
                .Include(m => m.IdTratamientoNavigation)
                .Include(m => m.IdProductoNavigation)
                .SingleAsync(m => m.CodigoDetalle == id && m.CodigoFactura == codigoFactura && m.IdTratamiento== IdTratamiento && m.IdProducto == IdProducto);
        }

        private DBDentistaContext _db
        {
            get { return dbContext as DBDentistaContext; }
        }
    }
}
