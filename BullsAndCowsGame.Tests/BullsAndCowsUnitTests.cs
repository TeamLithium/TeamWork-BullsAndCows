[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCowsGame.Tests
{
    using System;
    using BullsAndCows;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BullsAndCowsUnitTests
    {
        [TestMethod]
        public void CheckRandomGenerator()
        {
            BullsAndCows secretNumberOne = new BullsAndCows();
            Thread.Sleep(500);
            BullsAndCows secretNumberTwo = new BullsAndCows();

            Assert.AreEqual(false, secretNumberOne.SecretDigits == secretNumberTwo.SecretDigits);
        }
    }
}
