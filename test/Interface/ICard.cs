using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;

namespace test.Interface
{
    interface ICard
    {
        public void PrintMe();
        public string MakeAsString();
        public bool SatisfiesSuit(Suit suit);
    }
}
