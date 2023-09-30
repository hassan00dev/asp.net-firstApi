using FirstAPI.Data;
using FirstAPI.Models.Domain;
using FirstAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoteController : Controller
{
    private readonly FirstApiDbContext _dbContext;

    public NoteController(FirstApiDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var notes = _dbContext.notes.ToList();
        var response = new List<NoteDto>();
        foreach (var note in notes)
        {
            response.Add(new NoteDto()
            {
                Id = note.Id,
                Title = note.Title,
                Description = note.Description,
            });
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult Show([FromRoute] Guid id)
    {
        var note = _dbContext.notes.Find(id);

        if (note == null)
        {
            return NotFound();
        }

        var response = new NoteDto()
        {
            Id = note.Id,
            Title = note.Title,
            Description = note.Description,
        };
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Create([FromBody] AddNoteRequestDto addNoteRequestDto)
    {
        var note = new Note()
        {
            Title = addNoteRequestDto.Title,
            Description = addNoteRequestDto.Description,
        };
        _dbContext.notes.Add(note);
        _dbContext.SaveChanges();
        
        var noteDto = new NoteDto()
        {
            Id = note.Id,
            Title = note.Title,
            Description = note.Description,
        };

        return CreatedAtAction(nameof(Show), new { Id = note.Id }, noteDto);
    }
}