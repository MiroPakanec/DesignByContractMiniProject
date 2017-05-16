using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE
{
    public class TestHangmanImpl : IHangMan
    {
        private static Random random = new Random();
        private string _fullWord;
        private int errors = 0;
        private int _max_errors = 6;
        private ISet<char> guesses = new HashSet<char>();
        private char[] guessedWord;

        public void GenerateWord(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            _fullWord = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            guessedWord = Enumerable.Repeat<char>('_', length).ToArray();
        }

        public int GetErrorCount()
        {
            return errors;
        }

        public IEnumerable<char> GetFullWord()
        {
            return _fullWord;
        }

        public bool GetGameOver()
        {
            var word = GetGuessedWord();
            return errors > _max_errors || !GetGuessedWord().Contains('_');
        }

        public string GetGuessedWord()
        {
            return new string(guessedWord);
        }


        public int GetMaxErrors()
        {
            return _max_errors;
        }

        public ISet<char> GetUsedLetters()
        {
            return guesses;
        }

        public void Guess(char letter)
        {
            if(guesses.Contains(letter)) {
                return;
            }

            guesses.Add(letter);
            if (!_fullWord.ToLower().Contains(Char.ToLower(letter)))
            {
                errors++;
            } else
            {
                for (int i = 0; i < _fullWord.Length; i++)
                {
                    if (_fullWord[i] == letter)
                    {
                        StringBuilder sb = new StringBuilder(new string( guessedWord));
                        sb[i] = letter;
                        guessedWord = sb.ToString().ToCharArray();
                    }
                }
            }
        }

        public void SetMaxErrors(int count)
        {
            _max_errors = count;
        }
    }
}
