[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCows
{
    using System;

    /// <summary>
    /// The play class of the program. Contains the main method.
    /// </summary>
    public class PlayGame
    {
        /// <summary>
        /// The main method of the program. Starts the game.
        /// </summary>
        public static void Main()
        {
            PlayEngine newBullsAndCowsGame = new PlayEngine();
            newBullsAndCowsGame.StartGame();
        }
    }
}
