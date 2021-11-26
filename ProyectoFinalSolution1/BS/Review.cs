using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.DO.Interfaces;
using DAL.EF;

namespace BS
{
    public class Review : ICRUD<data.Review>
    {
        private readonly DBDentistaContext db;

        public Review(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.Review t)
        {
            new DAL.Review(db).Delete(t);
        }

        public IEnumerable<data.Review> GetAll()
        {
            return new DAL.Review(db).GetAll();
        }

        public Task<IEnumerable<data.Review>> GetAllAsync()
        {
            return new DAL.Review(db).GetAllAsync();
        }

        public data.Review GetOneById(int id)
        {
            return new DAL.Review(db).GetOneById(id);
        }

        public Task<data.Review> GetOneByIdAsync(int id)
        {
            return new DAL.Review(db).GetOneByIdAsync(id);
        }

        public void Insert(data.Review t)
        {
            new DAL.Review(db).Insert(t);
        }

        public void Update(data.Review t)
        {
            new DAL.Review(db).Update(t);
        }
    }
}
