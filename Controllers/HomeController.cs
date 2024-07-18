using Lanches_Mac.Models;
using Lanches_Mac.Repositories;
using Lanches_Mac.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lanches_Mac.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public HomeController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lancheRepository.LanchePreferido
            };
            return View(homeViewModel);
        }

       

    }
}
