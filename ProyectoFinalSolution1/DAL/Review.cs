using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL
{
    public class Review : ICRUD<data.Review>
    {
        private RepositoryReview repo;

        public Review(DBDentistaContext _Db)
        {
            repo = new RepositoryReview(_Db);
        }

        public void Delete(data.Review t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Review> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Review>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Review GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Review> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Review t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Review t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}