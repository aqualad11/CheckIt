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

        /// <summary>
        /// Gets token from the Database
        /// </summary>
        /// <param name="jwt"></param>
        /// <param name="userID"></param>
        /// <returns>Token object or null if Token does not exist</returns>
        public Token GetToken(string jwt, Guid userID)
        {
            Token token = db.Tokens.Where(t => t.jwt == jwt && t.userID == userID).FirstOrDefault();
            return token;
        }

        /// <summary>
        /// Addes Token to the database
        /// </summary>
        /// <param name="token"></param>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateException">
        /// Thrown if User does not exist in database.
        /// Thrown if Token is a duplicate
        /// </exception>
        public void AddToken(Token token)
        {
            db.Tokens.Add(token);
            db.SaveChanges();
        }

        /// <summary>
        /// Updates the Token in the Database. Used mainly to make a token invalid.
        /// </summary>
        /// <param name="token"></param>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateConcurrencyException">Thrown if Token does not exist in database</exception>
        public void UpdateToken(Token token)
        {
            db.Entry(token).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Removes Token from the database
        /// </summary>
        /// <param name="token"></param>
        /// <exception cref="System.InvalidOperationException">Thrown if Token does not exist in database.</exception>
        public void RemoveToken(Token token)
        {
            db.Tokens.Remove(token);
            db.SaveChanges();
            
        }
    }
}
