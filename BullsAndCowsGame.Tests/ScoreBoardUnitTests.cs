[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCowsGame.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BullsAndCows;

    [TestClass]
    public class ScoreBoardUnitTests
    {
        [TestMethod]
        public void ScoreBoardAddTest()
        {
            ScoreBoard board = new ScoreBoard();
            board.Add("Pesho", 5);
            Assert.AreEqual(1, board.Count());
        }
    }
}
