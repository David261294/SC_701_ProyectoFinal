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
    public class ContactoController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public ContactoController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Contacto>>> GetContacto()
        {
            var res = new BS.Contacto(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Contacto>, IEnumerable<models.Contacto>>(res).ToList();
            return mapaux;
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Contacto>> GetContacto(int id)
        {
            var Contacto = new BS.Contacto(dbcontext).GetOneById(id);

            if (Contacto == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Contacto, models.Contacto>(Contacto);
            return mapaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContacto(int id, models.Contacto Contacto)
        {
            if (id != Contacto.IdContacto)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Contacto, data.Contacto>(Contacto);
                new BS.Contacto(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ContactoExists(id))
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
        public async Task<ActionResult<models.Contacto>> PostContacto(models.Contacto Contacto)
        {
            var mapaux = mapper.Map<models.Contacto, data.Contacto>(Contacto);
            new BS.Contacto(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetContacto", new { id = Contacto.IdContacto }, Contacto);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Contacto>> DeleteContacto(int id)
        {
            var Contacto = new BS.Contacto(dbcontext).GetOneById(id);
            if (Contacto == null)
            {
                return NotFound();
            }

            new BS.Contacto(dbcontext).Delete(Contacto);
            var mapaux = mapper.Map<data.Contacto, models.Contacto>(Contacto);
            return mapaux;
        }

        private bool ContactoExists(int id)
        {
            return (new BS.Contacto(dbcontext).GetOneById(id) != null);
        }
    }
}




