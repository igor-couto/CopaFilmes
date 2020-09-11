namespace CopaDeFilmes.Domain.Interfaces
{
    public interface IMovie
    {
        string Id { get; set; }
        int Ano { get; set; }
        float Nota { get; set; }
        string Titulo { get; set; }

        bool IsBetterThan(IMovie other);
        bool ResolveTie(IMovie other);
    }
}