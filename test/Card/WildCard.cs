using System;
using System.Collections.Generic;
using System.Text;
using test.Interface;

namespace test.Card
{
    internal class WildCard : ICard
    {
        public string MakeAsString()
        {
            throw new NotImplementedException();
        }

        public void PrintMe()
        {
            throw new NotImplementedException();
        }

        public bool SatisfiesSuit(Suit suit)
        {
            return true;
        }
    }
}
