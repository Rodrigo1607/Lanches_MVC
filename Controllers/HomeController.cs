using Lanches_Mac.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lanches_Mac.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            
            return View();
        }

       

    }
}
