using Microsoft.EntityFrameworkCore;
using Profit.Models.Db;

namespace Profit.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlite(ConnectionBuilder.GetConnectionString());                        
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Gasto> Gasto { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<Ingrediente_Receita> Ingrediente_Receita { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Receita> Receita { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Venda_Produto> Venda_Produto { get; set; }
    }
}
