namespace Core.Entities;

public class ConcertArtist
{
    public int ConcertArtistId { get; set; }

    public int ConcertId { get; set; }

    public int ArtistId { get; set; }

    public bool IsOpeningAct { get; set; }

    public DateTime PerformanceStartTime { get; set; }

    public bool IsHeadliner { get; set; }

    public virtual Artist Artist { get; set; } = null!;

    public virtual Concert Concert { get; set; } = null!;
}
