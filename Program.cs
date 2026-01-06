using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParkingLotSystem.Areas.Identity.Data;
using ParkingLotSystem.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using ParkingLotSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Authorization policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

// Razor Pages + access rules (Lab 6)
builder.Services.AddRazorPages(options =>
{
    // Require login
    options.Conventions.AuthorizeFolder("/Subscriptions");
    options.Conventions.AuthorizeFolder("/Subscribers");

    // Admin-only CRUD
    options.Conventions.AuthorizePage("/ParkingLots/Create", "AdminOnly");
    options.Conventions.AuthorizePage("/ParkingLots/Edit", "AdminOnly");
    options.Conventions.AuthorizePage("/ParkingLots/Delete", "AdminOnly");

    options.Conventions.AuthorizePage("/SubscriptionPlans/Create", "AdminOnly");
    options.Conventions.AuthorizePage("/SubscriptionPlans/Edit", "AdminOnly");
    options.Conventions.AuthorizePage("/SubscriptionPlans/Delete", "AdminOnly");
});

// App DB
builder.Services.AddDbContext<ParkingLotSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ParkingLotSystemContext")));

// Identity DB
builder.Services.AddDbContext<ParkingLotSystemIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ParkingLotSystemIdentityContext")));

// Identity + Roles
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ParkingLotSystemIdentityContext>()
.AddDefaultTokenProviders();

builder.Services.AddTransient<IEmailSender, EmailSender>();

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