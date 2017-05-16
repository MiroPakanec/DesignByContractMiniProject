using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;


namespace BE
{
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
        //[ContractInvariantMethod]
        //private void ObjectInvariant()
        //{
        //    Contract.Invariant();
        //}

        public IEnumerable<char> GetFullWord()
        {
            Contract.Ensures(Contract.Result<IEnumerable<char>>() != null, "The full word cannot be null.");
            Contract.Ensures(Contract.Result<IEnumerable<char>>().Count() > 2, "The full word has to have at least 2 characters.");
            Contract.Ensures(Contract.Result<IEnumerable<char>>().Count() < 30, "The full word has to have at most 30 characters.");

            return default(IEnumerable<char>);
        }

        public string GetGuessedWord()
        {
            Contract.Requires(Contract.Result<IEnumerable<char>>() != null, "The full word cannot be null.");
            Contract.Requires(GetFullWord().Count() > 2, "The full word has to have at least 2 characters.");
            Contract.Requires(GetFullWord().Count() < 30, "The full word has to have at least 2 characters.");

            Contract.Ensures(Contract.Result<string>() != null, "The guessed word cannot be null.");
            Contract.Ensures(Contract.Result<string>().Count() == GetFullWord().Count(), "The guessed word has to have the same length as full word.");

            return default(string);
        }

        public ISet<char> GetUsedLetters()
        {
            Contract.Ensures(Contract.Result<ISet<char>>() != null, "The full word cannot be null.");
            //Contract.Ensures(Contract.ForAll(0, Contract.Result<ISet<char>>().Count,
            //    i => char.IsLetter(Contract.Result<ISet<char>>().ElementAt(i))));
            
            return default(ISet<char>);
        }

        public int GetErrorCount()
        {
            Contract.Ensures(Contract.Result<int>() >= 0, "Error count cannot be smaller than zero.");
            Contract.Ensures(Contract.Result<int>() <= GetMaxErrors(), "Error count has to be smaller or equal than maximum amount of erros.");

            return default(int);
        }

        public int GetMaxErrors()
        {
            Contract.Ensures(Contract.Result<int>() > 0, "Max Error count cannot be smaller than zero.");

            return default(int);
        }


        public bool GetGameOver()
        {
            Contract.Ensures(GetErrorCount() == GetMaxErrors());

            return default(bool);
        }

        public void GenerateWord(int length)
        {
            throw new NotImplementedException();
        }

        public void Guess(char letter)
        {
            throw new NotImplementedException();
        }

        public void SetMaxErrors(int count)
        {
            throw new NotImplementedException();
        }
    }
}
