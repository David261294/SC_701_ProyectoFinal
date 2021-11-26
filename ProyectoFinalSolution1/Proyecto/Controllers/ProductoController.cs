using AutoMapper;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using models = API.Models;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public ProductoController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Producto>>> GetProducto()
        {
            var res = new BS.Producto(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Producto>, IEnumerable<models.Producto>>(res).ToList();
            return mapaux;
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Producto>> GetProducto(int id)
        {
            var Producto = new BS.Producto(dbcontext).GetOneById(id);

            if (Producto == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Producto, models.Producto>(Producto);
            return mapaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, models.Producto Producto)
        {
            if (id != Producto.IdProducto)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Producto, data.Producto>(Producto);
                new BS.Producto(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Groups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Producto>> PostProducto(models.Producto Producto)
        {
            var mapaux = mapper.Map<models.Producto, data.Producto>(Producto);
            new BS.Producto(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetProducto", new { id = Producto.IdProducto }, Producto);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Producto>> DeleteProducto(int id)
        {
            var Producto = new BS.Producto(dbcontext).GetOneById(id);
            if (Producto == null)
            {
                return NotFound();
            }

            new BS.Producto(dbcontext).Delete(Producto);
            var mapaux = mapper.Map<data.Producto, models.Producto>(Producto);
            return mapaux;
        }

        private bool ProductoExists(int id)
        {
            return (new BS.Producto(dbcontext).GetOneById(id) != null);
        }
    }
}



