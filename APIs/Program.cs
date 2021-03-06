using APIs.Models;
using APIs.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
});
builder.Services.AddScoped<IGenreRepo, GenreRepo>();
builder.Services.AddScoped<IMovieRepo, MovieRepo>();
builder.Services.AddControllers();
builder.Services.AddCors(options => {
    options.AddPolicy("MyPolicy", policyBuilder =>
{
    policyBuilder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
});
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors("MyPolicy");
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
