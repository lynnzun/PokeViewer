using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokeViewer.DAL;

namespace PokeViewer.Models
{
    public class DatabaseConnections
    {
        PokeViewerContext db = new PokeViewerContext();

        public List<Pokemon> GetPokemonsFromDB()
        {
            var pokemons = new List<Pokemon>();
            pokemons = db.Pokemons.ToList();

            return pokemons;
        }
        public Pokemon GetPokemonFromDB(int id)
        {
            var pokemon = new Pokemon();
            pokemon = db.Pokemons.Find(id);

            return pokemon;
        }
        public List<FavouritesPokemon> GetPokemonsFromFavouriteDB()
        {
            var pokemons = new List<FavouritesPokemon>();
            pokemons = db.FavouritesPokemons.ToList();
            foreach (var pokemon in pokemons)
            {
                pokemon.FavouritePokemon = GetPokemonFromDB(pokemon.PokemonId);
            }

            return pokemons;
        }
        public bool SaveFavouritePokemonToDB(FavouritesPokemon pokemon)
        {
            try
            {
                db.FavouritesPokemons.Add(pokemon);
                db.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }
    }
}
