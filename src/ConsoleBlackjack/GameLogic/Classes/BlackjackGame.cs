using Pastel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ConsoleBlackjack.GameLogic.Classes
{
    public class BlackjackGame
    {
        public void Play()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "♠♥♣♦ Blackjack ♠♥♣♦";

            //string path = Server.MapPath("TrackData/vehicle_points.txt");
            //AppDomain.CurrentDomain.BaseDirectory
            var text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"Assets\TextFile1.txt", Encoding.UTF8);
            Console.WriteLine(text);
            Console.WriteLine();

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
                var playersHand = new BlackjackHand();
                playersHand.AddRange(dealer.DealCards(2, true));
                var sumOfPlayersCards = playersHand.SumCardValues();

                var dealersHand = new BlackjackHand();
                dealersHand.AddRange(new List<FrenchCard>
                {
                    dealer.DealCard(faceUp: true),
                    dealer.DealCard(faceUp: false)
                });

                OutputDealersHand(dealersHand);
                OutputPlayersHand(playersHand);

                while (playersHand.SumCardValues() < 21 && playersInput != "s")
                {
                    playersInput = OfferPlayerAChoiceAndGetInput("[h]it or [s]tay?");

                    if (playersInput == "h")
                    {
                        playersHand.Add(dealer.DealCard(faceUp: true));
                        OutputPlayersHand(playersHand);
                    }
                }

                if (playersHand.SumCardValues() > 21)
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
                dealersHand.Single(c => !c.IsCardFaceUp).IsCardFaceUp = true;
                OutputDealersHand(dealersHand);

                while (dealersHand.SumCardValues() < playersHand.SumCardValues())
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("\nThe dealer deals himself a card.");
                    Thread.Sleep(1000);

                    dealersHand.Add(dealer.DealCard(true));
                    OutputDealersHand(dealersHand);
                }

                var sumOfDealerCards = dealersHand.SumCardValues();

                if (sumOfPlayersCards > sumOfDealerCards || sumOfDealerCards > 21)
                {
                    Console.WriteLine("You win!".Pastel("#f5e042"));
                    // TODO: payout
                }
                else
                {
                    Console.WriteLine("The dealer wins".Pastel("#f54278"));
                }

                Console.WriteLine($"Your current balance is: X");
                playersInput = OfferPlayerAChoiceAndGetInput("Would you like to make another bet? [y]es or [n]o");
            }

            //do {
            //    while (!Console.KeyAvailable) {

            //    }       
            //} while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private void OutputPlayersHand(BlackjackHand blackjackHand)
        {
            Console.WriteLine("Your cards are: ");
            OutputCardsAndTotal(blackjackHand, "#ff59c7");
        }

        private void OutputDealersHand(BlackjackHand blackjackHand)
        {
            Console.WriteLine("The dealer's cards are: ");
            OutputCardsAndTotal(blackjackHand, "#1E90FF");
        }

        private void OutputCardsAndTotal(BlackjackHand blackjackHand, string hexColor)
        {
            Console.WriteLine(
                    $"{string.Join(',', blackjackHand.Select(card => card.CurrentCardAspect)).Pastel(hexColor)} - (Total = {blackjackHand.SumCardValues()})\n"
                );
        }

        private double AskForBetAmount()
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

        private string OfferPlayerAChoiceAndGetInput(string prompt)
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

        private List<string> RegexStringBasedUserOptions(string promptToUser)
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
