[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ScoreBoard
    {
        private const int BoardSize = 5;
        private static ScoreBoard scoreBoardInstance;
        private List<KeyValuePair<string, int>> highScores;

        public ScoreBoard()
        {
            this.highScores = new List<KeyValuePair<string, int>>();
        }

        public static ScoreBoard GetInstance()
        {
            if (scoreBoardInstance == null)
            {
                scoreBoardInstance = new ScoreBoard();
            }

            return scoreBoardInstance;
        }

        public bool IsHighScore(int attempts)
        {
            if (this.highScores.Count < BoardSize || this.highScores.Last().Value < attempts)
            {
                return true;
            }

            return false;
        }

        public void Add(string name, int attempts)
        {
            this.highScores.Add(new KeyValuePair<string, int>(name, attempts));

            this.Sort();

            if (this.highScores.Count > BoardSize)
            {
                this.highScores.RemoveAt(this.highScores.Count - 1);
            }
        }

        public void PrintScoreBoard()
        {
            if (this.highScores.Count == 0)
            {
                Console.WriteLine("Scoreboard empty! \r\n");
            }
            else
            {
                Console.WriteLine("Scoreboard:");

                for (int index = 0; index < this.highScores.Count; index++)
                {
                    string name = this.highScores[index].Key;
                    int attempts = this.highScores[index].Value;
                    Console.WriteLine("{0}. {1} --> {2} guesses", index + 1, name, attempts);
                }

                Console.WriteLine();
            }
        }

        private void Sort()
        {
            this.highScores.Sort(new Comparison<KeyValuePair<string, int>>((first, second) => second.Value.CompareTo(first.Value)));
        }
    }
}