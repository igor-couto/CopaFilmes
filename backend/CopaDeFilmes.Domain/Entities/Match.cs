using CopaDeFilmes.Domain.Interfaces;

namespace CopaDeFilmes.Domain.Entities
{
    class Match : IMatch
    {
        public IMovie Winner { get; private set; }
        public IMovie Loser { get; private set; }

        public Match(IMovie movieA, IMovie movieB)
        {
            PlayMatch(movieA, movieB);
        }

        public void PlayMatch(IMovie movieA, IMovie movieB) 
        {
            if (movieA.IsBetterThan(movieB))
            {
                Winner = movieA;
                Loser = movieB;
            }
            else
            {
                Winner = movieB;
                Loser = movieA;
            }
        }
    }
}