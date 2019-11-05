using ConsoleBlackjack.GameLogic.Classes;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BlackjackIntegrationTest.GameLogicTests
{
    public sealed class BlackjackHandTests
    {
        private IList<FrenchCard> _generatedDeck;

        public BlackjackHandTests()
        {
            var cardFactory = new BlackjackCardDeckFactory();
            _generatedDeck = cardFactory.GenerateDeck();
        }

        private void TurnAllCardsFaceUp(BlackjackHand blackjackHand)
        {
            foreach (var card in blackjackHand)
                card.IsCardFaceUp = true;
        }

        [Fact]
        public void SumCardValues_BasicTest()
        {
            // pull some regular cards and assert the sum
            var fiveCard = _generatedDeck.First(c => c.CardValues.Count() == 1 && c.CardValues.Sum() == 5);
            var tenCard = _generatedDeck.First(c => c.CardValues.Count() == 1 && c.CardValues.Sum() == 10);

            var blackjackHand = new BlackjackHand
            {
                fiveCard,
                tenCard
            };

            TurnAllCardsFaceUp(blackjackHand);

            blackjackHand.SumCardValues().ShouldBe(15);
        }

        [Fact]
        public void SumCardValues_BasicTest2()
        {
            // pull some regular cards and assert the sum
            var fiveCard = _generatedDeck.First(c => c.CardValues.Count() == 1 && c.CardValues.Sum() == 5);
            var tenCard = _generatedDeck.First(c => c.CardValues.Count() == 1 && c.CardValues.Sum() == 10);
            var threeCard = _generatedDeck.First(c => c.CardValues.Count() == 1 && c.CardValues.Sum() == 3);

            var blackjackHand = new BlackjackHand
            {
                fiveCard,
                tenCard,
                threeCard
            };

            TurnAllCardsFaceUp(blackjackHand);

            blackjackHand.SumCardValues().ShouldBe(18);
        }

        [Fact]
        public void SumCardValues_Under21WithAce()
        {
            // pull some regular cards and assert the sum
            var elevenCard = _generatedDeck.First(c => c.CardValues.Count() == 2);
            var fiveCard = _generatedDeck.First(c => c.CardValues.Count() == 1 && c.CardValues.Sum() == 5);

            var blackjackHand = new BlackjackHand
            {
                elevenCard,
                fiveCard
            };

            TurnAllCardsFaceUp(blackjackHand);

            blackjackHand.SumCardValues().ShouldBe(16);
        }

        [Fact]
        public void SumCardValues_21WithAce()
        {
            // pull some regular cards and assert the sum
            var elevenCard = _generatedDeck.First(c => c.CardValues.Count() == 2);
            var tenCard = _generatedDeck.First(c => c.CardValues.Count() == 1 && c.CardValues.Sum() == 10);

            var blackjackHand = new BlackjackHand
            {
                elevenCard,
                tenCard
            };

            TurnAllCardsFaceUp(blackjackHand);

            blackjackHand.SumCardValues().ShouldBe(21);
        }

        [Fact]
        public void SumCardValues_Over21WithAce()
        {
            // pull some regular cards and assert the sum
            var elevenCard = _generatedDeck.First(c => c.CardValues.Count() == 2);
            var tenCard = _generatedDeck.First(c => c.CardValues.Count() == 1 && c.CardValues.Sum() == 10);
            var threeCard = _generatedDeck.First(c => c.CardValues.Count() == 1 && c.CardValues.Sum() == 3);

            var blackjackHand = new BlackjackHand
            {
                elevenCard,
                tenCard,
                threeCard
            };

            TurnAllCardsFaceUp(blackjackHand);

            blackjackHand.SumCardValues().ShouldBe(14);
        }
    }
}
