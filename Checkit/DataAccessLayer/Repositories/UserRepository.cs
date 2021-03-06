﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataBaseContext db;

        public UserRepository(DataBaseContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Retrieves User from Database using their email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User, or null if user is null</returns>
        public User GetUserbyEmail(string email)
        {
            var user = db.Users.Where(u => u.userEmail == email).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Retrieves User from Database using their ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>User, or null if user is null</returns>
        public User GetUserbyID(Guid userID)
        {
            var user = db.Users.Where(u => u.userID == userID).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Retrieves User from Database using their ssoID
        /// </summary>
        /// <param name="ssoID"></param>
        /// <returns>User, or null if user is null</returns>
        public User  GetUserbySSOID(Guid ssoID)
        {
            var user = db.Users.Where(u => u.ssoID == ssoID).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Retrieves a user's ID from the database using their email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Guid GetUserIDbyEmail(string email)
        {
            Guid userID = db.Users.Where(u => u.userEmail == email).Select(u => u.userID).FirstOrDefault();
            return userID;
        }

        public int GetCountOfAllUsers()
        {
            int count = db.Users.Count();
            return count;
        }

        public List<User> GetAllUsers()
        {
            var users = db.Users.ToList();
            return users;
        }

        
        public int GetCount(int month, int year)
        {
            int count = db.Users.Where(u => u.createdAt.Month == month && u.createdAt.Year == year).Count();
            return count;
        }
        

        /// <summary>
        /// Adds the User passed in to the Database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True if successful, else reutrns false.</returns>
        public void AddUser(User user)
        {
            
            db.Users.Add(user);
            db.SaveChanges();
              
            
        }

        //throws System.Data.Entity.Infrastructure.DbUpdateConcurrencyException
        //if user does not exist in DB
        //throws System.ArgumentNullException
        //if user is null
        /// <summary>
        /// Updates user in the database
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateConcurrencyException">Thrown if user does not exist in DB</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if user is null</exception>
        public void UpdateUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        //TODO: figure out where to handle an empty user or user that does not exist
        //throws System.InvalidOperationException if user not found
        //throws ArgumentNullException if null user passed in
        /// <summary>
        /// Removes user from the database
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="System.InvalidOperationException">Thrown if user is not found</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if user is null</exception>
        public void RemoveUser(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
    }
}
