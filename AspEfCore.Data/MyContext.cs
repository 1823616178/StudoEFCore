using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AspEfCore.Domain;
namespace AspEfCore.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CitiesProvince>()
                .HasKey(x => new { x.CitiesId, x.CompanyId });
            modelBuilder.Entity<CitiesProvince>()
                .HasOne(x => x.Cities).WithMany(x => x.CitiesProvinces).HasForeignKey(x => x.CitiesId);
        }
        public DbSet<Province> provinces { set; get; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<CitiesProvince> citiesProvinces { set; get; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Mayor> mayors { set; get; }
    }
}
