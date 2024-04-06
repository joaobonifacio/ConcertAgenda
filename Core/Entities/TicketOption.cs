namespace Core.Entities;

public class TicketOption
{
    public int TicketOptionId { get; set; }

    public int ConcertId { get; set; }

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual Concert Concert { get; set; } = null!;
}
