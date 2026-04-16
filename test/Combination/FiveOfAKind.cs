using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;
using test.Interface;

namespace test.Combination
{
    class FiveOfAKind : IHandType
    {
        public int Mult => 12;
        public int Points => 120;
        public string Name => "Five Of A Kind";
        public bool Matches(List<Card> cards)
        {
            var groups = HandUtils.GetGroups(cards);
            return groups.Values.Any(v => v == 5);
        }
    }
}
