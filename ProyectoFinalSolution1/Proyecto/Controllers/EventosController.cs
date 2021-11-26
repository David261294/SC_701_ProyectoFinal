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
    public class EventosController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public EventosController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Eventos>>> GetEventos()
        {
            var res = new BS.Eventos(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Eventos>, IEnumerable<models.Eventos>>(res).ToList();
            return mapaux;
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Eventos>> GetEventos(int id)
        {
            var Eventos = new BS.Eventos(dbcontext).GetOneById(id);

            if (Eventos == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Eventos, models.Eventos>(Eventos);
            return mapaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventos(int id, models.Eventos Eventos)
        {
            if (id != Eventos.IdEvento)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Eventos, data.Eventos>(Eventos);
                new BS.Eventos(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!EventosExists(id))
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
        public async Task<ActionResult<models.Eventos>> PostEventos(models.Eventos Eventos)
        {
            var mapaux = mapper.Map<models.Eventos, data.Eventos>(Eventos);
            new BS.Eventos(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetEventos", new { id = Eventos.IdEvento }, Eventos);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Eventos>> DeleteEventos(int id)
        {
            var Eventos = new BS.Eventos(dbcontext).GetOneById(id);
            if (Eventos == null)
            {
                return NotFound();
            }

            new BS.Eventos(dbcontext).Delete(Eventos);
            var mapaux = mapper.Map<data.Eventos, models.Eventos>(Eventos);
            return mapaux;
        }

        private bool EventosExists(int id)
        {
            return (new BS.Eventos(dbcontext).GetOneById(id) != null);
        }
    }
}




