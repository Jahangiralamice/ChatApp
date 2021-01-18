using ChatApp.Models;
using System.Data.Entity;

namespace ChatApp.Context
{
    public class ChatContext : DbContext
    {
        public ChatContext(): base("ChatContext")
        {

        }

        public DbSet<UserRegistration> UserRegistrations { get; set; }
    }
}