using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginn
{
    class LogsContext : DbContext
    {

        public LogsContext() : base(Properties.Settings.Default.DbConnect)
        { }
        public DbSet<Logs> Logs { get; set; }
    }
}
