using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    class Card : ICard
    {
        public CardValue Value;
        public Suit Suit;
        public Card(CardValue startValue, Suit startSuit)
        {
            this.Value = startValue;
            this.Suit = startSuit;
        }

        public void PrintMe()
        {
            Console.WriteLine(this.Value);
        }

        public string MakeAsString()
        {
            return this.Suit.ToString() + " " + this.Value.ToString();
        }

        public bool SatisfiesSuit(Suit suit)
        {
            return this.Suit == suit;
        }
    }
}