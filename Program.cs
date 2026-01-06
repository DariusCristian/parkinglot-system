using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParkingLotSystem.Data;
using ParkingLotSystem.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// App DB (your existing one)
builder.Services.AddDbContext<ParkingLotSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ParkingLotSystemContext")));

// Identity DB (new one)
builder.Services.AddDbContext<ParkingLotSystemIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ParkingLotSystemIdentityContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ParkingLotSystemIdentityContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();