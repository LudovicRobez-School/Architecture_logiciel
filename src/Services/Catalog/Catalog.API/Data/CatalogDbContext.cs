using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Models;
using ApiLibrary.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data
{
    public class CatalogDbContext : BaseDbContext
    {

        public CatalogDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

       public DbSet<Product> Products { get; set; }
       public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
