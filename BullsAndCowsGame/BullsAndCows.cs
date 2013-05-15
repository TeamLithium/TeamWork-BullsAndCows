[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BullsAndCows
    {
        public readonly int DigitsNumber = 4;
        private Random randomDigit = new Random();
        private List<int> secretDigits;
        private char[] helpDigits;

        public BullsAndCows()
        {
            this.secretDigits = new List<int>();
            this.CreateRandomDigits();
        }

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

        public bool IsGuessCorrect(string guess, out int bulls, out int cows)
        {
            bulls = 0;
            cows = 0;

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

        public void RevealRandomDigit(ref int helpUsedCount)
        {
            if (helpUsedCount == this.DigitsNumber)
            {
                Console.WriteLine("You cannot use more help.\nGame Over.\n");
            }
            else
            {
                int helpPosition;

                do
                {
                    helpPosition = this.randomDigit.Next(this.DigitsNumber);
                }
                while (this.helpDigits[helpPosition] != 'X');

                this.helpDigits[helpPosition] = char.Parse(this.secretDigits[helpPosition].ToString());
                helpUsedCount++;

                Console.WriteLine("The number looks like " + new string(this.helpDigits));
            }
        }

        private void CreateRandomDigits()
        {
            for (int index = 0; index < this.DigitsNumber; index++)
            {
                this.secretDigits.Add(this.randomDigit.Next(0, 10));
            }

            this.helpDigits = new char[this.DigitsNumber];

            for (int index = 0; index < this.DigitsNumber; index++)
            {
                this.helpDigits[index] = 'X';
            }
        }
    }
}