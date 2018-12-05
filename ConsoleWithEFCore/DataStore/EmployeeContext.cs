// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeContext.cs" company="LiteObject">
//   
// </copyright>
// <summary>
//   The employee context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleWithEFCore.DataStore
{
    using System;
    using System.Linq;

    using ConsoleWithEFCore.Extensions;
    using ConsoleWithEFCore.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;

    /// <summary>
    /// The employee context.
    /// </summary>
    public class EmployeeContext : DbContext
    {
        /// <summary>
        /// The seed.
        /// </summary>
        private readonly bool seed;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeContext"/> class.
        /// </summary>
        public EmployeeContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeContext"/> class.
        /// </summary>
        /// <param name="seed">
        /// The seed.
        /// </param>
        public EmployeeContext(bool seed)
        {
            this.seed = seed;
        }

        /// <summary>
        /// Gets or sets the companies.
        /// </summary>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <inheritdoc />
        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();
            var timestamp = DateTime.Now;

            foreach (var entry in this.ChangeTracker.Entries().Where(e =>
                (e.State == EntityState.Added || e.State == EntityState.Modified)
                && !e.Metadata.IsOwned()))
            {
                entry.Property("Modified").CurrentValue = timestamp;

                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = timestamp;
                }
            }

            return base.SaveChanges();
        }

        /// <summary>
        /// The on configuring.
        /// </summary>
        /// <param name="optionsBuilder">
        /// The options builder.
        /// </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                //@"Server=localhost,1433;Database=ConsoleWithEFCore;User Id=sa;Password=Ul.123456;",
                @"Server=(localdb)\mssqllocaldb;Database=ConsoleWithEFCore;Trusted_Connection=True;",
                options => options.EnableRetryOnFailure()); // Connection Resiliency

            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseLoggerFactory(
                new LoggerFactory(
                    new[]
                        {
                            new ConsoleLoggerProvider(
                                (category, level) =>
                                    category == DbLoggerCategory.Database.Command.Name
                                    && level == LogLevel.Information,
                                true)
                        }));
        }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Owned type feature for value object
            /* modelBuilder.Entity<Employee>().OwnsOne(e => e.Name); // Name_FirstName, Name_LastName */
            modelBuilder.Entity<Employee>().OwnsOne(e => e.Name).Property(n => n.FirstName).HasColumnName("FirstName");
            modelBuilder.Entity<Employee>().OwnsOne(e => e.Name).Property(n => n.LastName).HasColumnName("LastName");

            if (this.seed)
            {
                modelBuilder.Seed();
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
