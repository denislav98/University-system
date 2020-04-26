using System;

namespace UserLoginn
{
    public class User
    {
        public int UserId
        {
            get;
            set;
        }
        public string Username
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public string FacultyNumber
        {
            get;
            set;
        }
        public UserRole Role
        {
            get; set;
        }
        public DateTime Created
        {
            get;
            set;
        }
        public DateTime? ActiveTo
        {
            get; set;
        }

        public User()
        {

        }

        public User(string username, string password, string facultyNumber, UserRole role)
        {
            Username = username;
            Password = password;
            FacultyNumber = facultyNumber;
            Role = role;
        }

        public User(string username, string password, string facultyNumber, UserRole role, DateTime created) : this(username, password, facultyNumber, role)
        {
            Created = created;
        }

        public User(string username, string password, string facultyNumber, UserRole role, DateTime created, DateTime activeTo) : this(username, password, facultyNumber, role, created)
        {
            ActiveTo = activeTo;
        }
        public override string ToString()
        {
            return "Username: " + Username + " \n" +
                   "Password: " + Password + " \n" +
                   "FacultyNumber: " + FacultyNumber + " \n" +
                   "Role: " + Role + " \n" +
                   "Created at: " + Created + " \n" +
                   "Valid to : " + ActiveTo;
        }


        /*     public override string ToString()
             {
                 return "Username: " + Username + " \n" +
                        "Password: " + Password + " \n" +
                        "FacultyNumber: " + FacultyNumber + " \n" +
                        "Role: " + Role + " \n" +
                        "Created at: " + Created + " \n" +
                        "Valid to : " + ActiveTo;
             }*/
    }
}