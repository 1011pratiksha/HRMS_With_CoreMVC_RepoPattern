using HRMS_With_CoreMVC_RepoPattern.Repository;
using Microsoft.AspNetCore.Mvc;

public class AttendanceReportController : Controller
{
    private readonly IAttendanceReportRepository attendanceRepository;

    public AttendanceReportController(
        IAttendanceReportRepository attendanceRepository)
    {
        this.attendanceRepository = attendanceRepository;
    }

    public async Task<IActionResult> Index()
    {
        var attendance = await attendanceRepository.fetchAttendanceReports();

        ViewBag.TotalAttendance =
            await attendanceRepository.fetchTotalAttendance();

        ViewBag.PresentAttendance =
            await attendanceRepository.fetchPresentAttendance();

        ViewBag.AbsentAttendance =
            await attendanceRepository.fetchAbsentAttendance();

        return View(attendance);
    }
}