using ConsoleBlackjack.GameLogic.Common.FrenchCardEnums;
using ConsoleBlackjack.GameLogic.EnumExtensions;
using ConsoleBlackjack.GameLogic.Interfaces;

namespace ConsoleBlackjack.GameLogic.Classes
{
    public class FrenchCard : ICard
    {
        public FrenchCard(CardSuit cardSuit, CardType cardType, int[] cardValues)
        {
            CardSuit = cardSuit;
            CardType = cardType;
            CardValues = cardValues;
            CardFace = $"[{CardType.GetDescription()}{CardSuit.GetDescription()}]";
            CardBack = "[XX]";
        }

        public CardSuit CardSuit { get; private set; }
        public CardType CardType { get; private set; }
        public int[] CardValues { get; private set; }
        public string CardFace { get; private set; }
        public string CardBack { get; private set; }
        public string CurrentCardAspect => IsCardFaceUp ? CardFace : CardBack;
        public bool IsCardFaceUp { get; set; } = false;
    }
}