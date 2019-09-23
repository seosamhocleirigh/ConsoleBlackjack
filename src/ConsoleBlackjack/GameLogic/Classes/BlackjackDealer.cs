using ConsoleBlackjack.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
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

        public override FrenchCard DealCard(bool faceUp)
        {
            var card = CardDeck.First();
            CardDeck.Remove(card);
            card.IsCardFaceUp = faceUp;
            return card;
        }

        public override IList<FrenchCard> DealCards(int numberOfCards, bool faceUp)
        {
            var dealtCards = new List<FrenchCard>();

            for (int i = 0; i < numberOfCards; i++)
                dealtCards.Add(DealCard(faceUp));

            return dealtCards;
        }

        public override void TurnCardFaceUp(ref FrenchCard card) => card.IsCardFaceUp = true;

        public override void TurnCardFaceDown(ref FrenchCard card) => card.IsCardFaceUp = false;

        public override void TakeBet(double betAmount) => Bet = betAmount;

        public override double PayoutWinnings() => Bet * 2;
    }
}
