using ConsoleBlackjack.GameLogic.Classes;
using Shouldly;
using System.Linq;
using Xunit;

namespace BlackjackIntegrationTest.BlackjackDealerTests
{
    public class BlackjackDealerTests
    {
        private BlackjackCardDeckFactory _cardFactory = new BlackjackCardDeckFactory();

        [Fact]
        public void Dealer_Shuffle_Test()
        {
            var generatedDeck = _cardFactory.GenerateDeck();

            // TODO: how can we check for randomness in a list?
            // for simplicity, lets say if the first 4 cards are in their unshuffled order then the test fails - improve this later

            var firstFourCardTypes = generatedDeck.Take(4).Select(c => c.CardName.Split(" ").First());
            string.Join(',', firstFourCardTypes).ShouldNotBe("Ace,Two,Three,Four");
        }

        [Fact]
        public void Dealer_DealCard_Test()
        {
            var generatedDeck = _cardFactory.GenerateDeck();
            var dealer = new BlackjackDealer(_cardFactory);

            var card = dealer.DealCard();

            card.ShouldNotBeNull();
            card.ShouldBeOfType<FrenchCard>();
            card.ShouldBeSameAs(generatedDeck.First());

            card = dealer.DealCard();
            card.ShouldBeOfType<FrenchCard>();
            card.ShouldBeSameAs(generatedDeck.ElementAt(1));
        }

        [Fact]
        public void Dealer_TakeBet_Test()
        {
            var generatedDeck = _cardFactory.GenerateDeck();
            var dealer = new BlackjackDealer(_cardFactory);
            var betAmount = 99.99;

            dealer.TakeBet(betAmount);

            dealer.Bet.ShouldBe(betAmount);
        }

        // TODO: winning test - need to put rules for payouts in place
    }
}
