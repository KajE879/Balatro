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
        public int Points => 40;
        public string Name => "Full House";
        public bool Matches(List<Card> cards)
        {
            var groups = HandUtils.GetGroups(cards).Values;
            return groups.Contains(3) && groups.Contains(2);
        }
    }
}
