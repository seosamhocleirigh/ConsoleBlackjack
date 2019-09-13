using ConsoleBlackjack.GameLogic.Common;
using ConsoleBlackjack.GameLogic.Interfaces;

namespace ConsoleBlackjack.GameLogic.Classes
{
    public class Card : ICard
    {
        public Card(int[] cardValues, string cardName)
        {
            CardValues = cardValues;
            CardName = cardName;
        }

        public int[] CardValues { get; private set; }

        public string CardName { get; private set; }
    }
}