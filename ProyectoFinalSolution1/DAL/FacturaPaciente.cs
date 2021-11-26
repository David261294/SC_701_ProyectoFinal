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
    public class FacturaPaciente : ICRUD<data.FacturaPaciente>
    {
        private RepositoryFacturaPaciente repo;

        public FacturaPaciente(DBDentistaContext _Db)
        {
            repo = new RepositoryFacturaPaciente(_Db);
        }

        public void Delete(data.FacturaPaciente t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.FacturaPaciente> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.FacturaPaciente>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.FacturaPaciente GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.FacturaPaciente> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.FacturaPaciente t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.FacturaPaciente t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
