using DatingAgencyServer.Repositories;
using DatingAgencyServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AuthRepository>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<ClientService>();

builder.Services.AddScoped<AdminRepository>();
builder.Services.AddScoped<AdminService>();

builder.Services.AddScoped<EmployeeService>();

builder.Services.AddScoped<MeetingRepository>();
builder.Services.AddScoped<MeetingService>();

builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<CustomerService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();