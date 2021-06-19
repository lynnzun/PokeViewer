using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeViewer.Controllers
{
    public class FavouritesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
