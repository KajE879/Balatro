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
        public int Points => 30;
        public string Name => "Straight";
        public bool Matches(List<Card> cards)
        {
            if (cards.Count != 5)
                return false;
            return HandUtils.IsStraight(cards);
        }
    }
}
