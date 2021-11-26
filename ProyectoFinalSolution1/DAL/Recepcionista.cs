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
    public class Recepcionista : ICRUD<data.Recepcionista>
    {
        private Repository<data.Recepcionista> repo;

        public Recepcionista(DBDentistaContext _Db)
        {
            repo = new Repository<data.Recepcionista>(_Db);
        }
        public void Delete(data.Recepcionista t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Recepcionista> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Recepcionista>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Recepcionista GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Recepcionista> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Recepcionista t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Recepcionista t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
