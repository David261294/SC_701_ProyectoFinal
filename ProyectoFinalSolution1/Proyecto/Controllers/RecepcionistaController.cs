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
    public class RecepcionistaController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public RecepcionistaController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Recepcionista>>> GetRecepcionista()
        {
            var res = new BS.Recepcionista(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Recepcionista>, IEnumerable<models.Recepcionista>>(res).ToList();
            return mapaux;
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Recepcionista>> GetRecepcionista(int id)
        {
            var Recepcionista = new BS.Recepcionista(dbcontext).GetOneById(id);

            if (Recepcionista == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Recepcionista, models.Recepcionista>(Recepcionista);
            return mapaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecepcionista(int id, models.Recepcionista Recepcionista)
        {
            if (id != Recepcionista.IdRecepcionista)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Recepcionista, data.Recepcionista>(Recepcionista);
                new BS.Recepcionista(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!RecepcionistaExists(id))
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
        public async Task<ActionResult<models.Recepcionista>> PostRecepcionista(models.Recepcionista Recepcionista)
        {
            var mapaux = mapper.Map<models.Recepcionista, data.Recepcionista>(Recepcionista);
            new BS.Recepcionista(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetRecepcionista", new { id = Recepcionista.IdRecepcionista }, Recepcionista);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Recepcionista>> DeleteRecepcionista(int id)
        {
            var Recepcionista = new BS.Recepcionista(dbcontext).GetOneById(id);
            if (Recepcionista == null)
            {
                return NotFound();
            }

            new BS.Recepcionista(dbcontext).Delete(Recepcionista);
            var mapaux = mapper.Map<data.Recepcionista, models.Recepcionista>(Recepcionista);
            return mapaux;
        }

        private bool RecepcionistaExists(int id)
        {
            return (new BS.Recepcionista(dbcontext).GetOneById(id) != null);
        }
    }
}

