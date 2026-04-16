using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;
using test.Interface;

namespace test.Combination
{
    class StraightFlush : IHandType
    {
        public int Mult => 8;
        public int Points => 100;
        public string Name => "Straight Flush";
        public bool Matches(List<Card> cards)
        {
            if (cards.Count != 5)
                return false;
            return HandUtils.IsStraight(cards) && HandUtils.IsFlush(cards);
        }
    }
}
