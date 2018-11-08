using FluentAssertions;
using Xunit;

namespace SnakesAndLadders.Test
{
    public class WhenGameIsNotFinished
    {
        public WhenGameIsNotFinished()
        {
            _sut = new Board(100);
            _player = "Player-1";
            _sut.InitalisePlayer(_player);

            _sut.MovePlayer(_player, 3);
        }

        private readonly string _player;
        private readonly Board _sut;

        [Fact]
        public void ShouldNotHaveAWinner()
        {
            _sut.GetBoardStatus().Winner.Should().BeNullOrWhiteSpace();
        }

        [Fact]
        public void ShouldBeInCorrectState()
        {
            _sut.GetBoardStatus().State.Should().Be(GameState.Playing);
        }
    }
}