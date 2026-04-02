using System;
using System.Collections.Generic;
using System.Linq;
using test.Cards;

namespace test
{
    class ViewModel
    {
        private Model Model;

        private int DeckCardsTotal, DeckCardsRemaining = 0;
        private IEnumerable<Card> CardsInHand = new List<Card>();
        private IEnumerable<int> SelectedCards = new List<int>();

        private int CursorIndex = 0;

        public ViewModel(Model model)
        {
            this.Model = model;
            UpdateFromModel();
        }

        public void UpdateFromModel()
        {
            this.DeckCardsTotal = this.Model.Deck.TotalCardCount;
            this.DeckCardsRemaining = this.Model.Deck.CardsRemainingCount;
            this.CardsInHand = this.Model.PlayerHand.CardsInHand;
            this.SelectedCards = this.Model.PlayerHand.SelectedCards;
        }

        public void RenderUI()
        {
            Console.Clear();

            Console.WriteLine("Deck: " +
                this.DeckCardsRemaining + "/" +
                this.DeckCardsTotal);

            Console.WriteLine();

            for (int i = 0; i < this.CardsInHand.Count(); i++)
            {
                Card card = this.CardsInHand.ElementAt(i);

                Console.Write(i == CursorIndex ? ">" : " ");
                Console.Write(this.SelectedCards.Contains(i) ? "[x]" : "[ ]");

                Console.WriteLine(" " + card.MakeAsString());
            }

            Console.WriteLine();
        }

        public void HandleUserInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            int maxIndex = this.CardsInHand.Count() - 1;

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    CursorIndex--;
                    if (CursorIndex < 0) CursorIndex = 0;
                    break;

                case ConsoleKey.DownArrow:
                    CursorIndex++;
                    if (CursorIndex > maxIndex) CursorIndex = maxIndex;
                    break;

                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    ToggleCard(CursorIndex);
                    break;
            }
        }

        public void Run()
        {
            while (true)
            {
                UpdateFromModel();
                RenderUI();
                HandleUserInput();
            }
        }

        private void ToggleCard(int index)
        {
            if (this.SelectedCards.Contains(index))
            {
                this.Model.PlayerHand.DeselectCard(index);
            }
            else
            {
                if (this.SelectedCards.Count() < 5)
                    this.Model.PlayerHand.SelectCard(index);
            }

            UpdateFromModel();
        }
    }
}