namespace CopaDeFilmes.Domain.Interfaces
{
    public interface IMatch
    {
        IMovie Winner { get; }
        IMovie Loser { get; }

        void PlayMatch(IMovie movieA, IMovie movieB);
    }
}