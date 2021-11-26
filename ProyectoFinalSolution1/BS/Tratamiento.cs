using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Tratamiento : ICRUD<data.Tratamiento>
    {
        private readonly DBDentistaContext db;

        public Tratamiento(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.Tratamiento t)
        {
            new DAL.Tratamiento(db).Delete(t);
        }

        public IEnumerable<data.Tratamiento> GetAll()
        {
            return new DAL.Tratamiento(db).GetAll();
        }

        public Task<IEnumerable<data.Tratamiento>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Tratamiento GetOneById(int id)
        {
            return new DAL.Tratamiento(db).GetOneById(id);
        }

        public Task<data.Tratamiento> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Tratamiento t)
        {
            new DAL.Tratamiento(db).Insert(t);
        }

        public void Update(data.Tratamiento t)
        {
            new DAL.Tratamiento(db).Update(t);
        }
    }
}
