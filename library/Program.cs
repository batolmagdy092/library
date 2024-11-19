using library.Data;
using library.Repository.AuthorRepo;
using library.Repository.BookRepo;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
                                            options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconnection")));

builder.Services.AddScoped<IBookrepo, Bookrepo>();
builder.Services.AddScoped<IAuthorrepo , Authorrepo>();

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
