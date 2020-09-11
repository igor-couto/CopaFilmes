using CopaDeFilmes.API.Controllers;
using CopaDeFilmes.Application.Services;
using CopaDeFilmes.Domain.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CopaDeFilmes.API.Test
{
    public class MoviesControllerTest
    {
        [Fact]
        public async Task GetAsync_ShouldReturnMovies()
        {
            var moviesController = new MoviesController(new MovieService());

            var getResult = await moviesController.GetAsync();
            var result = getResult as OkObjectResult;
            var movies = result.Value as IEnumerable<IMovie>;

            Assert.IsAssignableFrom<IActionResult>(getResult);

            movies.Count().Should().Be(16);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnMoviesNotEmpty()
        {
            var moviesController = new MoviesController(new MovieService());

            var getResult = await moviesController.GetAsync();
            var result = getResult as OkObjectResult;
            var movies = result.Value as IEnumerable<IMovie>;


            Assert.IsAssignableFrom<IActionResult>(getResult);

            movies.Any(movie => string.IsNullOrEmpty(movie.Id)).Should().BeFalse();
        }

        [Fact]
        public async Task GetAsync_ShouldReturnMoviesWithUniqueIds()
        {
            var moviesController = new MoviesController(new MovieService());

            var getResult = await moviesController.GetAsync();
            var result = getResult as OkObjectResult;
            var movies = result.Value as IEnumerable<IMovie>;


            Assert.IsAssignableFrom<IActionResult>(getResult);

            var duplicates = movies.GroupBy(x => x.Id).Where(grp => grp.Count() > 1).Sum(grp => grp.Count());

            duplicates.Should().Be(0);
        }
    }
}
