namespace FirstAPI.Models.Domain;

public class Note
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
}