using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Helper;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
                .HasOne(j => j.CreatedBy)
                .WithMany()
                .HasForeignKey(j => j.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.CreatedBy)
                .WithMany()
                .HasForeignKey(p => p.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserType = UserType.ADMIN,
                    FirstName = "Rick",
                    LastName = "Sanchez",
                    CreatedAtDate = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    LastEdited = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    Login = "sancheezium",
                    Password = "1234",
                    Avatar = ""
                },
                new User
                {
                    Id = 2,
                    UserType = UserType.PROJECT_MANAGER,
                    FirstName = "Morty",
                    LastName = "Smith",
                    CreatedAtDate = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    LastEdited = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    Login = "morty",
                    Password = "1234",
                    Avatar = ""
                },
                new User
                {
                    Id = 3,
                    UserType = UserType.EMPLOYEE,
                    FirstName = "Summer",
                    LastName = "Smith",
                    CreatedAtDate = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    LastEdited = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    Login = "sumsum",
                    Password = "1234",
                    Avatar = ""
                }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Name = "Spaceship to Mars",
                    Description = "Building a spaceship that will get us to Mars",
                    Status = ProjectStatus.PREPARED,
                    CreatedById = 2,
                    CreatedAtDate = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    LastEdited = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    DeadlineDate = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1 + 100,
                    Priority = Priority.MODERATE
                }
            );

            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    Id = 1,
                    Name = "Build a starting pod",
                    Description = "Build a pod for the rocket to start",
                    Status = JobStatus.TO_DO,
                    CreatedById = 2,
                    CreatedAtDate = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    LastEdited = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    DeadlineDate = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1 + 20,
                    Priority = Priority.HIGH,
                    ProjectId = 1
                }
            );
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Job> Jobs { get; set; }

    }
}
