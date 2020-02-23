using System;

namespace UserLoginn
{
    class User
    {
        private string username;
        private string password;
        private string facultyNumber;
        private Int32 role;
        private DateTime created;
        private DateTime activeTo;

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

        public User(string username, string password, string facultyNumber, int role, DateTime created) : this(username, password, facultyNumber, role)
        {
            this.created = created;
        }

        public User(string username, string password, string facultyNumber, int role, DateTime created, DateTime activeTo) : this(username, password, facultyNumber, role, created)
        {
            this.activeTo = activeTo;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string FacultyNumber
        {
            get { return facultyNumber; }
            set { facultyNumber = value; }
        }

        public Int32 Role
        {
            get { return role; }
            set { role = value; }
        }
        public DateTime Created
        {
            get { return created; }
            set { created = value; }
        }

        public DateTime ActiveTo
        {
            get { return activeTo; }
            set { activeTo = value; }
        }

        public override string ToString()
        {
            return "Username: " + username + " " +
                   "Password: " + password + " " +
                   "FacultyNumber: " + facultyNumber + " " +
                   "Role: " + role +
                   "Created at: " + created +
                   "Valid to : " + activeTo;
        }
    }
}