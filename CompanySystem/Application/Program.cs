using Business.Interfaces;
using Business.Managers;
using Infrastructure.Repository;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CompanySystemContext>(options =>
                options.UseSqlServer(
                    "Server=localhost;Database=CompanySystemDB;User=SA;" +
                    "Password=NadaSQL100;TrustServerCertificate=True;MultipleActiveResultSets=True"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
builder.Services.AddScoped<IUserRoleManager, UserRoleManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IEmployeeDetailManager, EmployeeDetailManager>();
builder.Services.AddScoped<IUserDetailManager, UserDetailManager>();

var app = builder.Build();

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