using System;
using System.Collections.Generic;
using System.Text;

namespace UserLoginn
{
    static class UserData
    {
        
        static private User _testUser;
        static private void ResetTestUserData()
        {
            _testUser = new User();
            _testUser.facultyNumber = "121217033";
            _testUser.password = "pass1";
            _testUser.username = "baiIvan";
            _testUser.Role = UserRole.ADMIN;
        }
        static public User TestUser
        {
            get {
                ResetTestUserData();
                return _testUser;
            }
            private set {

            }
        }

    }
}
