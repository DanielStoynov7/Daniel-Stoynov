using Dani.DataAccess.Entities;
using DaniWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DaniWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity { Id = 1, Name = "Action", DisplayOrder = 1 },
                new CategoryEntity { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new CategoryEntity { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }
    }
}
