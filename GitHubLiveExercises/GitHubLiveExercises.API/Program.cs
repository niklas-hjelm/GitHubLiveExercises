using DataAccess.Repositories;
using GitHubLiveExercises.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<AnimalRepository>();



var app = builder.Build();


app.MapAnimalEndpoints();

app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
