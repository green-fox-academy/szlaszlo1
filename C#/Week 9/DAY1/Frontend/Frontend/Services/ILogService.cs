using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public interface ILogService
    {
        void AddNew(string endpoint,string data);
        List<LogObject> GetAll();
    }
}
