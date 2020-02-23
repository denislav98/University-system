using System;

namespace UserLoginn
{
    class LoginValidation
    {
        private static UserRole _userRoles;
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
            currentUserRole = (UserRole)user.Role;

            return true;
        }

        public static UserRole currentUserRole
        {
            get { return _userRoles; }

            private set { }
        }
    }
}
