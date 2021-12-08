using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryReunion : IRepository<data.Reunion>
    {
        Task<IEnumerable<data.Reunion>> GetAllAsync();
        Task<data.Reunion> GetOneByIdAsync( int id/*, int IdDentista, int IdRecepcionista*/);
    }
}
