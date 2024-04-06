namespace Core.Entities;

public class Venue
{
    public int VenueId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int? Capacity { get; set; }

    public virtual ICollection<Concert> Concerts { get; } = new List<Concert>();
}
