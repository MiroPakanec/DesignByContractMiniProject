using BE;
using System;

namespace FE
{
    internal class Game
    {
        private readonly IHangMan _hangman;
        private int _gameCounter;

        internal Game(IHangMan hangman)
        {
            _hangman = hangman;
            _gameCounter = 0;
        }

        internal void Restart()
        {
            Printer.PrintGameDescription();

            var wordLength = Convert.ToInt32(Console.ReadLine());
            _hangman.GenerateWord(wordLength);
        }

        internal void Play()
        {
            Restart();

            while (_hangman.GetGameOver() == false)
            {
                Printer.PrintRoundDescription(_hangman, _gameCounter);
                var guess = Console.ReadKey().KeyChar;

                _hangman.Guess(guess);
                _gameCounter++;
            }

            Printer.PrintResult(_hangman);
            Console.Read();
        }
    }
}
