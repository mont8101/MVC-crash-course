using Microsoft.EntityFrameworkCore;
using MVC_crash_course.Models;

namespace MVC_crash_course.Data
{
    public class MVCContext : DbContext
    {
        public MVCContext(DbContextOptions<MVCContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
    }
}
