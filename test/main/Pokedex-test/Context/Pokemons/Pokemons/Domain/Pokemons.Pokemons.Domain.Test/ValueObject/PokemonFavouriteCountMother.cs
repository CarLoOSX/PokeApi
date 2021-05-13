using System;
using System.Linq;

namespace Pokemons.Pokemons.Domain.Test.ValueObject
{
    public class PokemonFavouriteCountMother
    {
        private static int _count = 6;

        public static int Count()
        {
            return _count;
        }

    }
}
