[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class that holds the computer's secret number
    /// </summary>
    public class BullsAndCowsNumber
    {
        /// <summary>
        /// A readonly field which contains the number of digits in the secret number
        /// </summary>
        public readonly int DigitsNumber = 4;

        private Random randomDigit = new Random();

        /// <summary>
        /// List that holds the digits in the secret number
        /// </summary>
        private List<int> secretDigits;

        /// <summary>
        /// Char string which initially contains XXXX. After calling the RevealRandomDigit method 
        /// one random X is replaced with a number from the secretDigits list
        /// </summary>
        private char[] helpDigits;

        /// <summary>
        /// Constructor for the class
        /// </summary>
        public BullsAndCowsNumber()
        {
            this.secretDigits = new List<int>();
            this.CreateRandomDigits();
        }

        /// <summary>
        /// Basic property for the secretDigits list. Returns the secretDigits as an integer number
        /// </summary>
        public int SecretDigits
        {
            get
            {
                int number = 0;

                for (int index = 0; index < this.DigitsNumber; index++)
                {
                    number = (number * 10) + this.secretDigits[index];
                }

                return number;
            }
        }

        /// <summary>
        /// Checks if user guess is correct and if true, returns the number of bulls and cows
        /// in the guess.
        /// </summary>
        /// <param name="guess">Pass the guess as a string</param>
        /// <param name="bulls">A pointer to the bulls variable</param>
        /// <param name="cows">A pointer to the bulls cows</param>
        public bool IsGuessCorrect(string guess, ref int bulls, ref int cows)
        {
            if (guess.Length != this.DigitsNumber)
            {
                return false;
            }

            int[] guessedDigits = new int[this.DigitsNumber];
            bool[] checkedDigits = new bool[this.DigitsNumber];

            for (int index = 0; index < this.DigitsNumber; index++)
            {
                if (!int.TryParse(guess[index].ToString(), out guessedDigits[index]))
                {
                    return false;
                }

                if (guessedDigits[index] == this.secretDigits[index])
                {
                    if (checkedDigits[index])
                    {
                        cows--;
                    }
                    else
                    {
                        checkedDigits[index] = true;
                    }

                    bulls++;
                }
                else if (this.secretDigits.Contains(guessedDigits[index]))
                {
                    int indexOfCow = this.secretDigits.IndexOf(guessedDigits[index]);
                    if (!checkedDigits[indexOfCow])
                    {
                        checkedDigits[indexOfCow] = true;
                        cows++;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the max amount of helps is used. If used returns a string containing apropriate 
        /// message. If not used changes the first X to a number in the helpDigits string
        /// and returns a string containing a message with the numbers
        /// </summary>
        /// <param name="helpUsedCount">Pass the number of helps currently used as a refference</param>
        public string RevealRandomDigit(ref int helpUsedCount)
        {
            if (helpUsedCount == this.DigitsNumber)
            {
                string overMessage = "You cannot use more help.\r\nGame Over.";

                return overMessage; 
            }
            else
            {
                int helpPosition = 0;
                bool isPositionFound = false;

                for (int index = 0; (index < this.DigitsNumber) && !isPositionFound; index++)
                {
                    if (this.helpDigits[index] == 'X')
                    {
                        helpPosition = index;
                        isPositionFound = true;                        
                    }
                }

                this.helpDigits[helpPosition] = char.Parse(this.secretDigits[helpPosition].ToString());
                helpUsedCount++;

                return String.Format("The numbers look like {0}", new string(this.helpDigits));
            }
        }

        /// <summary>
        /// A private method filling the list of digits (secretDigits). And the helpDigits with X's
        /// </summary>
        private void CreateRandomDigits()
        {
            for (int index = 0; index < this.DigitsNumber; index++)
            {
                if (index == 0)
                {
                    this.secretDigits.Add(this.randomDigit.Next(1, 10));
                }
                else
                {
                    this.secretDigits.Add(this.randomDigit.Next(0, 10));
                }
            }

            this.helpDigits = new char[this.DigitsNumber];

            for (int index = 0; index < this.DigitsNumber; index++)
            {
                this.helpDigits[index] = 'X';
            }
        }
    }
}