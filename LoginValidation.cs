using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
    class LoginValidation
    {
        private static UserRole _userRoles;
        private static string _currentUserUsername;
       

        private string username;
        private string password;
        private string errorMessage;
        private ActionOnError actionOnError;
        public delegate void ActionOnError(string errorMsg);

        public LoginValidation(string username, string password, ActionOnError actionOnError)
        {
            this.username = username;
            this.password = password;
            this.actionOnError = actionOnError;
        }
        public bool ValidateUserInput(ref User user)
        {

            if (username.Equals(string.Empty))
            {
                errorMessage = "Empty username is entered";
                actionOnError(errorMessage);
                currentUserRole = UserRole.ANONYMOUS;
                return false;
            }

            if (password.Equals(string.Empty))
            {
                errorMessage = "Empty password is entered";
                actionOnError(errorMessage);
                currentUserRole = UserRole.ANONYMOUS;
                return false;
            }

            if (username.Length < 5)
            {
                errorMessage = "Username must contains more than 5 characters";
                actionOnError(errorMessage);
                currentUserRole = UserRole.ANONYMOUS;
                return false;
            }

            if (password.Length < 5)
            {
                errorMessage = "Password must contains more than 5 characters";
                actionOnError(errorMessage);
                currentUserRole = UserRole.ANONYMOUS;
                return false;
            }

            user = UserData.IsUserPassCorrect(username, password);

            if (user == null)
            {
                errorMessage = "No such user exists";
                actionOnError(errorMessage);
                currentUserRole = UserRole.ANONYMOUS;
                return false;
            }
            _userRoles = (UserRole)user.Role;
            _currentUserUsername = user.Username;
            Logger.LogActivity("Successfully log in");
            return true;
        }
        public static bool AreLoginAtemptsExceededInThreeMinutes()
        {
           
            List<string> loggLines = Logger.ReadLoggFileContent();
            if(loggLines.Count < 3)
            {
                Logger.LogActivity("Loggs are less than 3");
                return false;
            }
            List<string> lastThreeLoginAttempts = loggLines
                .Where(log => log.Contains("Failed to login at"))
                .Reverse()
                .Take(3)
                .ToList();

            if(lastThreeLoginAttempts.Count < 3)
            {
                return false;
            }

            List<string> firstLogginAttempt = lastThreeLoginAttempts[0].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string firstDate = firstLogginAttempt[0] + " " + firstLogginAttempt[1] + " " + firstLogginAttempt[2];
            List<string> secondLogginAttempt = lastThreeLoginAttempts[2].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string lastDate = secondLogginAttempt[0] + " " + secondLogginAttempt[1] + " " + secondLogginAttempt[2];

            TimeSpan firstAndThirdAttemptTimeDifference = DateTime.Parse(firstDate).Subtract(DateTime.Parse(lastDate));
            if (firstAndThirdAttemptTimeDifference.TotalMinutes <= 3)
            {
                return true;
            }
            return false;
        }
        public static UserRole currentUserRole
        {
            get { return _userRoles; }

            private set { }
        }
        public static string currentUserUsername
        {
            get { return _currentUserUsername; }
            private set {  }
        }
    }
}
