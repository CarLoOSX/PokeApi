using Pokemons.Pokemons.Domain.Repositories;
using Pokemons.Pokemons.Domain.ValueObject;

namespace Pokemons.Pokemons.Application.UseCase
{
    public class PokemonAddedToFavouritesNotifier
    {
        private PokemonRepository _pokemonRepository;

        public PokemonAddedToFavouritesNotifier(PokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public void Execute(PokemonId pokemonId)
        {
            _pokemonRepository.SaveFavourite(pokemonId);
        }
    }
}