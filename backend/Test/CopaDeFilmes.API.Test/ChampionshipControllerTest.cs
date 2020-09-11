using CopaDeFilmes.API.Controllers;
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
                Ano = 2018,
                Nota = 8.8f,
                Titulo = "Vingadores: Guerra Infinita"
            },

            new Movie()
            {
                Id = "tt3606756",
                Ano = 2018,
                Nota = 8.5f,
                Titulo = "Os Incríveis 2"
            },
            new Movie()
            {
                Id = "tt4881806",
                Ano = 2018,
                Nota = 6.7f,
                Titulo = "Jurassic World: Reino Ameaçado"
            },
            new Movie()
            {
                Id = "tt5164214",
                Ano = 2018,
                Nota = 6.3f,
                Titulo = "Oito Mulheres e um Segredo"
            },
            new Movie()
            {
                Id = "tt7784604",
                Ano = 2018,
                Nota = 7.8f,
                Titulo = "Hereditário"
            },
            new Movie()
            {
                Id = "tt5463162",
                Ano = 2018,
                Nota = 8.1f,
                Titulo = "Deadpool 2"
            },
            new Movie()
            {
                Id = "tt3778644",
                Ano = 2018,
                Nota = 7.2f,
                Titulo = "Han Solo: Uma História Star Wars"
            },
            new Movie()
            {
                Id = "tt3501632",
                Ano = 2017,
                Nota = 7.9f,
                Titulo = "Thor: Ragnarok"
            }
        };

        [Fact]
        public void Post_ShouldReturnOK()
        {
            var championshipController = new ChampionshipController();

            var result = championshipController.Post(movies);

            var okResult = result as OkObjectResult;
            okResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public void Post_ShouldReturnBadRequest()
        {
            var championshipController = new ChampionshipController();

            var emptyMovies = new List<Movie>();

            var result = championshipController.Post(emptyMovies);

            var okResult = result as OkObjectResult;
            okResult.StatusCode.Should().Be(400);
        }
    }
}
