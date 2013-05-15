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
        public void CheckHighScoreComparer()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            for (int index = 0; index < scoreBoard.BoardSize; index++)
            {
                scoreBoard.Add("Pesho", 5);
            }

            Assert.AreEqual(true, scoreBoard.IsHighScore(6));
        }
    }
}
