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
    public class Tratamiento : ICRUD<data.Tratamiento>
    {
        private Repository<data.Tratamiento> repo;

        public Tratamiento(DBDentistaContext _Db)
        {
            repo = new Repository<data.Tratamiento>(_Db);
        }
        public void Delete(data.Tratamiento t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Tratamiento> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Tratamiento>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Tratamiento GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Tratamiento> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Tratamiento t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Tratamiento t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
