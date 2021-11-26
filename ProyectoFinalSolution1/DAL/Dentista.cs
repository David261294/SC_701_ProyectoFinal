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
    public class Dentista : ICRUD<data.Dentista>
    {
        private Repository<data.Dentista> repo;

        public Dentista(DBDentistaContext _Db)
        {
            repo = new Repository<data.Dentista>(_Db);
        }
        public void Delete(data.Dentista t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Dentista> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Dentista>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Dentista GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Dentista> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Dentista t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Dentista t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
