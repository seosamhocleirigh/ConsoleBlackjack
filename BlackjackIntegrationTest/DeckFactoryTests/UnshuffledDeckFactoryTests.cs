using ConsoleBlackjack.GameLogic.Classes;
using Shouldly;
using System.Linq;
using Xunit;

namespace BlackjackIntegrationTest.CardFactoryTests
{
    public sealed class UnshuffledDeckFactoryTests
    {
        private Deck _generatedDeck;

        public UnshuffledDeckFactoryTests()
        {
            var cardFactory = new DeckFactory();
            _generatedDeck = cardFactory.GenerateDeck();
        }

        [Fact]
        public void CardFactory_CardCountTest()
        {
            _generatedDeck.Count.ShouldBe(52);
        }

        // TODO: add testing around name a values, consider ordering suits if there is a traditional spec for that
        [Fact]
        public void CardFactory_DoubleValuesTest()
        {
            _generatedDeck.Where(d => d.CardValues.Count() == 2).Count().ShouldBe(4);
        }

        [Fact]
        public void CardFactory_SingleValuesTest()
        {
            _generatedDeck.Where(d => d.CardValues.Count() == 1).Count().ShouldBe(48);
        }
    }
}
