using System.Collections.Generic;
namespace CacauShowApi324133124.Models
{
    public class Produto
    {
        public int Id {get; set;}
        public required string Nome {get; set;}
        public required string Tipo {get; set;}
        public decimal PrecoBase { get; set; }

        public ICollection<LoteProducao>? LotesProducao { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}