using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
namespace BS
{
    public class Recepcionista : ICRUD<data.Recepcionista>
    {
        private readonly DBDentistaContext db;

        public Recepcionista(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.Recepcionista t)
        {
            new DAL.Recepcionista(db).Delete(t);
        }

        public IEnumerable<data.Recepcionista> GetAll()
        {
            return new DAL.Recepcionista(db).GetAll();
        }

        public Task<IEnumerable<data.Recepcionista>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Recepcionista GetOneById(int id)
        {
            return new DAL.Recepcionista(db).GetOneById(id);
        }

        public Task<data.Recepcionista> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Recepcionista t)
        {
            new DAL.Recepcionista(db).Insert(t);
        }

        public void Update(data.Recepcionista t)
        {
            new DAL.Recepcionista(db).Update(t);
        }
    }
}
