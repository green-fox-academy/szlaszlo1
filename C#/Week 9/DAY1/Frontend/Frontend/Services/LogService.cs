using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frontend.Models;
using Frontend.Repositories;

namespace Frontend.Services
{
    public class LogService : ILogService
    {
        ILogRepository logrepo;
        public LogService(ILogRepository logrepo)
        {
            this.logrepo = logrepo;
        }
        public void AddNew(string endpoint,string data)
        {
            
            logrepo.Create(new LogObject { createdAt=DateTime.Now,endpoint=endpoint,data=data});
        }

        public List<LogObject> GetAll()
        {
            return logrepo.ReadAll();
        }
    }
}
