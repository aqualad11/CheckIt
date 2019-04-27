using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


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


        public bool AddToken(Token token)
        {
            try
            {
                db.Tokens.Add(token);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool UpdateToken(Token token)
        {
            try
            {
                db.Entry(token).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }catch(Exception e)//
            {
                return false;
            }
        }
        
        public bool RemoveToken(Token token)
        {
            try
            {
                db.Tokens.Remove(token);
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
            
        }
    }
}
