[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCows
{
    using System;

    public class PlayEngine
    {
        private const string StartText = "Welcome to “Bulls and Cows” game.Please try to guess my secret 4-digit number.\n" +
                                                "Use 'top' to view the top scoreboard, 'restart' to start a new game\n" +
                                                "and 'help' to cheat and 'exit' to quit the game.\n";

        private const string ScoreBoardEnterAllowedText = "Please enter your name for the top scoreboard: ";
        private const string ScoreBoardEnterUnallowedText = "You are not allowed to enter the top scoreboard.";

        private bool isGameRunning = true;
        private int helpUsedCount;
        private int atemptsCount;
        private ScoreBoard scoreBoard = new ScoreBoard();

        public void StartGame()
        {
            Console.WriteLine(StartText);

            BullsAndCows secretNumber = new BullsAndCows();
            secretNumber.CreateRandomDigits();
            this.helpUsedCount = 0;
            this.atemptsCount = 0;

            do
            {
                Console.WriteLine("Enter your guess or command: ");
                string inputLine = Console.ReadLine().Trim().ToLower();

                switch (inputLine)
                {
                    case "help": 
                        secretNumber.RevealRandomDigit(ref this.helpUsedCount);
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
                        this.ManageNumbersCommand(inputLine, secretNumber);
                        break;
                }
            }
            while (this.isGameRunning);
        }

        private void ManageNumbersCommand(string inputLine, BullsAndCows secretNumber)
        {
            int bullsCount = 0;
            int cowsCount = 0;

            if (secretNumber.IsGuessCorrect(inputLine, out bullsCount, out cowsCount))
            {
                this.atemptsCount++;

                if (bullsCount == secretNumber.DigitsNumber)
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
