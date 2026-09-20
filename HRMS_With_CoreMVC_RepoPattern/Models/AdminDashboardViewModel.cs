using System;
using System.Collections.Generic;

namespace HRMS_With_CoreMVC_RepoPattern.Models
{
    public class AdminDashboardViewModel
    {
        // =========================
        // TOP STATISTICS
        // =========================

        public int TotalEmployees { get; set; }

        public int TotalDepartments { get; set; }

        public int TotalProjects { get; set; }

        public int TotalTasks { get; set; }

        public int TotalClients { get; set; }

        public int TotalJobApplicants { get; set; }

        public int NewHires { get; set; }


        // =========================
        // EMPLOYEES BY DEPARTMENT
        // =========================

        public List<DepartmentEmployeeViewModel> EmployeesByDepartment { get; set; }
            = new List<DepartmentEmployeeViewModel>();


        // =========================
        // EMPLOYEE STATUS
        // =========================

        public int ActiveEmployees { get; set; }

        public int InactiveEmployees { get; set; }

        public int OnLeaveEmployees { get; set; }

        public int OtherEmployees { get; set; }


        // =========================
        // ATTENDANCE
        // =========================

        public int PresentEmployees { get; set; }

        public int HalfDayEmployees { get; set; }

        public int AbsentEmployees { get; set; }

        public int AttendanceTotal { get; set; }


        // =========================
        // CLOCK IN / OUT
        // =========================

        public List<AttendanceDashboardViewModel> TodayAttendance { get; set; }
            = new List<AttendanceDashboardViewModel>();


        // =========================
        // PROJECTS
        // =========================

        public List<ProjectDashboardViewModel> Projects { get; set; }
            = new List<ProjectDashboardViewModel>();


        // =========================
        // TASK STATISTICS
        // =========================

        public int CompletedTasks { get; set; }

        public int OnHoldTasks { get; set; }

        public int InProgressTasks { get; set; }

        public int PendingTasks { get; set; }
        public int TeamMembers { get; set; }

        public int PresentToday { get; set; }

        public int PendingLeaveRequests { get; set; }
        public decimal TeamPerformance { get; set; }
        // =========================
        // TIMESHEET
        // =========================

        public int TotalWorkHours { get; set; }


        // =========================
        // PAYROLL / EARNINGS
        // =========================

        public decimal TotalEarnings { get; set; }

        public decimal WeeklyProfit { get; set; }
    }


    // ==========================================
    // DEPARTMENT DASHBOARD DATA
    // ==========================================

    public class DepartmentEmployeeViewModel
    {
        public string DepartmentName { get; set; }

        public int EmployeeCount { get; set; }
    }


    // ==========================================
    // ATTENDANCE DASHBOARD DATA
    // ==========================================

    public class AttendanceDashboardViewModel
    {
        public int UserId { get; set; }

        public string EmployeeName { get; set; }

        public DateTime? CheckIn { get; set; }

        public DateTime? CheckOut { get; set; }

        public string Status { get; set; }

        public int Late { get; set; }
    }


    // ==========================================
    // PROJECT DASHBOARD DATA
    // ==========================================

    public class ProjectDashboardViewModel
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public DateTime EndDate { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }
    }
}