using Locadora.Models;
using Locadora.Models.EmployeeAttendant;
using Locadora.Models.EmployeeRecepcionist;
using Microsoft.EntityFrameworkCore;


namespace Locadora.Data;
public class LocadoraContext : DbContext{

    public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options)
    {
    }
    public DbSet<Game> Games { get; set; }
    public DbSet<Attendant> Attendants { get; set; }
    public DbSet<Recepcionist> Recepcionists { get; set; }
}