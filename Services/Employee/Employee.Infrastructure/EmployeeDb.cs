using Microsoft.EntityFrameworkCore;
using Employee.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlock.Infrastructure;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Employee.Infrastructure
{
    public class EmployeeDb : DbContext
    {
        public DbSet<Employees> Employee { get; set; }
        public DbSet<Lookup> Lookup { get; set; }
        public DbSet<LookupType> LookupType { get; set; }
       public void InitDatabase()
        {
            this.Database.Migrate();
        }
        public EmployeeDb()
        {
            
        }
        public EmployeeDb(DbContextOptions <EmployeeDb> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DbSchema.Employee);
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is DomainBase && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((DomainBase)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((DomainBase)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
    }
}
