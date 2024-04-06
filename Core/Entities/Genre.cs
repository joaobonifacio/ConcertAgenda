namespace Core.Entities;

public class Genre
{
    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Artist> Artists { get; } = new List<Artist>();

    public virtual ICollection<SubGenre> SubGenres { get; } = new List<SubGenre>();
}
