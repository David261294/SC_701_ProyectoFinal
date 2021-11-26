using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class ExpedientePaciente : ICRUD<data.ExpedientePaciente>
    {
        private readonly DBDentistaContext db;

        public ExpedientePaciente(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.ExpedientePaciente t)
        {
            new DAL.ExpedientePaciente(db).Delete(t);
        }

        public IEnumerable<data.ExpedientePaciente> GetAll()
        {
            return new DAL.ExpedientePaciente(db).GetAll();
        }

        public Task<IEnumerable<data.ExpedientePaciente>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.ExpedientePaciente GetOneById(int id)
        {
            return new DAL.ExpedientePaciente(db).GetOneById(id);
        }

        public Task<data.ExpedientePaciente> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.ExpedientePaciente t)
        {
            new DAL.ExpedientePaciente(db).Insert(t);
        }

        public void Update(data.ExpedientePaciente t)
        {
            new DAL.ExpedientePaciente(db).Update(t);
        }
    }
}
