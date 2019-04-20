using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private DataBaseContext db;
        public TokenRepository(DataBaseContext db)
        {
            this.db = db;
        }

        public Token GetToken(string jwt, Guid userID)
        {
            Token token = db.Tokens.Where(t => t.jwt == jwt && t.userID == userID).First();
            return token;
        }

        public void AddToken(Token token)
        {
            db.Tokens.Add(token);
            db.SaveChanges();
        }
        
        public void RemoveToken(Token token)
        {
            db.Tokens.Remove(token);
            db.SaveChanges();
        }
    }
}
