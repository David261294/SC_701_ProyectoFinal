using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Citas : ICRUD<data.Citas>
    {
        private readonly DBDentistaContext db;

        public Citas(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.Citas t)
        {
            new DAL.Citas(db).Delete(t);
        }

        public IEnumerable<data.Citas> GetAll()
        {
            return new DAL.Citas(db).GetAll();
        }

        public Task<IEnumerable<data.Citas>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Citas GetOneById(int id)
        {
            return new DAL.Citas(db).GetOneById(id);
        }

        public Task<data.Citas> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Citas t)
        {
            new DAL.Citas(db).Insert(t);
        }

        public void Update(data.Citas t)
        {
            new DAL.Citas(db).Update(t);
        }
    }
}
