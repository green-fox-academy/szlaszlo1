using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reddit.Repositories
{
    public interface IRedditRepository<Type>
    {
        void Create(Type t);
        List<Type> GetAll();
        void Update(Type t);
        void Delete(Type t);
        Type GetElement(int i);
    }
}
