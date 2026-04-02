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
        public bool Matches(List<Card> cards)
        {
            return HandUtils.IsStraight(cards) && HandUtils.IsFlush(cards);
        }
    }
}
