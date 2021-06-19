using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PokeViewer.Models
{
    public class FavouritesPokemon
    {
        [Key]
        public int id { get; set; }
        [MaxLength(50)]
        public string Owner { get; set; }
        [MaxLength(50)]
        public string PersonalName { get; set; }
        public int PokemonId { get; set; }
        [NotMapped]
        public Pokemon FavouritePokemon { get; set; }

    }
}
