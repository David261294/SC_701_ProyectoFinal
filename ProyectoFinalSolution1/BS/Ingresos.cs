using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.DO.Interfaces;
using DAL.EF;

namespace BS
{
    public class Ingresos : ICRUD<data.Ingresos>
    {
        private readonly DBDentistaContext db;

        public Ingresos(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.Ingresos t)
        {
            new DAL.Ingresos(db).Delete(t);
        }

        public IEnumerable<data.Ingresos> GetAll()
        {
            return new DAL.Ingresos(db).GetAll();
        }

        public Task<IEnumerable<data.Ingresos>> GetAllAsync()
        {
            return new DAL.Ingresos(db).GetAllAsync();
        }

        public data.Ingresos GetOneById(int id)
        {
            return new DAL.Ingresos(db).GetOneById(id);
        }

        public Task<data.Ingresos> GetOneByIdAsync(int id)
        {
            return new DAL.Ingresos(db).GetOneByIdAsync(id);
        }

        public void Insert(data.Ingresos t)
        {
            new DAL.Ingresos(db).Insert(t);
        }

        public void Update(data.Ingresos t)
        {
            new DAL.Ingresos(db).Update(t);
        }
    }
}
