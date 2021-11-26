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
    public class DetalleFacturaController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public DetalleFacturaController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Foci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.DetalleFactura>>> GetDetalleFactura()
        {
            var res = await new BS.DetalleFactura(dbcontext).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.DetalleFactura>, IEnumerable<models.DetalleFactura>>(res).ToList();

            return mapaux;

            // Este GetAll no trae las relaaciones
            //return new BE.BS.Foci(dbcontext).GetAll().ToList();
        }

        // GET: api/Foci/5
        [HttpGet("{id},{codigoFactura},{IdTratamiento},{IdProducto}")]
        public async Task<ActionResult<models.DetalleFactura>> GetDetalleFactura(int id,int codigoFactura, int IdTratamiento, int IdProducto)
        {
            var DetalleFactura = await new BS.DetalleFactura(dbcontext).GetOneByIdAsync(id, codigoFactura, IdTratamiento, IdProducto);
            var mapaux = mapper.Map<data.DetalleFactura, models.DetalleFactura>(DetalleFactura);

            // Este Get no trae las relaaciones
            //var foci = new BE.BS.Foci(dbcontext).GetOneById(id);

            if (DetalleFactura == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Foci/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleFactura(int id, models.DetalleFactura DetalleFactura)
        {
            if (id != DetalleFactura.CodigoDetalle)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.DetalleFactura, data.DetalleFactura>(DetalleFactura);
                new BS.DetalleFactura(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!DetalleFacturaExists(id))
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

        // POST: api/Foci
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{CodigoFactura},{IdTratamiento},{IdProducto}")]
        public async Task<ActionResult<models.DetalleFactura>> PostDetalleFactura(models.DetalleFactura DetalleFactura)
        {
            var mapaux = mapper.Map<models.DetalleFactura, data.DetalleFactura>(DetalleFactura);
            new BS.DetalleFactura(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetDetalleFactura", new { id = DetalleFactura.CodigoFactura , DetalleFactura.IdTratamiento,DetalleFactura.IdProducto}, DetalleFactura);
        }

        // DELETE: api/Foci/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.DetalleFactura>> DeleteDetalleFactura(int id)
        {
            var DetalleFactura = new BS.DetalleFactura(dbcontext).GetOneById(id);
            if (DetalleFactura == null)
            {
                return NotFound();
            }

            new BS.DetalleFactura(dbcontext).Delete(DetalleFactura);
            var mapaux = mapper.Map<data.DetalleFactura, models.DetalleFactura>(DetalleFactura);
            return mapaux;
        }

        private bool DetalleFacturaExists(int id)
        {
            return (new BS.DetalleFactura(dbcontext).GetOneById(id) != null);
            //return _context.Foci.Any(e => e.FocusId == id);
        }
    }
}
