using HRMS_With_CoreMVC_RepoPattern.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HRMS_With_CoreMVC_RepoPattern.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EventTypes> EventTypes { get; set; }
        public DbSet<EventModel> Events { get; set; }

        public DbSet<TaskBoards> TaskBoards { get; set; }
        public DbSet<Tasks> Task { get; set; }

        public DbSet<TaskMembers> Taskmember { get; set; }

        public DbSet<Projects> AllProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EventModel>(e =>
            {
                e.HasOne(x => x.EventType)
                .WithMany(x => x.Event)
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
               .WithMany(x => x.Task)
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

        }
    }
}
