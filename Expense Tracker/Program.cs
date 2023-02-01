using Microsoft.EntityFrameworkCore;
using Expense_Tracker.Models;
using Microsoft.AspNetCore.Identity;
using Expense_Tracker.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
builder.Services.AddCoreAdmin("Admin");
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDgzNUAzMTM4MmUzNDJlMzBFNTFZdHBJQkROTWFMWDQ1dlBoWlNMWERoditkeXlFQVIxcCtuYnc4VTJNPQ==");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "Admin",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapRazorPages();
});

app.MapRazorPages();
app.UseCoreAdminCustomUrl("coreadmin");
app.Run();