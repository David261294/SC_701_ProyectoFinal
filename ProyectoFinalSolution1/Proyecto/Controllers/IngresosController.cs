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
    public class IngresosController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public IngresosController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Foci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Ingresos>>> GetIngresos()
        {
            var res = await new BS.Ingresos(dbcontext).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.Ingresos>, IEnumerable<models.Ingresos>>(res).ToList();

            return mapaux;

            // Este GetAll no trae las relaaciones
            //return new BE.BS.Foci(dbcontext).GetAll().ToList();
        }

        // GET: api/Foci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Ingresos>> GetIngresos(int id)
        {
            var Ingresos = await new BS.Ingresos(dbcontext).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.Ingresos, models.Ingresos>(Ingresos);

            // Este Get no trae las relaaciones
            //var foci = new BE.BS.Foci(dbcontext).GetOneById(id);

            if (Ingresos == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Foci/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngresos(int id, models.Ingresos Ingresos)
        {
            if (id != Ingresos.IdIngreso)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Ingresos, data.Ingresos>(Ingresos);
                new BS.Ingresos(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!IngresosExists(id))
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
        public async Task<ActionResult<models.Ingresos>> PostIngresos(models.Ingresos Ingresos)
        {
            var mapaux = mapper.Map<models.Ingresos, data.Ingresos>(Ingresos);
            new BS.Ingresos(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetIngresos", new { id = Ingresos.IdIngreso }, Ingresos);

        }

        // DELETE: api/Foci/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Ingresos>> DeleteIngresos(int id)
        {
            var Ingresos = new BS.Ingresos(dbcontext).GetOneById(id);
            if (Ingresos == null)
            {
                return NotFound();
            }

            new BS.Ingresos(dbcontext).Delete(Ingresos);
            var mapaux = mapper.Map<data.Ingresos, models.Ingresos>(Ingresos);
            return mapaux;
        }

        private bool IngresosExists(int id)
        {
            return (new BS.Ingresos(dbcontext).GetOneById(id) != null);
            //return _context.Foci.Any(e => e.FocusId == id);
        }
    }
}


