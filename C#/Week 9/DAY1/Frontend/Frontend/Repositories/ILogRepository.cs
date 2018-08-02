using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Repositories
{
    public interface ILogRepository
    {
        void Create(LogObject lo);
        List<LogObject> ReadAll();

    }
}
