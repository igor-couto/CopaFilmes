using CopaDeFilmes.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CopaDeFilmes.Domain.Entities
{
    public class Championship : IChampionship
    {
        private IEnumerable<IMovie> Movies;

        public IPodium Podium;

        public IMovie Winner { get; set; }

        public Championship(IEnumerable<IMovie> movies)
        {
            Movies = movies;

            SortMovies();

            SetPositions();

            Play();
        }

        public void SortMovies()
        {
            Movies = Movies.OrderBy(movie => movie.Title);
        }

        public void SetPositions()
        {
            var lastIndex = Movies.Count() - 1;

            var orderedMoviesList = new List<IMovie>();

            for (var index = 0; index <= lastIndex / 2; index++)
            {
                orderedMoviesList.Add(Movies.ElementAt(index));
                orderedMoviesList.Add(Movies.ElementAt(lastIndex - index));
            }

            Movies = orderedMoviesList;
        }

        private void Play() 
        {
            Phase lastPlayedPhase;
            var competingMovies = Movies.ToList();

            do
            {
                lastPlayedPhase = new Phase(competingMovies);
                competingMovies = lastPlayedPhase.Winners;
            }
            while (lastPlayedPhase.HasNextPhase());

            var winner = lastPlayedPhase.Matches.First().Winner;
            var secondPlace = lastPlayedPhase.Matches.First().Loser;

            //Podium = new Podium
            //{
            //    Winner = lastPlayedPhase.Matches.First().Winner,
            //    SecondPlace = lastPlayedPhase.Matches.First().Loser
            //};

            Podium = new Podium();
            Podium.Finalists.Add(winner);
            Podium.Finalists.Add(secondPlace);


        }
    }
}
