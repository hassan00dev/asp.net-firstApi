namespace FirstAPI.Models.DTO;

public class NoteDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
}