[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCows
{
    using System;

    /// <summary>
    /// A class maintaining the commands and the user input. 
    /// </summary>
    public class PlayEngine
    {
        /// <summary>
        /// A constant string, containing the welcome message of the game
        /// </summary>
        private const string StartText = "Welcome to “Bulls and Cows” game.Please try to guess my secret 4-digit number.\n" +
                                                "Use 'top' to view the top scoreboard, 'restart' to start a new game\n" +
                                                "and 'help' to cheat and 'exit' to quit the game.\n";

        /// <summary>
        /// A bool variable which indicates if a game is currently running or not.
        /// </summary>
        private bool isGameRunning = true;

        /// <summary>
        /// Counts the number of helps used
        /// </summary>
        private int helpUsedCount;

        /// <summary>
        /// Counts the number of atempts by the user.
        /// </summary>
        private int atemptsCount;

        /// <summary>
        /// A variable of type ScoreBoard which contains the high scores in the game
        /// </summary>
        private ScoreBoard scoreBoard = new ScoreBoard();

        /// <summary>
        /// Stats the game, gets user input and using a switch statement selects the
        /// apropriate menu
        /// </summary>
        public void StartGame()
        {
            Console.WriteLine(StartText);

            BullsAndCowsNumber secretNumber = new BullsAndCowsNumber();
            this.helpUsedCount = 0;
            this.atemptsCount = 0;

            do
            {
                Console.WriteLine("Enter your guess or command: ");
                string inputLine = Console.ReadLine().Trim().ToLower();

                switch (inputLine)
                {
                    case "help": 
                        string digitsRevealed = secretNumber.RevealRandomDigit(ref this.helpUsedCount);
                        Console.WriteLine(digitsRevealed);
                        break;
                    case "top": 
                        Console.WriteLine(this.scoreBoard);
                        break;
                    case "restart":
                        Console.Clear();
                        this.StartGame();
                        break;
                    case "exit":
                        this.isGameRunning = false;
                        Console.WriteLine("Good bye!");
                        break;
                    default:
                        this.ManageUserGuess(inputLine, secretNumber);
                        break;
                }
            }
            while (this.isGameRunning);
        }

        /// <summary>
        /// A private method which manages the user guess if the input is a string 
        /// different than a command. If the guess is a string of numbers, the 
        /// method is executed completely. If not prints an apropriate message.
        /// </summary>
        private void ManageUserGuess(string inputLine, BullsAndCowsNumber secretNumber)
        {
            int bullsCount = 0;
            int cowsCount = 0;

            if (secretNumber.IsGuessCorrect(inputLine, ref bullsCount, ref cowsCount))
            {
                this.atemptsCount++;

                if (bullsCount == secretNumber.DigitsNumber)
                {
                    Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts and {1} cheats.", this.atemptsCount, this.helpUsedCount);
                    Console.WriteLine(new string('-', 80));

                    if (this.helpUsedCount == 0 && this.scoreBoard.IsHighScore(this.atemptsCount))
                    {
                        Console.WriteLine("Please enter your name for the top scoreboard: ");

                        string name = Console.ReadLine();
                        this.scoreBoard.Add(name, this.atemptsCount);
                    }
                    else
                    {
                        Console.WriteLine("You are not allowed to enter the top scoreboard.");
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
