using ChatApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Data
{
    public class ChatDbContext:DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
    }
}
