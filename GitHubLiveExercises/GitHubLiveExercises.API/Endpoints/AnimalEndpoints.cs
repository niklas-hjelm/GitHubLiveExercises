using DataAccess.Repositories;
using GitHubLiveExercises.Common.Interfaces;

namespace GitHubLiveExercises.API.Endpoints;

public static class AnimalEndpoints
{
    public static IEndpointRouteBuilder MapAnimalEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/animal");

        group.MapGet("/", async (AnimalRepository repo) =>
        {
            return Results.Ok(await repo.GetAllAsync());
        });

        group.MapGet("/{id}", async (AnimalRepository repo, int id) =>
        {
            var existingAnimal = await repo.GetByIdAsync(id);
            if (existingAnimal is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(existingAnimal);
        });

        group.MapPost("/", async (AnimalRepository repo, Animal animal) =>
        {
            //TODO: Review this endpoint
            await repo.AddAsync(animal);
            return Results.Ok();
        });

        group.MapPut("/{id}", async (AnimalRepository repo, int id, Animal animal) =>
        {
            var existingAnimal = await repo.GetByIdAsync(id);
            if (existingAnimal is null)
            {
                return Results.NotFound();
            }
            await repo.UpdateAsync(animal);
            return Results.Ok();
        });

        group.MapDelete("/{id}", async (AnimalRepository repo, int id) =>
        {
            var existingAnimal = await repo.GetByIdAsync(id);
            if (existingAnimal is null)
            {
                return Results.NotFound();
            }
            await repo.DeleteAsync(existingAnimal);
            return Results.Ok();
        });

        return app;
    }
}