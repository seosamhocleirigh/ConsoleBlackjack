using System.Collections.Generic;

namespace ConsoleBlackjack.GameLogic.Interfaces
{
    public abstract class BaseDealer<ICard>
    {
        // TODO: add method to deal more than 1 card
        public double Bet { get; protected set; }
        public IList<ICard> CardDeck { get; protected set; }
        private IDeckFactory<ICard> _deckFactory;

        public BaseDealer(IDeckFactory<ICard> deckFactory) => _deckFactory = deckFactory;

        public void GetNewCardDeck() => CardDeck = _deckFactory.GenerateDeck();

        public abstract void ShuffleDeck();
        public abstract ICard DealCard(bool faceUp);
        public abstract void TurnCardFaceUp(ref ICard card);
        public abstract void TurnCardFaceDown(ref ICard card);
        public abstract void TakeBet(double betAmount);
        // TODO: winnings will be paid on rules, those rules should be defined and explained to user on load and probably should become a dependancy for the dealer
        public abstract double PayoutWinnings();
    }
}
