using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;
using test.Interface;

namespace test.Combination
{
    class FullHouse : IHandType
    {
        public int Mult => 4;
        public bool Matches(List<Card> cards)
        {
            var groups = HandUtils.GetGroups(cards).Values;
            return groups.Contains(3) && groups.Contains(2);
        }
    }
}
