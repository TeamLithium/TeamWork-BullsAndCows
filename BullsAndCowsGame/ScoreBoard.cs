[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class containing the high scores in a game.
    /// </summary>
    public class ScoreBoard
    {
        /// <summary>
        /// A readonly field containing the size of the high scores board
        /// </summary>
        public readonly int BoardSize = 5;

        /// <summary>
        /// List , containing users currently in the high scores board
        /// </summary>
        private List<KeyValuePair<string, int>> highScores;

        /// <summary>
        /// Constructor for the class. Initializes the highScores list
        /// </summary>
        public ScoreBoard()
        {
            this.highScores = new List<KeyValuePair<string, int>>();
        }

        /// <summary>
        /// Checks if a given score is an attempt
        /// </summary>
        /// <param name="score">Pass the number of attempts by the user.</param>
        /// <returns>True if the last of the scores in the sorted 
        /// highScore list has less attempts
        /// </returns>
        public bool IsHighScore(int score)
        {
            if (this.highScores.Count < this.BoardSize || this.highScores.Last().Value > score)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds ann attemt to the high scores board and removes the last 
        /// element of the list if the list has more elements than BoardSize
        /// </summary>
        /// <param name="name">Pass the user name as a string</param>
        /// <param name="score">Pass the number of attempts as an integer</param>
        public void Add(string name, int score)
        {
            this.highScores.Add(new KeyValuePair<string, int>(name, score));

            this.Sort();

            if (this.highScores.Count > this.BoardSize)
            {
                this.highScores.RemoveAt(this.highScores.Count - 1);
            }
        }

        /// <summary>
        /// Property which contains the number of high scores currently in the board
        /// </summary>
        public int Count()
        {
            return this.highScores.Count();
        }

        /// <summary>
        /// An override mothod for ToString(). Building the high scores board
        /// in an elegant and beautiful way. Almost sexy!
        /// </summary>
        /// <returns>String containing the formated high scores board</returns>
        public override string ToString()
        {
            StringBuilder scoreBoardAsString = new StringBuilder();

            if (this.highScores.Count == 0)
            {
                scoreBoardAsString.AppendLine("Scoreboard empty!");
            }
            else
            {
                scoreBoardAsString.AppendLine("Scoreboard:");

                for (int index = 0; index < this.highScores.Count; index++)
                {
                    string name = this.highScores[index].Key;
                    int attempts = this.highScores[index].Value;
                    scoreBoardAsString.AppendFormat("{0}. {1} --> {2} guesses", index + 1, name, attempts);
                    scoreBoardAsString.AppendLine();
                }

                scoreBoardAsString.AppendLine();
            }

            return scoreBoardAsString.ToString();
        }

        /// <summary>
        /// Void method which sorts the list of high score
        /// </summary>
        private void Sort()
        {
            this.highScores.Sort(new Comparison<KeyValuePair<string, int>>((first, second) => first.Value.CompareTo(second.Value)));
        }
    }
}