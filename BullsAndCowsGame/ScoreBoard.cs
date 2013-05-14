using System;
using System.Collections.Generic;
using System.Linq;

public class ScoreBoard
{
    private const int BoardSize = 5;
    private static ScoreBoard scoreBoardInstance;
    private List<KeyValuePair<string, int>> score;

    private ScoreBoard()
    {
        this.score = new List<KeyValuePair<string, int>>();
    }

    private void Sort()
    {
        this.score.Sort(new Comparison<KeyValuePair<string, int>>((first, second) => second.Value.CompareTo(first.Value)));
    }

    public bool IsHighScore(int attempts)
    {
        if (this.score.Count < BoardSize || this.score.Last().Value < attempts)
        {
            return true;
        }

        return false;
    }

    public static ScoreBoard GetInstance()
    {
        if (scoreBoardInstance == null)
        {
            scoreBoardInstance = new ScoreBoard();
        }

        return scoreBoardInstance;
    }

    public void Add(string name, int attempts)
    {
        this.score.Add(new KeyValuePair<string, int>(name, attempts));
        this.Sort();
        if (this.score.Count > BoardSize)
        {
            this.score.RemoveAt(this.score.Count - 1);
        }
    }

    public void PrintScoreBoard()
    {
        if (this.score.Count == 0)
        {
            Console.WriteLine("Scoreboard empty!");
            Console.WriteLine();
            return;
        }

        this.Sort();
        Console.WriteLine("Scoreboard:");

        for (int index = 0; index < this.score.Count; index++)
        {
            string name = this.score[index].Key;
            int attempts = this.score[index].Value;
            Console.WriteLine("{0}. {1} --> {2} guesses", index + 1, name, attempts);
        }

        Console.WriteLine();
    }
}