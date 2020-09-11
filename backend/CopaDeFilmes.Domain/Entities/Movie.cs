using CopaDeFilmes.Domain.Interfaces;

namespace CopaDeFilmes.Domain.Entities
{
    public class Movie : IMovie
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public float Nota { get; set; }

        public bool IsBetterThan(IMovie other)
        {
            if (Nota == other.Nota)
                return ResolveTie(other);

            return (Nota > other.Nota);
        }

        public bool ResolveTie(IMovie other)
        {
            return string.CompareOrdinal(Titulo.ToLower(), other.Titulo.ToLower()) < 0;
        }
    }
}
