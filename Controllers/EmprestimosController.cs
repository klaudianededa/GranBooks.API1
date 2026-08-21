using GranBooks.API.Data;
using GranBooks.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GranBooks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmprestimosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/emprestimos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emprestimo>>> GetEmprestimos()
        {
            return await _context.Emprestimos
                .Include(e => e.Livro) // Traz os dados do livro junto
                .ToListAsync();
        }

        // POST: api/emprestimos/retirar/5
        [HttpPost("retirar/{livroId}")]
        public async Task<ActionResult<Emprestimo>> RealizarEmprestimo(int livroId)
        {
            var livro = await _context.Livros.FindAsync(livroId);
            if (livro == null) return NotFound("Livro não encontrado.");

            if (livro.Copias <= 0)
            {
                return BadRequest("Não há cópias disponíveis para empréstimo.");
            }

            // Diminui o estoque
            livro.Copias -= 1;

            // Cria o registro do empréstimo
            var emprestimo = new Emprestimo
            {
                LivroId = livroId,
                DataEmprestimo = DateTime.Now,
                Status = "Ativo"
            };

            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();

            return Ok(emprestimo);
        }

        // PUT: api/emprestimos/devolver/5
        [HttpPut("devolver/{id}")]
        public async Task<IActionResult> DevolverEmprestimo(int id)
        {
            var emprestimo = await _context.Emprestimos
                .Include(e => e.Livro)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (emprestimo == null) return NotFound("Empréstimo não encontrado.");

            if (emprestimo.Status == "Devolvido")
            {
                return BadRequest("Este livro já foi devolvido.");
            }

            // Atualiza o status e devolve a cópia para o livro
            emprestimo.Status = "Devolvido";
            emprestimo.DataDevolucao = DateTime.Now;

            if (emprestimo.Livro != null)
            {
                emprestimo.Livro.Copias += 1;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}