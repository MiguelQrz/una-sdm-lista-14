using CacauShowApi324133124.Models;
using Microsoft.EntityFrameworkCore;

/*
db steps
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet ef migrations add InitialCreate
dotnet ef database update
*/

namespace CacauShowApi324133124.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Franquia> Franquias { get; set; }
        public DbSet<LoteProducao> LotesProducao { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Unidade)
                .WithMany(f => f.Pedidos)
                .HasForeignKey(p => p.UnidadeId);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Produto)
                .WithMany(prod => prod.Pedidos)
                .HasForeignKey(p => p.ProdutoId);

            modelBuilder.Entity<LoteProducao>()
                .HasOne(l => l.Produto)
                .WithMany(p => p.LotesProducao)
                .HasForeignKey(l => l.ProdutoId);
        }
    }
}