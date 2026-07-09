using MeetupsServerApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetupsServerApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Event>? Events { get; set; }
    }
}
