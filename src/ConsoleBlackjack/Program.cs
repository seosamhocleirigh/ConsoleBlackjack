using ConsoleBlackjack.GameLogic.Classes;
using ConsoleBlackjack.GameLogic.Common.FrenchCardEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Pastel;

namespace ConsoleBlackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "♠♥♣♦ Blackjack ♠♥♣♦";
            // TODO: create game in simple format here
            // TODO: write a consoleoutput engine to help write messages to console, including displaying cards, card face up/down etc
            // TODO: write a class that give a game intro, manual, how to play etc
            // TODO: sum logic for ace when sum goes over 21

            var deckFactory = new BlackjackCardDeckFactory();
            var dealer = new BlackjackDealer(deckFactory);

            var playersInput = "y";

            while (playersInput == "y")
            {
                double betAmount = AskForBetAmount();

                dealer.TakeBet(betAmount);
                dealer.GetNewCardDeck();
                dealer.ShuffleDeck();

                // deal player 2 cards
                var listPlayerCards = new BlackjackHand();
                listPlayerCards.AddRange(dealer.DealCards(2, true));
                var sumOfPlayersCards = listPlayerCards.SumCardValues();

                var listDealerCards = new BlackjackHand();
                listDealerCards.AddRange(new List <FrenchCard>
                {
                    dealer.DealCard(faceUp: true),
                    dealer.DealCard(faceUp: false)
                });
                var sumOfDealerCards = listDealerCards.SumCardValues();

                Console.WriteLine("The dealer's cards are: " + string.Join(',', listDealerCards.Select(card => card.CurrentCardAspect)).Pastel("#1E90FF"));
                Console.WriteLine("Your cards are: " + string.Join(',', listPlayerCards.Select(card => card.CardFace)).Pastel("#ff59c7"));

                while (listPlayerCards.SumCardValues() < 21 && playersInput != "s")
                {
                    playersInput = OfferPlayerAChoiceAndGetInput("[h]it or [s]tay?");

                    if (playersInput == "h")
                    {
                        listPlayerCards.Add(dealer.DealCard(faceUp: true));
                        Console.WriteLine("Your cards are: " + string.Join(',', listPlayerCards.Select(card => card.CardFace)).Pastel("#ff59c7"));
                    }
                }

                if (listPlayerCards.SumCardValues() > 21)
                {
                    Console.WriteLine("You are bust °º¤ø,¸¸,ø¤º°`°º¤ø,¸,ø¤°º¤ø,¸¸,ø¤º°`°º¤ø,¸".Pastel("#ff9994"));

                    playersInput = OfferPlayerAChoiceAndGetInput("Would you like to make another bet? [y]es or [n]o");

                    if (playersInput == "y")
                    {
                        continue;
                    }

                    break;
                }

                // engage dealer
                listDealerCards.Single(c => !c.IsCardFaceUp).IsCardFaceUp = true;
                Console.WriteLine("The dealer's cards are: " + string.Join(',', listDealerCards.Select(card => card.CurrentCardAspect)).Pastel("#1E90FF"));

                while (sumOfDealerCards < sumOfPlayersCards)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("The dealer deals himself a card.");
                    Thread.Sleep(1000);
                    listDealerCards.Add(dealer.DealCard(true));
                    Console.WriteLine("The dealers cards are: " + string.Join(',', listDealerCards.Select(card => card.CardFace)).Pastel("#1E90FF"));
                    sumOfDealerCards = listDealerCards.SumCardValues();
                }

                if (sumOfPlayersCards > sumOfDealerCards || sumOfDealerCards > 21)
                {
                    Console.WriteLine("You win!".Pastel("#ff59c7"));
                    // TODO: payout
                }
                else
                {
                    Console.WriteLine("The dealer wins");
                }

                Console.WriteLine($"Your current balance is: X");
                playersInput = OfferPlayerAChoiceAndGetInput("Would you like to make another bet? [y]es or [n]o");
            }

            //do {
            //    while (!Console.KeyAvailable) {

            //    }       
            //} while (Console.ReadKey(true).Key != ConsoleKey.Escape);   
        }

        public class BlackjackHand : List<FrenchCard>
        {
            public int SumCardValues()
            {
                var sum = 0;
                foreach (var card in this)
                {
                    sum += card.CardValues.Max();
                }

                if (sum > 21 && this.Any(c => c.CardType == CardType.Ace))
                {
                    var numberOfAces = this.Count(c => c.CardType == CardType.Ace);
                    sum -= numberOfAces * 10;
                }

                return sum;
            }
        }

        private static double AskForBetAmount()
        {
            const string betPrompt = "Place your bet amount:";
            Console.WriteLine(betPrompt);
            double betAmount;

            while (!double.TryParse(Console.ReadLine(), out betAmount))
            {
                Console.WriteLine(betPrompt);
            }

            return betAmount;
        }

        private static string OfferPlayerAChoiceAndGetInput(string prompt)
        {
            var validUserInputs = RegexStringBasedUserOptions(prompt);

            Console.WriteLine(prompt);
            var playersInput = Console.ReadLine();

            while (!validUserInputs.Contains(playersInput))
            {
                Console.WriteLine(prompt);
                playersInput = Console.ReadLine();
            }

            return playersInput;
        }

        private static List<string> RegexStringBasedUserOptions(string promptToUser)
        {
            if (!promptToUser.Contains("[") && !promptToUser.Contains("]"))
            {
                throw new Exception("Prompt does not contain a valid option, eg: [y]/[n]");
            }

            var regex = @"\[\S*\]";
            var matches = Regex.Matches(promptToUser, regex);

            var matchList = matches.Cast<Match>().Select(match => match.Value).ToList();
            var validOptions = matchList.Select(m => m.Replace("[", "").Replace("]", "")).ToList();

            return validOptions;
        }
    }
}
