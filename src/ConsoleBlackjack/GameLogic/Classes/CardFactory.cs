using ConsoleBlackjack.GameLogic.Common.FrenchCardEnums;
using System;
using ConsoleBlackjack.GameLogic.Extensions;

namespace ConsoleBlackjack.GameLogic.Classes
{
    public class DeckFactory
    {
        // TODO: need generic way to allow words to be numbers
        public Deck GenerateDeck()
        {
            var deck = new Deck();
            var cardSuits = EnumExtensions.GetValues<CardSuit>();
            var cardValues = EnumExtensions.GetValues<CardType>();

            foreach (var cardSuit in cardSuits)
            {
                foreach (var cardValue in cardValues)
                {
                    Card card;
                    var cardName = $"{cardValue} of {cardSuit}";

                    switch (cardValue)
                    {
                        case CardType.Ace:
                            card = new Card(new int[] { 1, 11 }, cardName);
                            break;
                        case CardType.Two:
                            card = new Card(new int[] { 2 }, cardName);
                            break;
                        case CardType.Three:
                            card = new Card(new int[] { 3 }, cardName);
                            break;
                        case CardType.Four:
                            card = new Card(new int[] { 4 }, cardName);
                            break;
                        case CardType.Five:
                            card = new Card(new int[] { 5 }, cardName);
                            break;
                        case CardType.Six:
                            card = new Card(new int[] { 6 }, cardName);
                            break;
                        case CardType.Seven:
                            card = new Card(new int[] { 7 }, cardName);
                            break;
                        case CardType.Eight:
                            card = new Card(new int[] { 8 }, cardName);
                            break;
                        case CardType.Nine:
                            card = new Card(new int[] { 9 }, cardName);
                            break;
                        case CardType.Ten:
                            card = new Card(new int[] { 10 }, cardName);
                            break;
                        case CardType.Jack:
                        case CardType.Queen:
                        case CardType.King:
                            card = new Card(new int[] { 10 }, cardName);
                            break;
                        default:
                            throw new Exception("Card could not be generated");
                    }

                    deck.AddCard(card);
                }
            }

            return deck;
        }
    }
}
