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
            // TODO: update all keys in all entities

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
                    Avatar = "",
                    SupervisorId = 2
                },
                new User
                {
                    Id = 4,
                    UserType = UserType.EMPLOYEE,
                    FirstName = "Bird",
                    LastName = "Person",
                    CreatedAtDate = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    LastEdited = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    Login = "bird_person",
                    Password = "birb",
                    Avatar = "",
                    SupervisorId = 2
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
                },
                new Job
                {
                    Id = 2,
                    Name = "Build a rocket",
                    Description = "Build a rocket to take the shuttle outside the atmosphere",
                    Status = JobStatus.TO_DO,
                    CreatedById = 2,
                    CreatedAtDate = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    LastEdited = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    DeadlineDate = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1 + 35,
                    Priority = Priority.MODERATE,
                    ProjectId = 1
                }
            );

            modelBuilder.Entity<JobEntry>().HasData(
                new JobEntry
                {
                    Id = 1,
                    UserId = 3,
                    JobId = 1,
                    StartedAtDate = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    StartedAtTime = DateTimeHelper.ConvertToClarion(DateTime.Now).Item2
                },
                new JobEntry
                {
                    Id = 2,
                    UserId = 4,
                    JobId = 2,
                    StartedAtDate = DateTimeHelper.ConvertToClarion(DateTime.Now).Item1,
                    StartedAtTime = DateTimeHelper.ConvertToClarion(DateTime.Now).Item2
                }
            );
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobEntry> JobEntries { get; set; }

    }
}
