using Microsoft.EntityFrameworkCore;
using Test_React_ASPnet.Domain.Entity;

namespace Tess_React_ASPnet.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tool> Tools { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tool_User> Tool_User { get; set; }
    }
}
