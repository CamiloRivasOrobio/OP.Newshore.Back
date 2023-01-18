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
        private readonly IDateTimeService _dateTime;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
        }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Journey> Journey { get; set; }
        public DbSet<Transport> Personas { get; set; }
        public Task<int> SaveChangeAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.feregistro = _dateTime.NowUtc;
                        break;
                    case EntityState.Added:
                        entry.Entity.febaja = _dateTime.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
