using Microsoft.EntityFrameworkCore;
using art_store.DataAccess;
using System.Text.Json.Serialization;
using art_store.Services.Contract;
using art_store.DataAccess.Repository;
using art_store.DataAccess.Repository.Contracts;
using art_store.Services;
using art_store.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
// Так как у тебя нет  ViewModels, а сразу используются  ентити, то получаются бесконечные вложеноности
// можешь посмотрть, что будет без этих строк
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new ApplicationException("Could not load 'DefaultConnection' connection string");
}

builder.Services.AddDbContext<art_storeDbContext>(options =>
            options.UseSqlServer(ConfigurationExtensions.GetConnectionString(builder.Configuration, "DefaultConnection"))
            );

builder.Services.AddScoped<IArtRepository, ArtRepository>();
builder.Services.AddScoped<IArtService, ArtService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(ArtProfile));
builder.Services.AddAutoMapper(typeof(DriverProfile));
builder.Services.AddAutoMapper(typeof(OrderProfile));
builder.Services.AddAutoMapper(typeof(UserProfile));


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
