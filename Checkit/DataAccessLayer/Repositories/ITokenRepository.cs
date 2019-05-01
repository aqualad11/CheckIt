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

        void AddToken(Token token);
        void UpdateToken(Token token);
        void RemoveToken(Token token);

    }
}
