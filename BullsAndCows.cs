using System;
using System.Collections.Generic;
using System.Linq;

//napisah go nabyrzo ama NE SAM GO TESTVALA! probwaj dali raboti, maj ima bug ako sa 4 bika parvonanchalno
class BullsAndCows
{
    private const int DigitsNumber = 4;
    private const string START_EXPRESSION = "Welcome to “Bulls and Cows” game.Please try to guess my secret 4-digit number.\n" +
                                            "Use 'top' to view the top scoreboard, 'restart' to start a new game\n" +
                                            "and 'help' to cheat and 'exit' to quit the game.";
    private const string ENTER_GUES = "Enter your guess or command: ";
    private const string HELP = "The number looks like";
    private const string HELP_UNAVAILABLE = "You cannot use more help.";
    private const string WRONG_GUES = "Wrong number! ";
    private const string WRONG_INPUT = "Wrong input format! ";
    private const string IN_SCOREBOARD = "Please enter your name for the top scoreboard: ";
    private const string OUT_SCOREBOARD = "You are not allowed to enter the top scoreboard.";
    private const string EXIT_GAME = "Good bye!";

    private Random r;
    private List<int> digits;
    private char[] helpExpression;

    public BullsAndCows()
    {
        this.r = new Random();
        SetDigits();
    }

    private void SetDigits()
    {
        this.digits = new List<int>();
        for (int index = 0; index < DigitsNumber; index++)
        {
            digits.Add(r.Next(0, 10));
        }
        this.helpExpression = new char[DigitsNumber];
        for (int index = 0; index < DigitsNumber; index++)
        {
            helpExpression[index] = 'X';
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

        int[] guestedDigits = new int[DigitsNumber];
        for (int index = 0; index < DigitsNumber; index++)
        {
            if (!int.TryParse(guess[index].ToString(), out guestedDigits[index]))
            {
                return false;
            }

            if (guestedDigits[index] == this.digits[index])
            {
                bulls++;
            }
            else if (this.digits.Contains(guestedDigits[index]))
            {
                cows++;
            }
        }
        return true;
    }

    private string Help()
    {
        int helpPosition = this.r.Next(DigitsNumber);
        while (this.helpExpression[helpPosition] != 'X')
        {
            helpPosition = this.r.Next(DigitsNumber);
        }
        this.helpExpression[helpPosition] = char.Parse(this.digits[helpPosition].ToString());
        return new string(this.helpExpression);
    }

    public void StartGame()
    {
        while (true)
        {
            bool flag1 = false;
            int count2 = 0;
            int count1 = 0;
            Console.WriteLine(START_EXPRESSION);
            do
            {
                Console.WriteLine(ENTER_GUES);
                string line = Console.ReadLine().Trim().ToLower();

                if (line.CompareTo("help") == 0)
                {
                    if (count2 == DigitsNumber)
                    {
                        Console.WriteLine(HELP_UNAVAILABLE);
                        continue;
                    }
                    count2++;
                    string helpExpression = Help();
                    Console.WriteLine("{0} {1}", HELP, helpExpression);
                    continue;
                }
                else if (line.CompareTo("top") == 0)
                {
                    ScoreBoard scoreboard = ScoreBoard.GetInstance();
                    scoreboard.SortScoreBoard();
                }
                else if (line.CompareTo("restart") == 0)
                {
                    Console.WriteLine();
                    break;
                }
                else if (line.CompareTo("exit") == 0)
                {
                    flag1 = true;
                    Console.WriteLine(EXIT_GAME);
                    break;
                }

                int count3 = 0;
                int count4 = 0;
                if (!ProccessGuess(line, out count3, out count4))
                {
                    Console.WriteLine(WRONG_INPUT);
                    continue;
                }
                count1++;
                if (count3 == DigitsNumber)
                {
                    Console.WriteLine(count2 == 0 ? "Congratulations! You guessed the secret number in {0} attempts and {1} cheats." : "Congratulations! You guessed the secret number in {0} attempts.", count1, count2);
                    Console.WriteLine(new string('-', 80));

                    ScoreBoard scoreBoard = ScoreBoard.GetInstance();
                    if (count2 == 0 && scoreBoard.IsHighScore(count1))
                    {
                        Console.WriteLine(IN_SCOREBOARD);
                        string name = Console.ReadLine();
                        scoreBoard.Add(name, count1);
                    }
                    else
                    {
                        Console.WriteLine(OUT_SCOREBOARD);
                    }
                    scoreBoard.SortScoreBoard();
                    break;
                }
                else
                {
                    Console.WriteLine("{0} Bulls: {1}, Cows: {2}", WRONG_GUES, count3, count4);
                }
            }
            while (true);

            if (flag1)
            {
                break;
            }
            SetDigits();
        }
    }

    public static void Main()
    {
        BullsAndCows game = new BullsAndCows();
        game.StartGame();
    }
}