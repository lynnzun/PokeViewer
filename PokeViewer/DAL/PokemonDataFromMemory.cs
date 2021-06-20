using PokeViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeViewer.DAL
{
    public class PokemonDataFromMemory : IPokemonData
    {
        public List<FavouritesPokemon> GetAllFavouritesPokemons()
        {
            throw new NotImplementedException();
        }

        public List<Pokemon> GetAllPokemons()
        {
            var pokemons = new List<Pokemon>();
            pokemons.Add(new Pokemon { PokemonId = 0, Name = "Nazwa", Height = 5, Weight = 10 });
            pokemons.Add(new Pokemon { PokemonId = 152, Name = "Nowa nazwa", Height = 4, Weight = 12 });

            return pokemons;
        }

        public FavouritesPokemon GetFavouritePokemon(int id)
        {
            throw new NotImplementedException();
        }

        public Pokemon GetPokemon(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveFavouritePokemon(FavouritesPokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}