using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.Repository;

namespace DAL
{
    public class Contacto : ICRUD<data.Contacto>
    {
        private Repository<data.Contacto> repo;

        public Contacto(DBDentistaContext _Db)
        {
            repo = new Repository<data.Contacto>(_Db);
        }
        public void Delete(data.Contacto t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Contacto> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Contacto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Contacto GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Contacto> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Contacto t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Contacto t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
