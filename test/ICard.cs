using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    interface ICard
    {
        public void PrintMe();
        public string MakeAsString();

        public bool SatisfiesSuit(Suit suit);
    }
}
