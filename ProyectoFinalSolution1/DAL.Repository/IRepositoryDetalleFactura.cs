using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryDetalleFactura : IRepository<data.DetalleFactura>
    {
        Task<IEnumerable<data.DetalleFactura>> GetAllAsync();
        Task<data.DetalleFactura> GetOneByIdAsync(int id/*,int codigoFactura, int IdTratamiento, int IdProducto*/);
    }
}
