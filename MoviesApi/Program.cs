using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies.Entities.Movies;
using Movies.Helpers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<MoviesDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Movies")));

builder.Services.AddScoped(provider =>
{
    var mConfig = new MapperConfiguration(conf =>
    {
        conf.AddProfile(new AutoMapperProfile());
    });

    return mConfig.CreateMapper();
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
