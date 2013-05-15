[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCowsGame.Tests
{
    using System;
    using BullsAndCows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Reflection;
    using System.Collections.Generic;

    [TestClass]
    public class BullsAndCowsUnitTests
    {
        [TestMethod]
        public void OneBullAndZeroCowsTest()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCows game = new BullsAndCows();

            Type type = typeof(BullsAndCows);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls = 0;
            int cows = 0;
            game.IsGuessCorrect("1111", out bulls, out cows);
            Assert.IsTrue(bulls == 1 && cows == 0);
        }

        [TestMethod]
        public void OneBullAndTwoCowsTest()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCows game = new BullsAndCows();

            Type type = typeof(BullsAndCows);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls, cows;
            game.IsGuessCorrect("3211", out bulls, out cows);
            Assert.IsTrue(bulls == 1 && cows == 2);
        }

        [TestMethod]
        public void ZeroBullsAndZeroCowsTest()
        {
            BullsAndCows game = new BullsAndCows();
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };            

            Type type = typeof(BullsAndCows);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls, cows;
            game.IsGuessCorrect("5699", out bulls, out cows);
            Assert.IsTrue(bulls == 0 && cows == 0);
        }

        [TestMethod]
        public void FourBullsTest()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCows game = new BullsAndCows();

            Type type = typeof(BullsAndCows);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls, cows;
            game.IsGuessCorrect("1234", out bulls, out cows);
            Assert.IsTrue(bulls == 4 && cows == 0);
        }

        [TestMethod]
        public void FourCowsTest()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCows game = new BullsAndCows();

            Type type = typeof(BullsAndCows);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls, cows;
            game.IsGuessCorrect("4321", out bulls, out cows);
            Assert.IsTrue(bulls == 0 && cows == 4);
        }

        [TestMethod]
        public void OneCowTestWithTwoEqualDigitsInTheGuess()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCows game = new BullsAndCows();

            Type type = typeof(BullsAndCows);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls, cows;
            game.IsGuessCorrect("2528", out bulls, out cows);
            Assert.IsTrue(bulls == 0 && cows == 1);
        }

        [TestMethod]
        public void OneBullAndZeroCowsTestWithTwoEqualDigitsInTheGuess()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCows game = new BullsAndCows();

            Type type = typeof(BullsAndCows);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls, cows;
            game.IsGuessCorrect("2259", out bulls, out cows);
            Assert.IsTrue(bulls == 1 && cows == 0);
        }

        [TestMethod]
        public void ThreeCowsOneBullTest()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCows game = new BullsAndCows();

            Type type = typeof(BullsAndCows);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls, cows;
            game.IsGuessCorrect("2431", out bulls, out cows);
            Assert.IsTrue(bulls == 1 && cows == 3);
        }

        [TestMethod]
        public void TwoBullsTwoCowsTest()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCows game = new BullsAndCows();

            Type type = typeof(BullsAndCows);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls, cows;
            game.IsGuessCorrect("4231", out bulls, out cows);
            Assert.IsTrue(bulls == 2 && cows == 2);
        }

        [TestMethod]
        public void OneBullOneCowTest()
        {
            List<int> secretNumber = new List<int>() { 5, 5, 3, 4 };
            BullsAndCows game = new BullsAndCows();

            Type type = typeof(BullsAndCows);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls, cows;
            game.IsGuessCorrect("9558", out bulls, out cows);
            Assert.IsTrue(bulls == 1 && cows == 1);
        }
    }
}
