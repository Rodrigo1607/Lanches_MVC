using Lanches_Mac.Models;

namespace Lanches_Mac.ViewModels
{
    public class LancheListViewModel
    {

        public IEnumerable<Lanche> Lanche { get; set; }

        public string CategoriaAtual {  get; set; }

    }
}
