using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Contacto : ICRUD<data.Contacto>
    {
        private readonly DBDentistaContext db;

        public Contacto(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.Contacto t)
        {
            new DAL.Contacto(db).Delete(t);
        }

        public IEnumerable<data.Contacto> GetAll()
        {
            return new DAL.Contacto(db).GetAll();
        }

        public Task<IEnumerable<data.Contacto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Contacto GetOneById(int id)
        {
            return new DAL.Contacto(db).GetOneById(id);
        }

        public Task<data.Contacto> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Contacto t)
        {
            new DAL.Contacto(db).Insert(t);
        }

        public void Update(data.Contacto t)
        {
            new DAL.Contacto(db).Update(t);
        }
    }
}
