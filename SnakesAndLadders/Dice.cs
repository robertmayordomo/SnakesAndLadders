using System;

namespace SnakesAndLadders
{
    public static class Dice
    {
        private static readonly Random InternalDice = new Random(Guid.NewGuid().GetHashCode());

        public static int Roll()
        {
            return InternalDice.Next(1, 7);
        }
    }
}