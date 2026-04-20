using CacauShowApi324133124.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;


namespace CacauShowApi324133124.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Franquia> Franquias {get; set;}
        public DbSet<LoteProducao> Lotes {get; set;}
        public DbSet<Pedido> Pedidos {get; set;}
        public DbSet<Produto> Produtos {get; set;}

    }
}