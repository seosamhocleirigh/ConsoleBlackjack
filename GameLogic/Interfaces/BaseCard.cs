using ConsoleBlackjack.GameLogic.Common;

namespace ConsoleBlackjack.GameLogic.Interfaces
{
    public class BaseCard
    {
        public BaseCard(CardName cardName, Suit suit)
        {
            CardName = cardName;
            Suit = suit;
        }

        public CardName? CardName { get; private set; }
        public Suit? Suit { get; private set; }
        public string Name => $"{CardName} of {Suit.ToString()}";
    }
}