using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLoginn
{
    public static class UserData
    {
        private static UserContext dbContext = new UserContext();
        static private List<User> _testUsers;
        private static void ResetTestUserData()
        {
            if (TestUsersIfEmpty())
            {
                CreateTestUsers();
                foreach (User user in _testUsers)
                {
                    dbContext.Users.Add(user);
                }
                dbContext.SaveChanges();
            }
        }

        private static bool TestUsersIfEmpty()
        {
            IEnumerable<User> queryStudents = dbContext.Users;
            int countStudents = queryStudents.Count();
            return countStudents == 0;
        }

        private static void CreateTestUsers()
        {
            _testUsers = new List<User>();
            _testUsers.Add(new User("test12", "test12", "121217033", UserRole.ANONYMOUS, DateTime.Now, DateTime.MaxValue));
            _testUsers.Add(new User("ivancho", "ivan1", "121217033", UserRole.ADMIN, DateTime.Now, DateTime.MaxValue));
            _testUsers.Add(new User("mariika", "mariika1", "121217033", UserRole.STUDENT, DateTime.Now, DateTime.MaxValue));
        }

        public static void DeleteUserByFacultyNumber(string facultyNumber)
        {
            User user =(from usr in dbContext.Users
                        where usr.FacultyNumber == facultyNumber
                        select usr).First();
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
        }
        public static User IsUserPassCorrect(string username, string password)
        {
            User user = (from u in dbContext.Users
                         where u.Username.Equals(username) &&
                               u.Password.Equals(password)
                         select u).FirstOrDefault();
            return user;
        }
        public static void SetUserActiveTo(string username, DateTime newDate)
        {
            User user = GetUserByUsername(username);
            user.ActiveTo = newDate;
            Logger.LogActivity("Activity changed for User : " + username);
        }

        public static void AssignUserRole(int userId, UserRole newRole)
        {
            UserContext context = new UserContext();
            User usr = (from u in TestUsers
                        where u.UserId == userId
                        select u).First();
            usr.Role = newRole;
            context.SaveChanges();
            Logger.LogActivity("Role changed for User with Id : " + userId);
        }

        private static User GetUserByUsername(string username)
        {
            return (from user in dbContext.Users
                    where user.Username == username
                    select user).First();
        }

        public static List<User> TestUsers
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
