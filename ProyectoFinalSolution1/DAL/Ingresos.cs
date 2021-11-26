using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL
{
    public class Ingresos : ICRUD<data.Ingresos>
    {
        private RepositoryIngresos repo;

        public Ingresos(DBDentistaContext _Db)
        {
            repo = new RepositoryIngresos(_Db);
        }

        public void Delete(data.Ingresos t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Ingresos> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Ingresos>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Ingresos GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Ingresos> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Ingresos t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Ingresos t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
