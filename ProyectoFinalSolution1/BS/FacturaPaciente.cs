using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.DO.Interfaces;
using DAL.EF;

namespace BS
{
    public class FacturaPaciente : ICRUD<data.FacturaPaciente>
    {
        private readonly DBDentistaContext db;

        public FacturaPaciente(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.FacturaPaciente t)
        {
            new DAL.FacturaPaciente(db).Delete(t);
        }

        public IEnumerable<data.FacturaPaciente> GetAll()
        {
            return new DAL.FacturaPaciente(db).GetAll();
        }

        public Task<IEnumerable<data.FacturaPaciente>> GetAllAsync()
        {
            return new DAL.FacturaPaciente(db).GetAllAsync();
        }

        public data.FacturaPaciente GetOneById(int id)
        {
            return new DAL.FacturaPaciente(db).GetOneById(id);
        }

        public Task<data.FacturaPaciente> GetOneByIdAsync(int id)
        {
            return new DAL.FacturaPaciente(db).GetOneByIdAsync(id);
        }

        public void Insert(data.FacturaPaciente t)
        {
            new DAL.FacturaPaciente(db).Insert(t);
        }

        public void Update(data.FacturaPaciente t)
        {
            new DAL.FacturaPaciente(db).Update(t);
        }
    }
}
