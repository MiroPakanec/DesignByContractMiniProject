using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE
{
    public class Game
    {
        private const string Exit_Keyword = "exit";
        private const string Restart_Keyword = "restart";
        private readonly IHangMan _hangman;
        public Game(IHangMan hangman)
        {
            _hangman = hangman;
        }

        public void Restart()
        {
            Console.WriteLine("Welcome to absolutely horrible game of hangman, please enter word length you want (3+):");
            int wordLength = Convert.ToInt32(Console.ReadLine());
            _hangman.GenerateWord(wordLength);
        }

        public void Play()
        {
            Restart();
            while(!_hangman.GetGameOver())
            {
                Console.WriteLine("WORD: {0}", _hangman.GetGuessedWord());
                Console.WriteLine("Past guesses: {0}", string.Join(",",_hangman.GetUsedLetters()));
                Console.WriteLine("To restart write '{0}', to exit write '{1}'", Restart_Keyword, Exit_Keyword);
                Console.WriteLine("Your next guess: ");
                char guess = Console.ReadKey().KeyChar;
                _hangman.Guess(guess);
            }
            if(_hangman.GetErrorCount() < _hangman.GetMaxErrors())
            {
                Console.WriteLine("Congratzzzz, you won");
            } else
            {
                Console.WriteLine("Tough luck, you lost. The word was {0}", _hangman.GetFullWord());
            }
            Console.Read();
        }
    }
}
