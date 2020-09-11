using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using CopaDeFilmes.Application.Interfaces;

namespace CopaDeFilmes.API.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _moviesService;

        public MoviesController(IMovieService moviesService)
        {
            _moviesService = moviesService;
        }

        /// <summary>
        /// Retorna todos os filmes disponíveis para se disputar um torneio
        /// </summary>
        /// <returns>Retorna todos os filmes em formato json</returns>
        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var movies = await _moviesService.LoadMoviesAsync();

                return Ok(movies);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error fetching the list of movies: {exception.Message}");
            }
        }
    }

}