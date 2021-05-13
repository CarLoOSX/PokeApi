namespace Users.Users.Domain.Shared
{
    public class DomainEvent
    {
        public readonly string Message;

        public DomainEvent(string message)
        {
            Message = message;
        }
    }
}