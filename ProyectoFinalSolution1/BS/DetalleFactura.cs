using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.DO.Interfaces;
using DAL.EF;

namespace BS
{
    public class DetalleFactura : ICRUD<data.DetalleFactura>
    {
        private readonly DBDentistaContext db;

        public DetalleFactura(DBDentistaContext _Db)
        {
            db = _Db;
        }
        public void Delete(data.DetalleFactura t)
        {
            new DAL.DetalleFactura(db).Delete(t);
        }

        public IEnumerable<data.DetalleFactura> GetAll()
        {
            return new DAL.DetalleFactura(db).GetAll();
        }

        public Task<IEnumerable<data.DetalleFactura>> GetAllAsync()
        {
            return new DAL.DetalleFactura(db).GetAllAsync();
        }

        public data.DetalleFactura GetOneById(int id)
        {
            return new DAL.DetalleFactura(db).GetOneById(id);
        }

        public Task<data.DetalleFactura> GetOneByIdAsync(int id,int codigoFactura, int IdTratamiento, int IdProducto)
        {
            return new DAL.DetalleFactura(db).GetOneByIdAsync(id,codigoFactura,IdTratamiento,IdProducto);
        }

        public Task<data.DetalleFactura> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.DetalleFactura t)
        {
            new DAL.DetalleFactura(db).Insert(t);
        }

        public void Update(data.DetalleFactura t)
        {
            new DAL.DetalleFactura(db).Update(t);
        }
    }
}
