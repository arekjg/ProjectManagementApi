using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable(tb => tb.HasTrigger("OnUserInsert"))
                .ToTable(tb => tb.HasTrigger("OnUserUpdate"));
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Job> Jobs { get; set; }

    }
}
