using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;
using test.Interface;

namespace test.Combination
{
    class Pair : IHandType
    {
        public int Mult => 2;
        public int Points => 10;
        public string Name => "Pair";
        public bool Matches(List<Card> cards)
        {
            var groups = HandUtils.GetGroups(cards);
            return groups.Values.Any(v => v == 2);
        }
    }
}
