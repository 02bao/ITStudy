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
        public static string configsql = "Host=dpg-cogb33cf7o1s73fqpvqg-a.singapore-postgres.render.com:5432;Database=renderitstudy;Username=renderitstudy_user;Password=VYTZYnl42MPWN8IZA7CAz1Gl69ZrgUXI";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(configsql);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
