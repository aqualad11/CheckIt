using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{
    public interface IUserRepository
    {
        User getUserbyID(Guid userID);
        User getUserbyEmail(string email);
        Guid getUserIDbyEmail(string email);

        void addUser(User user);
        void updateUser(User user);
        void removeUser(User user);
    }
}
