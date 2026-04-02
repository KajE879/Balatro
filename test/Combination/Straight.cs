using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;
using test.Interface;

namespace test.Combination
{
    class Straight : IHandType
    {
        public int Mult => 4;
        public bool Matches(List<Card> cards)
        {
            return HandUtils.IsStraight(cards);
        }
    }
}
