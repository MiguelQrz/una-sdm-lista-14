namespace CacauShowApi324133124.Models
{
    public class Franquia
    {
        public int Id {get; set;}

        public required string NomeLoja {get; set;}

        public required string Cidade {get; set;}
        
        public int CapacidadeEstoque { get; set; }

    }
}