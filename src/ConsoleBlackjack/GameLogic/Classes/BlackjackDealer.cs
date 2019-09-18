using ConsoleBlackjack.GameLogic.Interfaces;
using System;
using System.Linq;

namespace ConsoleBlackjack.GameLogic.Classes
{
    public class BlackjackDealer : BaseDealer<FrenchCard>
    {
        public BlackjackDealer(IDeckFactory<FrenchCard> deckFactory) : base(deckFactory)
        {

        }

        public override void ShuffleDeck()
        {
            var randomNumberGenerator = new Random();
            var shuffledCardDeck = new BlackjackCardDeck();

            while (CardDeck.Count > 0)
            {
                var cardPosition = randomNumberGenerator.Next(CardDeck.Count);
                var randomCard = CardDeck.ElementAt(cardPosition);
                shuffledCardDeck.Add(randomCard);
                CardDeck.Remove(randomCard);
            }

            CardDeck = shuffledCardDeck;
        }

        public override FrenchCard DealCard()
        {
            var card = CardDeck.First();
            CardDeck.Remove(card);
            return card;
        }

        public override void TakeBet(double betAmount) => Bet = betAmount;

        public override double PayoutWinnings() => Bet * 2;
    }
}
