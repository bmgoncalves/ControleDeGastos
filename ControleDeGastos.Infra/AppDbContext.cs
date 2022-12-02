using ControleDeGastos.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;


namespace ControleDeGastos.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public DbSet<Entries> Entries { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }

        
    }
}
