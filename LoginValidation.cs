using System;
using System.Collections.Generic;
using System.Text;

namespace UserLoginn
{
    class LoginValidation
    {
        static private UserRole _userRoles;
        private String username;
        private String password;
        private String errorMessage;

        public LoginValidation(String username, String password)
        {
            this.username = username;
            this.password = password;
        }
        public bool ValidateUserInput(User user)
        {
            /*
                        user.username = UserData.TestUser.username;
                        user.password = UserData.TestUsers.password;
                        user.facultyNumber = UserData.TestUsers.facultyNumber;
                        user.role = UserData.TestUsers.role;

                        currentUserRole = (UserRole) user.role;*/

            if (username.Equals(string.Empty))
            {
                errorMessage = "Не е посочено потребителско име";
                currentUserRole = UserRole.ANONYMOUS;
                return false;
            }

            Boolean emptyPassword = password.Equals(string.Empty);
            if (emptyPassword == true)
            {
                errorMessage = "Не е посочена парола";
                currentUserRole = UserRole.ANONYMOUS;
                return false;
            }

            if (username.Length < 5)
            {
                errorMessage = "Потребитеското има трябва да бъде с повече от 5 знака";
                currentUserRole = UserRole.ANONYMOUS;
                return false;
            }

            if (password.Length < 5)
            {
                errorMessage = "Паролата трябва да бъде с повече от 5 знака";
                currentUserRole = UserRole.ANONYMOUS;
                return false;
            }

            User user1 = UserData.IsUserPassCorrect(username, password);
            user.username = user1.username;
            user.password = user1.password;
            user.facultyNumber = user1.facultyNumber;
            user.role = user1.role;

            currentUserRole = (UserRole)user.role;
            if (user1 == null)
            {
                errorMessage = "Невалиден потребител";
                currentUserRole = UserRole.ANONYMOUS;
                return false;
            }
            currentUserRole = (UserRole)user.role;
            return true;
        }

        public static UserRole currentUserRole
        {
            get { return _userRoles; }

            private set { }
        }
    }
}
