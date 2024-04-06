namespace Core.Entities;

public class Artist
{
    public int ArtistId { get; set; }

    public string Name { get; set; } = null!;

    public int? GenreId { get; set; }

    public virtual ICollection<ConcertArtist> ConcertArtists { get; } = new List<ConcertArtist>();

    public virtual Genre? Genre { get; set; }

    public virtual ICollection<SubGenre> SubGenres { get; } = new List<SubGenre>();
}
