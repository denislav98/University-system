using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginn
{
    public class Logs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogsId
        {
            get;
            set;
        }
        public DateTime? Date
        {
            get; set;
        }
        public string Activity
        {
            get;
            set;
        }
        public string Username
        {
            get;
            set;
        }
        public UserRole Role
        {
            get; set;
        }

        public Logs()
        {

        }
        public Logs(string username, UserRole role, string activity)
        {
            Date = DateTime.Now;
            Username = username;
            Role = role;
            Activity = activity;
        }
        public override string ToString()
        {
            return Date + " " + Username + " " + Role + " " + Activity + "\n";
        }
    }
}
