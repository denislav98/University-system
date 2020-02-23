using System;
using System.Collections.Generic;

namespace UserLoginn
{
    static class UserData
    {
        static private List<User> _testUsers;
        private static void ResetTestUserData()
        {
            _testUsers = new List<User>();
            _testUsers.Add(new User("test12", "test12", "121217033", 1, DateTime.Now, DateTime.MaxValue));
            _testUsers.Add(new User("ivancho", "ivan1", "121217033", 2, DateTime.Now, DateTime.MaxValue));
            _testUsers.Add(new User("mariika", "mariika1", "121217033", 5, DateTime.Now, DateTime.MaxValue));
        }
        public static User IsUserPassCorrect(string username, string password)
        {
            List<User> users = TestUsers;

            foreach (User user in users)
            {
                if (username.Equals(user.Username) && password.Equals(user.Password))
                {
                    return user;
                }
            }

            return null;
        }
        public static void SetUserActiveTo(string username, DateTime newDate)
        {
            User user = GetUserByUsername(username);
            user.ActiveTo = newDate;
            Logger.LogActivity("Activity changed for User : " + username);
        }

        public static void AssignUserRole(string username, UserRole newRole)
        {
            User user = GetUserByUsername(username);
            user.Role = Convert.ToInt32(newRole);
            Logger.LogActivity("Role changed for User : " + username);
        }

        private static User GetUserByUsername(string username)
        {
            List<User> users = TestUsers;

            foreach (User user in users)
            {
                if (username.Equals(user.Username))
                {
                    return user;
                }
            }
            return null;
        }

        static public List<User> TestUsers
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
