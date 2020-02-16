using System;
using System.Collections.Generic;
using System.Text;

namespace UserLoginn
{
    class LoginValidation
    {
        static private UserRole _userRoles;
        public bool ValidateUserInput(User user)
        {
            if (user.password.Length < 3 && user.password.Contains("@e42"))
            {
                return false;
            }
            return true;
        }

        public static UserRole currentUserRole
        {
            get { return _userRoles; }

            private set { }
        }
    }
}
