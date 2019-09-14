using ConsoleBlackjack.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleBlackjack.GameLogic.Classes
{
    // TODO: shuffling and drawing would be functions of the dealer
    public class BlackjackCardDeck : List<FrenchCard>
    {
        //public void AddCard(ICard card) => this.Add(card);

        //public ICard DrawTopCard()
        //{
        //    var card = this.FirstOrDefault();
        //    this.Remove(card);
        //    return card;
        //}

        //// TODO: maybe open to DI for shuffle logic in future
        //public void Shuffle()
        //{
        //    var shuffledDeck = new List<ICard>();
        //    var random = new Random();

        //    while (this.Any())
        //    {
        //        var randomIntBasedOnListCount = random.Next(this.Count - 1);
        //        var randomCard = this.ElementAt(randomIntBasedOnListCount);
        //        shuffledDeck.Add(randomCard);
        //        this.Remove(randomCard);
        //    }

        //    this.AddRange(shuffledDeck);
        //}
    }
}
