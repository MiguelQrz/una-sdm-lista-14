namespace CacauShowApi324133124.Models
{
    public class LoteProducao
    {
        public int Id {get; set;}

        public required string CodigoLote {get; set;}

        public DateTime DataFabricacao {get; set;}

        public required int ProdutoId {get; set;}

        public required string Status { get; set; } = "Em produção";

    }
}