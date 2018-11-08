using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace SnakesAndLadders.Test
{
    public class WhenRollingDice
    {
        private static void Roll(Action<int> result, int rollCount = 1000000)
        {
            foreach (var _ in Enumerable.Range(0, rollCount))
            {
                result(Dice.Roll());
            }
        }

        [Fact]
        public void NumberShouldNeverBeGreaterThanSix()
        {
            Roll(number => number.Should().BeLessOrEqualTo(6));
        }

        [Fact]
        public void NumberShouldNeverBeLessThanOne()
        {
            Roll(number => number.Should().BeGreaterThan(0));
        }

        [Fact]
        public void ShouldHaveASpreadAcrossAllPossibleNumbers()
        {
            var diceRollCounts = new Dictionary<int, int>();

            Roll(number =>
            {
                if (diceRollCounts.TryGetValue(number, out var total))
                {
                    diceRollCounts[number]++;
                }
                else
                {
                    diceRollCounts[number] = 1;
                }
            });

            diceRollCounts.Keys.Count.Should().Be(6);
        }
    }
}