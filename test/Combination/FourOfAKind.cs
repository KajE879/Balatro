using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;
using test.Interface;

namespace test.Combination
{
    class FourOfAKind : IHandType
    {
        public int Mult => 7;
        public bool Matches(List<Card> cards)
        {
            var groups = HandUtils.GetGroups(cards);
            return groups.Values.Any(v => v == 4);
        }
    }
}
