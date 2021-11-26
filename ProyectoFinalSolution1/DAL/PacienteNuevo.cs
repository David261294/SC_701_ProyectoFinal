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
    public class PacienteNuevo : ICRUD<data.PacienteNuevo>
    {
        private Repository<data.PacienteNuevo> repo;

        public PacienteNuevo(DBDentistaContext _Db)
        {
            repo = new Repository<data.PacienteNuevo>(_Db);
        }
        public void Delete(data.PacienteNuevo t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.PacienteNuevo> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.PacienteNuevo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.PacienteNuevo GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.PacienteNuevo> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.PacienteNuevo t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.PacienteNuevo t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
