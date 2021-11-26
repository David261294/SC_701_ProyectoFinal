using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Dentista : ICRUD<data.Dentista>
    {
        private readonly DBDentistaContext db;

        public Dentista(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.Dentista t)
        {
            new DAL.Dentista(db).Delete(t);
        }

        public IEnumerable<data.Dentista> GetAll()
        {
            return new DAL.Dentista(db).GetAll();
        }

        public Task<IEnumerable<data.Dentista>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Dentista GetOneById(int id)
        {
            return new DAL.Dentista(db).GetOneById(id);
        }

        public Task<data.Dentista> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Dentista t)
        {
            new DAL.Dentista(db).Insert(t);
        }

        public void Update(data.Dentista t)
        {
            new DAL.Dentista(db).Update(t);
        }
    }
}
