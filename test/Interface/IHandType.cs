using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;

namespace test.Interface
{
    interface IHandType
    {
        bool Matches(List<Card> cards);
        int Mult { get; }
    }
}
