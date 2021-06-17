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

namespace PokeViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var Pokemons = GetPokemonsFromMemory();
            var Pokemons = GetPokemonsFromAPIAsync().Result;
            return View(Pokemons);
        }

        private object GetPokemonsFromMemory()
        {
            var Pokemons = new List<Pokemon>();
            Pokemons.Add(new Pokemon { PokemonId = 0, Name = "Nazwa", Height = 5, Weight = 10 });
            Pokemons.Add(new Pokemon { PokemonId = 152, Name = "Nowa nazwa", Height = 4, Weight = 12 });
            
            return Pokemons;
        }

        private async Task<object> GetPokemonsFromAPIAsync()
        {
            var Pokemons = new List<Pokemon>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://pokeapi.co/api/v2/pokemon/151")
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var pokemon = new Pokemon();


                pokemon = JsonSerializer.Deserialize<Pokemon>(body);
                Pokemons.Add(pokemon);
            }
            return Pokemons;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
