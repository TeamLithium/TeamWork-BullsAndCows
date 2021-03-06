﻿[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCowsGame.Tests
{
    using System;
    using BullsAndCows;
    using System.Threading;
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
            BullsAndCowsNumber game = new BullsAndCowsNumber();

            Type type = typeof(BullsAndCowsNumber);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls = 0;
            int cows = 0;
            game.IsGuessCorrect("1111", ref bulls, ref cows);
            Assert.IsTrue(bulls == 1 && cows == 0);
        }

        [TestMethod]
        public void OneBullAndTwoCowsTest()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCowsNumber game = new BullsAndCowsNumber();

            Type type = typeof(BullsAndCowsNumber);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls = 0;
            int cows = 0;
            game.IsGuessCorrect("3211", ref bulls, ref cows);
            Assert.IsTrue(bulls == 1 && cows == 2);
        }

        [TestMethod]
        public void ZeroBullsAndZeroCowsTest()
        {
            BullsAndCowsNumber game = new BullsAndCowsNumber();
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };

            Type type = typeof(BullsAndCowsNumber);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls = 0;
            int cows = 0;
            game.IsGuessCorrect("5699", ref bulls, ref cows);
            Assert.IsTrue(bulls == 0 && cows == 0);
        }

        [TestMethod]
        public void FourBullsTest()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCowsNumber game = new BullsAndCowsNumber();

            Type type = typeof(BullsAndCowsNumber);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls = 0;
            int cows = 0;
            game.IsGuessCorrect("1234", ref bulls, ref cows);
            Assert.IsTrue(bulls == 4 && cows == 0);
        }

        [TestMethod]
        public void FourCowsTest()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCowsNumber game = new BullsAndCowsNumber();

            Type type = typeof(BullsAndCowsNumber);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls = 0;
            int cows = 0;
            game.IsGuessCorrect("4321", ref bulls, ref cows);
            Assert.IsTrue(bulls == 0 && cows == 4);
        }

        [TestMethod]
        public void OneCowTestWithTwoEqualDigitsInTheGuess()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCowsNumber game = new BullsAndCowsNumber();

            Type type = typeof(BullsAndCowsNumber);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls = 0;
            int cows = 0;
            game.IsGuessCorrect("2528", ref bulls, ref cows);
            Assert.IsTrue(bulls == 0 && cows == 1);
        }

        [TestMethod]
        public void OneBullAndZeroCowsTestWithTwoEqualDigitsInTheGuess()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCowsNumber game = new BullsAndCowsNumber();

            Type type = typeof(BullsAndCowsNumber);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls = 0;
            int cows = 0;
            game.IsGuessCorrect("2259", ref bulls, ref cows);
            Assert.IsTrue(bulls == 1 && cows == 0);
        }

        [TestMethod]
        public void ThreeCowsOneBullTest()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCowsNumber game = new BullsAndCowsNumber();

            Type type = typeof(BullsAndCowsNumber);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls = 0;
            int cows = 0;
            game.IsGuessCorrect("2431", ref bulls, ref cows);
            Assert.IsTrue(bulls == 1 && cows == 3);
        }

        [TestMethod]
        public void TwoBullsTwoCowsTest()
        {
            List<int> secretNumber = new List<int>() { 1, 2, 3, 4 };
            BullsAndCowsNumber game = new BullsAndCowsNumber();

            Type type = typeof(BullsAndCowsNumber);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls = 0;
            int cows = 0;
            game.IsGuessCorrect("4231", ref bulls, ref cows);
            Assert.IsTrue(bulls == 2 && cows == 2);
        }

        [TestMethod]
        public void OneBullOneCowTest()
        {
            List<int> secretNumber = new List<int>() { 5, 5, 8, 9 };
            BullsAndCowsNumber game = new BullsAndCowsNumber();

            Type type = typeof(BullsAndCowsNumber);
            var fieldValue = type.GetField("secretDigits", BindingFlags.Instance | BindingFlags.NonPublic);
            fieldValue.SetValue(game, secretNumber);

            int bulls = 0;
            int cows = 0;
            game.IsGuessCorrect("4553", ref bulls, ref cows);
            Assert.IsTrue(bulls == 1 && cows == 1);
        }

        [TestMethod]
        public void CheckRandomGenerator()
        {
            BullsAndCowsNumber secretNumberOne = new BullsAndCowsNumber();
            Thread.Sleep(100);
            BullsAndCowsNumber secretNumberTwo = new BullsAndCowsNumber();

            Assert.AreEqual(false, secretNumberOne.SecretDigits == secretNumberTwo.SecretDigits);
        }

        [TestMethod]
        public void CheckGuessWithGreaterLenght()
        {
            BullsAndCowsNumber secretNumber = new BullsAndCowsNumber();

            string guess = "12345";
            int bulls = 0, cows = 0;

            Assert.IsFalse(secretNumber.IsGuessCorrect(guess, ref bulls, ref cows));
        }

        [TestMethod]
        public void CheckIncorectGuessAtempt()
        {
            BullsAndCowsNumber secretNumber = new BullsAndCowsNumber();

            string guess = "pesh";
            int bulls = 0, cows = 0;

            Assert.IsFalse(secretNumber.IsGuessCorrect(guess, ref bulls, ref cows));
        }

        [TestMethod]
        public void TestMaxHelpsUsed()
        {
            BullsAndCowsNumber secretNumber = new BullsAndCowsNumber();
            int usedHelps = secretNumber.DigitsNumber;

            string expected = secretNumber.RevealRandomDigit(ref usedHelps);

            Assert.AreEqual(expected, "You cannot use more help.\r\nGame Over.");
        }

        [TestMethod]
        public void TestHelpDigitsOutput()
        {
            BullsAndCowsNumber secretNumber = new BullsAndCowsNumber();
            int usedHelps = 0;
            int firstSectetDigit = secretNumber.SecretDigits / 1000;

            string expected = secretNumber.RevealRandomDigit(ref usedHelps);

            Assert.AreEqual(expected, string.Format("The numbers look like {0}XXX", firstSectetDigit));
        }

        [TestMethod]
        public void TestHelpDigitsOutputOnlyDigits()
        {
            BullsAndCowsNumber secretNumber = new BullsAndCowsNumber();
            int usedHelps = 0;
            int secretDigits = secretNumber.SecretDigits;

            for (int index = 0; index < secretNumber.DigitsNumber - 1; index++)
            {
                secretNumber.RevealRandomDigit(ref usedHelps);
            }
            string expected = secretNumber.RevealRandomDigit(ref usedHelps);
            

            Assert.AreEqual(expected, string.Format("The numbers look like {0}", secretDigits));
        }
    }
}
