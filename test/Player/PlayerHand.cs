using System;
using System.Collections.Generic;
using System.Linq;
using test.Cards;

namespace test.Player
{
    class PlayerHand
    {
        private List<Card> Hand;
        private List<int> SelectedIndexes;
        public IEnumerable<Card> CardsInHand => this.Hand;
        public IEnumerable<int> SelectedCards => this.SelectedIndexes;

        public int MaxSelectedCards { get; private set; } = 5;

        public PlayerHand(int maxCards)
        {
            this.Hand = new List<Card>();
            this.SelectedIndexes = new List<int>();
        }

        public void AddCard(Card newCard)
        {
            this.Hand.Add(newCard);
        }

        public void SelectCard(int index)
        {
            if (index < 0 || index >= Hand.Count)
                return;

            if (SelectedIndexes.Contains(index))
                return;

            if (SelectedIndexes.Count >= MaxSelectedCards)
                return;

            SelectedIndexes.Add(index);
        }

        public void DeselectCard(int index)
        {
            if (index < 0 || index >= Hand.Count)
                return;

            SelectedIndexes.Remove(index);
        }

        public List<Card> GetSelected()
        {
            return Hand
                .Where((card, index) => SelectedIndexes.Contains(index))
                .ToList();
        }

        public void RemoveSelected()
        {
            Hand = Hand
                .Where((card, index) => !SelectedIndexes.Contains(index))
                .ToList();

            SelectedIndexes.Clear();
        }
    }
}
