using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.ServiceLayer;

namespace CheckIt.ManagerLayer
{
    public class UADManager
    {
        private UADService uADService;
        public UADManager()
        {
            uADService = new UADService();
        }
        public List<int> GetChartStats(string chartName)
        {
            List<int> list = new List<int>();
            switch (chartName)
            {
                case "LoginsBarChart":
                    list = uADService.GetLoginsBarChart();
                    break;
                case "TimePerPageBarChart":
                    list = uADService.GetTimePerPageBarChart();
                    break;
                case "LoginsAndUsersBarChart":
                    list = uADService.GetLoginsAndUsersBarChart();
                    break;
                case "TopFiveFeaturesBarChart":
                    list = uADService.GetTopFiveFeaturesBarChart();
                    break;
                case "AverageSessionBarChart":
                    list = uADService.GetAverageSessionBarChart();
                    break;
                case "AverageSessionLineChart":
                    list = uADService.GetAverageSessionLineChart();
                    break;
                case "AverageLoggedInUsersLineChart":
                    list = uADService.GetAverageLoggedInUsersLineChart();
                    break;
                default:
                    Console.WriteLine("Other");
                    break;
            }

            return list;
        }
    }
}
