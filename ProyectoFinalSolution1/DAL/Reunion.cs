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
    public class Reunion : ICRUD<data.Reunion>
    {
        private RepositoryReunion repo;

        public Reunion(DBDentistaContext _Db)
        {
            repo = new RepositoryReunion(_Db);
        }

        public void Delete(data.Reunion t)
        {
            repo.DeleteAsync(t);
            repo.Commit();
        }

        public IEnumerable<data.Reunion> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Reunion>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Reunion GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Reunion> GetOneByIdAsync(int id/*, int IdDentista, int IdRecepcionista*/)
        {
            return repo.GetOneByIdAsync(id/*,IdDentista, IdRecepcionista*/);
        }

        //public Task<data.Reunion> GetOneByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public void Insert(data.Reunion t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Reunion t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
