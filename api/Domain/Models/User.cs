namespace Domain.Models;

public class User
{
    public Guid Id {get;set;}
    public required string FullName {get;set;}
    public required string GroupName { get; set; }
}