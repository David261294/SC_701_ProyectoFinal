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
    public class DentistaController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public DentistaController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Dentista>>> GetDentista()
        {
            var res = new BS.Dentista(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Dentista>, IEnumerable<models.Dentista>>(res).ToList();
            return mapaux;
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Dentista>> GetDentista(int id)
        {
            var Dentista = new BS.Dentista(dbcontext).GetOneById(id);

            if (Dentista == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Dentista, models.Dentista>(Dentista);
            return mapaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDentista(int id, models.Dentista Dentista)
        {
            if (id != Dentista.IdDentista)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Dentista, data.Dentista>(Dentista);
                new BS.Dentista(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!DentistaExists(id))
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
        public async Task<ActionResult<models.Dentista>> PostDentista(models.Dentista Dentista)
        {
            var mapaux = mapper.Map<models.Dentista, data.Dentista>(Dentista);
            new BS.Dentista(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetDentista", new { id = Dentista.IdDentista }, Dentista);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Dentista>> DeleteDentista(int id)
        {
            var Dentista = new BS.Dentista(dbcontext).GetOneById(id);
            if (Dentista == null)
            {
                return NotFound();
            }

            new BS.Dentista(dbcontext).Delete(Dentista);
            var mapaux = mapper.Map<data.Dentista, models.Dentista>(Dentista);
            return mapaux;
        }

        private bool DentistaExists(int id)
        {
            return (new BS.Dentista(dbcontext).GetOneById(id) != null);
        }
    }
}


