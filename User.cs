using System;
using System.Collections.Generic;
using System.Text;

namespace UserLoginn
{
    class User
    {
        public String username;
        public String password;
        public String facultyNumber;
        public Int32 role;

        public User()
        {

        }

        public User(string username, string password, string facultyNumber, Int32 role)
        {
            this.username = username;
            this.password = password;
            this.facultyNumber = facultyNumber;
            this.role = role;
        }

        public override string ToString()
        {
            return "Username: " + this.username + " " +
                   "Password: " + this.password + " " +
                   "FacultyNumber: " + this.facultyNumber + " " +
                   "Role: " + this.role;
        }
    }
}