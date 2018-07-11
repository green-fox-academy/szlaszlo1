using Microsoft.EntityFrameworkCore;
using RedditBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditBackend.Repositories
{
    public class RedditContext:DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public RedditContext(DbContextOptions<RedditContext> options):base(options)
        {

        }
    }
}
