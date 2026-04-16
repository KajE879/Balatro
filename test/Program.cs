using System;
using test.Player;
using test.Cards;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck testDeck = new Deck();
            testDeck.Shuffle();

            PlayerHand hand = new PlayerHand(8);

            for (int i = 0; i < 8; i++)
            {
                var card = testDeck.TakeCard();
                if (card != null)
                    hand.AddCard(card);
            }

            Model model = new Model(testDeck, hand);
            ViewModel vm = new ViewModel(model);

            vm.Run();
        }
    }
}
