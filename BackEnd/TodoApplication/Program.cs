using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using TodoApplication.Authentication;
using TodoApplication.Interface;
using TodoApplication.Models;
using TodoApplication.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskContext>();
builder.Services.AddScoped<IUserDetails, UserDetailsRepository>();
builder.Services.AddScoped<IUserDetailsService, UserDetailsService>();
builder.Services.AddScoped<ICategoryDetails, CategoryDetailsRepository>();
builder.Services.AddScoped<ICategoryDetailsService, CategoryDetailsService>();
builder.Services.AddScoped<ITaskDetails, TaskDetailsRepository>();
builder.Services.AddScoped<ITaskDetailsService, TaskDetailsService>();
builder.Services.AddScoped<ITokenGeneration, TokenGeneration>();
builder.Services.AddScoped<ITokenValidator, TokenValidator>();
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
     {
         var tokenValidator = builder.Services.BuildServiceProvider().GetService<ITokenValidator>();
         options.TokenValidationParameters = tokenValidator.GetTokenValidationParameters();
     });



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new List<string>()
        }
    });
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo V1");
    });
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
