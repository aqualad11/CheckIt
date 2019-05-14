using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer.Repositories;
using CheckIt.DataAccessLayer;
using System.IO;
using System.Globalization;

namespace CheckIt.ServiceLayer
{
    public class UADService
    {
        public Config config = new Config();

        public List<int> GetTimePerPageBarChart()
        {
            //From Logs, make count variables for "navigated to home, search, about, profile, dashboard" 
            //List = 5

            // GetPageStats
            var list = GetPageStats();
            return list;
        }

        public List<int> GetLoginsBarChart()
        {
            //From Logs, get all "user logged in, user failed to log in" and add them for total logins. 
            //List = 3

            //GetLoginStats
            var list = GetLoginStats();
            return list;
        }

        public List<int> GetLoginsAndUsersBarChart()
        {
            //From Logs, Get all "user logged in" with X months (jan-dec), add these 12 to the list. Then from DAL/UserRepository, GetCount(jan,2019) -> (dec-2019) then add these 12 to the list
            //List = 24
            //GetUsersPerMonthStats
            throw new NotImplementedException();
        }

        public List<int> GetTopFiveFeaturesBarChart()
        {
            //From Logs, Get all "used Search", "Went to watchlist", "Went to Profile settings", "Went to dashboard", "Clicked Item url" add these to the list
            //List = 5

            // GetFeatureStats
            var list = GetFeatureStats();
            return list;
        }

        public List<int> GetAverageSessionBarChart()
        {
            var list = new List<int>(new int[36]);
            for(int i = 0; i<36; i++)
            {
                if (i < 12) list[i] = 20;
                else if (i < 24) list[i] = 40;
                else list[i] = 60;
            }
            return list;
        }

        public List<int> GetAverageSessionLineChart()
        {
            return new List<int> { 20, 45, 40, 15, 55, 70 };
        }

        public List<int> GetAverageLoggedInUsersLineChart()
        {
            // From Logs, Get all "user logged in" with X months (jan-Jun), add these 6 to the list.
            // AND desciption and date
            // Clear date and description variables after each log
            var list = GetLoggedInPerMonthStats(6);
            return list;
        }

        public List<int> GetPageStats()
        {
            DirectoryInfo path = new DirectoryInfo(config.LOG_DIRECTORY);
            List<int> chartList = new List<int>(new int[5]);
            //BEST: USE MEMORY STREAM, LOAD INTO MEM STREAM 
            //BETTER: INSTEAD OF LIST USE STRING BUILDER: MEM EFFICIENT WAY TO STORE STRINGS

            try
            {
                foreach (var log in path.GetFiles("*Telemetry.json"))
                {
                    var currentLog = Path.Combine(path.FullName, log.Name);
                    using (StreamReader logReader = new StreamReader(currentLog))
                    {
                        string data = "";
                        while ((data = logReader.ReadLine()) != null)
                        {
                            chartList[0] += ContainsSearch(data, "home");
                            chartList[1] += ContainsSearch(data, "search");
                            chartList[2] += ContainsSearch(data, "profile");
                            chartList[3] += ContainsSearch(data, "watchlist");
                            chartList[4] += ContainsSearch(data, "dashboard");
                        }
                    }
                }
                return chartList;
            }
            catch (FileNotFoundException e)
            {
                //Console.WriteLine("File not does exist. " + e.Message);
            }

            return chartList;
        }

        public List<int> GetLoginStats()
        {
            DirectoryInfo path = new DirectoryInfo(config.LOG_DIRECTORY);
            List<int> chartList = new List<int>(new int[3]);
            //BEST: USE MEMORY STREAM, LOAD INTO MEM STREAM 
            //BETTER: INSTEAD OF LIST USE STRING BUILDER: MEM EFFICIENT WAY TO STORE STRINGS

            try
            {
                foreach (var log in path.GetFiles("*Telemetry.json"))
                {
                    var currentLog = Path.Combine(path.FullName, log.Name);
                    using (StreamReader logReader = new StreamReader(currentLog))
                    {
                        string data = "";
                        while ((data = logReader.ReadLine()) != null)
                        {
                            chartList[0] += ContainsSearch(data, "failed to log in");
                            chartList[1] += ContainsSearch(data, "User has logged in");
                        }
                    }
                }
                chartList[2] = chartList[0] + chartList[1];
                return chartList;
            }
            catch (FileNotFoundException e)
            {
                //Console.WriteLine("File not does exist. " + e.Message);
            }

            return chartList;
        }

        public List<int> GetUsersPerMonthStats()
        {
            List<int> chartList = new List<int>(new int[24]);
            //BEST: USE MEMORY STREAM, LOAD INTO MEM STREAM 
            //BETTER: INSTEAD OF LIST USE STRING BUILDER: MEM EFFICIENT WAY TO STORE STRINGS
            using (var _db = new DataBaseContext())
            {
                UserRepository userRepository = new UserRepository(_db);
                var loggedInList = GetLoggedInPerMonthStats(12);
                var totalUsers = new List<int>();
                for (int i = 1; i <= 12; i++)
                {
                    //totalUsers.Add(userRepository.GetCount(i, 2019));
                }
            }

            return chartList;
        }


        public List<int> GetFeatureStats()
        {
            DirectoryInfo path = new DirectoryInfo(config.LOG_DIRECTORY);
            List<int> chartList = new List<int>(new int[5]);
            //BEST: USE MEMORY STREAM, LOAD INTO MEM STREAM 
            //BETTER: INSTEAD OF LIST USE STRING BUILDER: MEM EFFICIENT WAY TO STORE STRINGS

            try
            {
                foreach (var log in path.GetFiles("*Telemetry.json"))
                {
                    var currentLog = Path.Combine(path.FullName, log.Name);
                    using (StreamReader logReader = new StreamReader(currentLog))
                    {
                        string data = "";
                        while ((data = logReader.ReadLine()) != null)
                        {
                            chartList[0] += ContainsSearch(data, "searched for");
                            chartList[1] += ContainsSearch(data, "went to their watchlist");
                            chartList[2] += ContainsSearch(data, "went to their profile");
                            chartList[3] += ContainsSearch(data, "went to the admin dashboard");
                            chartList[4] += ContainsSearch(data, "routed to");
                        }
                    }
                }
                return chartList;
            }
            catch (FileNotFoundException e)
            {
                //Console.WriteLine("File not does exist. " + e.Message);
            }

            return chartList;
        }

        public List<int> GetLoggedInPerMonthStats(int months)
        {
            DirectoryInfo path = new DirectoryInfo(config.LOG_DIRECTORY);
            List<int> chartList = new List<int>(new int[months]);
            //BEST: USE MEMORY STREAM, LOAD INTO MEM STREAM 
            //BETTER: INSTEAD OF LIST USE STRING BUILDER: MEM EFFICIENT WAY TO STORE STRINGS

            try
            {
                int i = 1;
                foreach (var log in path.GetFiles("*Telemetry.json"))
                {
                    int logMonth = LogFileDate(log.FullName).Month;
                    if (i != logMonth) { i=logMonth; }
                    var currentLog = Path.Combine(path.FullName, log.Name);
                    if (logMonth == i && i <= months)  
                    {
                        using (StreamReader logReader = new StreamReader(currentLog))
                        {
                            string data = "";
                            while ((data = logReader.ReadLine()) != null)
                            {
                                chartList[logMonth-1] += ContainsSearch(data, "User has logged in");
                            }
                        }
                    }
                    
                }
                return chartList;
            }
            catch (FileNotFoundException e)
            {
                //Console.WriteLine("File not does exist. " + e.Message);
            }

            return chartList;
        }

        public int ContainsSearch(string data, string searched)
        {
            if (data.Contains(searched))
            { 
                return 1;
            }
            return 0;
        }
        public int ContainsSearchDate(string data, string searched, int month)
        {
            if (data.Contains(searched))
            {
                return 1;
            }
            return 0;
        }

        public DateTime LogFileDate(string logFile)
        {
            Config config = new Config();
            string logName = Path.GetFileName(logFile);
            string logDate = logName.Split('_')[0];
            DateTime.TryParseExact(logDate, config.DATE_FORMAT, new CultureInfo("en-US"), DateTimeStyles.None, out DateTime parsedDate);
            return parsedDate;
        }
    }
}
