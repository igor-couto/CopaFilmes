using CopaDeFilmes.Domain.Entities;
using Xunit;

namespace CopaDeFilmes.Domain.Test
{
    public class MovieTests
    {
        [Theory]
        [InlineData(10.0f, 3.0f, true)]
        [InlineData(3.0f, 10.0f, false)]
        [InlineData(10.0f, 0.0f, true)]
        [InlineData(0.0f, 10.0f, false)]
        [InlineData(float.MaxValue, float.MinValue, true)]
        [InlineData(float.MinValue, float.MaxValue, false)]
        public void IsBetterThan_ShoudReturnBetterMovieByNota(float betterNota, float worstNota, bool expected)
        {
            var betterMovie = new Movie { Nota = betterNota };
            var worstMovie = new Movie { Nota = worstNota };

            var actual = betterMovie.IsBetterThan(worstMovie);

            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData("A", "B", true)]
        [InlineData("B", "A", false)]
        [InlineData("a", "B", true)]
        [InlineData("B", "a", false)]
        [InlineData("007 - Skyfall", "Zootopia", true)]
        [InlineData("Zootopia", "007 - Skyfall", false)]
        public void ResolveTie_ShoudReturnBetterMovie(string betterTitle, string worstTitle, bool expected)
        {
            var betterMovie = new Movie
            {
                Nota = 5.0f,
                Titulo = betterTitle
            };
            var worstMovie = new Movie
            {
                Nota = 5.0f,
                Titulo = worstTitle
            };

            var actual = betterMovie.ResolveTie(worstMovie);

            Assert.Equal(actual, expected);
        }
    }
}
