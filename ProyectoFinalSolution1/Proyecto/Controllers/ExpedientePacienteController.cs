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
    public class ExpedientePacienteController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public ExpedientePacienteController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.ExpedientePaciente>>> GetExpedientePaciente()
        {
            var res = new BS.ExpedientePaciente(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.ExpedientePaciente>, IEnumerable<models.ExpedientePaciente>>(res).ToList();
            return mapaux;
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.ExpedientePaciente>> GetExpedientePaciente(int id)
        {
            var ExpedientePaciente = new BS.ExpedientePaciente(dbcontext).GetOneById(id);

            if (ExpedientePaciente == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.ExpedientePaciente, models.ExpedientePaciente>(ExpedientePaciente);
            return mapaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpedientePaciente(int id, models.ExpedientePaciente ExpedientePaciente)
        {
            if (id != ExpedientePaciente.IdPaciente)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.ExpedientePaciente, data.ExpedientePaciente>(ExpedientePaciente);
                new BS.ExpedientePaciente(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ExpedientePacienteExists(id))
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
        public async Task<ActionResult<models.ExpedientePaciente>> PostExpedientePaciente(models.ExpedientePaciente ExpedientePaciente)
        {
            var mapaux = mapper.Map<models.ExpedientePaciente, data.ExpedientePaciente>(ExpedientePaciente);
            new BS.ExpedientePaciente(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetExpedientePaciente", new { id = ExpedientePaciente.IdPaciente }, ExpedientePaciente);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.ExpedientePaciente>> DeleteExpedientePaciente(int id)
        {
            var ExpedientePaciente = new BS.ExpedientePaciente(dbcontext).GetOneById(id);
            if (ExpedientePaciente == null)
            {
                return NotFound();
            }

            new BS.ExpedientePaciente(dbcontext).Delete(ExpedientePaciente);
            var mapaux = mapper.Map<data.ExpedientePaciente, models.ExpedientePaciente>(ExpedientePaciente);
            return mapaux;
        }

        private bool ExpedientePacienteExists(int id)
        {
            return (new BS.ExpedientePaciente(dbcontext).GetOneById(id) != null);
        }
    }
}



