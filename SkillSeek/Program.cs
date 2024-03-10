using SkillSeek.Identity.Dependency;
using SkillSeek.Infrastructure.Dependency;
using SkillSeek.Infrastructure.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var configuration = builder.Configuration;

services.AddInfrastructureService(configuration);

services.AddIdentityService(configuration);

services.AddControllersWithViews();

services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

services.ConfigureApplicationCookie(options =>
{
    options.LogoutPath = "/Account/Logout";
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

services.AddRazorPages();

var app = builder.Build();

// app.UseExceptionHandler("/Home/Error");

app.UseHsts();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();

    dbInitializer.Initialize();
}

app.Run();