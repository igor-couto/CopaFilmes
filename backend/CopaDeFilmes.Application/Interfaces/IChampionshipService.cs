using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Domain.Interfaces;
using System.Collections.Generic;

namespace CopaDeFilmes.Application.Interfaces
{
    public interface IChampionshipService
    {
        IPodium CreateChampionship(IEnumerable<Movie> movies);
    }
}