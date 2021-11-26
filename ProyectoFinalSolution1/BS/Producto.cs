using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Producto : ICRUD<data.Producto>
    {
        private readonly DBDentistaContext db;

        public Producto(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.Producto t)
        {
            new DAL.Producto(db).Delete(t);
        }

        public IEnumerable<data.Producto> GetAll()
        {
            return new DAL.Producto(db).GetAll();
        }

        public Task<IEnumerable<data.Producto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Producto GetOneById(int id)
        {
            return new DAL.Producto(db).GetOneById(id);
        }

        public Task<data.Producto> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Producto t)
        {
            new DAL.Producto(db).Insert(t);
        }

        public void Update(data.Producto t)
        {
            new DAL.Producto(db).Update(t);
        }
    }
}
