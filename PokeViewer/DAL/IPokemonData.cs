using PokeViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeViewer.DAL
{
    public interface IPokemonData
    {
        List<Pokemon> GetAllPokemons();
        List<FavouritesPokemon> GetAllFavouritesPokemons();
        Pokemon GetPokemon(int id);
        FavouritesPokemon GetFavouritePokemon(int id);
        bool SaveFavouritePokemon(FavouritesPokemon pokemon);
    }
}
