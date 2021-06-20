using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokeViewer.DAL;

namespace PokeViewer.Models
{
    public class PokemonDataFromDatabase : IPokemonData
    {
        PokeViewerContext db = new PokeViewerContext();

        public List<Pokemon> GetAllPokemons()
        {
            var pokemons = new List<Pokemon>();
            pokemons = db.Pokemons.ToList();

            return pokemons;
        }

        public List<FavouritesPokemon> GetAllFavouritesPokemons()
        {
            var pokemons = new List<FavouritesPokemon>();
            pokemons = db.FavouritesPokemons.ToList();
            foreach (var pokemon in pokemons)
            {
                pokemon.FavouritePokemon = GetPokemon(pokemon.PokemonId);
            }

            return pokemons;
        }

        public Pokemon GetPokemon(int id)
        {
            var pokemon = new Pokemon();
            pokemon = db.Pokemons.Find(id);

            return pokemon;
        }

        public FavouritesPokemon GetFavouritePokemon(int id)
        {
            var favouritePokemon = new FavouritesPokemon();
            favouritePokemon = db.FavouritesPokemons.Find(id);

            return favouritePokemon;
        }

        public bool SaveFavouritePokemon(FavouritesPokemon pokemon)
        {
            try
            {
                db.FavouritesPokemons.Add(pokemon);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public bool RemoveFavouritePokemon(FavouritesPokemon pokemon)
        {
            try
            {
                db.FavouritesPokemons.Remove(pokemon);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
