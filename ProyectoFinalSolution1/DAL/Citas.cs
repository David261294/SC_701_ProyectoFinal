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
    public class Citas : ICRUD<data.Citas>
    {
        private Repository<data.Citas> repo;

        public Citas(DBDentistaContext _Db)
        {
            repo = new Repository<data.Citas>(_Db);
        }
        public void Delete(data.Citas t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Citas> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Citas>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Citas GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Citas> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Citas t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Citas t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
