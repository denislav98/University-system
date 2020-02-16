using System;
using System.Collections.Generic;
using System.Text;

namespace UserLoginn
{
    static class UserData
    {

        static private User[] _testUsers;
        private static void ResetTestUserData()
        {
            _testUsers = new User[3];
            _testUsers[0] = new User("pedal1", "kur123", "121217033", 1);
            _testUsers[1] = new User("ivancho", "kur123", "121217033", 5);
            _testUsers[2] = new User("mariika", "kur123", "121217033", 5);
        }
        public static User IsUserPassCorrect(string username, string password)
        {
            User[] users = TestUsers;

            foreach (User user in users)
            {
                if (username.Equals(user.username) && password.Equals(user.password))
                {
                    return user;
                }
            }

            return null;
        }

        static public User[] TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            private set
            {

            }
        }

    }
}
