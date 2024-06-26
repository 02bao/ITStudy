﻿using ITStudy.Models;
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
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Lectures> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Vouchers> Vouchers { get; set; }
        public DbSet<BuyCourses> BuyCourses { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        //public static string configsql = "Host=dpg-cogb33cf7o1s73fqpvqg-a.singapore-postgres.render.com:5432;Database=renderitstudy;Username=renderitstudy_user;Password=VYTZYnl42MPWN8IZA7CAz1Gl69ZrgUXI";
        public static string configsql = "Host=localhost:5432;Database=Study;Username=postgres;Password=postgres";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(configsql);
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public  Random random = new Random();
        public  string randomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
