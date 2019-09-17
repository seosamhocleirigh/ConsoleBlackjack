using ConsoleBlackjack.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBlackjack.GameLogic.Classes
{
    public class BlackjackDealer : BaseDealer<FrenchCard>
    {
        public double Bet { get; set; }
        private BlackjackCardDeck _cardDeck;

        public BlackjackDealer(IDeckFactory<FrenchCard> deckFactory) : base(deckFactory)
        {

        }

        public override void Shuffle()
        {
            throw new NotImplementedException();
        }

        public override FrenchCard DealCard()
        {
            throw new NotImplementedException();
        }

        public override void TakeBet(double betAmount)
        {
            throw new NotImplementedException();
        }

        public override double PayoutWinnings()
        {
            throw new NotImplementedException();
        }
    }
}
