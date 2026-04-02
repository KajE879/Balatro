using System;
using System.Collections.Generic;
using System.Text;
using test.Cards;

namespace test
{
    static class HandUtils
    {
        public static bool IsFlush(List<Card> cards)
            => cards.All(c => c.Suit == cards[0].Suit);

        public static bool IsStraight(List<Card> cards)
        {
            var values = cards.Select(c => c.Value).Distinct().OrderBy(x => x).ToList();
            if (values.Count != 5) return false;

            for (int i = 1; i < values.Count; i++)
                if (values[i] != values[i - 1] + 1)
                    return false;

            return true;
        }

        public static Dictionary<CardValue, int> GetGroups(List<Card> cards)
        {
            return cards
                .GroupBy(c => c.Value)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}
