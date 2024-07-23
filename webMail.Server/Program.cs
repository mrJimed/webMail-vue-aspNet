using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using webMail.Server.Configuration;
using webMail.Server.DbContexts;
using webMail.Server.Factories;
using webMail.Server.Services.Classes;
using webMail.Server.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(2);
        options.SlidingExpiration = true;
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.None;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    });


// My services
builder.Services.AddDbContext<WebMailDbContext>(optionsBuilder => optionsBuilder.UseLazyLoadingProxies()
    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton(ServiceFactory.CreateMailService);
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IMailHistoryService, MailHistoryService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseCors(corsBuilder => corsBuilder.WithOrigins(builder.Configuration.GetClientUrl())
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.Run();
