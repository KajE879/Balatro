using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;
using test.Interface;

namespace test.Combination
{
    class ThreeOfAKind : IHandType
    {
        public int Mult => 3;
        public int Points => 30;
        public string Name => "Three Of A Kind";
        public bool Matches(List<Card> cards)
        {
            var groups = HandUtils.GetGroups(cards);
            return groups.Values.Any(v => v == 3);
        }
    }
}
