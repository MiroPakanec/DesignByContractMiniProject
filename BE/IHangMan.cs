using System;
using System.Diagnostics.Contracts;


namespace BE
{
    public interface IHangMan
    {
        
    }

    [ContractClassFor(typeof(IHangMan))]
    internal abstract class TestContract : IHangMan
    {
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(GetWeight() >= 0);
        }

        public int GetWeight()
        {
            Contract.Ensures(Contract.Result<string>()!= null);
            throw new NotImplementedException();
        }

        public void AddKgs(int kgs)
        {
            throw new NotImplementedException();
        }
    }
}
