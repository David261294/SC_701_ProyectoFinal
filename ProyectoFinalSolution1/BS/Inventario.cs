using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Inventario : ICRUD<data.Inventario>
    {
        private readonly DBDentistaContext db;

        public Inventario(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.Inventario t)
        {
            new DAL.Inventario(db).Delete(t);
        }

        public IEnumerable<data.Inventario> GetAll()
        {
            return new DAL.Inventario(db).GetAll();
        }

        public Task<IEnumerable<data.Inventario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Inventario GetOneById(int id)
        {
            return new DAL.Inventario(db).GetOneById(id);
        }

        public Task<data.Inventario> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Inventario t)
        {
            new DAL.Inventario(db).Insert(t);
        }

        public void Update(data.Inventario t)
        {
            new DAL.Inventario(db).Update(t);
        }
    }
}
