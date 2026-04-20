namespace CacauShowApi324133124.Models
{
    public class Pedido
    {
        public int Id {get; set;}

        public required int UnidadeId {get; set;} //FK unidade

        public required int ProdutoId {get; set;} //FK produto
        
        public required int Quantidade { get; set; }

        public decimal ValorTotal { get; set; }


    }
}