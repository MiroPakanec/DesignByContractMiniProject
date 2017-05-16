using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace FE
{
    internal static class Printer
    {
        internal static void PrintGameDescription()
        {
            Console.WriteLine("Welcome to absolutely horrible game of hangman, please enter word length you want (2+):");
        }

        internal static void PrintRoundDescription(IHangMan hangman, int gameCounter)
        {
            Console.WriteLine();
            Console.WriteLine($"----------Round {gameCounter}----------");
            Console.WriteLine($"WORD: {hangman.GetGuessedWord()}");
            Console.WriteLine($"PAST GUESSES: {string.Join(",", hangman.GetUsedLetters())}");
            Console.WriteLine("Your next guess: ");
        }

        internal static void PrintResult(IHangMan hangman)
        {
            Console.WriteLine(hangman.GetErrorCount() < hangman.GetMaxErrors()
                ? "Congratzzzz, you won"
                : $"Tough luck, you lost. The word was {hangman.GetFullWord()}");
        }
    }
}
