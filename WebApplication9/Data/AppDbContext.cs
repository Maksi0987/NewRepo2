using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication9.Models;

namespace WebApplication9.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AiPrompt> AiPrompts { get; set; }
    }
}