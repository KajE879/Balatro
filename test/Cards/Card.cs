using System;
using System.Collections.Generic;
using System.Text;
using test.Interface;

namespace test.Cards
{
    class Card : ICard
    {
        public CardValue Value { get; set; }
        public Suit Suit { get; set; }
        public int ChipValue => (int)Value;

        public Card(CardValue startValue, Suit startSuit)
        {
            this.Value = startValue;
            this.Suit = startSuit;
        }

        public void PrintMe()
        {
            Console.WriteLine(this.MakeAsString());
        }

        public string MakeAsString()
        {
            string rank = "";

            if (Value == CardValue.Ace)   rank = "A";
            else if (Value == CardValue.King)  rank = "K";
            else if (Value == CardValue.Queen) rank = "Q";
            else if (Value == CardValue.Jack)  rank = "J";
            else if (Value == CardValue.Ten)   rank = "10";
            else rank = ((int)Value).ToString();

            string suit = "";

            if (Suit == Suit.Hearts)   suit = "♥";
            else if (Suit == Suit.Diamonds) suit = "♦";
            else if (Suit == Suit.Spades)   suit = "♠";
            else if (Suit == Suit.Clovers)  suit = "♣";

            return rank + suit;
        }

        public bool SatisfiesSuit(Suit suit)
        {
            return this.Suit == suit;
        }
    }
}
