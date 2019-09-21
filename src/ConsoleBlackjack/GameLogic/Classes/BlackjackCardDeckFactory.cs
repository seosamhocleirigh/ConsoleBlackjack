using ConsoleBlackjack.GameLogic.Common.FrenchCardEnums;
using System;
using ConsoleBlackjack.GameLogic.Interfaces;
using System.Collections.Generic;

namespace ConsoleBlackjack.GameLogic.Classes
{
    public class BlackjackCardDeckFactory : IDeckFactory<FrenchCard>
    {
        public IList<FrenchCard> GenerateDeck()
        {
            var deck = new BlackjackCardDeck();
            var cardSuits = EnumExtensions.EnumExtensions.GetValues<CardSuit>();
            var cardTypes = EnumExtensions.EnumExtensions.GetValues<CardType>();

            foreach (var cardSuit in cardSuits)
            {
                foreach (var cardValue in cardTypes)
                {
                    FrenchCard card;
                    var cardName = $"{cardValue} of {cardSuit}";

                    switch (cardValue)
                    {
                        case CardType.Ace:
                            card = new FrenchCard(cardSuit, cardValue, new int[] { 1, 11 });
                            break;
                        case CardType.Two:
                            card = new FrenchCard(cardSuit, cardValue, new int[] { 2 });
                            break;
                        case CardType.Three:
                            card = new FrenchCard(cardSuit, cardValue, new int[] { 3 });
                            break;
                        case CardType.Four:
                            card = new FrenchCard(cardSuit, cardValue, new int[] { 4 });
                            break;
                        case CardType.Five:
                            card = new FrenchCard(cardSuit, cardValue, new int[] { 5 });
                            break;
                        case CardType.Six:
                            card = new FrenchCard(cardSuit, cardValue, new int[] { 6 });
                            break;
                        case CardType.Seven:
                            card = new FrenchCard(cardSuit, cardValue, new int[] { 7 });
                            break;
                        case CardType.Eight:
                            card = new FrenchCard(cardSuit, cardValue, new int[] { 8 });
                            break;
                        case CardType.Nine:
                            card = new FrenchCard(cardSuit, cardValue, new int[] { 9 });
                            break;
                        case CardType.Ten:
                            card = new FrenchCard(cardSuit, cardValue, new int[] { 10 });
                            break;
                        case CardType.Jack:
                        case CardType.Queen:
                        case CardType.King:
                            card = new FrenchCard(cardSuit, cardValue, new int[] { 10 });
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
