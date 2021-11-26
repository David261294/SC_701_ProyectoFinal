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
    public class ExpedientePaciente : ICRUD<data.ExpedientePaciente>
    {
        private Repository<data.ExpedientePaciente> repo;

        public ExpedientePaciente(DBDentistaContext _Db)
        {
            repo = new Repository<data.ExpedientePaciente>(_Db);
        }
        public void Delete(data.ExpedientePaciente t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.ExpedientePaciente> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.ExpedientePaciente>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.ExpedientePaciente GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.ExpedientePaciente> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.ExpedientePaciente t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.ExpedientePaciente t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
