namespace Core.Entities;

public class Concert
{
    public int ConcertId { get; set; }

    public string? Name { get; set; }

    public DateTime Date { get; set; }

    public int VenueId { get; set; }

    public bool IsFestival { get; set; }

    public virtual ICollection<ConcertArtist> ConcertArtists { get; } = new List<ConcertArtist>();

    public virtual ICollection<TicketOption> TicketOptions { get; } = new List<TicketOption>();

    public virtual Venue Venue { get; set; } = null!;
}
