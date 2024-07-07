using Lanches_Mac.Repositories;
using Lanches_Mac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lanches_Mac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            this._lancheRepository = lancheRepository;
        }

        public IActionResult List()
        {
            //    var lanche = _lancheRepository.Lanche;
            //    return View(lanche);

            var lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.Lanche = _lancheRepository.Lanche;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual";


            return View(lanchesListViewModel);
        }
    }
}
