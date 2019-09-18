using ConsoleBlackjack.GameLogic.Classes;
using Moq;
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
            var dealer = new BlackjackDealer(_cardFactory);

            // TODO: how can we check for randomness in a list?
            // for simplicity, lets say if the first 4 cards are in their unshuffled order then the test fails - improve this later

            dealer.GetNewCardDeck();
            dealer.ShuffleDeck();

            dealer.CardDeck.Count.ShouldBe(52);

            var firstFourCardTypes = dealer.CardDeck.Take(4).Select(c => c.CardName.Split(" ").First());
            string.Join(',', firstFourCardTypes).ShouldNotBe("Ace,Two,Three,Four");
        }

        [Fact]
        public void Dealer_DealCard_Test()
        {
            var dealer = new BlackjackDealer(_cardFactory);

            dealer.GetNewCardDeck();
            var expectedCard = dealer.CardDeck.First();
            var card = dealer.DealCard();

            card.ShouldNotBeNull();
            card.ShouldBeOfType<FrenchCard>();
            card.ShouldBeSameAs(expectedCard);
            dealer.CardDeck.Count.ShouldBe(51);

            expectedCard = dealer.CardDeck.First();
            card = dealer.DealCard();
            card.ShouldBeOfType<FrenchCard>();
            card.ShouldBeSameAs(expectedCard);
            dealer.CardDeck.Count.ShouldBe(50);

            expectedCard = dealer.CardDeck.First();
            card = dealer.DealCard();
            card.ShouldBeOfType<FrenchCard>();
            card.ShouldBeSameAs(expectedCard);
            dealer.CardDeck.Count.ShouldBe(49);
        }

        [Fact]
        public void Dealer_TakeBet_Test()
        {
            var dealer = new BlackjackDealer(_cardFactory);
            var betAmount = 99.99;

            dealer.TakeBet(betAmount);
            dealer.Bet.ShouldBe(betAmount);

            betAmount = 59.99;
            dealer.TakeBet(betAmount);
            dealer.Bet.ShouldBe(betAmount);
        }

        [Fact]
        public void Dealer_PayoutWinnings_Test()
        {
            var moqDeckFactory = new Mock<BlackjackCardDeckFactory>();
            var dealer = new BlackjackDealer(moqDeckFactory.Object);

            var betAmount = 10.00;

            dealer.TakeBet(betAmount);

            var payout = dealer.PayoutWinnings();

            // the current logic will simply double the winnings, this will be further improved in later versions
            payout.ShouldBe(20.00);
        }
    }
}
