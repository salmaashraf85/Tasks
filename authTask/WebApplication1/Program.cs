
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using WebApplication1.Attributes;
using WebApplication1.Data;
using WebApplication1.Mapper;
using WebApplication1.Models;
using WebApplication1.Service;
using WebApplication1.Service.Implementation;
using WebApplication1.Service.Interfaces;
using WebApplication1.Settings;

namespace WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Add services to the container.

            builder.Services.AddControllers();
            var configuration = builder.Configuration;

            // Configure Mail settings
            var mailSetting = configuration.GetSection("Mail").Get<MailSetting>();
            if (mailSetting == null)
            {
                throw new InvalidOperationException("Mail configuration section is missing or invalid.");
            }
            builder.Services.AddSingleton(mailSetting);

            // Configure Server settings
            var serverSetting = configuration.GetSection("Server").Get<ServerSetting>();
            if (serverSetting == null)
            {
                throw new InvalidOperationException("Server configuration section is missing or invalid.");
            }
            builder.Services.AddSingleton(serverSetting);

            // Configure DataProtectionTokenProvider settings
            var dataProtectionTokenProviderSetting = configuration.GetSection("DataProtectionTokenProvider").Get<DataProtectionTokenProviderSetting>();
            if (dataProtectionTokenProviderSetting == null)
            {
                throw new InvalidOperationException("DataProtectionTokenProvider configuration section is missing or invalid.");
            }
            builder.Services.AddSingleton(dataProtectionTokenProviderSetting);

            builder.Services.AddScoped<IPasswordResetService, PasswordResetService>();

            // Register services
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IOtpService, OtpService>();
            builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            builder.Services.AddScoped<ValidateSessionAttribute>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

            builder.Services.AddAutoMapper(cfg => { }, typeof(ProfileMapper).Assembly);
            builder.Services.AddHttpContextAccessor();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });

                
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
    });
            });
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

                await RoleSeeder.Initialize(roleManager, userManager);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
