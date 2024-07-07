using Lanches_Mac.Models;

namespace Lanches_Mac.Repositories
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categoria { get; }
    }
}
