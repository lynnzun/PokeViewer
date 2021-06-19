using PokeViewer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PokeViewer.DAL
{
    public class PokeViewerContext : DbContext
    {
        public PokeViewerContext() : base("PokeViewerConnectionString")
        {

        }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<FavouritesPokemon> FavouritesPokemons { get; set; }
}
}
