using System;
using System.Collections.Generic;
using System.Linq;
using test.Cards;
using test.Player;

namespace test
{
    class ViewModel
    {
        private Model Model;

        private int DeckCardsTotal, DeckCardsRemaining = 0;
        private IEnumerable<Card> CardsInHand = new List<Card>();
        private IEnumerable<int> SelectedCards = new List<int>();

        private HandScore? LastScore;

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
            this.LastScore = this.Model.LastScore;
        }

        public void RenderUI()
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Level " + this.Model.Level
                + "  |  Score: " + this.Model.LevelScore + " / " + this.Model.LevelTarget
                + "  |  Hands: " + this.Model.HandsLeft
                + "  |  Discards: " + this.Model.DiscardsLeft
                + "  |  Deck: " + this.DeckCardsRemaining + "/" + this.DeckCardsTotal);

            Console.WriteLine();

            for (int i = 0; i < this.CardsInHand.Count(); i++)
            {
                Card card = this.CardsInHand.ElementAt(i);

                Console.Write(i == CursorIndex ? ">" : " ");
                Console.Write(this.SelectedCards.Contains(i) ? "[x]" : "[ ]");
                Console.WriteLine(" " + card.MakeAsString());
            }

            Console.WriteLine();

            var selected = this.Model.PlayerHand.GetSelected();
            var preview = this.Model.EvaluatePreview();

            if (selected.Count == 0)
            {
                Console.WriteLine("Hand:  None");
                Console.WriteLine("Score: 0 x 0 = 0");
            }
            else
            {
                Console.WriteLine("Hand:  " + preview.Name);
                Console.WriteLine("Score: (" + preview.Points + " + " + preview.CardSum + ") x " + preview.Mult + " = " + preview.Total);
            }
            Console.WriteLine();
            Console.WriteLine("[P] Play hand   [D] Discard   [Up/Down] Move   [Space] Select");

            if (this.Model.GameOver)
            {
                Console.WriteLine();
                Console.WriteLine("GAME OVER - press any key to quit");
            }
        }

        public void HandleUserInput()
        {
            if (this.Model.GameOver)
            {
                Console.ReadKey(true);
                Environment.Exit(0);
            }

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

                case ConsoleKey.P:
                    this.Model.PlayHand();
                    this.UpdateFromModel();
                    if (CursorIndex > this.CardsInHand.Count() - 1)
                        CursorIndex = this.CardsInHand.Count() - 1;
                    break;

                case ConsoleKey.D:
                    this.Model.DiscardSelected();
                    this.UpdateFromModel();
                    if (CursorIndex > this.CardsInHand.Count() - 1)
                        CursorIndex = this.CardsInHand.Count() - 1;
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
