using Core.Entities;
using Core.Interfaces;
using Infrastructure.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConcertsController: BaseApiController
    {
        private readonly IConcertRepository repo;

        public ConcertsController(IConcertRepository concertRepository)
        {
            repo = concertRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Concert>>> GetConcerts()
        {
            var concerts = await repo.GetConcerts();

            if(concerts.Count == 0)
            {
                return NoContent();
            }

            return Ok(concerts);
        }

        public async Task<ActionResult<Concert>> GetConcertById(int id)
        {
            var concert = await repo.GetConcertById(id);

            if(concert == null)
            {
                return NoContent();
            }

            return concert;
        }
    }
}