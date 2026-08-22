namespace Domain.Models;

public class Room
{
    public Guid Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
}