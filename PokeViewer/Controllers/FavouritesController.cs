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

        public FavouritesPokemon AddFavourite(string ownerName, string personalName, int pokemonId)
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
            
            return petPokemon;
        }
    }
}
