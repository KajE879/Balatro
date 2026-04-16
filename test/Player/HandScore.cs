using System;
using System.Collections.Generic;
using System.Text;

namespace test.Player
{
    class HandScore
    {
        public string Name { get; set; } = string.Empty;
        public int Points { get; set; }   // base chips from hand type
        public int CardSum { get; set; } 
        public int Mult { get; set; }

        // Balatro formula: (base chips + card values) x multiplier
        public int Total => (Points + CardSum) * Mult;
    }
}
