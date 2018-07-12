using Microsoft.EntityFrameworkCore;
using RedditBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditBackend.Repositories
{
    public class UserRepository : IRedditRepository<User>
    {
        RedditContext redditContext;
        public UserRepository(RedditContext redditContext)
        {
            this.redditContext = redditContext;
        }
        public User Create(User user)
        {
            redditContext.Users.Add(user);
            redditContext.SaveChanges();
            return Read(user.UserName);
        }

        public void Delete(User user)
        {
            redditContext.Users.Remove(user);
            redditContext.SaveChanges();
        }

        public User Read(string UserName)
        {
            return redditContext.Users.FirstOrDefault(x => x.UserName == UserName);
        }

        public List<User> ReadAll()
        {
            return redditContext.Users.Include(x=>x.Posts).ToList();
        }

        public void Update(User user)
        {
            redditContext.Users.Update(user);
            redditContext.SaveChanges();
        }
    }
}
