using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryReview : IRepository<data.Review>
    {
        Task<IEnumerable<data.Review>> GetAllAsync();
        Task<data.Review> GetOneByIdAsync(int id);
    }
}
