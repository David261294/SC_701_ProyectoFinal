using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class PacienteNuevo : ICRUD<data.PacienteNuevo>
    {
        private readonly DBDentistaContext db;

        public PacienteNuevo(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.PacienteNuevo t)
        {
            new DAL.PacienteNuevo(db).Delete(t);
        }

        public IEnumerable<data.PacienteNuevo> GetAll()
        {
            return new DAL.PacienteNuevo(db).GetAll();
        }

        public Task<IEnumerable<data.PacienteNuevo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.PacienteNuevo GetOneById(int id)
        {
            return new DAL.PacienteNuevo(db).GetOneById(id);
        }

        public Task<data.PacienteNuevo> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.PacienteNuevo t)
        {
            new DAL.PacienteNuevo(db).Insert(t);
        }

        public void Update(data.PacienteNuevo t)
        {
            new DAL.PacienteNuevo(db).Update(t);
        }
    }
}
