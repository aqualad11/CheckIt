using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;

namespace CheckIt.ServiceLayer
{
    public class UADService
    {
        public List<int> GetTimePerPageBarChart()
        {
            //From Logs, make count variables for "navigated to home, search, about, profile, dashboard" 
            //List = 5
            throw new NotImplementedException();
        }

        public List<int> GetLoginsBarChart()
        {
            //From Logs, get all "user logged in, user failed to log in" and add them for total logins. 
            //List = 3
            throw new NotImplementedException();
        }

        public List<int> GetLoginsAndUsersBarChart()
        {
            //From Logs, Get all "user logged in" with X months (jan-dec), add these 12 to the list. Then from DAL/UserRepository, GetCount(jan,2019) -> (dec-2019) then add these 12 to the list
            //List = 24
            throw new NotImplementedException();
        }

        public List<int> GetTopFiveFeaturesBarChart()
        {
            //From Logs, Get all "used Search", "Went to watchlist", "Went to Profile settings", "Went to dashboard", "Clicked Item url" add these to the list
            //List = 5
            throw new NotImplementedException();
        }

        public List<int> GetAverageSessionBarChart()
        {
            //Default
            throw new NotImplementedException();
        }

        public List<int> GetAverageSessionLineChart()
        {
            //Default
            throw new NotImplementedException();
        }

        public List<int> GetAverageLoggedInUsersLineChart()
        {
            //From Logs, Get all "user logged in" with X months (jan-Jun), add these 12 to the list.
            throw new NotImplementedException();
        }
    }
}
