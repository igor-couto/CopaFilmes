using CopaDeFilmes.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaDeFilmes.Application.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> LoadMoviesAsync();
    }
}