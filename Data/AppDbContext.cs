using Microsoft.EntityFrameworkCore;
using GranBooks.API.Models;

namespace GranBooks.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
    }
}