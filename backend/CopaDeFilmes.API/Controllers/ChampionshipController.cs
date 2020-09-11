using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using CopaDeFilmes.Application.Services;
using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Application.Interfaces;

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

        [HttpPost()]
        public IActionResult Post([FromBody] IEnumerable<Movie> movies)
        {
            var podium = _championshipService.CreateChampionship(movies);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Serialize(podium.Finalists, options);

            return Ok(result);
        }
    }
}