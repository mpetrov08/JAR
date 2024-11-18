using JAR.Core.Hubs;
using JAR.Extensions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("JarDbContextConnection") ?? throw new InvalidOperationException("Connection string 'JarDbContextConnection' not found.");

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.MapHub<ChatHub>("/chatHub");

await app.CreateAdminRoleAsync();

app.Run();