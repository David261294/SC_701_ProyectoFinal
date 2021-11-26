using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.EF;

namespace DAL.Repository
{
    public class RepositoryReview : Repository<data.Review>, IRepositoryReview
    {
        public RepositoryReview(DBDentistaContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Review>> GetAllAsync()
        {
            return await _db.Review
                .Include(m => m.IdCitasNavigation)
                .ToListAsync();
        }

        public async Task<data.Review> GetOneByIdAsync(int id)
        {
            return await _db.Review
                .Include(m => m.IdCitasNavigation)
                .SingleAsync(m => m.IdReview == id);
        }

        private DBDentistaContext _db
        {
            get { return dbContext as DBDentistaContext; }
        }
    }
}