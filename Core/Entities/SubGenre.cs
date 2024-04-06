namespace Core.Entities;

public class SubGenre
{
    public int SubGenreId { get; set; }

    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;

    public virtual ICollection<Artist> Artists { get; } = new List<Artist>();
}
