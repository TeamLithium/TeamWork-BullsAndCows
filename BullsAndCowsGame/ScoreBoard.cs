[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ScoreBoard
    {
        public readonly int BoardSize = 5;
        private List<KeyValuePair<string, int>> highScores;

        public ScoreBoard()
        {
            this.highScores = new List<KeyValuePair<string, int>>();
        }

        public bool IsHighScore(int attempts)
        {
            if (this.highScores.Count < this.BoardSize || this.highScores.Last().Value < attempts)
            {
                return true;
            }

            return false;
        }

        public void Add(string name, int attempts)
        {
            this.highScores.Add(new KeyValuePair<string, int>(name, attempts));

            this.Sort();

            if (this.highScores.Count > this.BoardSize)
            {
                this.highScores.RemoveAt(this.highScores.Count - 1);
            }
        }

        public int Count()
        {
            return this.highScores.Count();
        }

        public override string ToString()
        {
            StringBuilder scoreBoardAsString = new StringBuilder();

            if (this.highScores.Count == 0)
            {
                scoreBoardAsString.AppendLine("Scoreboard empty! \r\n");
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

        private void Sort()
        {
            this.highScores.Sort(new Comparison<KeyValuePair<string, int>>((first, second) => first.Value.CompareTo(second.Value)));
        }
    }
}