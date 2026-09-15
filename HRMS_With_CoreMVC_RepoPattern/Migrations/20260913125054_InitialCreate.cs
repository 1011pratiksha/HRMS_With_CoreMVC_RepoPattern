using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS_With_CoreMVC_RepoPattern.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        //protected override void Up(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.CreateTable(
        //        name: "addAdminDocNames",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            DocName = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_addAdminDocNames", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "addEmployeeDocNames",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            DocName = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_addEmployeeDocNames", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AdminDocuments",
        //        columns: table => new
        //        {
        //            AdminDocId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            DocName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            DocFile = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AdminDocuments", x => x.AdminDocId);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AllProjects",
        //        columns: table => new
        //        {
        //            ProjectId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ProjectName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
        //            ClientName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
        //            StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            ProjectValue = table.Column<double>(type: "float", nullable: false),
        //            PriceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
        //            LogoPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
        //            Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AllProjects", x => x.ProjectId);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DeductionType",
        //        columns: table => new
        //        {
        //            DeductionTypeId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            DeductionsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DeductionType", x => x.DeductionTypeId);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Departments",
        //        columns: table => new
        //        {
        //            DepartmentId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            NoOfEmployee = table.Column<int>(type: "int", nullable: false),
        //            Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Departments", x => x.DepartmentId);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "EarningType",
        //        columns: table => new
        //        {
        //            EarntypeId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            EarningName = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_EarningType", x => x.EarntypeId);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "EmployeePerformances",
        //        columns: table => new
        //        {
        //            ID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            EmployeeId = table.Column<int>(type: "int", nullable: false),
        //            Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            DateofJoin = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            ROName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            DateofConfirmation = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            RODesignation = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            PreviousyearsofExp = table.Column<int>(type: "int", nullable: false),
        //            Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Sub_Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Weightage = table.Column<int>(type: "int", nullable: true),
        //            Percentage_Achieved_Self = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
        //            Points_Scored_Self = table.Column<int>(type: "int", nullable: false),
        //            Percentage_Achieved_RO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
        //            Points_Scored_RO = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_EmployeePerformances", x => x.ID);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "EventTypes",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            color = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_EventTypes", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "MasterLeaveType",
        //        columns: table => new
        //        {
        //            LeaveTypeId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            LeaveType = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_MasterLeaveType", x => x.LeaveTypeId);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Role",
        //        columns: table => new
        //        {
        //            RoleId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Role", x => x.RoleId);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Trainer",
        //        columns: table => new
        //        {
        //            TrainerId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Phone = table.Column<long>(type: "bigint", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Trainer", x => x.TrainerId);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TrainingType",
        //        columns: table => new
        //        {
        //            TrainingTypeId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            TrainingTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TrainingType", x => x.TrainingTypeId);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Task",
        //        columns: table => new
        //        {
        //            TaskId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
        //            Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            ProjectId = table.Column<int>(type: "int", nullable: false),
        //            Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
        //            FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Task", x => x.TaskId);
        //            table.ForeignKey(
        //                name: "FK_Task_AllProjects_ProjectId",
        //                column: x => x.ProjectId,
        //                principalTable: "AllProjects",
        //                principalColumn: "ProjectId",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Designations",
        //        columns: table => new
        //        {
        //            DesignationId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            DepartmentId = table.Column<int>(type: "int", nullable: true),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            NoOfEmployee = table.Column<int>(type: "int", nullable: true),
        //            status = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Designations", x => x.DesignationId);
        //            table.ForeignKey(
        //                name: "FK_Designations_Departments_DepartmentId",
        //                column: x => x.DepartmentId,
        //                principalTable: "Departments",
        //                principalColumn: "DepartmentId");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Events",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Date = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            EventTypeId = table.Column<int>(type: "int", nullable: false),
        //            Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Events", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Events_EventTypes_EventTypeId",
        //                column: x => x.EventTypeId,
        //                principalTable: "EventTypes",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DepartmentLeaves",
        //        columns: table => new
        //        {
        //            DepartmentLeavesId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            DepartmentId = table.Column<int>(type: "int", nullable: false),
        //            LeaveTypeId = table.Column<int>(type: "int", nullable: false),
        //            LeavesCount = table.Column<int>(type: "int", nullable: false),
        //            Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DepartmentLeaves", x => x.DepartmentLeavesId);
        //            table.ForeignKey(
        //                name: "FK_DepartmentLeaves_Departments_DepartmentId",
        //                column: x => x.DepartmentId,
        //                principalTable: "Departments",
        //                principalColumn: "DepartmentId",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_DepartmentLeaves_MasterLeaveType_LeaveTypeId",
        //                column: x => x.LeaveTypeId,
        //                principalTable: "MasterLeaveType",
        //                principalColumn: "LeaveTypeId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TaskBoards",
        //        columns: table => new
        //        {
        //            TaskBoardId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            ProjectId = table.Column<int>(type: "int", nullable: false),
        //            TaskId = table.Column<int>(type: "int", nullable: false),
        //            Percentage = table.Column<int>(type: "int", nullable: false),
        //            DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TaskBoards", x => x.TaskBoardId);
        //            table.ForeignKey(
        //                name: "FK_TaskBoards_AllProjects_ProjectId",
        //                column: x => x.ProjectId,
        //                principalTable: "AllProjects",
        //                principalColumn: "ProjectId",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_TaskBoards_Task_TaskId",
        //                column: x => x.TaskId,
        //                principalTable: "Task",
        //                principalColumn: "TaskId",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Deduction",
        //        columns: table => new
        //        {
        //            DeductionId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            DeductionTypeId = table.Column<int>(type: "int", nullable: false),
        //            DepartmentId = table.Column<int>(type: "int", nullable: false),
        //            DesignationId = table.Column<int>(type: "int", nullable: false),
        //            DeductionPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
        //            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Deduction", x => x.DeductionId);
        //            table.ForeignKey(
        //                name: "FK_Deduction_DeductionType_DeductionTypeId",
        //                column: x => x.DeductionTypeId,
        //                principalTable: "DeductionType",
        //                principalColumn: "DeductionTypeId",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Deduction_Departments_DepartmentId",
        //                column: x => x.DepartmentId,
        //                principalTable: "Departments",
        //                principalColumn: "DepartmentId",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Deduction_Designations_DesignationId",
        //                column: x => x.DesignationId,
        //                principalTable: "Designations",
        //                principalColumn: "DesignationId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Earning",
        //        columns: table => new
        //        {
        //            EarningsId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            EarntypeId = table.Column<int>(type: "int", nullable: false),
        //            EarningsPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
        //            DepartmentId = table.Column<int>(type: "int", nullable: false),
        //            DesignationId = table.Column<int>(type: "int", nullable: false),
        //            CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Earning", x => x.EarningsId);
        //            table.ForeignKey(
        //                name: "FK_Earning_Departments_DepartmentId",
        //                column: x => x.DepartmentId,
        //                principalTable: "Departments",
        //                principalColumn: "DepartmentId",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Earning_Designations_DesignationId",
        //                column: x => x.DesignationId,
        //                principalTable: "Designations",
        //                principalColumn: "DesignationId",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Earning_EarningType_EarntypeId",
        //                column: x => x.EarntypeId,
        //                principalTable: "EarningType",
        //                principalColumn: "EarntypeId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "User",
        //        columns: table => new
        //        {
        //            UserId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            RoleId = table.Column<int>(type: "int", nullable: false),
        //            DepartmentId = table.Column<int>(type: "int", nullable: true),
        //            DesignationtId = table.Column<int>(type: "int", nullable: true),
        //            DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            AboutEmployee = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            ReportingManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_User", x => x.UserId);
        //            table.ForeignKey(
        //                name: "FK_User_Departments_DepartmentId",
        //                column: x => x.DepartmentId,
        //                principalTable: "Departments",
        //                principalColumn: "DepartmentId");
        //            table.ForeignKey(
        //                name: "FK_User_Designations_DesignationtId",
        //                column: x => x.DesignationtId,
        //                principalTable: "Designations",
        //                principalColumn: "DesignationId");
        //            table.ForeignKey(
        //                name: "FK_User_Role_RoleId",
        //                column: x => x.RoleId,
        //                principalTable: "Role",
        //                principalColumn: "RoleId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "EducationDetails",
        //        columns: table => new
        //        {
        //            EducationDetailsId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            EducationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            startdate = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            enddate = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            UserId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_EducationDetails", x => x.EducationDetailsId);
        //            table.ForeignKey(
        //                name: "FK_EducationDetails_User_UserId",
        //                column: x => x.UserId,
        //                principalTable: "User",
        //                principalColumn: "UserId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "EmployeeBankDetails",
        //        columns: table => new
        //        {
        //            BankDetailId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            IFSCCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            UserId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_EmployeeBankDetails", x => x.BankDetailId);
        //            table.ForeignKey(
        //                name: "FK_EmployeeBankDetails_User_UserId",
        //                column: x => x.UserId,
        //                principalTable: "User",
        //                principalColumn: "UserId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "EmployeeFamilyDetails",
        //        columns: table => new
        //        {
        //            FamilyDetailId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Relation = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            UserId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_EmployeeFamilyDetails", x => x.FamilyDetailId);
        //            table.ForeignKey(
        //                name: "FK_EmployeeFamilyDetails_User_UserId",
        //                column: x => x.UserId,
        //                principalTable: "User",
        //                principalColumn: "UserId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FileUpload",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            UserId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FileUpload", x => x.id);
        //            table.ForeignKey(
        //                name: "FK_FileUpload_User_UserId",
        //                column: x => x.UserId,
        //                principalTable: "User",
        //                principalColumn: "UserId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "LeaveBalance",
        //        columns: table => new
        //        {
        //            LeaveBalanceId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            UserId = table.Column<int>(type: "int", nullable: false),
        //            DepartmentLeavesId = table.Column<int>(type: "int", nullable: false),
        //            LeaveTypeId = table.Column<int>(type: "int", nullable: false),
        //            TotalLeaves = table.Column<int>(type: "int", nullable: false),
        //            UsedLeaves = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_LeaveBalance", x => x.LeaveBalanceId);
        //            table.ForeignKey(
        //                name: "FK_LeaveBalance_DepartmentLeaves_DepartmentLeavesId",
        //                column: x => x.DepartmentLeavesId,
        //                principalTable: "DepartmentLeaves",
        //                principalColumn: "DepartmentLeavesId",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_LeaveBalance_MasterLeaveType_LeaveTypeId",
        //                column: x => x.LeaveTypeId,
        //                principalTable: "MasterLeaveType",
        //                principalColumn: "LeaveTypeId",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_LeaveBalance_User_UserId",
        //                column: x => x.UserId,
        //                principalTable: "User",
        //                principalColumn: "UserId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "LeaveRequest",
        //        columns: table => new
        //        {
        //            LeaveRequestId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            UserId = table.Column<int>(type: "int", nullable: false),
        //            LeaveTypeId = table.Column<int>(type: "int", nullable: false),
        //            StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            NumberOfDays = table.Column<int>(type: "int", nullable: false),
        //            Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            StatusHistory = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_LeaveRequest", x => x.LeaveRequestId);
        //            table.ForeignKey(
        //                name: "FK_LeaveRequest_MasterLeaveType_LeaveTypeId",
        //                column: x => x.LeaveTypeId,
        //                principalTable: "MasterLeaveType",
        //                principalColumn: "LeaveTypeId",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_LeaveRequest_User_UserId",
        //                column: x => x.UserId,
        //                principalTable: "User",
        //                principalColumn: "UserId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ProjectsUser",
        //        columns: table => new
        //        {
        //            ProjectsProjectId = table.Column<int>(type: "int", nullable: false),
        //            UsersUserId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProjectsUser", x => new { x.ProjectsProjectId, x.UsersUserId });
        //            table.ForeignKey(
        //                name: "FK_ProjectsUser_AllProjects_ProjectsProjectId",
        //                column: x => x.ProjectsProjectId,
        //                principalTable: "AllProjects",
        //                principalColumn: "ProjectId",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ProjectsUser_User_UsersUserId",
        //                column: x => x.UsersUserId,
        //                principalTable: "User",
        //                principalColumn: "UserId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Promotion",
        //        columns: table => new
        //        {
        //            PromotionId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            UserID = table.Column<int>(type: "int", nullable: false),
        //            DesignationFrom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
        //            DesignationTo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
        //            Date = table.Column<DateTime>(type: "datetime2", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Promotion", x => x.PromotionId);
        //            table.ForeignKey(
        //                name: "FK_Promotion_User_UserID",
        //                column: x => x.UserID,
        //                principalTable: "User",
        //                principalColumn: "UserId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Resignation",
        //        columns: table => new
        //        {
        //            ResignationId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            UserID = table.Column<int>(type: "int", nullable: false),
        //            DepartmentId = table.Column<int>(type: "int", nullable: false),
        //            NoticeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            ResignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Resignation", x => x.ResignationId);
        //            table.ForeignKey(
        //                name: "FK_Resignation_Departments_DepartmentId",
        //                column: x => x.DepartmentId,
        //                principalTable: "Departments",
        //                principalColumn: "DepartmentId",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Resignation_User_UserID",
        //                column: x => x.UserID,
        //                principalTable: "User",
        //                principalColumn: "UserId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Taskmember",
        //        columns: table => new
        //        {
        //            AssignedId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            TaskId = table.Column<int>(type: "int", nullable: false),
        //            UserId = table.Column<int>(type: "int", nullable: false),
        //            UserId1 = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Taskmember", x => x.AssignedId);
        //            table.ForeignKey(
        //                name: "FK_Taskmember_Task_TaskId",
        //                column: x => x.TaskId,
        //                principalTable: "Task",
        //                principalColumn: "TaskId",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Taskmember_User_UserId",
        //                column: x => x.UserId,
        //                principalTable: "User",
        //                principalColumn: "UserId",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Taskmember_User_UserId1",
        //                column: x => x.UserId1,
        //                principalTable: "User",
        //                principalColumn: "UserId");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Termination",
        //        columns: table => new
        //        {
        //            TerminationId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            UserID = table.Column<int>(type: "int", nullable: false),
        //            TerminationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            NoticeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            ResignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Termination", x => x.TerminationId);
        //            table.ForeignKey(
        //                name: "FK_Termination_User_UserID",
        //                column: x => x.UserID,
        //                principalTable: "User",
        //                principalColumn: "UserId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Timesheet",
        //        columns: table => new
        //        {
        //            TimesheetId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            UserId = table.Column<int>(type: "int", nullable: false),
        //            Date = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            WorkHours = table.Column<int>(type: "int", nullable: false),
        //            Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
        //            ProjectId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Timesheet", x => x.TimesheetId);
        //            table.ForeignKey(
        //                name: "FK_Timesheet_AllProjects_ProjectId",
        //                column: x => x.ProjectId,
        //                principalTable: "AllProjects",
        //                principalColumn: "ProjectId",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Timesheet_User_UserId",
        //                column: x => x.UserId,
        //                principalTable: "User",
        //                principalColumn: "UserId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Training",
        //        columns: table => new
        //        {
        //            TrainingId = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            TrainerId = table.Column<int>(type: "int", nullable: false),
        //            TrainingTypeId = table.Column<int>(type: "int", nullable: false),
        //            UserId = table.Column<int>(type: "int", nullable: false),
        //            TrainingCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
        //            Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Training", x => x.TrainingId);
        //            table.ForeignKey(
        //                name: "FK_Training_Trainer_TrainerId",
        //                column: x => x.TrainerId,
        //                principalTable: "Trainer",
        //                principalColumn: "TrainerId",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Training_TrainingType_TrainingTypeId",
        //                column: x => x.TrainingTypeId,
        //                principalTable: "TrainingType",
        //                principalColumn: "TrainingTypeId",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Training_User_UserId",
        //                column: x => x.UserId,
        //                principalTable: "User",
        //                principalColumn: "UserId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Deduction_DeductionTypeId",
        //        table: "Deduction",
        //        column: "DeductionTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Deduction_DepartmentId",
        //        table: "Deduction",
        //        column: "DepartmentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Deduction_DesignationId",
        //        table: "Deduction",
        //        column: "DesignationId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DepartmentLeaves_DepartmentId",
        //        table: "DepartmentLeaves",
        //        column: "DepartmentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DepartmentLeaves_LeaveTypeId",
        //        table: "DepartmentLeaves",
        //        column: "LeaveTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Designations_DepartmentId",
        //        table: "Designations",
        //        column: "DepartmentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Earning_DepartmentId",
        //        table: "Earning",
        //        column: "DepartmentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Earning_DesignationId",
        //        table: "Earning",
        //        column: "DesignationId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Earning_EarntypeId",
        //        table: "Earning",
        //        column: "EarntypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_EducationDetails_UserId",
        //        table: "EducationDetails",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_EmployeeBankDetails_UserId",
        //        table: "EmployeeBankDetails",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_EmployeeFamilyDetails_UserId",
        //        table: "EmployeeFamilyDetails",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Events_EventTypeId",
        //        table: "Events",
        //        column: "EventTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FileUpload_UserId",
        //        table: "FileUpload",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_LeaveBalance_DepartmentLeavesId",
        //        table: "LeaveBalance",
        //        column: "DepartmentLeavesId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_LeaveBalance_LeaveTypeId",
        //        table: "LeaveBalance",
        //        column: "LeaveTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_LeaveBalance_UserId",
        //        table: "LeaveBalance",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_LeaveRequest_LeaveTypeId",
        //        table: "LeaveRequest",
        //        column: "LeaveTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_LeaveRequest_UserId",
        //        table: "LeaveRequest",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProjectsUser_UsersUserId",
        //        table: "ProjectsUser",
        //        column: "UsersUserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Promotion_UserID",
        //        table: "Promotion",
        //        column: "UserID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Resignation_DepartmentId",
        //        table: "Resignation",
        //        column: "DepartmentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Resignation_UserID",
        //        table: "Resignation",
        //        column: "UserID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Task_ProjectId",
        //        table: "Task",
        //        column: "ProjectId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_TaskBoards_ProjectId",
        //        table: "TaskBoards",
        //        column: "ProjectId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_TaskBoards_TaskId",
        //        table: "TaskBoards",
        //        column: "TaskId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Taskmember_TaskId",
        //        table: "Taskmember",
        //        column: "TaskId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Taskmember_UserId",
        //        table: "Taskmember",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Taskmember_UserId1",
        //        table: "Taskmember",
        //        column: "UserId1");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Termination_UserID",
        //        table: "Termination",
        //        column: "UserID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Timesheet_ProjectId",
        //        table: "Timesheet",
        //        column: "ProjectId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Timesheet_UserId",
        //        table: "Timesheet",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Training_TrainerId",
        //        table: "Training",
        //        column: "TrainerId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Training_TrainingTypeId",
        //        table: "Training",
        //        column: "TrainingTypeId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Training_UserId",
        //        table: "Training",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_User_DepartmentId",
        //        table: "User",
        //        column: "DepartmentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_User_DesignationtId",
        //        table: "User",
        //        column: "DesignationtId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_User_RoleId",
        //        table: "User",
        //        column: "RoleId");
        //}

        ///// <inheritdoc />
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "addAdminDocNames");

        //    migrationBuilder.DropTable(
        //        name: "addEmployeeDocNames");

        //    migrationBuilder.DropTable(
        //        name: "AdminDocuments");

        //    migrationBuilder.DropTable(
        //        name: "Deduction");

        //    migrationBuilder.DropTable(
        //        name: "Earning");

        //    migrationBuilder.DropTable(
        //        name: "EducationDetails");

        //    migrationBuilder.DropTable(
        //        name: "EmployeeBankDetails");

        //    migrationBuilder.DropTable(
        //        name: "EmployeeFamilyDetails");

        //    migrationBuilder.DropTable(
        //        name: "EmployeePerformances");

        //    migrationBuilder.DropTable(
        //        name: "Events");

        //    migrationBuilder.DropTable(
        //        name: "FileUpload");

        //    migrationBuilder.DropTable(
        //        name: "LeaveBalance");

        //    migrationBuilder.DropTable(
        //        name: "LeaveRequest");

        //    migrationBuilder.DropTable(
        //        name: "ProjectsUser");

        //    migrationBuilder.DropTable(
        //        name: "Promotion");

        //    migrationBuilder.DropTable(
        //        name: "Resignation");

        //    migrationBuilder.DropTable(
        //        name: "TaskBoards");

        //    migrationBuilder.DropTable(
        //        name: "Taskmember");

        //    migrationBuilder.DropTable(
        //        name: "Termination");

        //    migrationBuilder.DropTable(
        //        name: "Timesheet");

        //    migrationBuilder.DropTable(
        //        name: "Training");

        //    migrationBuilder.DropTable(
        //        name: "DeductionType");

        //    migrationBuilder.DropTable(
        //        name: "EarningType");

        //    migrationBuilder.DropTable(
        //        name: "EventTypes");

        //    migrationBuilder.DropTable(
        //        name: "DepartmentLeaves");

        //    migrationBuilder.DropTable(
        //        name: "Task");

        //    migrationBuilder.DropTable(
        //        name: "Trainer");

        //    migrationBuilder.DropTable(
        //        name: "TrainingType");

        //    migrationBuilder.DropTable(
        //        name: "User");

        //    migrationBuilder.DropTable(
        //        name: "MasterLeaveType");

        //    migrationBuilder.DropTable(
        //        name: "AllProjects");

        //    migrationBuilder.DropTable(
        //        name: "Designations");

        //    migrationBuilder.DropTable(
        //        name: "Role");

        //    migrationBuilder.DropTable(
        //        name: "Departments");
        //}
    }
}
