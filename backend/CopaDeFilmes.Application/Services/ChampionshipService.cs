using System;
using System.Collections.Generic;
using System.Linq;
using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.Exceptions;
using CopaDeFilmes.Domain.Interfaces;
using CopaDeFilmes.Domain.Entities;

namespace CopaDeFilmes.Application.Services
{
    public class ChampionshipService : IChampionshipService
    {
        public IPodium CreateChampionship(IEnumerable<Movie> movies)
        {
            try
            {
                if (movies.Count() > 8)
                    throw new InvalidNumberOfMoviesException();

                var championship = new Championship(movies);

                return championship.Podium;
            }
            catch (InvalidNumberOfMoviesException exception)
            {
                //return StatusCode(StatusCodes.Status400BadRequest, $"Erro ao gerar campeonato: {exception.Message}");
                return null;
            }
            catch (Exception exception)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao gerar campeonato: {exception.Message}");
                return null;
            }
        }
    }
}
