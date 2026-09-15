using HRMS_With_CoreMVC_RepoPattern.Data;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using HRMS_With_CoreMVC_RepoPattern.Services;
using Microsoft.EntityFrameworkCore;
using HRMS_With_CoreMVC_RepoPattern.Repository;
using HRMS_With_CoreMVC_RepoPattern.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped<IEventTypeService, EventTypeService>();
builder.Services.AddScoped<IEventService,  EventService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("dbconn")
    ));
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPromotionRepository, PromotionService>();
builder.Services.AddScoped<ITrainerRepository, TrainerService>();

builder.Services.AddScoped<ITrainingTypeRepository, TrainingTypeService>();

builder.Services.AddScoped<IProjectRepository, ProjectRepositoryServices>();


builder.Services.AddScoped<IResignationRepository, ResignationService>();
builder.Services.AddScoped<ITerminationRepository, TerminationService>();
builder.Services.AddScoped<ITrainingRepository, TrainingService>();

builder.Services.AddScoped<ILeaveService, LeaveService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",

  //  pattern: "{controller=Project}/{action=Index}/{id?}")
    pattern: "{controller=Auth}/{action=SignIn}/{id?}")

    //pattern: "{controller=Resignation}/{action=Index}/{id?}")

    .WithStaticAssets();


app.Run();