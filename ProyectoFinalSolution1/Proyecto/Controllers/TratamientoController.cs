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
    public class TratamientoController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public TratamientoController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Tratamiento>>> GetTratamiento()
        {
            var res = new BS.Tratamiento(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Tratamiento>, IEnumerable<models.Tratamiento>>(res).ToList();
            return mapaux;
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Tratamiento>> GetTratamiento(int id)
        {
            var Tratamiento = new BS.Tratamiento(dbcontext).GetOneById(id);

            if (Tratamiento == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Tratamiento, models.Tratamiento>(Tratamiento);
            return mapaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTratamiento(int id, models.Tratamiento Tratamiento)
        {
            if (id != Tratamiento.IdTratamiento)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Tratamiento, data.Tratamiento>(Tratamiento);
                new BS.Tratamiento(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!TratamientoExists(id))
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
        public async Task<ActionResult<models.Tratamiento>> PostTratamiento(models.Tratamiento Tratamiento)
        {
            var mapaux = mapper.Map<models.Tratamiento, data.Tratamiento>(Tratamiento);
            new BS.Tratamiento(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetTratamiento", new { id = Tratamiento.IdTratamiento }, Tratamiento);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Tratamiento>> DeleteTratamiento(int id)
        {
            var Tratamiento = new BS.Tratamiento(dbcontext).GetOneById(id);
            if (Tratamiento == null)
            {
                return NotFound();
            }

            new BS.Tratamiento(dbcontext).Delete(Tratamiento);
            var mapaux = mapper.Map<data.Tratamiento, models.Tratamiento>(Tratamiento);
            return mapaux;
        }

        private bool TratamientoExists(int id)
        {
            return (new BS.Tratamiento(dbcontext).GetOneById(id) != null);
        }
    }
}



