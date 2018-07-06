using Microsoft.EntityFrameworkCore;
using Reddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reddit.Repositories
{
    public class RedditContext:DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public RedditContext(DbContextOptions<RedditContext> options):base(options)
        {

        }
    }
}
