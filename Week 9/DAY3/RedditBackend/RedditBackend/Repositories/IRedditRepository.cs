using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditBackend.Repositories
{
   public  interface IRedditRepository<Type>
    {
        List<Type> ReadAll();
        Type Create(Type type);
        void Update(Type type);
        void Delete(Type type);
    }
}
