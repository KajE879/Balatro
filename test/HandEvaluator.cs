using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using test.Cards;
using test.Combination;
using test.Interface;
using test.Player;

namespace test
{
    class HandEvaluator
    {
        private List<IHandType> hands = new List<IHandType>
        {
            new FlushFive(),
            new FlushHouse(),
            new FiveOfAKind(),
            new RoyalFlush(),
            new StraightFlush(),
            new FourOfAKind(),
            new FullHouse(),
            new Flush(),
            new Straight(),
            new ThreeOfAKind(),
            new TwoPair(),
            new Pair(),
            new HighCard()
        };

        public HandScore Evaluate(List<Card> cards)
        {
            var best = hands.First(h => h.Matches(cards));
            int cardSum = cards.Sum(c => c.ChipValue);

            return new HandScore
            {
                Name = best.Name,
                Points = best.Points,
                CardSum = cardSum,
                Mult = best.Mult
            };
        }
    }
}
