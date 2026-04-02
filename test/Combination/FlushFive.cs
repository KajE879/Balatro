using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;
using test.Interface;

namespace test.Combination
{
    class FlushFive : IHandType
    {
        public int Mult => 16;
        public bool Matches(List<Card> cards)
        {
            var groups = HandUtils.GetGroups(cards).Values;
            return HandUtils.IsFlush(cards) && groups.Any(v => v == 5);
        }
    }
}
