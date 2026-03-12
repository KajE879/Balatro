using System;
using System.Collections.Generic;
using System.Text;

namespace test {
    class program
    {
        static void Main(string[] args)
        {
            Deck testDeck = new Deck();
            // cards
            PlayerHand hand = new PlayerHand(5);
            // give card
            Model model = new Model(testDeck, hand);

            ViewModel viewModel = new ViewModel(model);
            viewModel.UpdateFromModel();
            viewModel.RenderUI();
        }
    }
}
