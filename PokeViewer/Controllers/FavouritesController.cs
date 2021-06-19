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
        private DatabaseConnections dbCon = new DatabaseConnections();
        public IActionResult Index(int? pokemonId)
        {
            var pokemon = new Pokemon();
            if (pokemonId != null)
            {
                pokemon = dbCon.GetPokemonFromDB(pokemonId.Value);
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
                FavouritePokemon = dbCon.GetPokemonFromDB(pokemonId)
            };
            if(petPokemon != null)
            {
                dbCon.SaveFavouritePokemonToDB(petPokemon);
            }
            
            return Redirect("FavouritesPokemon");
        }

        public IActionResult FavouritesPokemon(string searchQuery = null)
        {
            var favouritesPokemons = new List<FavouritesPokemon>();

            if (searchQuery != null)
            {
                favouritesPokemons = dbCon.GetPokemonsFromFavouriteDB().Where(p => p.FavouritePokemon.Name.Contains(searchQuery) || p.FavouritePokemon.PokemonId.ToString().Equals(searchQuery)).ToList();
            }
            else
            {
                favouritesPokemons = dbCon.GetPokemonsFromFavouriteDB();
            }

                return View(favouritesPokemons);
        }
    }
}