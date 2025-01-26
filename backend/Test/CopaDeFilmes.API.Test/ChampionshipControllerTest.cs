using CopaDeFilmes.API.Controllers;
using CopaDeFilmes.Application.Services;
using CopaDeFilmes.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace CopaDeFilmes.API.Test
{
    public class ChampionshipControllerTest
    {

        private static readonly List<Movie> movies = new List<Movie>()
        {
            new Movie()
            {
                Id = "tt4154756",
                Year = 2018,
                Rating = 8.8f,
                Title = "Vingadores: Guerra Infinita"
            },

            new Movie()
            {
                Id = "tt3606756",
                Year = 2018,
                Rating = 8.5f,
                Title = "Os Incríveis 2"
            },
            new Movie()
            {
                Id = "tt4881806",
                Year = 2018,
                Rating = 6.7f,
                Title = "Jurassic World: Reino Ameaçado"
            },
            new Movie()
            {
                Id = "tt5164214",
                Year = 2018,
                Rating = 6.3f,
                Title = "Oito Mulheres e um Segredo"
            },
            new Movie()
            {
                Id = "tt7784604",
                Year = 2018,
                Rating = 7.8f,
                Title = "Hereditário"
            },
            new Movie()
            {
                Id = "tt5463162",
                Year = 2018,
                Rating = 8.1f,
                Title = "Deadpool 2"
            },
            new Movie()
            {
                Id = "tt3778644",
                Year = 2018,
                Rating = 7.2f,
                Title = "Han Solo: Uma História Star Wars"
            },
            new Movie()
            {
                Id = "tt3501632",
                Year = 2017,
                Rating = 7.9f,
                Title = "Thor: Ragnarok"
            }
        };

        [Fact]
        public void Post_ShouldReturnOK()
        {
            var championshipController = new ChampionshipController(new ChampionshipService());

            var result = championshipController.Post(movies);

            var okResult = result as OkObjectResult;
            okResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public void Post_ShouldReturnBadRequest()
        {
            var championshipController = new ChampionshipController(new ChampionshipService());

            var emptyMovies = new List<Movie>();

            var result = championshipController.Post(emptyMovies);
            
            var badRequestResult = result as ObjectResult;
            badRequestResult.StatusCode.Should().Be(400);
        }
    }
}
