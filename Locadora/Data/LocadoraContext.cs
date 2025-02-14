using Locadora.Models;
using Microsoft.EntityFrameworkCore;


namespace Locadora.Data;
public class LocadoraContext : DbContext{

    public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options)
    {
    }
    public DbSet<Game> Games { get; set; }
}