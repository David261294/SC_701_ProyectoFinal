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
    public class DetalleFactura : ICRUD<data.DetalleFactura>
    {
        private RepositoryDetalleFactura repo;

        public DetalleFactura(DBDentistaContext _Db)
        {
            repo = new RepositoryDetalleFactura(_Db);
        }

        public void Delete(data.DetalleFactura t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.DetalleFactura> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.DetalleFactura>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.DetalleFactura GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.DetalleFactura> GetOneByIdAsync(int id/*,int codigoFactura, int IdTratamiento, int IdProducto*/)
        {
            return repo.GetOneByIdAsync(id/*, codigoFactura,IdTratamiento,IdProducto*/);
        }

        //public Task<data.DetalleFactura> GetOneByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public void Insert(data.DetalleFactura t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.DetalleFactura t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
