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
    public class Inventario : ICRUD<data.Inventario>
    {
        private Repository<data.Inventario> repo;

        public Inventario(DBDentistaContext _Db)
        {
            repo = new Repository<data.Inventario>(_Db);
        }
        public void Delete(data.Inventario t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Inventario> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Inventario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Inventario GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Inventario> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Inventario t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Inventario t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
