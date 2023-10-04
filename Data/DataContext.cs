using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //protected override void OnModelCreating


        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

    }
}
