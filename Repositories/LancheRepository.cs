using Lanches_Mac.Contexto;
using Lanches_Mac.Models;
using Microsoft.EntityFrameworkCore;

namespace Lanches_Mac.Repositories
{
    public class LancheRepository : ILancheRepository
    {

        public readonly AppDbContext _context;

        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Lanche> Lanche => _context.Lanche.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchePreferido => _context.Lanche.
                                                                Where(l => l.ISLanchePreferido)
                                                                .Include(c => c.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanche.FirstOrDefault(l => l.LancheId == lancheId);
        }
    }
}
