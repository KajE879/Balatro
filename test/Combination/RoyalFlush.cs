using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using test.Cards;
using test.Interface;

namespace test.Combination
{
    class RoyalFlush : IHandType
    {
        public int Mult => 8;
        public int Points => 100;
        public string Name => "Royal Flush";
        public bool Matches(List<Card> cards)
        {
            if (cards.Count != 5)
                return false;
            var value = cards.Select(c => c.Value).OrderBy(x => x).ToArray();
            return value.SequenceEqual(new[] { CardValue.Ten, CardValue.Jack, CardValue.Queen, CardValue.King, CardValue.Ace })
                && HandUtils.IsFlush(cards);
        }
    }
}
