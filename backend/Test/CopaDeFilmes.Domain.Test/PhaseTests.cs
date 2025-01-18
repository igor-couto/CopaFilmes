using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using Moq;
using CopaDeFilmes.Domain.Entities;
using CopaDeFilmes.Domain.Interfaces;

namespace CopaDeFilmes.Domain.Test
{
    public class PhaseTests
    {
        private IMovie CreateMockMovie(string id, string titulo, int ano, float nota)
        {
            var mockMovie = new Mock<IMovie>();
            mockMovie.Setup(m => m.Id).Returns(id);
            mockMovie.Setup(m => m.Titulo).Returns(titulo);
            mockMovie.Setup(m => m.Ano).Returns(ano);
            mockMovie.Setup(m => m.Nota).Returns(nota);
            return mockMovie.Object;
        }

        private List<IMovie> GetMockMovies(int count, float baseNota = 5.0f)
        {
            var movies = new List<IMovie>();
            for (var i = 1; i <= count; i++)
            {
                movies.Add(CreateMockMovie(
                    Guid.NewGuid().ToString(),
                    $"Movie {i}",
                    2020 + i,
                    baseNota + i
                ));
            }
            return movies;
        }

        [Fact]
        public void Constructor_ShouldInitializeMatchesAndWinners_WithEvenNumberOfMovies()
        {
            // Arrange
            var movies = GetMockMovies(4);

            // Act
            var phase = new Phase(movies);

            // Assert
            phase.Matches.Should().HaveCount(2, because: "there are 4 movies and each match requires 2 movies");
            phase.Winners.Should().HaveCount(2, because: "each match has one winner");

            for (var i = 0; i < phase.Matches.Count; i++)
            {
                var match = phase.Matches[i];
                match.Winner.Should().Be(movies[2 * i + 1], "Winner should be the movie with the higher Nota");
            }

            for (var i = 0; i < phase.Winners.Count; i++)
            {
                phase.Winners[i].Nota.Should().BeGreaterThan(movies[2 * i].Nota, "Winner should have a higher Nota than the opponent");
            }
        }

        [Fact]
        public void Constructor_ShouldInitializeMatchesAndWinners_WithOddNumberOfMovies_ThrowsException()
        {
            // Arrange
            var movies = GetMockMovies(3);

            // Act
            Action act = () => new Phase(movies);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("*Index was out of range*");
        }

        [Fact]
        public void Constructor_ShouldInitializeEmptyMatchesAndWinners_WithNoMovies()
        {
            // Arrange
            var movies = new List<IMovie>();

            // Act
            var phase = new Phase(movies);

            // Assert
            phase.Matches.Should().BeEmpty("no movies were provided, so no matches should be created");
            phase.Winners.Should().BeEmpty("no matches were created, so there should be no winners");
        }

        [Fact]
        public void Play_ShouldCreateCorrectNumberOfMatches_AndSelectWinners()
        {
            // Arrange
            var movies = GetMockMovies(6);
            var phase = new Phase(new List<IMovie>());

            // Act
            phase.Play(movies);

            // Assert
            phase.Matches.Should().HaveCount(3, "6 movies should result in 3 matches");
            phase.Winners.Should().HaveCount(3, "each match should produce one winner");

            for (var i = 0; i < phase.Matches.Count; i++)
            {
                var match = phase.Matches[i];
                match.Winner.Should().Be(movies[2 * i + 1], "Winner should be the movie with the higher Nota");
            }

            for (var i = 0; i < phase.Winners.Count; i++)
            {
                phase.Winners[i].Nota.Should().BeGreaterThan(movies[2 * i].Nota, "Winner should have a higher Nota than the opponent");
            }
        }

        [Fact]
        public void Play_WithOddNumberOfMovies_ShouldThrowException()
        {
            // Arrange
            var movies = GetMockMovies(5);
            var phase = new Phase(new List<IMovie>());

            // Act
            Action act = () => phase.Play(movies);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("*Index was out of range*");
        }

        [Fact]
        public void Play_WithEmptyMovieList_ShouldNotCreateMatchesOrWinners()
        {
            // Arrange
            var movies = new List<IMovie>();
            var phase = new Phase(new List<IMovie>());

            // Act
            phase.Play(movies);

            // Assert
            phase.Matches.Should().BeEmpty("no movies were provided, so no matches should be created");
            phase.Winners.Should().BeEmpty("no matches were created, so there should be no winners");
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(1, false)]
        [InlineData(0, false)]
        [InlineData(5, true)]
        public void HasNextPhase_ShouldReturnExpectedResult(int numberOfWinners, bool expected)
        {
            // Arrange
            var phase = new Phase(new List<IMovie>());
            for (var i = 0; i < numberOfWinners; i++)
            {
                var mockMovie = CreateMockMovie(Guid.NewGuid().ToString(), $"Winner {i + 1}", 2021, 7.0f);
                phase.Winners.Add(mockMovie);
            }

            // Act
            var result = phase.HasNextPhase();

            // Assert
            result.Should().Be(expected, $"HasNextPhase should return {expected} when there are {numberOfWinners} winners");
        }

        [Fact]
        public void HasNextPhase_ShouldReturnTrue_WhenExactlyTwoWinners()
        {
            // Arrange
            var phase = new Phase(new List<IMovie>()); // Initialize empty phase
            var movie1 = CreateMockMovie(Guid.NewGuid().ToString(), "Winner 1", 2021, 8.0f);
            var movie2 = CreateMockMovie(Guid.NewGuid().ToString(), "Winner 2", 2021, 7.5f);
            phase.Winners.Add(movie1);
            phase.Winners.Add(movie2);

            // Act
            var result = phase.HasNextPhase();

            // Assert
            result.Should().BeTrue("there are exactly two winners, so there should be a next phase");
        }

        [Fact]
        public void HasNextPhase_ShouldReturnFalse_WhenLessThanTwoWinners()
        {
            // Arrange
            var phase = new Phase(new List<IMovie>()); // Initialize empty phase
            var movie1 = CreateMockMovie(Guid.NewGuid().ToString(), "Winner 1", 2021, 8.0f);
            phase.Winners.Add(movie1);

            // Act
            var result = phase.HasNextPhase();

            // Assert
            result.Should().BeFalse("there is only one winner, so there should not be a next phase");
        }

        [Fact]
        public void Play_WithDuplicateMovies_ShouldHandleCorrectly()
        {
            // Arrange
            var movie1 = CreateMockMovie(Guid.NewGuid().ToString(), "Movie 1", 2021, 7.0f);
            var movie2 = CreateMockMovie(movie1.Id, "Movie 1 Duplicate", 2021, 8.0f);
            var movies = new List<IMovie> { movie1, movie2 };

            // Act
            var phase = new Phase(movies);

            // Assert
            phase.Matches.Should().HaveCount(1, "there are 2 movies, so there should be 1 match");
            phase.Winners.Should().HaveCount(1, "each match produces one winner");
            phase.Winners[0].Should().Be(movie2, "the winner should be the movie with the higher Nota even if IDs are duplicate");
        }

        [Fact]
        public void Play_WithIdenticalNota_ShouldSelectSecondMovieAsWinner()
        {
            // Arrange
            var movie1 = CreateMockMovie(Guid.NewGuid().ToString(), "Movie 1", 2021, 7.0f);
            var movie2 = CreateMockMovie(Guid.NewGuid().ToString(), "Movie 2", 2021, 7.0f);
            var movies = new List<IMovie> { movie1, movie2 };

            // Act
            var phase = new Phase(movies);

            // Assert
            phase.Matches.Should().HaveCount(1, "there are 2 movies, so there should be 1 match");
            phase.Winners.Should().HaveCount(1, "each match produces one winner");
            phase.Winners[0].Should().Be(movie2, "when Nota is equal, the second movie should be selected as the winner");
        }
    }
}
