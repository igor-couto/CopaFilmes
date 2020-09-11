using CopaDeFilmes.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaDeFilmes.API.Controllers
{
    public interface IMoviesService
    {
        public Task<IEnumerable<IMovie>> LoadMoviesAsync();
    }
}