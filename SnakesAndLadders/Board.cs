using System.Collections.Generic;

namespace SnakesAndLadders
{
    public class Board
    {
        private readonly Dictionary<string, int> _playerPosition = new Dictionary<string, int>();
        private readonly int _totalBoardSquares;
        private GameState _state;
        private string _winner;

        public Board(int totalBoardSquares)
        {
            _totalBoardSquares = totalBoardSquares;
            _state = GameState.NotStarted;
        }

        public void InitalisePlayer(string player)
        {
            _playerPosition.TryAdd(player, 1);
        }

        public int GetPlayerPosition(string player)
        {
            if (!_playerPosition.TryGetValue(player, out var position))
            {
                throw new PlayerNotFoundException(player);
            }

            return position;
        }

        public void MovePlayer(string player, int spaces)
        {
            if (_state == GameState.Finished)
            {
                throw new GameOverException();
            }

            if (_playerPosition.TryGetValue(player, out var position))
            {
                if (position + spaces >= _totalBoardSquares)
                {
                    _state = GameState.Finished;
                    _winner = player;
                }
                else
                {
                    _state = GameState.Playing;
                }

                _playerPosition[player] += spaces;
            }
        }

        public GameStatus GetBoardStatus()
        {
            return new GameStatus
            {
                Winner = _winner,
                State = _state
            };
        }
    }
}