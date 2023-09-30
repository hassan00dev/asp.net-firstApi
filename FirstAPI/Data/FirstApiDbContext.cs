using FirstAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Data;

public class FirstApiDbContext: DbContext
{
    public FirstApiDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Note> notes { get; set; }
}