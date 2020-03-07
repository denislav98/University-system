using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserLoginn
{
    static class Logger
    {
        private const string logFileName = "test.txt";
        private static List<string> currentSessionActivities = new List<string>();
        static public void LogActivity(string activity)
        {
            string activityLine =  DateTime.Now + " " 
                                 + LoginValidation.currentUserUsername + " " 
                                 + LoginValidation.currentUserRole + " " 
                                 + activity + "\n";
            currentSessionActivities.Add(activityLine);

            if (File.Exists(logFileName))
            {
                File.AppendAllText(logFileName, activityLine);
            }
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
           // return File.ReadAllText(logFileName);
        }

        public static string GetCurrentSessionActivities()
        {
            string currentActivity = currentSessionActivities[currentSessionActivities.Count - 1];
            return currentActivity;
        }
    }
}
