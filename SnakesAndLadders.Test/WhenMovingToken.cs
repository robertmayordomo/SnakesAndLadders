using FluentAssertions;
using Xunit;

namespace SnakesAndLadders.Test
{
    public class WhenMovingToken
    {
        public WhenMovingToken()
        {
            _sut = new Board(100);
            _player = "Player-1";
        }

        private readonly string _player;
        private readonly Board _sut;

        [Theory]
        [InlineData(3, 4, 8)]
        [InlineData(6, 6, 13)]
        [InlineData(1, 1, 3)]
        [InlineData(1, 5, 7)]
        public void PlayerGetsMultipleTurnsShouldProgressToCorrectSpace(int initialRoll, int secondRoll, int expectedPosition)
        {
            _sut.InitalisePlayer(_player);

            _sut.MovePlayer(_player, initialRoll);
            _sut.MovePlayer(_player, secondRoll);

            _sut.GetPlayerPosition(_player).Should().Be(expectedPosition);
        }

        [Fact]
        public void PlayerShouldProgressToCorrectPosition()
        {
            _sut.InitalisePlayer(_player);

            _sut.MovePlayer(_player, 3);

            _sut.GetPlayerPosition(_player).Should().Be(4);
        }

        [Fact]
        public void TokenShouldBeginOnSquareOne()
        {
            _sut.InitalisePlayer(_player);

            _sut.GetPlayerPosition(_player).Should().Be(1);
        }
        
        [Fact]
        public void GameShouldBeWinnable()
        {
            _sut.InitalisePlayer(_player);

            _sut.MovePlayer(_player, 96);
            _sut.MovePlayer(_player, 3);

            _sut.GetBoardStatus().State.Should().Be(GameState.Finished);
            _sut.GetBoardStatus().Winner.Should().Be(_player);
        }
    }
}