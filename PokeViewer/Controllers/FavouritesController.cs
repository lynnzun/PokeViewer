using Microsoft.AspNetCore.Mvc;
using PokeViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeViewer.Controllers
{
    public class FavouritesController : Controller
    {
        public IActionResult Index(int? pokemonId)
        {
            var pokemon = new Pokemon();
            if (pokemonId != null)
            {
                pokemon = DatabaseConnections.GetPokemonFromDB(pokemonId.Value);
                return View(pokemon);
            }
            else
            {
                return View(pokemon);
            }

            return Redirect(Url.Action("Error","Home"));
        }

        public Pokemon AddFavourite(int id)
        {
            var pokemon = new Pokemon();
            return pokemon;
        }
    }
}
