using Lanches_Mac.Contexto;
using Lanches_Mac.Models;

namespace Lanches_Mac.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categoria => _context.Categoria;

    }
}
