using ConsoleBlackjack.GameLogic.Classes;
using Shouldly;
using System.Linq;
using Xunit;

namespace BlackjackIntegrationTest.CardFactoryTests
{
    public sealed class UnshuffledDeckFactoryTests
    {
        private BlackjackCardDeck _generatedDeck;

        public UnshuffledDeckFactoryTests()
        {
            var cardFactory = new BlackjackCardDeckFactory();
            _generatedDeck = cardFactory.GenerateDeck();
        }

        [Fact]
        public void CardFactory_CardCountTest()
        {
            _generatedDeck.Count.ShouldBe(52);
        }

        // TODO: add testing around name a values, consider ordering suits if there is a traditional spec for that
        [Fact]
        public void CardFactory_DoubleValues_CountTest()
        {
            _generatedDeck.Where(d => d.CardValues.Count() == 2).Count().ShouldBe(4);
        }

        [Fact]
        public void CardFactory_SingleValues_CountTest()
        {
            _generatedDeck.Where(d => d.CardValues.Count() == 1).Count().ShouldBe(48);
        }

        [Fact]
        public void CardFactory_DoubleValueCard_ValuesTest()
        {
            _generatedDeck.First(d => d.CardValues.Count() == 2).CardValues.ShouldBe(new int[] { 1, 11 });
        }

        [Fact]
        public void CardFactory_DoubleValueCards_DescriptionTest()
        {
            var doubleValueCards = _generatedDeck.Where(d => d.CardValues.Count() == 2);

            doubleValueCards.Count().ShouldBe(4);
            doubleValueCards.Count(d => d.CardName.Equals("Ace of Diamonds", System.StringComparison.Ordinal)).ShouldBe(1);
            doubleValueCards.Count(d => d.CardName.Equals("Ace of Hearts", System.StringComparison.Ordinal)).ShouldBe(1);
            doubleValueCards.Count(d => d.CardName.Equals("Ace of Spades", System.StringComparison.Ordinal)).ShouldBe(1);
            doubleValueCards.Count(d => d.CardName.Equals("Ace of Clubs", System.StringComparison.Ordinal)).ShouldBe(1);
        }

        [Fact]
        public void CardFactory_SingleValueCards_DescriptionTest()
        {

        }
    }
}
