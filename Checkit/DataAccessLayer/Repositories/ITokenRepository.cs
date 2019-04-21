using CheckIt.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public interface ITokenRepository
    {
        Token GetToken(string jwt, Guid userID);

        bool AddToken(Token token);
        bool UpdateToken(Token token);
        bool RemoveToken(Token token);

    }
}
