using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Test
    {
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
