namespace Users.Users.Domain.Shared
{
    public class PokemonFavouriteAddedDomainEvent : DomainEvent
    {
        public PokemonFavouriteAddedDomainEvent(string message) : base(message)
        {
        }
    }
}