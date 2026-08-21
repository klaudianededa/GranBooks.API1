namespace GranBooks.API.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public int LivroId { get; set; }
        public Livro? Livro { get; set; } // Propriedade de navegação para trazer os dados do livro junto
        public DateTime DataEmprestimo { get; set; } = DateTime.Now;
        public DateTime? DataDevolucao { get; set; }
        public string Status { get; set; } = "Ativo"; // "Ativo" ou "Devolvido"
    }
}