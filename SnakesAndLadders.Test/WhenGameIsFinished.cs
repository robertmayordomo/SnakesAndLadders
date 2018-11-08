using System;
using FluentAssertions;
using Xunit;

namespace SnakesAndLadders.Test
{
    public class WhenGameIsFinished
    {
        public WhenGameIsFinished()
        {
            _sut = new Board(100);
            _player = "Player-1";
            _sut.InitalisePlayer(_player);

            _sut.MovePlayer(_player, 96);
            _sut.MovePlayer(_player, 3);
        }

        private readonly string _player;
        private readonly Board _sut;

        [Fact]
        public void ShouldNotBeAbleMove()
        {
            Action move = () => _sut.MovePlayer(_player, 1);

            move.Should().Throw<GameOverException>();
        }
    }
}