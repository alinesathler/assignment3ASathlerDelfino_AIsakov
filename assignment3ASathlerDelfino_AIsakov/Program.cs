using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//Aline Sathler Delfino - Assignment 3
//Name of Project: Rock, Paper, Scissors (RPS) Tournament
//Purpose: C# console application of a tournament of Rock, Paper, Scissors
//Revision History:
//REV00 - 2023/10/26 - Initial version

namespace assignment3ASathlerDelfino_AIsakov {
    internal class Program {
        

        //Player choose its draw
        static uint PlayerPlays() {
            uint playerChoice;

            Console.WriteLine("\nSelect your draw:");
            Console.WriteLine("Rock, Press: 1");
            Console.WriteLine("Paper, Press: 2");
            Console.WriteLine("Scissors, Press: 3");

            Console.ForegroundColor = ConsoleColor.Yellow;
            playerChoice = Convert.ToUInt16(Console.ReadLine());
            Console.ResetColor();

            if (playerChoice >= 1 && playerChoice <= 3) {
                return playerChoice;
            } else {
                throw new ArgumentOutOfRangeException();
            }

        }

        //Commputer draw is selected randomly
        static uint ComputerPlays() {
            Random rand = new Random();

            uint computerChoice = (uint) rand.Next(1, 4);

            return computerChoice;

        }

        //Interpretating players choices
        static string WriteChoices(string player, uint choice) {
            string prompt = "";

            if (choice == 1) {
                prompt = player + " chose Rock.";
            } else if (choice == 2) {
                prompt = player + " chose Paper.";
            } else if (choice == 3) {
                prompt = player + " chose Scissors.";
            }

            return prompt;
        }

        //Checking who won the game
        static string CheckingWinner(uint playerChoice, uint computerChoice) {
            string winner = "";
            if (playerChoice == computerChoice) {
                winner = "DRAW!";
            } else if ((playerChoice == 1 && computerChoice == 2) || (playerChoice == 3 && computerChoice == 1) || (playerChoice == 2 && computerChoice == 3)) {
                winner = "Computer Wins";
            } else if ((playerChoice == 2 && computerChoice == 1) || (playerChoice == 1 && computerChoice == 3) || (playerChoice == 3 && computerChoice == 2)) {
                winner = "Player Wins";
            }

            return winner;
        }
        static void Main() {
            uint games, computerChoice, playerChoice, playerWins = 0, computerWins = 0;
            string winner;

            Console.WriteLine("Welcome to Rock, Paper, Scissors Tournament!");
            Console.WriteLine("How many games would you like to play?");

            try {
                //RPS Number of Games
                Console.ForegroundColor = ConsoleColor.Yellow;
                games = Convert.ToUInt16(Console.ReadLine());
                Console.ResetColor();

                //Loop for running for the quantity of games
                for (int i = 0; i < games; i++)
                {
                    playerChoice = PlayerPlays();
                    computerChoice = ComputerPlays();

                    Console.WriteLine("Rock, Paper, Scissors, DRAW!");

                    //Writing the opponents choices on terminal
                    Console.WriteLine(WriteChoices("Player", playerChoice));
                    Console.WriteLine(WriteChoices("Computer", computerChoice));

                    //Checking who won the game
                    winner = CheckingWinner(playerChoice, computerChoice);
                    Console.WriteLine(winner);

                    //Adding the win for the winner
                    if (winner == "Player Wins") {
                        playerWins++;
                    } else if (winner == "Computer Wins") {
                        computerWins++;
                    }

                    //Displaying the result of consecutive games
                    Console.WriteLine("\nStandings:");
                    Console.WriteLine("Player Wins: " + playerWins);
                    Console.WriteLine("Computer Wins: " + computerWins);
                }

                //Showing the winner of the series
                if (playerWins > computerWins) {
                    Console.WriteLine("\nCongrats Player Wins the Series!!");
                } else if (playerWins < computerWins) {
                    Console.WriteLine("\nComputer Wins the Series.");
                } else {
                    Console.WriteLine("\nSeries ended in a draw.");
                }

            } catch (FormatException) {
                Console.WriteLine("Invalid input.");
            } catch (ArgumentOutOfRangeException) {
                Console.WriteLine("Invalid menu.");
            } finally {
                Console.ResetColor();
            }
        }
    }
}
