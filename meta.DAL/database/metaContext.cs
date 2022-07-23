using meta.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta.DAL.database
{
    public class metaContext: DbContext
    {
      

        public metaContext(DbContextOptions<metaContext> opts) : base(opts)
        { }
        public DbSet<Department>? Department { get; set; }
        public DbSet<Employee>? Employee { get; set; }
        public DbSet<Country>? Country { get; set; }
        public DbSet<City>? City { get; set; }
        public DbSet<District>? District { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                    .HasOne<Country>(s => s.Country)
                    .WithMany(g => g.City)
                    .HasForeignKey(s => s.CountryId);

            modelBuilder.Entity<District>()
                    .HasOne<City>(s => s.City)
                    .WithMany(g => g.District)
                    .HasForeignKey(s => s.CityId);

            modelBuilder.Entity<Employee>()
                    .HasOne<District>(s => s.District)
                    .WithMany(g => g.Employee)
                    .HasForeignKey(s => s.DistrictId);
        }


    }
}
