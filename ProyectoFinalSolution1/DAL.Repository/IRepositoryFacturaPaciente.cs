using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryFacturaPaciente : IRepository<data.FacturaPaciente>
    {
        Task<IEnumerable<data.FacturaPaciente>> GetAllAsync();
        Task<data.FacturaPaciente> GetOneByIdAsync(int id);
    }
}
