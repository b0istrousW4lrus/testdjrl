using DjRequestLive.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using DjRequestLive.Data.Logging.EFLogging;
using Microsoft.Extensions.Logging;

namespace DjRequestLive.Data
{
    public class DjRequestLiveDbContext : DbContext
    {
        
        public DjRequestLiveDbContext(DbContextOptions<DjRequestLiveDbContext> options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(true, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            AddAuditInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var lf = new LoggerFactory();
            lf.AddProvider(new MyLoggerProvider());
            optionsBuilder.UseLoggerFactory(lf);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyConfigurations(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            var configurations = Assembly.GetExecutingAssembly().DefinedTypes.Where(t =>
           t.ImplementedInterfaces.Any(i =>
              i.IsGenericType &&
              i.Name.Equals(typeof(IEntityTypeConfiguration<>).Name,
                     StringComparison.InvariantCultureIgnoreCase)
            ) &&
            t.IsClass &&
            !t.IsAbstract &&
            !t.IsNested)
            .ToList();

            foreach (var configuration in configurations)
            {
                var entityType = configuration.BaseType.GenericTypeArguments.SingleOrDefault(t => t.IsClass);
                var applyGenericMethod = typeof(ModelBuilder).GetMethods().Single(x => x.Name == "ApplyConfiguration" && x.GetParameters().All(y => y.ParameterType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

                foreach (var iface in configuration.GetInterfaces())
                {
                    // if type implements interface IEntityTypeConfiguration<SomeEntity>
                    if (iface.IsConstructedGenericType && iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    {
                        // make concrete ApplyConfiguration<SomeEntity> method
                        var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
                        // and invoke that with fresh instance of your configuration type
                        applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(configuration) });
                        break;
                    }
                }
                //var applyConfigGenericMethod = applyConfigMethod.MakeGenericMethod(entityType);

                //applyConfigGenericMethod.Invoke(modelBuilder,
                //        new object[] { Activator.CreateInstance(configuration) });
            }
        }

        private void AddAuditInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
                ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}
