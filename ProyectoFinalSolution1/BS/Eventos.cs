using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
namespace BS
{
    public class Eventos : ICRUD<data.Eventos>
    {
        private readonly DBDentistaContext db;

        public Eventos(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.Eventos t)
        {
            new DAL.Eventos(db).Delete(t);
        }

        public IEnumerable<data.Eventos> GetAll()
        {
            return new DAL.Eventos(db).GetAll();
        }

        public Task<IEnumerable<data.Eventos>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Eventos GetOneById(int id)
        {
            return new DAL.Eventos(db).GetOneById(id);
        }

        public Task<data.Eventos> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Eventos t)
        {
            new DAL.Eventos(db).Insert(t);
        }

        public void Update(data.Eventos t)
        {
            new DAL.Eventos(db).Update(t);
        }
    }
}
