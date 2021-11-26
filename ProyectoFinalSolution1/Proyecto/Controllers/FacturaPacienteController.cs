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
    public class FacturaPacienteController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public FacturaPacienteController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Foci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.FacturaPaciente>>> GetFacturaPaciente()
        {
            var res = await new BS.FacturaPaciente(dbcontext).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.FacturaPaciente>, IEnumerable<models.FacturaPaciente>>(res).ToList();

            return mapaux;

            // Este GetAll no trae las relaaciones
            //return new BE.BS.Foci(dbcontext).GetAll().ToList();
        }

        // GET: api/Foci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.FacturaPaciente>> GetFacturaPaciente(int id)
        {
            var FacturaPaciente = await new BS.FacturaPaciente(dbcontext).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.FacturaPaciente, models.FacturaPaciente>(FacturaPaciente);

            // Este Get no trae las relaaciones
            //var foci = new BE.BS.Foci(dbcontext).GetOneById(id);

            if (FacturaPaciente == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Foci/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaPaciente(int id, models.FacturaPaciente FacturaPaciente)
        {
            if (id != FacturaPaciente.CodigoFactura)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.FacturaPaciente, data.FacturaPaciente>(FacturaPaciente);
                new BS.FacturaPaciente(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!FacturaPacienteExists(id))
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
        [HttpPost]
        public async Task<ActionResult<models.FacturaPaciente>> PostFacturaPaciente(models.FacturaPaciente FacturaPaciente)
        {
            var mapaux = mapper.Map<models.FacturaPaciente, data.FacturaPaciente>(FacturaPaciente);
            new BS.FacturaPaciente(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetFacturaPaciente", new { id = FacturaPaciente.CodigoFactura }, FacturaPaciente);
            
        }

        // DELETE: api/Foci/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.FacturaPaciente>> DeleteFacturaPaciente(int id)
        {
            var FacturaPaciente = new BS.FacturaPaciente(dbcontext).GetOneById(id);
            if (FacturaPaciente == null)
            {
                return NotFound();
            }

            new BS.FacturaPaciente(dbcontext).Delete(FacturaPaciente);
            var mapaux = mapper.Map<data.FacturaPaciente, models.FacturaPaciente>(FacturaPaciente);
            return mapaux;
        }

        private bool FacturaPacienteExists(int id)
        {
            return (new BS.FacturaPaciente(dbcontext).GetOneById(id) != null);
            //return _context.Foci.Any(e => e.FocusId == id);
        }
    }
}

