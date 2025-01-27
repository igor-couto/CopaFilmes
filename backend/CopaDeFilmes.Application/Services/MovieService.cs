using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Domain.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CopaDeFilmes.Application.Services
{
    public class MovieService : IMovieService
    {
        // private const string URL = "http://copafilmes.azurewebsites.net/api/filmes";
        private const string URL = "https://movies-api.com/api/movies";

        public async Task<IEnumerable<Movie>> LoadMoviesAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(URL);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return JsonSerializer.Deserialize<IEnumerable<Movie>>(response.Content.ReadAsStringAsync().Result, options);
        }
    }
}
