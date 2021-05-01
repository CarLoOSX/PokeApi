﻿using System;

namespace Users.Users.Domain.Exceptions
{
    public class PokemonFavoriteIsEmptyException : Exception
    {
        public override string Message
            => $"You must enter the id of the pokemon";
    }
}