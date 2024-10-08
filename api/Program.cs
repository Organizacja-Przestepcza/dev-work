using System.Text;
using api.Data;
using api.Interfaces;
using api.Models;
using api.Repositories;
using api.Service;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using static api.Data.StartupTasks;

var builder = WebApplication.CreateBuilder(args);
Env.Load();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddScoped<ITokenService, TokenService>();

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

if (string.IsNullOrEmpty(connectionString))
    throw new Exception(
        "Connection string not found. Ensure the .env file is correctly configured and placed in the root directory.");
builder.Configuration.AddInMemoryCollection(new List<KeyValuePair<string, string?>>
{
    new("ConnectionStrings:DefaultConnection", connectionString)
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");

if (string.IsNullOrEmpty(jwtIssuer)) throw new Exception("JWT Issuer configuration value is missing.");

if (string.IsNullOrEmpty(jwtAudience)) throw new Exception("JWT Audience configuration value is missing.");

if (string.IsNullOrEmpty(jwtKey)) throw new Exception("JWT key cannot be null or empty");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtIssuer,
        ValidateAudience = true,
        ValidAudience = jwtAudience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(IdentityData.RequireAdminPolicyName,
        policy => policy.RequireClaim(IdentityData.AdminClaimName));
});

builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IBookmarkRepository, BookmarkRepository>();
builder.Services.AddScoped<IConnectionRepository, ConnectionRepository>();
builder.Services.AddScoped<IPostInteractionRepository, PostInteractionRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("nuxtApp", corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("http://localhost:3000");
        corsPolicyBuilder.AllowAnyHeader();
        corsPolicyBuilder.AllowAnyMethod();
        corsPolicyBuilder.AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("nuxtApp");
    app.UseSwagger();
    app.UseSwaggerUI();
}

await DatabaseUpdateAsync(app.Services);
await AdminSeedAsync(app.Services);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();