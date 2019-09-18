using ConsoleBlackjack.GameLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleBlackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: create game in simple format here
            // TODO: write a consoleoutput engine to help write messages to console, including displaying cards, card face up/down etc
            // TODO: write a class that give a game intro, manual, how to play etc

            var deckFactory = new BlackjackCardDeckFactory();
            var dealer = new BlackjackDealer(deckFactory);

            Console.WriteLine("Press Control + C to exit at any time");
            while (true)
            {
                Console.WriteLine("Place your bet amount:");
                double betAmount;

                while (!double.TryParse(Console.ReadLine(), out betAmount))
                {
                    Console.WriteLine("Place a valid bet amount:");
                }

                dealer.TakeBet(betAmount);
                dealer.GetNewCardDeck();
                dealer.ShuffleDeck();

                // deal player 2 cards
                var listPlayerCards = new List<FrenchCard>
                {
                    dealer.DealCard(),
                    dealer.DealCard()
                };

                var listDealerCards = new List<FrenchCard>
                {
                    dealer.DealCard(),
                    dealer.DealCard()
                };


                // TODO: card face down needs to be done
                Console.WriteLine("The dealer has dealt you: " + string.Join(',', listPlayerCards.Select(card => card.CardName)));
                Console.WriteLine("The dealer has dealt himself: " + string.Join(',', listDealerCards.Select(card => card.CardName)));
                Console.WriteLine("Hit[h] or stay[s]?");

                var playersInput = "";

                while (playersInput != "h" && playersInput != "s")
                {
                    playersInput = Console.ReadLine();
                }

                if (playersInput == "h")
                {
                    listPlayerCards.Add(dealer.DealCard());
                    Console.WriteLine("Your cards are: " + string.Join(',', listPlayerCards.Select(card => card.CardName)));
                }
            }

            //do {
            //    while (!Console.KeyAvailable) {
                    
            //    }       
            //} while (Console.ReadKey(true).Key != ConsoleKey.Escape);   
        }
    }
}
