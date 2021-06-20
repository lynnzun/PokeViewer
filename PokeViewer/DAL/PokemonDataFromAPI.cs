using PokeViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokeViewer.DAL
{
    public class PokemonDataFromAPI : IPokemonData
    {
        public List<FavouritesPokemon> GetAllFavouritesPokemons()
        {
            throw new NotImplementedException();
        }

        public List<Pokemon> GetAllPokemons()
        {
            var pokemons = new List<Pokemon>();
            for (int i = 1; i <= 151; i++)
            {
                pokemons.Add(GetPokemon(i));
            }

            return pokemons;
        }

        public FavouritesPokemon GetFavouritePokemon(int id)
        {
            throw new NotImplementedException();
        }

        public Pokemon GetPokemon(int id)
        {
            var pokemon = new Pokemon();
            pokemon = GetPokemonFromAPIAsync(id).Result;

            return pokemon;
        }

        public bool SaveFavouritePokemon(FavouritesPokemon pokemon)
        {
            throw new NotImplementedException();
        }

        private async Task<Pokemon> GetPokemonFromAPIAsync(int id)
        {
            var pokemon = new Pokemon();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://pokeapi.co/api/v2/pokemon/" + id.ToString())
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                pokemon = JsonSerializer.Deserialize<Pokemon>(body);
            }

            return pokemon;
        }
    }
}