using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AspEfCore.Domain;
namespace AspEfCore.Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Province> provinces { set; get; }
        public DbSet<Cities> Cities { get; set; }
    }
}
