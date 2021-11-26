using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.DO.Interfaces;
using DAL.EF;

namespace BS
{
    public class Reunion : ICRUD<data.Reunion>
    {
        private readonly DBDentistaContext db;

        public Reunion(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.Reunion t)
        {
            new DAL.Reunion(db).Delete(t);
        }

        public IEnumerable<data.Reunion> GetAll()
        {
            return new DAL.Reunion(db).GetAll();
        }

        public Task<IEnumerable<data.Reunion>> GetAllAsync()
        {
            return new DAL.Reunion(db).GetAllAsync();
        }

        public data.Reunion GetOneById(int id)
        {
            return new DAL.Reunion(db).GetOneById(id);
        }

        public Task<data.Reunion> GetOneByIdAsync(int id, int IdDentista, int IdRecepcionista)
        {
            return new DAL.Reunion(db).GetOneByIdAsync(id, IdDentista,IdRecepcionista);
        }

        public Task<data.Reunion> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Reunion t)
        {
            new DAL.Reunion(db).Insert(t);
        }

        public void Update(data.Reunion t)
        {
            new DAL.Reunion(db).Update(t);
        }
    }
}
