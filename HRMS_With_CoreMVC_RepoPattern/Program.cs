using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Repositories;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using HRMS_With_CoreMVC_RepoPattern.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IEmployeeService, EmployeeServices>();
builder.Services.AddScoped<IEventTypeService, EventTypeService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("dbconn")
    ));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPromotionRepository, PromotionService>();
builder.Services.AddScoped<ITrainerRepository, TrainerService>();
builder.Services.AddScoped<ITrainingTypeRepository, TrainingTypeService>();

builder.Services.AddScoped<ITaskReportRepository, TaskReportService>();
builder.Services.AddScoped<IProjectReportRepository, ProjectReportRepositoryServices>();
builder.Services.AddScoped<IEmployeeReportRepository, EmployeeReportServices>();
builder.Services.AddScoped<IAttendanceReportRepository, AttendanceReportServices>();
builder.Services.AddScoped<IResignationRepository, ResignationService>();
builder.Services.AddScoped<ITerminationRepository, TerminationService>();
builder.Services.AddScoped<IDailyReportRepository, DailyReportService>();
builder.Services.AddScoped<ILeaveReportRepository, LeaveReportServices>();
builder.Services.AddScoped<IPayslipReportRepository, PayslipReportServices>();
builder.Services.AddScoped<ITrainingRepository, TrainingService>();
builder.Services.AddScoped<IFileUploadRepository, FileUploadService>();
builder.Services.AddScoped<ILeaveService, LeaveService>();

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=SignIn}/{id?}")
    .WithStaticAssets();

app.Run();