using Domain;

namespace Application;

// Defined in Application, implemented in Infrastructure.
public interface IGreetingRepository
{
    Task<Greeting> GetAsync(CancellationToken cancellationToken = default);
}
