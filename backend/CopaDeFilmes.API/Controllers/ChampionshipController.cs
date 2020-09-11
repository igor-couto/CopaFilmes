using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System;

namespace CopaDeFilmes.API.Controllers
{
    [ApiController]
    [Route("championship")]
    public class ChampionshipController : Controller
    {
        private readonly IChampionshipService _championshipService;

        public ChampionshipController(IChampionshipService championshipService) 
        {
            _championshipService = championshipService;
        }

        /// <summary>
        /// Inicia um novo torneio
        /// </summary>
        /// <param name="movies">Filmes escolhidos para participar do torneio</param>
        /// <returns>Retorna os vencedores do torneio</returns>
        [HttpPost()]
        public IActionResult Post([FromBody] IEnumerable<Movie> movies)
        {
            try 
            {
                var podium = _championshipService.CreateChampionship(movies);

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var result = JsonSerializer.Serialize(podium.Finalists, options);

                return Ok(result);
            }
            catch (InvalidNumberOfMoviesException exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Error generating championship: {exception.Message}");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error generating championship: {exception.Message}");
            }

        }
    }
}