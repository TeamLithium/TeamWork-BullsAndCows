[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCowsGame.Tests
{
    using System;
    using BullsAndCows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ScoreBoardUnitTests
    {
        [TestMethod]
        public void ScoreBoardAddTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.Add("Pesho", 5);
            Assert.AreEqual(1, scoreBoard.Count());
        }

        [TestMethod]
        public void ScoreBoardKeeps5HighScoresTrueTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            for (int index = 0; index < 10; index++)
            {
                scoreBoard.Add("Pesho", 2);
            }

            Assert.AreEqual(5, scoreBoard.Count());
        }

        [TestMethod]
        public void EmtpyScoreBoardTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            string expected = "Scoreboard empty!" + Environment.NewLine;
            Assert.AreEqual(expected, scoreBoard.ToString());
        }

        [TestMethod]
        public void IsHighScoreTrueTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            for (int index = 0; index < scoreBoard.BoardSize; index++)
            {
                scoreBoard.Add("Pesho", 5);
            }

            Assert.IsTrue(scoreBoard.IsHighScore(3));
        }

        [TestMethod]
        public void IsHighScoreFalseTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            for (int index = 0; index < scoreBoard.BoardSize; index++)
            {
                scoreBoard.Add("Pesho", 1);
            }

            Assert.IsFalse(scoreBoard.IsHighScore(4));
        }

        [TestMethod]
        public void TestScoreboardPrinting()
        {
            int results = 2;
            ScoreBoard scoreBoard = new ScoreBoard();
            for (int index = 0; index < results; index++)
            {
                scoreBoard.Add("Pesho", index + 1);
            }

            Assert.AreEqual(scoreBoard.ToString(), string.Format("{0}\r\n{1}\r\n{2}\r\n\r\n",
                                                                    "Scoreboard:",
                                                                    "1. Pesho --> 1 guesses",
                                                                    "2. Pesho --> 2 guesses"));
        }
    }
}
