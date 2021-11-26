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
    public class InventarioController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public InventarioController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Inventario>>> GetInventario()
        {
            var res = new BS.Inventario(dbcontext).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Inventario>, IEnumerable<models.Inventario>>(res).ToList();
            return mapaux;
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Inventario>> GetInventario(int id)
        {
            var Inventario = new BS.Inventario(dbcontext).GetOneById(id);

            if (Inventario == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Inventario, models.Inventario>(Inventario);
            return mapaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventario(int id, models.Inventario Inventario)
        {
            if (id != Inventario.IdInventario)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Inventario, data.Inventario>(Inventario);
                new BS.Inventario(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!InventarioExists(id))
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
        public async Task<ActionResult<models.Inventario>> PostInventario(models.Inventario Inventario)
        {
            var mapaux = mapper.Map<models.Inventario, data.Inventario>(Inventario);
            new BS.Inventario(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetInventario", new { id = Inventario.IdInventario }, Inventario);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Inventario>> DeleteInventario(int id)
        {
            var Inventario = new BS.Inventario(dbcontext).GetOneById(id);
            if (Inventario == null)
            {
                return NotFound();
            }

            new BS.Inventario(dbcontext).Delete(Inventario);
            var mapaux = mapper.Map<data.Inventario, models.Inventario>(Inventario);
            return mapaux;
        }

        private bool InventarioExists(int id)
        {
            return (new BS.Inventario(dbcontext).GetOneById(id) != null);
        }
    }
}




