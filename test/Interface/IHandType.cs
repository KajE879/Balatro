using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;

namespace test.Interface
{
    interface IHandType
    {
        bool Matches(List<Card> cards);
        string Name { get; }
        int Points { get; }
        int Mult { get; }
    }
}
