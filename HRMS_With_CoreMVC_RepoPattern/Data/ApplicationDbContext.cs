using HRMS_With_CoreMVC_RepoPattern.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HRMS_With_CoreMVC_RepoPattern.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EventModel>(e =>
            {
                e.HasOne(x => x.EventType)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.EventTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            });



            builder.Entity<Tasks>(e =>
            {
                e.HasOne(x => x.Project)
                .WithMany(x => x.Task)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TaskMembers>(e =>
            {
                e.HasOne(x => x.Task)
                 .WithMany(x => x.Taskmember)
                 .HasForeignKey(x => x.TaskId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.User)
                 .WithMany()
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TaskBoards>(e =>
            {
                e.HasOne(x => x.Project)
                 .WithMany(x => x.TaskBoard)
                 .HasForeignKey(x => x.ProjectId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Task)
                 .WithMany(x => x.TaskBoard)
                 .HasForeignKey(x => x.TaskId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<LeaveBalance>(e =>
            {
                e.HasOne(x => x.MasterLeaveType)
                    .WithMany(x => x.LeaveBalances)
                    .HasForeignKey(x => x.LeaveTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }
        public DbSet<EmployeeFamilyDetail> EmployeeFamilyDetails { get; set; }
        public DbSet<EmployeeBankDetails> EmployeeBankDetails { get; set; }
        public DbSet<EducationDetails> EducationDetails { get; set; }
        public DbSet<EventModel> Events { get; set; }
        public DbSet<EventTypes> EventTypes { get; set; }
        public DbSet<Projects> AllProjects { get; set; }
        public DbSet<AddAdminDocName> addAdminDocNames { get; set; }
        public DbSet<AddEmployeeDocName> addEmployeeDocNames { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Role> Role { get; set; }

        public DbSet<TrainingType> TrainingType { get; set; }
        public DbSet<Training> Training { get; set; }

        public DbSet<Trainer> Trainer { get; set; }

        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<Resignation> Resignation { get; set; }
        public DbSet<Termination> Termination { get; set; }
        public DbSet<FileUpload> FileUpload { get; set; }
        public DbSet<AdminDocuments> AdminDocuments { get; set; }
        public DbSet<TaskBoards> TaskBoards { get; set; }
        public DbSet<Tasks> Task { get; set; }

        public DbSet<TaskMembers> Taskmember { get; set; }
        public DbSet<Timesheet> Timesheet { get; set; }
        public DbSet<EmployeePerformance> EmployeePerformances { get; set; }

       


    }
}