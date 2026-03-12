using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    internal class Deck
    {
        private List<Card> Cards;
        private List<Card> CardsTaken;

        public Deck()
        {
            this.Cards = new List<Card>();
            this.CardsTaken = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    Card card = new Card(value, suit);
                    this.Cards.Add(card);
                    Console.WriteLine(card.Suit.ToString() + " " + card.Value.ToString());
                }
            }
        }
        public Card? TakeCard()
        {
            if (this.Cards.Count == 0)
            { 
                return null;
            }
            Card taken = this.Cards.First();
            this.Cards.RemoveAt(0);
            this.CardsTaken.Add(taken);
            return taken;
        }

        public void Reset()
        {
            this.Cards =
                this.Cards
                .Concat(this.CardsTaken)
                .ToList();
            this.CardsTaken = new List<Card>();
        }
        public void Shuffle()
        {
            this.Cards = this.Cards.Shuffle().ToList();
        }
    }
}
