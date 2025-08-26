using Ants3Arena.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ants3Arena.Api.Data.Contexts
{
    public class Ant3ArenaContext : DbContext
    {
        public Ant3ArenaContext(DbContextOptions<Ant3ArenaContext> options) : base(options)
        {
        }

        public DbSet<AntColor> AntColors { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Ant> Ants { get; set; }
    }
}
