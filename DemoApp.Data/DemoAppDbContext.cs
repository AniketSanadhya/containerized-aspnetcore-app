using DemoApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Data
{
    public class DemoAppDbContext : DbContext
    {
        public DemoAppDbContext(DbContextOptions<DemoAppDbContext> options):base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
    }
}
