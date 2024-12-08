using System.Text.Json;

namespace InterfacesEverywhere.Services;

// Production implementation hitting a real external API
public interface IMovieProvider
{
    Task<Movie> GetMovieAsync(string movieId);
}

public class FakeMovieProvider : IMovieProvider
{
    public Task<Movie> GetMovieAsync(string movieId)
    {
        return Task.FromResult(new Movie
        {
            Id = movieId,
            Title = "Fake Movie",
            Year = 2000
        });
    }
}

public class ExternalApiMovieProvider : IMovieProvider
{
    private readonly HttpClient _httpClient;

    public ExternalApiMovieProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Movie> GetMovieAsync(string movieId)
    {
        // Call external service
        var jsonData = await _httpClient.GetStringAsync($"https://api.example.com/movies/{movieId}");

        return JsonSerializer.Deserialize<Movie>(jsonData)!;
    }
}