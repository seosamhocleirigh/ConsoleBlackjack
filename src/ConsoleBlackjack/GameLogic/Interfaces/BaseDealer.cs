using System.Collections.Generic;

namespace ConsoleBlackjack.GameLogic.Interfaces
{
    public abstract class BaseDealer<ICard>
    {
        public double Bet { private get; set; }
        private IList<ICard> _cardDeck;
        private IDeckFactory<ICard> _deckFactory;

        public BaseDealer(IDeckFactory<ICard> deckFactory) => _deckFactory = deckFactory;

        public void GetNewCardDeck() => _cardDeck = _deckFactory.GenerateDeck();

        public abstract void Shuffle();
        public abstract ICard DealCard();
        public abstract void TakeBet(double betAmount);
        // TODO: winnings will be paid on rules, those rules should be defined and explained to user on load and probably should become a dependancy for the dealer
        public abstract double PayoutWinnings();
    }
}
