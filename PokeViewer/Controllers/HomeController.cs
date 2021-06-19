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
        private DatabaseConnections dbCon = new DatabaseConnections();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private object GetPokemonsFromMemory()
        {
            var Pokemons = new List<Pokemon>();
            Pokemons.Add(new Pokemon { PokemonId = 0, Name = "Nazwa", Height = 5, Weight = 10 });
            Pokemons.Add(new Pokemon { PokemonId = 152, Name = "Nowa nazwa", Height = 4, Weight = 12 });

            return Pokemons;
        }

        private async Task<Pokemon> GetPokemonsFromAPIAsync(int id)
        {
            var pokemon = new Pokemon();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://pokeapi.co/api/v2/pokemon/" + id.ToString())
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                pokemon = JsonSerializer.Deserialize<Pokemon>(body);
            }

            // Save to DB part

/*          PokeViewerContext db = new PokeViewerContext();
            db.Pokemons.Add(pokemon);
            db.SaveChanges();*/

            return pokemon;
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
                pokemons = dbCon.GetPokemonsFromDB().Where(p => p.Name.Contains(searchQuery) || p.PokemonId.ToString().Equals(searchQuery)).ToList();

                return View(pokemons);
            }
            else
            {
                pokemons = dbCon.GetPokemonsFromDB();
            }

            //var Pokemons = GetPokemonsFromMemory();

            return View(pokemons);
        }

        public IActionResult PokemonDetails(int? id)
        {
            //var Pokemon = GetPokemonsFromAPIAsync(id.Value).Result; // nullable int to int conversion
            var pokemon = dbCon.GetPokemonFromDB(id.Value); // nullable int to int conversion

            return View(pokemon);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
