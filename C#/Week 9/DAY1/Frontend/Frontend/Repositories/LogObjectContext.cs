using Frontend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Repositories
{
    public class LogObjectContext:DbContext
    {
        public DbSet<LogObject> LogObjects { get; set; }
        public LogObjectContext(DbContextOptions<LogObjectContext> options):base(options)
        {

        }
    }
}
