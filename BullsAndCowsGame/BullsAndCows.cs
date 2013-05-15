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
        private const string ScoreBoardEnterAllowedText = "Please enter your name for the top scoreboard: ";
        private const string ScoreBoardEnterUnallowedText = "You are not allowed to enter the top scoreboard.";

        private Random randomDigit = new Random();
        private List<int> digits;
        private char[] helpDigits;
        private bool isGameRunning = true;
        private int helpUsedCount;
        private int atemptsCount;
        private ScoreBoard scoreBoard;

        public BullsAndCows()
        {            
            this.scoreBoard = new ScoreBoard();
        }

        public void StartGame()
        {
            Console.WriteLine(StartText);
            this.digits = new List<int>();
            this.CreateRandomDigits();
            this.helpUsedCount = 0;
            this.atemptsCount = 0;

            do
            {
                Console.WriteLine(EnterGuessText);
                string inputLine = Console.ReadLine().Trim().ToLower();

                if (inputLine.CompareTo("help") == 0)
                {
                    this.RevealRandomDigit();
                }
                else if (inputLine.CompareTo("top") == 0)
                {
                    Console.WriteLine(this.scoreBoard);
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

        private void RevealRandomDigit()
        {
            if (this.helpUsedCount == DigitsNumber)
            {
                Console.WriteLine("You cannot use more help.\nGame Over.\n");
                this.StartGame();
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

                Console.WriteLine("The number looks like " + new string(this.helpDigits));
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

                    if (this.helpUsedCount == 0 && this.scoreBoard.IsHighScore(this.atemptsCount))
                    {
                        Console.WriteLine(ScoreBoardEnterAllowedText);

                        string name = Console.ReadLine();
                        this.scoreBoard.Add(name, this.atemptsCount);
                    }
                    else
                    {
                        Console.WriteLine(ScoreBoardEnterUnallowedText);
                    }

                    Console.WriteLine(this.scoreBoard);
                    this.StartGame();
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