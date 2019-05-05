using System;
using System.Globalization;
using System.IO;

namespace CheckIt.ServiceLayer
{
    public class ArchivingService : IArchivingService
    {
        /// <summary>
        /// This checks if a specific log file is older than 30 days
        /// </summary>
        /// <param name="logFile"> This is the filename, our naming convention is "MM-dd-yyyy_LOGTYPE"</param>
        /// <param name="months"> This is the number of months to check a file against</param>
        /// <returns>Returns a true if the file is older than the number of months. </returns>
        public bool OlderThanMonths(string logFile, int months)
        {
            var parsedDate = LogFileDate(logFile);
            var datePlusMonths = parsedDate.AddMonths(months);
            Console.Write(parsedDate + " vs ");
            Console.WriteLine(datePlusMonths);
            if(DateTime.Now.Date > datePlusMonths.Date)
            {
                Console.WriteLine(true);
                return true;
            }
            Console.WriteLine(false);
            return false;
        }

        /// <summary>
        /// This returns the dateTime of a specific log file given the file name
        /// </summary>
        /// <param name="logFile"> This is the filename, our naming convention is "MM-dd-yyyy_LOGTYPE"</param>
        /// <returns>Returns a DateTime of when a log file was created</returns>
        public DateTime LogFileDate(string logFile)
        {
            Config config = new Config();
            string logName = Path.GetFileName(logFile);
            string logDate = logName.Split('_')[0];
            DateTime.TryParseExact(logDate, config.DATE_FORMAT , new CultureInfo("en-US"), DateTimeStyles.None, out DateTime parsedDate);
            return parsedDate;
        }

        /// <summary>
        /// This moves logs from a source folder to a target folder if the log is older than the months parameter
        /// </summary>
        /// <param name="sourcePath">Starting folder of logs to be moved</param>
        /// <param name="targetPath">Destination folder of logs to be moved</param>
        /// <param name="months">Months to check against for all logs in the source folder</param>
        public void MoveLogs(string sourcePath, string targetPath, int months)
        {
            var list = Directory.GetFiles(sourcePath);
            foreach (string log in list)
            {
                if (OlderThanMonths(Path.GetFileName(log),months))
                {
                    string sourceFile = sourcePath + "\\" + Path.GetFileName(log);
                    string destFile = targetPath + "\\" + Path.GetFileName(log);
                    try
                    {
                        File.Move(sourceFile, destFile);
                    }
                    catch (UnauthorizedAccessException unauth)
                    {
                        Console.WriteLine("Unauthorized access to file or directory!");
                    }
                }
            }
        }

        /// <summary>
        /// This copies logs from a source folder to a target folder if the log is older than the months parameter
        /// </summary>
        /// <param name="sourcePath">Starting folder of logs to be copied</param>
        /// <param name="targetPath">Destination folder of logs to be copied</param>
        /// <param name="months">Months to check against for all logs in the source folder</param>
        public void CopyLogs(string sourcePath, string targetPath, int months)
        {
            var list = Directory.GetFiles(sourcePath);
            foreach (string log in list)
            {
                if (OlderThanMonths(Path.GetFileName(log), months))
                {
                    string sourceFile = sourcePath + "\\" + Path.GetFileName(log);
                    string destFile = targetPath + "\\" + Path.GetFileName(log);
                    try
                    {
                        File.Copy(sourceFile, destFile);
                    }
                    catch (UnauthorizedAccessException unauth)
                    {
                        Console.WriteLine("Unauthorized access to file or directory!");
                    }
                }
            }
        }

        /// <summary>
        /// This method gets the current date in a special format
        /// </summary>
        /// <returns>Returns a string date formatted as "MM-dd-yyyy"</returns>
        public string GetCurrentDate()
        {
            Config config = new Config();
            var dateTime = DateTime.Now;
            var date = dateTime.ToString(config.DATE_FORMAT);
            return date;
        }

        /// <summary>
        /// Checks if a directory is empty
        /// </summary>
        /// <param name="path">The directory to check</param>
        /// <returns>true if directory is empty, false otherwise</returns>
        public bool IsDirectoryEmpty(string path)
        {
            return System.IO.Directory.GetFiles(path).Length == 0;
        }
    }
}
