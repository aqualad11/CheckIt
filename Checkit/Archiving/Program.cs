using System;
using CheckIt.ManagerLayer;
using Microsoft.Win32.TaskScheduler;

namespace CheckIt.Archiving
{
    public class Program
    {
        //executable to launch from the scheduled task
        string archivingExe = "D:\\Documents\\Github\\CheckIt\\CheckIt\\Archiving\\bin\\Debug\\Archiving.exe";
        private static System.Timers.Timer timer;
        private static int tries;

        /// <summary>
        /// Executable Program that backs up logs and archives logs whenever it is called.
        /// </summary>
        static void Main(string[] args)
        {
            //TimeSpan of 2 hours for the archive retry
            TimeSpan ts = new TimeSpan(2, 0, 0);

            //New instance of ArchiveManager
            ArchivingManager archivingManager = new ArchivingManager();
            //Backup the logs
            archivingManager.BackupLogs();

            //Archive logs older than 2 years
            bool archived = false;
            archived = archivingManager.ArchiveLogs();
            //If logs fail to archive 1-3 times wait 2 hours then try again
            if(!archived && tries < 3)
            {
                try
                {
                    System.Threading.Tasks.Task task = System.Threading.Tasks.Task.Delay(ts).ContinueWith(b => archivingManager.ArchiveLogs());
                    task.Wait();
                }
                catch(Exception e)
                {
                    Console.Write("2 Hour wait for re-archive has failed.");
                }
            }
            //Otherwise, stop archiving and email a system administrator
            else if (!archived && tries >= 3)
            {
                using (TaskService task = new TaskService())
                {
                    Microsoft.Win32.TaskScheduler.Task td = task.FindTask("LogArchiver");
                    td.Definition.Settings.Enabled = false;
                    Console.WriteLine("Email a System Administrator");
                    //ServiceLayer.EmailService.SendMail("kunal1005@yahoo.com", "Archiving is screwed up.");
                    tries = 0;
                }
            }
        }
    }
}
