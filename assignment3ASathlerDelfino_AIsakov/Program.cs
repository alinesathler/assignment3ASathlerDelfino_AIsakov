﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//Aline Sathler Delfino & Ana Isakov - Assignment 3
//Name of Project: Rock, Paper, Scissors (RPS) Tournament
//Purpose: C# console application of a tournament of Rock, Paper, Scissors
//Revision History:
//REV00 - 2023/10/26 - Initial version
//REV01 - 2023/10/30 - Adding tie Break
//REV02 - 2023/10/31 - Goodbye message, number of games bigger than 0, generic exception, switch statement, changing globals variables to class variables, manipulating exceptions to not close the program
//REV03 - 2023/11/01 - Undoing the manipulation of exceptions to not close the program: Space and Time Complexity

namespace assignment3ASathlerDelfino_AIsakov {

    internal class Program {
        //Class variables
        public static uint playerWins = 0, computerWins = 0;

        //Method player choose its draw
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

        //Method computer draw is selected randomly
        static uint ComputerPlays() {
            Random rand = new Random();

            uint computerChoice = (uint)rand.Next(1, 4);

            return computerChoice;

        }

        //Method interpretating players choices
        static string WriteChoices(string player, uint choice) {
            string prompt = "";

            switch (choice) {
                case 1:
                    prompt = player + " chose Rock.";
                    break;
                case 2:
                    prompt = player + " chose Paper.";
                    break;
                case 3:
                    prompt = player + " chose Scissors.";
                    break;
            }

            return prompt;
        }

        //Method checking winner game
        static string WinnerGame(uint playerChoice, uint computerChoice) {
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

        //Method checking winner series
        static void WinnerSeries() {
            //Showing the winner of the series
            if (playerWins > computerWins) {
                Console.WriteLine("\nCongrats Player Wins the Series!!");
            } else if (playerWins < computerWins) {
                Console.WriteLine("\nComputer Wins the Series.");
            } else {
                Console.WriteLine("\nSeries ended in a draw.");
                //Tie Breaker game
                TieBreaker();
            }
        }


        //Method game
        static void Game() {
            uint computerChoice, playerChoice;
            string winner;

            playerChoice = PlayerPlays();
            computerChoice = ComputerPlays();

            Console.WriteLine("Rock, Paper, Scissors, DRAW!");

            //Writing the opponents choices on terminal
            Console.WriteLine(WriteChoices("Player", playerChoice));
            Console.WriteLine(WriteChoices("Computer", computerChoice));

            //Checking who won the game
            winner = WinnerGame(playerChoice, computerChoice);
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

        //Method tie Breaker
        static void TieBreaker() {
            bool isDraw = true;
            do {
                Console.WriteLine("\n\nTIE BREAKER");
                Game();

                if (playerWins != computerWins) {
                    isDraw = false;
                }
            } while (isDraw);

            WinnerSeries();
        }

        static void Main() {
            uint games;

            Console.WriteLine("Welcome to Rock, Paper, Scissors Tournament!");
            Console.WriteLine("How many games would you like to play?");

            try {
                //RPS Number of Games
                Console.ForegroundColor = ConsoleColor.Yellow;
                games = Convert.ToUInt16(Console.ReadLine());
                Console.ResetColor();

                //Only execute if number of games > 0
                if (games > 0) {
                    //Loop for running for the quantity of games
                    for (int i = 0; i < games; i++) {
                        //Method that controls the game
                        Game();
                    }

                    //Checking who wins the series
                    WinnerSeries();
                }

            } catch (ArgumentOutOfRangeException) {
                Console.ResetColor();
                Console.WriteLine("Invalid menu.");
            } catch (FormatException) {
                Console.ResetColor();
                Console.WriteLine("Invalid input.");
            }  catch (OverflowException) {
                Console.ResetColor();
                Console.WriteLine("Invalid input.");
            } catch (Exception) {
                Console.ResetColor();
                Console.WriteLine("Something went wrong.");
            } finally {
                Console.WriteLine("\nGoodbye!!!\n");
            }
        }
    }
}
