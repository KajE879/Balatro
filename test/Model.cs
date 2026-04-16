using System.Collections.Generic;
using test.Player;
using test.Cards;

namespace test
{
    class Model
    {
        public Deck Deck { get; private set; }
        public PlayerHand PlayerHand { get; private set; }

        private HandEvaluator evaluator;

        public HandScore? LastScore { get; private set; }

        public int Level { get; private set; } = 1;
        public int LevelScore { get; private set; } = 0;
        public int LevelTarget => 300 * Level;

        public int HandsLeft { get; private set; } = 4;
        public int DiscardsLeft { get; private set; } = 3;

        public bool IsGameOver => HandsLeft <= 0 && LevelScore < LevelTarget;

        public Model(Deck deck, PlayerHand playerHand)
        {
            this.Deck = deck;
            this.PlayerHand = playerHand;
            this.evaluator = new HandEvaluator();
        }

        public void PlayHand()
        {
            List<Card> selected = PlayerHand.GetSelected();

            if (selected.Count == 0 || HandsLeft <= 0)
                return;

            LastScore = evaluator.Evaluate(selected);
            LevelScore += LastScore.Total;
            HandsLeft--;

            PlayerHand.Discard(Deck);

            if (LevelScore >= LevelTarget)
            {
                CheckLevel();
            }
        }

        public void DiscardSelected()
        {
            List<Card> selected = PlayerHand.GetSelected();

            if (selected.Count == 0 || DiscardsLeft <= 0)
                return;

            DiscardsLeft--;
            PlayerHand.Discard(Deck);
        }

        public HandScore EvaluatePreview()
        {
            var selected = PlayerHand.GetSelected();

            if (selected.Count == 0)
            {
                return new HandScore
                {
                    Name = "None",
                    Points = 0,
                    CardSum = 0,
                    Mult = 0
                };
            }

            return evaluator.Evaluate(selected);
        }

        private void CheckLevel()
        {
            Level++;
            LevelScore = 0;
            HandsLeft = 4;
            DiscardsLeft = 3;

            Deck.Reset();
            Deck.Shuffle();

            PlayerHand = new PlayerHand(8);
            for (int i = 0; i < 8; i++)
            {
                Card card = Deck.TakeCard();
                if (card != null)
                    PlayerHand.AddCard(card);
            }
        }
    }
}
