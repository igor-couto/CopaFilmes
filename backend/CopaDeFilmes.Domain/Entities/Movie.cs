using CopaDeFilmes.Domain.Interfaces;

namespace CopaDeFilmes.Domain.Entities
{
    public class Movie : IMovie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public float Rating { get; set; }

        public bool IsBetterThan(IMovie other)
        {
            if (Rating == other.Rating)
                return ResolveTie(other);

            return (Rating > other.Rating);
        }

        public bool ResolveTie(IMovie other)
        {
            return string.CompareOrdinal(Title.ToLower(), other.Title.ToLower()) < 0;
        }
    }
}
