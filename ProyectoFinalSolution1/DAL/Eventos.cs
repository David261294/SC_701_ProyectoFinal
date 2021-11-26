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
    public class Eventos : ICRUD<data.Eventos>
    {
        private Repository<data.Eventos> repo;

        public Eventos(DBDentistaContext _Db)
        {
            repo = new Repository<data.Eventos>(_Db);
        }
        public void Delete(data.Eventos t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Eventos> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Eventos>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Eventos GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Eventos> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Eventos t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Eventos t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
