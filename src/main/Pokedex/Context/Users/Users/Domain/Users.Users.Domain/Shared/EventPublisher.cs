using System.Collections.Generic;

namespace Users.Users.Domain.Shared
{
    public interface EventPublisher
    {
        void Publish(DomainEvent dEvent);

        void Publish(IList<DomainEvent> dEvents);
    }
}