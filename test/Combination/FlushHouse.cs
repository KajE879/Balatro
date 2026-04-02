using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;
using test.Interface;

namespace test.Combination
{
    class FlushHouse : IHandType
    {
        public int Mult => 14;
        public bool Matches(List<Card> cards)
        {
            var groups = HandUtils.GetGroups(cards).Values;
            return HandUtils.IsFlush(cards) && groups.Contains(3) && groups.Contains(2);
        }
    }
}
