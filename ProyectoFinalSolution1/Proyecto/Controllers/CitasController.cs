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
    public class CitasController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public CitasController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Citas>>> GetCitas()
        {
            var res = new BS.Citas(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Citas>, IEnumerable<models.Citas>>(res).ToList();
            return mapaux;
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Citas>> GetCitas(int id)
        {
            var Citas = new BS.Citas(dbcontext).GetOneById(id);

            if (Citas == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Citas, models.Citas>(Citas);
            return mapaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitas(int id, models.Citas Citas)
        {
            if (id != Citas.IdCitas)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Citas, data.Citas>(Citas);
                new BS.Citas(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!CitasExists(id))
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
        public async Task<ActionResult<models.Citas>> PostCitas(models.Citas Citas)
        {
            var mapaux = mapper.Map<models.Citas, data.Citas>(Citas);
            new BS.Citas(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetCitas", new { id = Citas.IdCitas }, Citas);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Citas>> DeleteCitas(int id)
        {
            var Citas = new BS.Citas(dbcontext).GetOneById(id);
            if (Citas == null)
            {
                return NotFound();
            }

            new BS.Citas(dbcontext).Delete(Citas);
            var mapaux = mapper.Map<data.Citas, models.Citas>(Citas);
            return mapaux;
        }

        private bool CitasExists(int id)
        {
            return (new BS.Citas(dbcontext).GetOneById(id) != null);
        }
    }
}



