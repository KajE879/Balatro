using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;
using test.Interface;

namespace test.Combination
{
    class Flush : IHandType
    {
        public int Mult => 4;
        public int Points => 35;
        public string Name => "Flush";
        public bool Matches(List<Card> cards)
        {
            if (cards.Count != 5)
                return false;
            return HandUtils.IsFlush(cards);
        }
    }
}
