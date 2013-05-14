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
                                                "and 'help' to cheat and 'exit' to quit the game.";

        private const string EnterGuessText = "Enter your guess or command: ";
        private const string HelpAvailableText = "The number looks like";
        private const string HelpUnavailableText = "You cannot use more help.";
        private const string ScoreBoardEnterAllowedText = "Please enter your name for the top scoreboard: ";
        private const string ScoreBoardEnterUnallowedText = "You are not allowed to enter the top scoreboard.";

        private Random randomDigit = new Random();
        private List<int> digits;
        private char[] helpExpression;
        private bool isGameRunning = true;
        private int helpCount = 0;
        private int atemptsCount = 0;

        public BullsAndCows()
        {
            this.digits = new List<int>();
        }

        public void StartGame()
        {
            Console.WriteLine(StartText);
            this.SetDigits();

            do
            {
                Console.WriteLine(EnterGuessText);
                string inputLine = Console.ReadLine().Trim().ToLower();

                if (inputLine.CompareTo("help") == 0)
                {
                    if (this.helpCount == DigitsNumber)
                    {
                        Console.WriteLine(HelpUnavailableText);
                    }
                    else
                    {
                        this.helpCount++;

                        Console.WriteLine("{0} {1}", HelpAvailableText, this.Help());
                    }
                }
                else if (inputLine.CompareTo("top") == 0)
                {
                    ScoreBoard scoreboard = ScoreBoard.GetInstance();
                    scoreboard.PrintScoreBoard();
                }
                else if (inputLine.CompareTo("restart") == 0)
                {
                    helpCount = 0;
                    atemptsCount = 0;

                    Console.WriteLine();
                    Console.WriteLine(new string('-', 80));
                    Console.WriteLine(StartText);

                    this.SetDigits();
                }
                else if (inputLine.CompareTo("exit") == 0)
                {
                    isGameRunning = false;
                    Console.WriteLine("Good bye!");
                }
                else
                {
                    this.ManageNumbersCommand(ref isGameRunning, helpCount, ref atemptsCount, inputLine);
                }
            }
            while (isGameRunning);
        }

        private void SetDigits()
        {
            for (int index = 0; index < DigitsNumber; index++)
            {
                this.digits.Add(this.randomDigit.Next(0, 10));
            }

            this.helpExpression = new char[DigitsNumber];

            for (int index = 0; index < DigitsNumber; index++)
            {
                this.helpExpression[index] = 'X';
            }
        }

        private bool ProccessGuess(string guess, out int bulls, out int cows)
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

        private string Help()
        {
            int helpPosition = this.randomDigit.Next(DigitsNumber);

            while (this.helpExpression[helpPosition] != 'X')
            {
                helpPosition = this.randomDigit.Next(DigitsNumber);
            }

            this.helpExpression[helpPosition] = char.Parse(this.digits[helpPosition].ToString());

            return new string(this.helpExpression);
        }

        private void ManageNumbersCommand(ref bool isGameRunning, int helpCount, ref int atemptsCount, string inputLine)
        {
            int bullsCount = 0;
            int cowsCount = 0;

            if (!this.ProccessGuess(inputLine, out bullsCount, out cowsCount))
            {
                Console.WriteLine("Wrong input format!");
            }
            else
            {
                atemptsCount++;

                if (bullsCount == DigitsNumber)
                {
                    Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts and {1} cheats.", atemptsCount, helpCount);
                    Console.WriteLine(new string('-', 80));

                    ScoreBoard scoreBoard = ScoreBoard.GetInstance();
                    if (helpCount == 0 && scoreBoard.IsHighScore(atemptsCount))
                    {
                        Console.WriteLine(ScoreBoardEnterAllowedText);

                        string name = Console.ReadLine();
                        scoreBoard.Add(name, atemptsCount);
                    }
                    else
                    {
                        Console.WriteLine(ScoreBoardEnterUnallowedText);
                    }

                    scoreBoard.PrintScoreBoard();

                    isGameRunning = false;
                }
                else
                {
                    Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bullsCount, cowsCount);
                }
            }
        }
    }
}