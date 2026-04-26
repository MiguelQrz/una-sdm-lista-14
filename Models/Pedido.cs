namespace CacauShowApi324133124.Models
{
    public class Pedido
    {
        public int Id {get; set;}
        public required int UnidadeId {get; set;}
        public Franquia? Unidade { get; set; }
        public required int ProdutoId {get; set;}
        public Produto? Produto { get; set; }
        public required int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
    }
}