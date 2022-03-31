using InMemory.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace InMemory.DAL
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions options) : base(options) { }

        public TestContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryProvider");
        }


        public DbSet<Teste> Teste { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teste>().HasAlternateKey(c => c.Title);
        }

    }
}