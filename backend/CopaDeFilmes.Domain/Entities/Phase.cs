using CopaDeFilmes.Domain.Interfaces;
using System.Collections.Generic;

namespace CopaDeFilmes.Domain.Entities
{
    public class Phase : IPhase
    {
        public List<IMatch> Matches { get; set; }
        public List<IMovie> Winners { get; set; }

        public Phase(List<IMovie> movies)
        {
            Matches = new List<IMatch>();
            Winners = new List<IMovie>();

            Play(movies);
        }

        public void Play(List<IMovie> movies) 
        {
            for (var index = 0; index < movies.Count; index += 2)
            {
                var match = new Match(movies[index], movies[index + 1]);

                Matches.Add(match);
                Winners.Add(match.Winner);
            }
        }

        public bool HasNextPhase()
        {
            return (Winners.Count >= 2);
        }
    }
}