namespace CopaDeFilmes.Domain.Interfaces
{
    public interface IMovie
    {
        string Id { get; set; }
        int Year { get; set; }
        float Rating { get; set; }
        string Title { get; set; }

        bool IsBetterThan(IMovie other);
        bool ResolveTie(IMovie other);
    }
}