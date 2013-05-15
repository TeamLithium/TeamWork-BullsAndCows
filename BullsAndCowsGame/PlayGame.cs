[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "Reviewed. Suppression is OK here.")]

namespace BullsAndCows
{
    using System;

    public class PlayGame
    {
        public static void Main()
        {
            PlayEngine newBullsAndCowsGame = new PlayEngine();
            newBullsAndCowsGame.StartGame();
        }
    }
}
