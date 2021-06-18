using PokeViewer.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeViewer.Models
{
    public class Pokemon
    {
        [JsonPropertyName("id")]
        public int PokemonId { get; set; }

        [JsonPropertyName("name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("sprites")]
        [NotMapped]
        public Sprites Sprites { get; set; }
    }
}
