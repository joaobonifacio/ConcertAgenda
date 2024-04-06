using Core.Interfaces;
using Core.Entities;
using Infrastructure.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ConcertRepository : IConcertRepository
    {

        private readonly ConcertsAgendaContext ctx;

        public ConcertRepository(ConcertsAgendaContext context)
        {
            ctx = context;
        }

        public async Task<Concert> GetConcertById(int id)
        {
            var concert = await ctx.Concerts.Where(c => c.ConcertId == id).FirstOrDefaultAsync();

            if(concert == null)
            {
                return new Concert();
            }

            return concert;
        }

        public async Task<IReadOnlyList<Concert>> GetConcerts()
        {
            var concerts = await ctx.Concerts.ToListAsync();

            if(concerts.Count == 0)
            {
                return new List<Concert>();
            } 

            return concerts;
        }
    }
}