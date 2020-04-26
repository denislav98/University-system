using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace UserLoginn
{
    public static class Logger
    {
        private const string logFileName = "test.txt";
        private static List<Logs> currentSessionActivities = new List<Logs>();
        static public void LogActivity(string activity)
        {
            Logs logs = new Logs(LoginValidation.currentUserUsername, LoginValidation.currentUserRole, activity);
            currentSessionActivities.Add(logs);
            SaveLogsToDb(logs);
            if (File.Exists(logFileName))
            {
                File.AppendAllText(logFileName, logs.ToString());
            }
        }

        private static void SaveLogsToDb(Logs logs)
        {
            LogsContext dbContext = new LogsContext();
            dbContext.Logs.Add(logs);
            dbContext.SaveChanges();
        }


        public static List<string> ReadLoggFileContent()
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = File.ReadAllLines(logFileName);
            foreach (string line in lines)
            {
                sb.Append(line + " \n");
            }

            List<string> loggs = sb.ToString().Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return loggs;
        }

        public static Logs GetCurrentSessionActivities()
        {
            Logs currentActivity = currentSessionActivities[currentSessionActivities.Count - 1];
            return currentActivity;
        }
    }
}
