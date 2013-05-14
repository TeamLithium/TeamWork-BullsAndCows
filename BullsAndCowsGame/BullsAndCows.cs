﻿using System;
using System.Collections.Generic;
using System.Linq;

class BullsAndCows
{
    private const int DIGITS_NUMBER = 4;
    private const string START_TEXT = "Welcome to “Bulls and Cows” game.Please try to guess my secret 4-digit number.\n" +
                                            "Use 'top' to view the top scoreboard, 'restart' to start a new game\n" +
                                            "and 'help' to cheat and 'exit' to quit the game.";
    private const string ENTER_GUESS_TEXT = "Enter your guess or command: ";
    private const string HELP_TEXT = "The number looks like";
    private const string HELP_UNAVAILABLE_TEXT = "You cannot use more help.";
    private const string SCOREBOARD_ALLOWED_TEXT = "Please enter your name for the top scoreboard: ";
    private const string SCOREBOARD_UNALLOWED_TEXT = "You are not allowed to enter the top scoreboard.";

    private Random randomDigit;
    private List<int> digits;
    private char[] helpExpression;

    public BullsAndCows()
    {
        this.randomDigit = new Random();
    }

    private void SetDigits()
    {
        this.digits = new List<int>();

        for (int index = 0; index < DIGITS_NUMBER; index++)
        {
            digits.Add(randomDigit.Next(0, 10));
        }

        this.helpExpression = new char[DIGITS_NUMBER];

        for (int index = 0; index < DIGITS_NUMBER; index++)
        {
            helpExpression[index] = 'X';
        }
    }

    private bool ProccessGuess(string guess, out int bulls, out int cows)
    {
        bulls = 0;
        cows = 0;

        if (guess.Length != DIGITS_NUMBER)
        {
            return false;
        }

        int[] guessedDigits = new int[DIGITS_NUMBER];

        for (int index = 0; index < DIGITS_NUMBER; index++)
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
        int helpPosition = this.randomDigit.Next(DIGITS_NUMBER);

        while (this.helpExpression[helpPosition] != 'X')
        {
            helpPosition = this.randomDigit.Next(DIGITS_NUMBER);
        }
        this.helpExpression[helpPosition] = char.Parse(this.digits[helpPosition].ToString());

        return new string(this.helpExpression);
    }

    public void StartGame()
    {
        bool isGameRunning = true;
        int helpCount = 0;
        int atemptsCount = 0;

        Console.WriteLine(START_TEXT);
        SetDigits();

        do
        {
            Console.WriteLine(ENTER_GUESS_TEXT);
            string inputLine = Console.ReadLine().Trim().ToLower();

            if (inputLine.CompareTo("help") == 0)
            {
                if (helpCount == DIGITS_NUMBER)
                {
                    Console.WriteLine(HELP_UNAVAILABLE_TEXT);
                }
                else
                {
                    helpCount++;

                    Console.WriteLine("{0} {1}", HELP_TEXT, Help());
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
                Console.WriteLine(START_TEXT);

                SetDigits();
            }
            else if (inputLine.CompareTo("exit") == 0)
            {
                isGameRunning = false;
                Console.WriteLine("Good bye!");
            }
            else
            {
                ManageNumbersCommand(ref isGameRunning, helpCount, ref atemptsCount, inputLine);
            }
        }
        while (isGameRunning);
    }

    private void ManageNumbersCommand(ref bool isGameRunning, int helpCount, ref int atemptsCount, string inputLine)
    {
        int bullsCount = 0;
        int cowsCount = 0;

        if (!ProccessGuess(inputLine, out bullsCount, out cowsCount))
        {
            Console.WriteLine("Wrong input format!");
        }
        else
        {
            atemptsCount++;

            if (bullsCount == DIGITS_NUMBER)
            {
                Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts and {1} cheats.", atemptsCount, helpCount);
                Console.WriteLine(new string('-', 80));

                ScoreBoard scoreBoard = ScoreBoard.GetInstance();
                if (helpCount == 0 && scoreBoard.IsHighScore(atemptsCount))
                {
                    Console.WriteLine(SCOREBOARD_ALLOWED_TEXT);

                    string name = Console.ReadLine();
                    scoreBoard.Add(name, atemptsCount);
                }
                else
                {
                    Console.WriteLine(SCOREBOARD_UNALLOWED_TEXT);
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

    public static void Main()
    {
        BullsAndCows newGame = new BullsAndCows();
        newGame.StartGame();
    }
}