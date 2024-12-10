using Microsoft.EntityFrameworkCore;
using WebApp_Multi_user_chat.Data;
using WebApp_Multi_user_chat.Interfaces;
using WebApp_Multi_user_chat.Services;

var builder = WebApplication.CreateBuilder(args);

// Ajouter la configuration CORS pour autoriser toutes les origines
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Permet toutes les origines
              .AllowAnyMethod()   // Permet toutes les m�thodes (GET, POST, etc.)
              .AllowAnyHeader();  // Permet tous les en-t�tes
    });
});

// Ajouter les services n�cessaires
builder.Services.AddDbContext<ChatDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddControllersWithViews(); // Si vous utilisez Razor
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IValidationService, ValidationService>();
builder.Services.AddScoped<IErrorHandlingService, ErrorHandlingService>();
builder.Services.AddScoped<IErrorLoggingService, ErrorLoggingService>();
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = long.MaxValue;
});

var app = builder.Build();

// Appliquer la politique CORS
app.UseCors("AllowAll");

// Autres middlewares (HTTPS, StaticFiles, etc.)
//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Mapping de la route par d�faut
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
