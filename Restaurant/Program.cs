using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;
using Restaurant.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<IRepository<MasterMenu>, MasterMenuRepository>();
builder.Services.AddScoped<IRepository<MasterCategoryMenu>, RMasterCategoryMenu>();
builder.Services.AddScoped<IRepository<MasterContactUsInformation>, RMasterContactUsInformation>();
builder.Services.AddScoped<IRepository<MasterItemMenu>, RMasterItemMenu>();
builder.Services.AddScoped<IRepository<MasterOffer>, RMasterOffer>();
builder.Services.AddScoped<IRepository<MasterService>, RMasterService>();
builder.Services.AddScoped<IRepository<MasterSlider>, RMasterSlider>();
builder.Services.AddScoped<IRepository<MasterPartner>, RMasterPartner>();
builder.Services.AddScoped<IRepository<MasterSocialMedium>, RMasterSocialMedium>();
builder.Services.AddScoped<IRepository<MasterWorkingHour>, RMasterWorkingHour>();
builder.Services.AddScoped<IRepository<TransactionBookTable>, RTransactionBookTable>();
builder.Services.AddScoped<IRepository<TransactionContactU>, RTransactionContactU>();
builder.Services.AddScoped<IRepository<SystemSetting>, RSystemSetting>();
builder.Services.AddScoped<IRepository<TransactionNewsletter>, RTransactionNewsletter>();

//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

//builder.Services.Configure<IdentityOptions>(XmlConfigurationExtensions =>
//{
//    XmlConfigurationExtensions.Password.RequireDigit = false;
//    XmlConfigurationExtensions.Password.RequireLowercase = false;
//    XmlConfigurationExtensions.Password.RequireNonAlphanumeric = false;
//    XmlConfigurationExtensions.Password.RequireUppercase = false;
//    XmlConfigurationExtensions.Password.RequiredLength = 3;
//    XmlConfigurationExtensions.Password.RequiredUniqueChars = 1;
//    XmlConfigurationExtensions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//    XmlConfigurationExtensions.Lockout.MaxFailedAccessAttempts = 5;
//    XmlConfigurationExtensions.Lockout.AllowedForNewUsers = true;
//    XmlConfigurationExtensions.User.RequireUniqueEmail = true;
//});

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));

});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Angular app URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAngularApp");




app.UseRouting();
//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
