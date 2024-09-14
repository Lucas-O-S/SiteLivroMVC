namespace SiteLivro.Models
{
    public class LivroViewModel
    {
        public int id { get; set; }
        public string titulo { get; set; }

        public string autor1 {  get; set; }

        public string? autor2 { get; set;}

        public string editora { get; set;}

        public int anoLancamento { get; set;}

        public int  edicao { get; set;}

        public decimal precoSugerido { get; set;}
    }
}
