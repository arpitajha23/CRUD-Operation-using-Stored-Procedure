using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DbContextData : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextData(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Student> Student { get; set; }
    }
}
