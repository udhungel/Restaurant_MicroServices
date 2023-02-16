using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Mango.Services.DbContexts;
using Manga.Services.Identity.Models;
using Manga.Services.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

//builder.Services.AddIdentityServer(options => {
//options.Events.RaiseErrorEvents = true;
//    options.Events.RaiseInformationEvents = true;
//    options.Events.RaiseFailureEvents = true;
//    options.Events.RaiseSuccessEvents = true;
//    options.EmitStaticAudienceClaim = true;
//}).AddInMemoryIdentityResources(SD.IdentityResources).AddInMemoryApiScopes(SD.ApiScopes)
//                                                     .AddInMemoryClients(SD.clients)
//                                                     .AddAspNetIdentity<ApplicationUser>();
var identityBuilder = builder.Services.AddIdentityServer(options =>
{ options.Events.RaiseErrorEvents = true;
  options.Events.RaiseInformationEvents = true;
  options.Events.RaiseFailureEvents = true;
  options.Events.RaiseSuccessEvents = true;
  options.EmitStaticAudienceClaim = true;
}).AddInMemoryIdentityResources(SD.IdentityResources)
  .AddInMemoryApiScopes(SD.ApiScopes)
  .AddInMemoryClients(SD.clients)
  .AddAspNetIdentity<ApplicationUser>();

identityBuilder.AddDeveloperSigningCredential();



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

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
