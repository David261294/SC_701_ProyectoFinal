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
    public class PacienteNuevoController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public PacienteNuevoController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.PacienteNuevo>>> GetPacienteNuevo()
        {
            var res = new BS.PacienteNuevo(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.PacienteNuevo>, IEnumerable<models.PacienteNuevo>>(res).ToList();
            return mapaux;
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.PacienteNuevo>> GetPacienteNuevo(int id)
        {
            var PacienteNuevo = new BS.PacienteNuevo(dbcontext).GetOneById(id);

            if (PacienteNuevo == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.PacienteNuevo, models.PacienteNuevo>(PacienteNuevo);
            return mapaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacienteNuevo(int id, models.PacienteNuevo PacienteNuevo)
        {
            if (id != PacienteNuevo.IdPacienteNuevo)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.PacienteNuevo, data.PacienteNuevo>(PacienteNuevo);
                new BS.PacienteNuevo(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!PacienteNuevoExists(id))
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
        public async Task<ActionResult<models.PacienteNuevo>> PostPacienteNuevo(models.PacienteNuevo PacienteNuevo)
        {
            var mapaux = mapper.Map<models.PacienteNuevo, data.PacienteNuevo>(PacienteNuevo);
            new BS.PacienteNuevo(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetPacienteNuevo", new { id = PacienteNuevo.IdPacienteNuevo }, PacienteNuevo);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.PacienteNuevo>> DeletePacienteNuevo(int id)
        {
            var PacienteNuevo = new BS.PacienteNuevo(dbcontext).GetOneById(id);
            if (PacienteNuevo == null)
            {
                return NotFound();
            }

            new BS.PacienteNuevo(dbcontext).Delete(PacienteNuevo);
            var mapaux = mapper.Map<data.PacienteNuevo, models.PacienteNuevo>(PacienteNuevo);
            return mapaux;
        }

        private bool PacienteNuevoExists(int id)
        {
            return (new BS.PacienteNuevo(dbcontext).GetOneById(id) != null);
        }
    }
}



