using Application;
using Domain;

namespace Infrastructure;

// Stand-in for a real database; replace later without touching other layers.
internal sealed class InMemoryGreetingRepository : IGreetingRepository
{
    public Task<Greeting> GetAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(new Greeting("Hello from the Infrastructure layer"));
}
