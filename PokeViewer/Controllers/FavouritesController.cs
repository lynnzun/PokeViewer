using Microsoft.AspNetCore.Mvc;
using PokeViewer.DAL;
using PokeViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeViewer.Controllers
{
    public class FavouritesController : Controller
    {
        private readonly IPokemonData _pokemonData;
        public FavouritesController(IPokemonData pokemonData)
        {
            _pokemonData = pokemonData;
        }
        public IActionResult Index(int? pokemonId)
        {
            var pokemon = new Pokemon();
            if (pokemonId != null)
            {
                pokemon = _pokemonData.GetPokemon(pokemonId.Value);
                return View(pokemon);
            }
            else
            {
                return View(pokemon);
            }

            return Redirect(Url.Action("Error","Home"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFavourite(string ownerName, string personalName, int pokemonId)
        {
            var petPokemon = new FavouritesPokemon
            {
                Owner = ownerName,
                PersonalName = personalName,
                PokemonId = pokemonId,
                FavouritePokemon = _pokemonData.GetPokemon(pokemonId)
            };
            if(petPokemon != null)
            {
                _pokemonData.SaveFavouritePokemon(petPokemon);
            }
            
            return Redirect("FavouritesPokemon");
        }

        public IActionResult FavouritesPokemon(string searchQuery = null)
        {
            var favouritesPokemons = new List<FavouritesPokemon>();

            if (searchQuery != null)
            {
                favouritesPokemons = _pokemonData.GetAllFavouritesPokemons().Where(p => p.FavouritePokemon.Name.Contains(searchQuery) || p.FavouritePokemon.PokemonId.ToString().Equals(searchQuery)).ToList();
            }
            else
            {
                favouritesPokemons = _pokemonData.GetAllFavouritesPokemons();
            }

                return View(favouritesPokemons);
        }
    }
}