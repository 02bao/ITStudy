using ITStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace ITStudy.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Instructors> Instructors { get; set; }
        public static string configsql = "Host=localhost:5432;Database=ITStudy;Username=postgres;Password=postgres";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(configsql);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
