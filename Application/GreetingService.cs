namespace Application;

public sealed class GreetingService(IGreetingRepository repository)
{
    public async Task<string> GetGreetingAsync(string? name, CancellationToken cancellationToken = default)
    {
        var greeting = await repository.GetAsync(cancellationToken);

        return string.IsNullOrWhiteSpace(name)
            ? greeting.Message
            : $"{greeting.Message}, {name.Trim()}!";
    }
}
