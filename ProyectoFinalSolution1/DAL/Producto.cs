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
    public class Producto : ICRUD<data.Producto>
    {
        private Repository<data.Producto> repo;

        public Producto(DBDentistaContext _Db)
        {
            repo = new Repository<data.Producto>(_Db);
        }
        public void Delete(data.Producto t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Producto> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Producto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Producto GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Producto> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Producto t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Producto t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
