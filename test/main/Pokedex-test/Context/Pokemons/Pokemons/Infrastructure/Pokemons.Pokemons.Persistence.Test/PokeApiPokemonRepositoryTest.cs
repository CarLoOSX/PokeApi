using Pokemons.Pokemons.Domain.Aggregate;
using Pokemons.Pokemons.Domain.Test.Aggregate;
using Pokemons.Pokemons.Domain.Test.ValueObject;
using Pokemons.Pokemons.Domain.ValueObject;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Pokemons.Pokemons.Persistence.Test
{
    public class PokeApiPokemonRepositoryTest
    {
        private readonly IMemoryCache memoryCache;

        public PokeApiPokemonRepositoryTest()
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();
            var serviceProvider = services.BuildServiceProvider();

            memoryCache = serviceProvider.GetService<IMemoryCache>();
        }


        [Fact]
        public async Task Search_Found_ReturnsPokemonDetail()
        {
            #region Arrange

            PokeApiPokemonRepository pokemonRepository = new PokeApiPokemonRepository(memoryCache);
            PokemonId pokemonId = new PokemonId(PokemonIdMother.Id());

            #endregion

            #region Act

            Pokemon pokemon = await pokemonRepository.Find(pokemonId);

            #endregion

            #region Assert

            var typesArray = pokemon.PokemonTypes.Types.Select(s => s.Type).ToArray();

            Assert.Equal(pokemon.PokemonId.Id, PokemonMother.Pokemon().PokemonId.Id);
            Assert.Equal(pokemon.PokemonName.Name, PokemonMother.Pokemon().PokemonName.Name);
            Assert.Equal(typesArray, PokemonMother.Pokemon().PokemonTypes.Types.Select(s => s.Type).ToArray(),
                StringComparer.InvariantCultureIgnoreCase);

            #endregion
        }

        [Fact]
        public async Task ExistsUser_ReturnsBool()
        {
            #region Arrange

            PokeApiPokemonRepository pokemonRepository = new PokeApiPokemonRepository(memoryCache);
            PokemonId pokemonId = new PokemonId(PokemonIdMother.Id());

            #endregion

            #region Act

            bool exists = await pokemonRepository.Exists(pokemonId);

            #endregion

            #region Assert

            Assert.True(exists);

            #endregion
        }

        [Fact]
        public async Task Search_NotFound_ReturnsNull()
        {
            #region Arrange

            PokeApiPokemonRepository pokemonRepository = new PokeApiPokemonRepository(memoryCache);
            PokemonId pokemonId = new PokemonId(PokemonIdMother.IdUnknown());

            #endregion

            #region Act

            Pokemon pokemon = await pokemonRepository.Find(pokemonId);

            #endregion

            #region Assert

            Assert.Null(pokemon);

            #endregion
        }
    }
}