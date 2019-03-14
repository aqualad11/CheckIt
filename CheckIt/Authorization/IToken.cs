using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.Authorizations
{
    public interface IToken
    {
        List<string> GetActions();
        string GetClient();
        int GetHeight();
    }
}
