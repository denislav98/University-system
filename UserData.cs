using System;

namespace UserLoginn
{
    static class UserData
    {
        static private User[] _testUsers;
        private static void ResetTestUserData()
        {
            _testUsers = new User[3];
            _testUsers[0] = new User("test", "test1", "121217033", 1, DateTime.Now, DateTime.MaxValue);
            _testUsers[1] = new User("ivan", "ivan1", "121217033", 2, DateTime.Now, DateTime.MaxValue);
            _testUsers[2] = new User("mariika", "mariika1", "121217033", 5, DateTime.Now, DateTime.MaxValue);
        }
        public static User IsUserPassCorrect(string username, string password)
        {
            User[] users = TestUsers;

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
            Console.WriteLine(user.ToString());
        }

        public static void AssignUserRole(string username, UserRole newRole)
        {
            User user = GetUserByUsername(username);
            user.Role = Convert.ToInt32(newRole);
        }

        private static User GetUserByUsername(string username)
        {
            User[] users = TestUsers;

            foreach (User user in users)
            {
                if (username.Equals(user.Username))
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
