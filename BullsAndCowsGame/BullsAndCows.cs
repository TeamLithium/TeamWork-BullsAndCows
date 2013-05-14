[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BullsAndCows
    {
        private const int DigitsNumber = 4;
        private const string StartText = "Welcome to “Bulls and Cows” game.Please try to guess my secret 4-digit number.\n" +
                                                "Use 'top' to view the top scoreboard, 'restart' to start a new game\n" +
                                                "and 'help' to cheat and 'exit' to quit the game.\n";

        private const string EnterGuessText = "Enter your guess or command: ";
        private const string HelpAvailableText = "The number looks like";
        private const string HelpUnavailableText = "You cannot use more help.";
        private const string ScoreBoardEnterAllowedText = "Please enter your name for the top scoreboard: ";
        private const string ScoreBoardEnterUnallowedText = "You are not allowed to enter the top scoreboard.";

        private Random randomDigit = new Random();
        private List<int> digits;
        private char[] helpDigits;
        private bool isGameRunning = true;
        private int helpUsedCount;
        private int atemptsCount;

        public BullsAndCows()
        {
            this.digits = new List<int>();
        }

        public void StartGame()
        {
            Console.WriteLine(StartText);
            this.CreateRandomDigits();
            this.helpUsedCount = 0;
            this.atemptsCount = 0;

            do
            {
                Console.WriteLine(EnterGuessText);
                string inputLine = Console.ReadLine().Trim().ToLower();

                if (inputLine.CompareTo("help") == 0)
                {
                    this.Help();
                }
                else if (inputLine.CompareTo("top") == 0)
                {
                    ScoreBoard scoreboard = ScoreBoard.GetInstance();
                    scoreboard.PrintScoreBoard();
                }
                else if (inputLine.CompareTo("restart") == 0)
                {
                    Console.Clear();
                    this.StartGame();
                }
                else if (inputLine.CompareTo("exit") == 0)
                {
                    this.isGameRunning = false;
                    Console.WriteLine("Good bye!");
                }
                else
                {
                    this.ManageNumbersCommand(inputLine);
                }
            }
            while (this.isGameRunning);
        }

        private void CreateRandomDigits()
        {
            for (int index = 0; index < DigitsNumber; index++)
            {
                this.digits.Add(this.randomDigit.Next(0, 10));
            }

            this.helpDigits = new char[DigitsNumber];

            for (int index = 0; index < DigitsNumber; index++)
            {
                this.helpDigits[index] = 'X';
            }
        }

        private bool IsGuessCorrect(string guess, out int bulls, out int cows)
        {
            bulls = 0;
            cows = 0;

            if (guess.Length != DigitsNumber)
            {
                return false;
            }

            int[] guessedDigits = new int[DigitsNumber];

            for (int index = 0; index < DigitsNumber; index++)
            {
                if (!int.TryParse(guess[index].ToString(), out guessedDigits[index]))
                {
                    return false;
                }

                if (guessedDigits[index] == this.digits[index])
                {
                    bulls++;
                }
                else if (this.digits.Contains(guessedDigits[index]))
                {
                    cows++;
                }
            }

            return true;
        }

        private void Help()
        {
            if (this.helpUsedCount == DigitsNumber)
            {
                Console.WriteLine(HelpUnavailableText);
            }
            else
            {
                int helpPosition;

                do
                {
                    helpPosition = this.randomDigit.Next(DigitsNumber);
                }
                while (this.helpDigits[helpPosition] != 'X');

                this.helpDigits[helpPosition] = char.Parse(this.digits[helpPosition].ToString());
                this.helpUsedCount++;

                Console.WriteLine("{0} {1}", HelpAvailableText, new string(this.helpDigits));
            }
        }

        private void ManageNumbersCommand(string inputLine)
        {
            int bullsCount = 0;
            int cowsCount = 0;

            if (this.IsGuessCorrect(inputLine, out bullsCount, out cowsCount))
            {
                this.atemptsCount++;

                if (bullsCount == DigitsNumber)
                {
                    Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts and {1} cheats.", this.atemptsCount, this.helpUsedCount);
                    Console.WriteLine(new string('-', 80));

                    ScoreBoard scoreBoard = ScoreBoard.GetInstance();
                    if (this.helpUsedCount == 0 && scoreBoard.IsHighScore(this.atemptsCount))
                    {
                        Console.WriteLine(ScoreBoardEnterAllowedText);

                        string name = Console.ReadLine();
                        scoreBoard.Add(name, this.atemptsCount);
                    }
                    else
                    {
                        Console.WriteLine(ScoreBoardEnterUnallowedText);
                    }

                    scoreBoard.PrintScoreBoard();

                    this.isGameRunning = false;
                }
                else
                {
                    Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}\n", bullsCount, cowsCount);
                }                
            }
            else
            {
                Console.WriteLine("Wrong input format!\n");
            }
        }
    }
}