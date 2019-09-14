using ConsoleBlackjack.GameLogic.Common.FrenchCardEnums;
using System;
using ConsoleBlackjack.GameLogic.Extensions;

namespace ConsoleBlackjack.GameLogic.Classes
{
    public class BlackjackCardDeckFactory
    {
        // TODO: need generic way to allow words to be numbers
        public BlackjackCardDeck GenerateDeck()
        {
            var deck = new BlackjackCardDeck();
            var cardSuits = EnumExtensions.GetValues<CardSuit>();
            var cardValues = EnumExtensions.GetValues<CardType>();

            foreach (var cardSuit in cardSuits)
            {
                foreach (var cardValue in cardValues)
                {
                    FrenchCard card;
                    var cardName = $"{cardValue} of {cardSuit}";

                    switch (cardValue)
                    {
                        case CardType.Ace:
                            card = new FrenchCard(new int[] { 1, 11 }, cardName);
                            break;
                        case CardType.Two:
                            card = new FrenchCard(new int[] { 2 }, cardName);
                            break;
                        case CardType.Three:
                            card = new FrenchCard(new int[] { 3 }, cardName);
                            break;
                        case CardType.Four:
                            card = new FrenchCard(new int[] { 4 }, cardName);
                            break;
                        case CardType.Five:
                            card = new FrenchCard(new int[] { 5 }, cardName);
                            break;
                        case CardType.Six:
                            card = new FrenchCard(new int[] { 6 }, cardName);
                            break;
                        case CardType.Seven:
                            card = new FrenchCard(new int[] { 7 }, cardName);
                            break;
                        case CardType.Eight:
                            card = new FrenchCard(new int[] { 8 }, cardName);
                            break;
                        case CardType.Nine:
                            card = new FrenchCard(new int[] { 9 }, cardName);
                            break;
                        case CardType.Ten:
                            card = new FrenchCard(new int[] { 10 }, cardName);
                            break;
                        case CardType.Jack:
                        case CardType.Queen:
                        case CardType.King:
                            card = new FrenchCard(new int[] { 10 }, cardName);
                            break;
                        default:
                            throw new Exception("Card could not be generated");
                    }

                    deck.Add(card);
                }
            }

            return deck;
        }
    }
}
