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
    public class ReviewController : ControllerBase
    {
        private readonly DBDentistaContext dbcontext;
        private readonly IMapper mapper;
        public ReviewController(DBDentistaContext _dbcontext, IMapper _mapper)
        {
            dbcontext = _dbcontext;
            mapper = _mapper;
        }

        // GET: api/Foci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Review>>> GetReview()
        {
            var res = await new BS.Review(dbcontext).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.Review>, IEnumerable<models.Review>>(res).ToList();

            return mapaux;

            // Este GetAll no trae las relaaciones
            //return new BE.BS.Foci(dbcontext).GetAll().ToList();
        }

        // GET: api/Foci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Review>> GetReview(int id)
        {
            var Review = await new BS.Review(dbcontext).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.Review, models.Review>(Review);

            // Este Get no trae las relaaciones
            //var foci = new BE.BS.Foci(dbcontext).GetOneById(id);

            if (Review == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Foci/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, models.Review Review)
        {
            if (id != Review.IdReview)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Review, data.Review>(Review);
                new BS.Review(dbcontext).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ReviewExists(id))
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
        [HttpPost]
        public async Task<ActionResult<models.Review>> PostReview(models.Review Review)
        {
            var mapaux = mapper.Map<models.Review, data.Review>(Review);
            new BS.Review(dbcontext).Insert(mapaux);

            return CreatedAtAction("GetReview", new { id = Review.IdReview }, Review);

        }

        // DELETE: api/Foci/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Review>> DeleteReview(int id)
        {
            var Review = new BS.Review(dbcontext).GetOneById(id);
            if (Review == null)
            {
                return NotFound();
            }

            new BS.Review(dbcontext).Delete(Review);
            var mapaux = mapper.Map<data.Review, models.Review>(Review);
            return mapaux;
        }

        private bool ReviewExists(int id)
        {
            return (new BS.Review(dbcontext).GetOneById(id) != null);
            //return _context.Foci.Any(e => e.FocusId == id);
        }
    }
}


