using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Xunit;
using Moq;
using CopaDeFilmes.API.Controllers;
using CopaDeFilmes.Domain.Interfaces;
using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Application.Interfaces;

namespace CopaDeFilmes.API.Test
{
    public class MoviesControllerTest
    {
        private readonly Mock<IMovieService> _mockMovieService;
        private readonly MoviesController _moviesController;
        private readonly List<Movie> _movies;

        public MoviesControllerTest()
        {
            _mockMovieService = new Mock<IMovieService>();
            _moviesController = new MoviesController(_mockMovieService.Object);
            _movies = new List<Movie>
            {
                new Movie { Id = "32f65e0d-a64a-4c76-8731-4c0934f0ca87", Titulo = "Deadpool 2", Ano = 2018, Nota = 8.2f },
                new Movie { Id = "77121f67-53b0-4b02-a80a-2bb34950e61b", Titulo = "Han Solo: Uma História Star Wars", Ano = 2018, Nota = 6.3f },
                new Movie { Id = "b612f92a-a198-4eba-b173-cfd4191611a0", Titulo = "Hereditário", Ano = 2018, Nota = 7.1f },
                new Movie { Id = "e88bccd8-1c3c-4ceb-a335-6026d57f6a09", Titulo = "Jurassic World: Reino Ameaçado", Ano = 2018, Nota = 4.8f },
                new Movie { Id = "f64417b0-af3c-4a17-b69c-d6786f632ea9", Titulo = "Oito Mulheres e um Segredo", Ano = 2018, Nota = 7.7f }
            };
        }

        [Fact]
        public async Task GetAsync_ShouldReturnOkResult_WithExpectedMovies()
        {
            // Arrange
            _mockMovieService
                .Setup(service => service.LoadMoviesAsync())
                .ReturnsAsync(_movies);

            // Act
            var result = await _moviesController.GetAsync();

            // Assert
            result.Should().BeOfType<OkObjectResult>()
                .Which.StatusCode.Should().Be(200);

            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();

            var returnedMovies = okResult.Value as IEnumerable<IMovie>;
            returnedMovies.Should().NotBeNull();
            returnedMovies.Should().HaveCount(_movies.Count);
            returnedMovies.Should().BeEquivalentTo(_movies);

            returnedMovies.Should().OnlyContain(movie => !string.IsNullOrEmpty(movie.Id));
            returnedMovies.GroupBy(m => m.Id).Should().OnlyContain(group => group.Count() == 1);

            _mockMovieService.Verify(service => service.LoadMoviesAsync(), Times.Once);
        }
    }
}
