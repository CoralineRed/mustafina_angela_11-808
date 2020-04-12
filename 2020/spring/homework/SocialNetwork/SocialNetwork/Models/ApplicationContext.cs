using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public List<Post> GetPosts(string login)
        {
            var userId = Users.FirstOrDefault(user => user.Login == login).Id;
            return Posts
                .Where(post => post.UserId == userId)
                .OrderByDescending(post => post.CreationTime)
                .ToList();
        }

        public async Task AddPost(Post post)
        {
            Posts.Add(post);
            await SaveChangesAsync();
        }

        public User GetUserByLogin(string login)
        {
            return Users.FirstOrDefault(u => u.Login == login);
        }
    }
}
