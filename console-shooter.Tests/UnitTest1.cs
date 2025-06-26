using Xunit;
using console_shooter;
using System;

namespace console_shooter.Tests
{
    public class GameTests
    {
        [Fact]
        public void MovePlayer_LeftArrow_DecreasesPlayerPos()
        {
            // Arrange
            var game = new Game(30);
            var initialPos = game.PlayerPos;

            // Act
            game.MovePlayer(ConsoleKey.LeftArrow);

            // Assert
            Assert.Equal(initialPos - 1, game.PlayerPos);
        }

        [Fact]
        public void MovePlayer_RightArrow_IncreasesPlayerPos()
        {
            // Arrange
            var game = new Game(30);
            var initialPos = game.PlayerPos;

            // Act
            game.MovePlayer(ConsoleKey.RightArrow);

            // Assert
            Assert.Equal(initialPos + 1, game.PlayerPos);
        }

        [Fact]
        public void MovePlayer_AtLeftBoundary_DoesNotMoveLeft()
        {
            // Arrange
            var game = new Game(30);
            // Move player to the far left
            while (game.PlayerPos > 0)
            {
                game.MovePlayer(ConsoleKey.LeftArrow);
            }
            var initialPos = game.PlayerPos;

            // Act
            game.MovePlayer(ConsoleKey.LeftArrow);

            // Assert
            Assert.Equal(initialPos, game.PlayerPos);
        }

        [Fact]
        public void UpdateScore_IncreasesScoreByOne()
        {
            // Arrange
            var game = new Game(30);
            var initialScore = game.Score;

            // Act
            game.UpdateScore();

            // Assert
            Assert.Equal(initialScore + 1, game.Score);
        }

        [Fact]
        public void MovePlayer_MultipleInputs_ProcessesAllMoves()
        {
            // Arrange
            var game = new Game(30);
            var initialPos = game.PlayerPos; // Assuming initialPos is 15 for screenWidth 30

            // Act: Move right 5 times, then left 2 times
            game.MovePlayer(ConsoleKey.RightArrow);
            game.MovePlayer(ConsoleKey.RightArrow);
            game.MovePlayer(ConsoleKey.RightArrow);
            game.MovePlayer(ConsoleKey.RightArrow);
            game.MovePlayer(ConsoleKey.RightArrow);
            game.MovePlayer(ConsoleKey.LeftArrow);
            game.MovePlayer(ConsoleKey.LeftArrow);

            // Assert: Expected position is initialPos + 5 - 2 = initialPos + 3
            Assert.Equal(initialPos + 3, game.PlayerPos);
        }
    }
}