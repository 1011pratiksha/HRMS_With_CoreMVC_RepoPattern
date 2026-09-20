using HRMS_With_CoreMVC_RepoPattern.Models;
using Microsoft.EntityFrameworkCore;

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

            builder.Entity<LeaveBalance>().ToTable("LeaveBalance");
            builder.Entity<LeaveRequest>().ToTable("LeaveRequest");
            builder.Entity<MasterLeaveType>().ToTable("MasterLeaveType");
            builder.Entity<Timesheet>().ToTable("Timesheet");
            builder.Entity<EventModel>(e =>
            {
                e.HasOne(x => x.EventType)
                    .WithMany(x => x.Events)
                    .HasForeignKey(x => x.EventTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Tasks
            builder.Entity<Tasks>(e =>
            {
                e.HasOne(x => x.Project)
                    .WithMany(x => x.Task)
                    .HasForeignKey(x => x.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Task Members
            builder.Entity<TaskMembers>(e =>
            {
                e.HasOne(x => x.Task)
                    .WithMany(x => x.Taskmember)
                    .HasForeignKey(x => x.TaskId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.User)
                    .WithMany(x => x.TaskMembers)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Leave Balance
            builder.Entity<LeaveBalance>(e =>
            {
                e.HasOne(x => x.MasterLeaveType)
                    .WithMany(x => x.LeaveBalances)
                    .HasForeignKey(x => x.LeaveTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Employee Salaries
            builder.Entity<EmployeeSalaries>(e =>
            {
                e.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Employee Earnings
            builder.Entity<EmployeeEarnings>(e =>
            {
                e.HasOne(x => x.EmployeeSalaries)
                    .WithMany(x => x.EmployeeEarnings)
                    .HasForeignKey(x => x.SalaryId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Earning)
                    .WithMany()
                    .HasForeignKey(x => x.EarningId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Employee Deductions
            builder.Entity<EmployeeDeductions>(e =>
            {
                e.HasOne(x => x.EmployeeSalaries)
                    .WithMany(x => x.EmployeeDeductions)
                    .HasForeignKey(x => x.SalaryId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Deduction)
                    .WithMany()
                    .HasForeignKey(x => x.DeductionId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Attendance
            builder.Entity<Attendance>(e =>
            {
                e.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.Property(x => x.WorkingHours)
                    .HasPrecision(18, 2);

                e.Property(x => x.ProductionHours)
                    .HasPrecision(18, 2);

                e.Property(x => x.OvertimeHours)
                    .HasPrecision(18, 2);

                e.Property(x => x.BreakHours)
                    .HasPrecision(18, 2);
            });

            // Timesheet
            builder.Entity<Timesheet>(e =>
            {
                e.HasOne(x => x.User)
                    .WithMany(x => x.Timesheets)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(x => x.Projects)
                    .WithMany()
                    .HasForeignKey(x => x.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Employee Bank Details
            builder.Entity<EmployeeBankDetails>(e =>
            {
                e.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Employee Family Details
            builder.Entity<EmployeeFamilyDetail>(e =>
            {
                e.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Education Details
            builder.Entity<EducationDetails>(e =>
            {
                e.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Experience
            builder.Entity<Experience>(e =>
            {
                e.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Payslips
            builder.Entity<Payslips>(e =>
            {
                e.HasOne(x => x.User)
                    .WithMany()
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Earning Precision
            builder.Entity<Earning>()
                .Property(x => x.EarningsPercentage)
                .HasPrecision(18, 2);

            // Employee Performance Precision
            builder.Entity<EmployeePerformance>()
                .Property(x => x.Percentage_Achieved_RO)
                .HasPrecision(18, 2);

            builder.Entity<EmployeePerformance>()
                .Property(x => x.Percentage_Achieved_Self)
                .HasPrecision(18, 2);
        }

        // Employee Details
        public DbSet<EmployeeFamilyDetail> EmployeeFamilyDetails { get; set; }
        public DbSet<EmployeeBankDetails> EmployeeBankDetails { get; set; }
        public DbSet<EducationDetails> EducationDetails { get; set; }
        public DbSet<Experience> Experiences { get; set; }

        // Events
        public DbSet<EventModel> Events { get; set; }
        public DbSet<EventTypes> EventTypes { get; set; }

        // Projects
        public DbSet<Projects> AllProjects { get; set; }

        // Documents
        public DbSet<AddAdminDocName> addAdminDocNames { get; set; }
        public DbSet<AddEmployeeDocName> addEmployeeDocNames { get; set; }
        public DbSet<FileUpload> FileUpload { get; set; }
        public DbSet<AdminDocuments> AdminDocuments { get; set; }

        // Users
        public DbSet<User> User { get; set; }

        // Master
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Role> Role { get; set; }

        // Training
        public DbSet<TrainingType> TrainingType { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Trainer> Trainer { get; set; }

        // Employee HR
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<Resignation> Resignation { get; set; }
        public DbSet<Termination> Termination { get; set; }

        // Tasks
        public DbSet<TaskBoards> TaskBoards { get; set; }
        public DbSet<Tasks> Task { get; set; }
        public DbSet<TaskMembers> Taskmember { get; set; }

        // Timesheet
        public DbSet<Timesheet> Timesheets { get; set; }

        // Performance
        public DbSet<EmployeePerformance> EmployeePerformances { get; set; }

        // Attendance
        public DbSet<Attendance> Attendance { get; set; }

        // Salary
        public DbSet<Deduction> Deduction { get; set; }
        public DbSet<DeductionType> DeductionType { get; set; }
        public DbSet<Earning> Earning { get; set; }
        public DbSet<EarningType> EarningType { get; set; }
        public DbSet<EmployeeSalaries> EmployeeSalaries { get; set; }
        public DbSet<EmployeeEarnings> EmployeeEarnings { get; set; }
        public DbSet<EmployeeDeductions> EmployeeDeductions { get; set; }

        // Leave
        public DbSet<DepartmentLeaves> DepartmentLeaves { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<MasterLeaveType> MasterLeaveTypes { get; set; }

        // Payslips
        public DbSet<Payslips> Payslips { get; set; }
    }
}