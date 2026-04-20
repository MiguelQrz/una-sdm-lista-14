namespace CacauShowApi324133124.Models
{
    public class Produto
    {
        public int Id {get; set;}

        public required string Nome {get; set;} //Ovo LaNut, Trufa etc...

        public required string Tipo {get; set;} //[Gourmet, Linha Regular, Sazonal]
        
        public decimal PrecoBase { get; set; }

    }
}