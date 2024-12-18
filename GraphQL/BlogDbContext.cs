using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : 
            base(options) 
        {
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
