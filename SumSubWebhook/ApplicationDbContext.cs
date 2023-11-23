using Microsoft.EntityFrameworkCore;
using SumSubWebhook.Models.Entities;

namespace SumSubWebhook
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationEntity> Applications { get; set; }
    }
}
