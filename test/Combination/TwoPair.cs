using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;
using test.Interface;

namespace test.Combination
{
    class TwoPair : IHandType
    {
        public int Mult => 2;
        public bool Matches(List<Card> cards)
        {
            var groups = HandUtils.GetGroups(cards);
            return groups.Values.Count(v => v == 2) == 2;
        }
    }
}
