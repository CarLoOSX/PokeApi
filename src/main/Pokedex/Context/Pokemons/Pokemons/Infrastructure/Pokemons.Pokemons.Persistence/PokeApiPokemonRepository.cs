using Newtonsoft.Json.Linq;
using Pokemons.Pokemons.Domain.Aggregate;
using Pokemons.Pokemons.Domain.Exceptions;
using Pokemons.Pokemons.Domain.Repositories;
using Pokemons.Pokemons.Domain.ValueObject;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Pokemons.Pokemons.Persistence
{
    public class PokeApiPokemonRepository : PokemonRepository
    {
        private const string ApiUrl = "https://pokeapi.co/api/v2/";
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private const string CacheKeyPrefix = "pokemon/";

        public PokeApiPokemonRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _httpClient = new HttpClient();
        }

        public async Task<bool> Exists(PokemonId pokemonId)
        {
            return await Find(pokemonId) != null;
        }

        public async Task<Pokemon> Find(PokemonId pokemonId)
        {
            var json = await Request(ApiUrl + $"pokemon/{pokemonId.Id}");

            if (json == null) return null;

            var cacheKey = GetCacheKey(pokemonId.Id.ToString());

            _memoryCache.TryGetValue(cacheKey, out Pokemon pokemonInMemory);

            return new Pokemon(
                new PokemonId(int.Parse(json["id"].ToString())),
                new PokemonName(json["name"].ToString()),
                new PokemonTypes(json["types"].Values("type").Select(x => new PokemonType(x["name"].ToString()))
                    .ToList()), new PokemonFavouriteCount(pokemonInMemory?.PokemonFavouriteCount.Count ?? 0)
            );
        }

        public async Task SaveFavourite(PokemonId pokemonId)
        {
            var cacheKey = GetCacheKey(pokemonId.Id.ToString());

            var pokemon = await Find(pokemonId);

            pokemon.PokemonFavouriteCount.Count++;

            _memoryCache.Set(cacheKey, pokemon);
        }

        private string GetCacheKey(string key)
        {
            return CacheKeyPrefix + key;
        }

        private async Task<JObject> Request(string url)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using (var response = await _httpClient
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                    .ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode == false)
                    {
                        var message = await response.Content.ReadAsStringAsync();

                        if ((int) response.StatusCode == 404)
                        {
                            return null;
                        }

                        throw new Exception(message);
                    }

                    var stream = await response.Content.ReadAsStreamAsync();

                    StreamReader reader = new StreamReader(stream);
                    return JObject.Parse(reader.ReadToEnd());
                }
            }
            catch (Exception)
            {
                throw new PokeApiRepositoryException();
            }
        }
    }
}