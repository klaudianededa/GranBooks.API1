using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GranBooks.API.Data;
using GranBooks.API.Models;

namespace GranBooks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LivrosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/livros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            return await _context.Livros.ToListAsync();
        }
    }
}