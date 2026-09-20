using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

public class AttendanceReportController : Controller
{
    private readonly IAttendanceReportRepository attendanceRepository;

    public AttendanceReportController(IAttendanceReportRepository attendanceRepository)
    {
        this.attendanceRepository = attendanceRepository;
    }

    public async Task<IActionResult> Index()
    {
        var attendance = await attendanceRepository.fetchAttendanceReports();

        ViewBag.TotalAttendance = await attendanceRepository.fetchTotalAttendance();
        ViewBag.PresentAttendance = await attendanceRepository.fetchPresentAttendance();
        ViewBag.AbsentAttendance = await attendanceRepository.fetchAbsentAttendance();
        ViewBag.HalfdayAttendance = await attendanceRepository.fetchHalfdayAttendance();

        var attendanceYears = attendance
            .Select(x => x.Date.Year)
            .Distinct()
            .OrderByDescending(x => x)
            .ToList();

        ViewBag.AttendanceYears = attendanceYears;
        ViewBag.CurrentYear = DateTime.Now.Year;

        return View(attendance);
    }
}