using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Workboard.Application.Helper;
using Workboard.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var allowSpecificOrigin = "allowSpecificOrigin";

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigin,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // Replace with frontend URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

builder.Services.InitializedDbConnection(builder.Configuration);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])) //secret key
        };
    });

//Add Scoped
builder.Services.AddScoped<JwtTokenHelper>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseCors(allowSpecificOrigin);

app.UseAuthorization();

app.MapControllers();

app.Run();
