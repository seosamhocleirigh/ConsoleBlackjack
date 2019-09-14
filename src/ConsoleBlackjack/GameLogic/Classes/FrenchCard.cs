using ConsoleBlackjack.GameLogic.Common;
using ConsoleBlackjack.GameLogic.Interfaces;

namespace ConsoleBlackjack.GameLogic.Classes
{
    public class FrenchCard : ICard
    {
        public FrenchCard(int[] cardValues, string cardName)
        {
            CardValues = cardValues;
            CardName = cardName;
        }

        public int[] CardValues { get; private set; }

        public string CardName { get; private set; }
    }
}