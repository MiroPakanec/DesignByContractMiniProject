using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace BE
{
    [ContractClass(typeof(HangManContracts))]
    public interface IHangMan
    {
        IEnumerable<char> GetFullWord();
        string GetGuessedWord();
        ISet<char> GetUsedLetters();
        int GetErrorCount();
        int GetMaxErrors();
        bool GetGameOver();

        void GenerateWord(int length);
        void Guess(char letter);
        void SetMaxErrors(int count);
    }

    [ContractClassFor(typeof(IHangMan))]
    internal abstract class HangManContracts : IHangMan
    {
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(GetFullWord().Count() > 2, "The full word has to have at least 2 characters.");
        }

        public IEnumerable<char> GetFullWord()
        {
            Contract.Ensures(Contract.Result<IEnumerable<char>>() != null, "The full word cannot be null.");
            Contract.Ensures(Contract.Result<IEnumerable<char>>().Count() > 2,
                "The full word has to have at least 2 characters.");
            Contract.Ensures(Contract.Result<IEnumerable<char>>().Count() < 30,
                "The full word has to have at most 30 characters.");

            return default(IEnumerable<char>);
        }

        public string GetGuessedWord()
        {
            Contract.Requires(GetFullWord() != null, "The full word cannot be null.");
            Contract.Requires(GetFullWord().Count() > 2, "The full word has to have at least 2 characters.");
            Contract.Requires(GetFullWord().Count() < 30, "The full word has to have at least 2 characters.");

            Contract.Ensures(Contract.Result<string>() != null, "The guessed word cannot be null.");
            Contract.Ensures(Contract.Result<string>().Count() == GetFullWord().Count(),
                "The guessed word has to have the same length as full word.");

            return default(string);
        }

        public ISet<char> GetUsedLetters()
        {
            Contract.Ensures(Contract.Result<ISet<char>>() != null, "The full word cannot be null.");
            
            return default(ISet<char>);
        }

        public int GetErrorCount()
        {
            Contract.Ensures(Contract.Result<int>() >= 0, "Error count cannot be smaller than zero.");
            Contract.Ensures(Contract.Result<int>() <= GetMaxErrors(),
                "Error count has to be smaller or equal than maximum amount of erros.");

            return default(int);
        }

        public int GetMaxErrors()
        {
            Contract.Ensures(Contract.Result<int>() > 0, "Max Error count cannot be smaller than zero.");

            return default(int);
        }

        public bool GetGameOver()
        {
            return default(bool);
        }

        public void GenerateWord(int length)
        {
            Contract.Requires(length > 2, "The word has to be at least 2 characters long.");

            Contract.Ensures(GetFullWord() != null, "Full word cannot be null.");
            Contract.Ensures(GetFullWord().Count() == length, "Full word has to be equal to specified length.");
            Contract.Ensures(Contract.ForAll(0, GetFullWord().Count(), i => char.IsLetter(GetFullWord().ElementAt(i))),
                "Every character in the generated word has to be a letter.");

            Contract.Ensures(GetUsedLetters().Any() == false, "The used letter have to reset after a new word is generated.");
            Contract.Ensures(GetErrorCount() == 0, "Error count has to be zero after a new word is generated.");

            Contract.Ensures(
                Contract.ForAll(0, GetGuessedWord().Count(), i => char.IsLetter(GetFullWord().ElementAt(i)) == false),
                "The Guessed word has to be empty after a new word is generated.");
        }

        public void Guess(char letter)
        {
            Contract.Requires(letter != '\0', "Guessed character cannot be a defaut value.");
            Contract.Requires(char.IsLetter(letter), "Guessed character has to be a letter.");

            Contract.Ensures((Contract.OldValue(GetErrorCount()) < GetErrorCount()) == false ||
                             Contract.OldValue(GetUsedLetters().Count) < GetUsedLetters().Count);

            Contract.Ensures(
                Contract.OldValue(
                    GetGuessedWord()
                        .Where(char.IsLetter)
                        .ToString()
                        .Equals(GetGuessedWord().Where(char.IsLetter).ToString())) ||
                Contract.OldValue(GetUsedLetters().Count) < GetUsedLetters().Count);
        }

        public void SetMaxErrors(int count)
        {
            Contract.Requires(count > 0, "Count have to be greater than 0.");
            Contract.Ensures(GetMaxErrors() == count, "Max error count has to be equal to count.");
        }
    }
}
