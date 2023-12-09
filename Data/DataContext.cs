using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserType = Helper.UserType.ADMIN,
                    FirstName = "Rick",
                    LastName = "Sanchez",
                    Created = DateTime.Now,
                    LastEdited = DateTime.Now,
                    Login = "sancheezium",
                    Password = "1234",
                    Avatar = ""
                },
                new User
                {
                    Id = 2,
                    UserType = Helper.UserType.PROJECT_MANAGER,
                    FirstName = "Morty",
                    LastName = "Smith",
                    Created = DateTime.Now,
                    LastEdited = DateTime.Now,
                    Login = "morty",
                    Password = "1234",
                    Avatar = ""
                },
                new User
                {
                    Id = 3,
                    UserType = Helper.UserType.EMPLOYEE,
                    FirstName = "Summer",
                    LastName = "Smith",
                    Created = DateTime.Now,
                    LastEdited = DateTime.Now,
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
                    Status = Helper.ProjectStatus.PREPARED,
                    CreatedById = 2,
                    Created = DateTime.Now,
                    LastEdited = DateTime.Now,
                    Deadline = DateTime.Now.AddDays(100),
                    Priority = Helper.Priority.MODERATE
                }
            );

            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    Id = 1,
                    Name = "Build a starting pod",
                    Description = "Build a pod for the rocket to start",
                    Status = Helper.JobStatus.TO_DO,
                    CreatedById = 2,
                    Created = DateTime.Now,
                    LastEdited = DateTime.Now,
                    Deadline = DateTime.Now.AddDays(20),
                    Priority = Helper.Priority.HIGH,
                    ProjectId = 1
                }
            );
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Job> Jobs { get; set; }

    }
}
