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
            //PokeViewerContext db = new PokeViewerContext();
            pokemons = db.Pokemons.ToList();

            return pokemons;
        }
        public Pokemon GetPokemonFromDB(int id)
        {
            var pokemon = new Pokemon();
            //PokeViewerContext db = new PokeViewerContext();
            pokemon = db.Pokemons.Find(id);

            return pokemon;
        }


    }
}
