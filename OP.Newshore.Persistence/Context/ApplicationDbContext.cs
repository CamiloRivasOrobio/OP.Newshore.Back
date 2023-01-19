using Microsoft.EntityFrameworkCore;
using OP.Newshore.Application.Interfaces;
using OP.Newshore.Domain.Common;
using OP.Newshore.Domain.Entities;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace OP.Newshore.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Journey> Journey { get; set; }
        public DbSet<Transport> Personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
