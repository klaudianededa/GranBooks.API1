namespace GranBooks.API1.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public int Copias { get; set; }
        public string Imagem { get; set; } = string.Empty;
    }
}