using Core.Entities;

namespace Core.Interfaces
{
    public interface IConcertRepository
    {
        Task<IReadOnlyList<Concert>> GetConcerts();

        Task<Concert> GetConcertById(int id);
    }
}