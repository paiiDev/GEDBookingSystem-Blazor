using GedBooking.Application.Features.Bookings.Queries.GetAllBookings;
using GedBooking.Application.Interfaces.Repositories;
using GedBooking.Infrastructure.Data;
using GedBooking.Infrastructure.Mappings;
using GedBooking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<BookingProfile>();
});

builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllBookingsQuery).Assembly));


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();



app.MapControllers();

app.Run();
