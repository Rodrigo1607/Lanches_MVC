using Lanches_Mac.Models;

namespace Lanches_Mac.Repositories
{
    public interface ILancheRepository
    {

        IEnumerable<Lanche> Lanche {  get; }
        IEnumerable<Lanche> LanchePreferido { get; }
        Lanche GetLancheById(int lancheId);
    }
}
