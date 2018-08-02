using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontend.Models;

namespace Frontend.Repositories
{
    public class LogRepository : ILogRepository
    {
        LogObjectContext logContext;
        public LogRepository(LogObjectContext logContext)
        {
            this.logContext = logContext;
        }
        public void Create(LogObject lo)
        {
            logContext.Add(lo);
            logContext.SaveChanges();
        }

        public List<LogObject> ReadAll()
        {
            return logContext.LogObjects.ToList();
        }
    }
}
