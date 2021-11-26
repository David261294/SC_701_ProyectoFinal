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
    public class ReunionController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public ReunionController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Foci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Reunion>>> GetReunion()
        {
            var res = await new BS.Reunion(dbcontext).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.Reunion>, IEnumerable<models.Reunion>>(res).ToList();

            return mapaux;

            // Este GetAll no trae las relaaciones
            //return new BE.BS.Foci(dbcontext).GetAll().ToList();
        }

        // GET: api/Foci/5
        [HttpGet("{id},{IdDentista}, {IdRecepcionista}")]
        public async Task<ActionResult<models.Reunion>> GetReunion(int id ,int IdDentista, int IdRecepcionista)
        {
            var Reunion = await new BS.Reunion(dbcontext).GetOneByIdAsync(id,IdDentista,IdRecepcionista);
            var mapaux = mapper.Map<data.Reunion, models.Reunion>(Reunion);

            // Este Get no trae las relaaciones
            //var foci = new BE.BS.Foci(dbcontext).GetOneById(id);

            if (Reunion == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Foci/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReunion(int id, models.Reunion Reunion)
        {
            if (id != Reunion.NumeroReunion)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Reunion, data.Reunion>(Reunion);
                new BS.Reunion(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ReunionExists(id))
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
        [HttpPost("{IdDentista}, {IdRecepcionista}")]
        public async Task<ActionResult<models.Reunion>> PostReunion(models.Reunion Reunion)
        {
            var mapaux = mapper.Map<models.Reunion, data.Reunion>(Reunion);
            new BS.Reunion(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetReunion", new { id = /*Reunion.NumeroReunion,*/ Reunion.IdDentista, Reunion.IdRecepcionista }, Reunion);
            

        }
            // DELETE: api/Foci/5
            [HttpDelete("{id}")]

            public async Task<ActionResult<models.Reunion>> DeleteReunion(int id/*, int IdDentista, int IdRecepcionista*/)
            {
                var Reunion = new BS.Reunion(dbcontext).GetOneById(id/*, IdDentista, IdRecepcionista*/);
                if (Reunion == null)
                {
                    return NotFound();
                }

                new BS.Reunion(dbcontext).Delete(Reunion);
                var mapaux = mapper.Map<data.Reunion, models.Reunion>(Reunion);
                return mapaux;
            }

            private bool ReunionExists(int id)
            {
                return (new BS.Reunion(dbcontext).GetOneById(id) != null);
                //return _context.Foci.Any(e => e.FocusId == id);
            }
        
    }
}


