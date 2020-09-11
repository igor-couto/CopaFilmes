using CopaDeFilmes.API.Controllers;
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
            var controller = new MoviesController();

            var getResult = await controller.GetAsync();
            var result = getResult as OkObjectResult;
            var movies = result.Value as IEnumerable<IMovie>;

            Assert.IsAssignableFrom<IActionResult>(getResult);

            movies.Count().Should().Be(16);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnMoviesNotEmpty()
        {
            var controller = new MoviesController();

            var getResult = await controller.GetAsync();
            var result = getResult as OkObjectResult;
            var movies = result.Value as IEnumerable<IMovie>;


            Assert.IsAssignableFrom<IActionResult>(getResult);

            movies.Any(movie => string.IsNullOrEmpty(movie.Id)).Should().BeFalse();
        }

        [Fact]
        public async Task GetAsync_ShouldReturnMoviesWithUniqueIds()
        {
            var controller = new MoviesController();

            var getResult = await controller.GetAsync();
            var result = getResult as OkObjectResult;
            var movies = result.Value as IEnumerable<IMovie>;


            Assert.IsAssignableFrom<IActionResult>(getResult);

            var duplicates = movies.GroupBy(x => x.Id).Where(grp => grp.Count() > 1).Sum(grp => grp.Count());

            duplicates.Should().Be(0);
        }
    }
}
