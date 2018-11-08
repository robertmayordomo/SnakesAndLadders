using System;

namespace SnakesAndLadders
{
    [Serializable]
    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException(string playerName) : base($"{playerName} not found on board") { }
    }
}