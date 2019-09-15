using ConsoleBlackjack.GameLogic.Classes;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BlackjackIntegrationTest.DealerTests
{
    public class DealerTests
    {
        [Fact]
        public void Dealer_Shuffle_Test()
        {
            var cardFactory = new BlackjackCardDeckFactory();
            var generatedDeck = cardFactory.GenerateDeck();

            // TODO: how can we check for randomness in a list?
            // for simplicity, lets say if the first 4 cards are in their unshuffled order then the test fails - improve this later

            var firstFourCardTypes = generatedDeck.Take(4).Select(c => c.CardName.Split(" ").First());
            string.Join(',', firstFourCardTypes).ShouldNotBe("Ace,Two,Three,Four");
        }
    }
}
