using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeViewer.Models
{
    public class FavouritesPokemon : Pokemon
    {
        public string Owner { get; set; }
        public string PersonalName { get; set; }

    }
}
