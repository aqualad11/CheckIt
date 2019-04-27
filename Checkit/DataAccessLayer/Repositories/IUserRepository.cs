using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public interface IUserRepository
    {
        User GetUserbyID(Guid userID);
        User GetUserbyEmail(string email);
        Guid GetUserIDbyEmail(string email);

        void AddUser(User user);
        void UpdateUser(User user);
        void RemoveUser(User user);
    }
}
