using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokeViewer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PokeViewer.DAL;

namespace PokeViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokemonData _pokemonData;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IPokemonData pokemonData)
        {
            _logger = logger;
            _pokemonData = pokemonData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Pokemons(string searchQuery = null)
        {
            var pokemons = new List<Pokemon>();

            if (searchQuery != null)
            {
                pokemons = _pokemonData.GetAllPokemons().Where(p => p.Name.Contains(searchQuery) || p.PokemonId.ToString().Equals(searchQuery)).ToList();

                return View(pokemons);
            }
            else
            {
                pokemons = _pokemonData.GetAllPokemons();
            }

            return View(pokemons);
        }

        public IActionResult PokemonDetails(int? id)
        {
            var pokemon = _pokemonData.GetPokemon(id.Value); // nullable int to int conversion

            return View(pokemon);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
