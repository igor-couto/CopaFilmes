namespace CopaDeFilmes.Domain.Interfaces
{
    public interface IChampionship
    {
        IMovie Winner { get; set; }
        void SetPositions();
        void SortMovies();
    }
}