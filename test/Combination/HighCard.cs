using System;
using System.Collections.Generic;
using System.Text;
using test.Interface;
using test.Cards;

namespace test.Combination
{
    class HighCard : IHandType
    {
        public int Mult => 1;
        public bool Matches(List<Card> cards)
        {
            return true;
        }
    }
}
