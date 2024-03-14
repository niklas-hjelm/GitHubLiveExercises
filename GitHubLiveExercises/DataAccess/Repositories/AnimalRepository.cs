using GitHubLiveExercises.Common.Interfaces;

namespace DataAccess.Repositories;

public class AnimalRepository(DbContext context) : IRepository<Animal>
{
	public async Task<IEnumerable<Animal>> GetAllAsync()
	{
		return await context.Animals.ToListAsync();
	}

	public async Task<Animal> GetByIdAsync(int id)
	{
		return await context.Animals.FindAsync(id);
	}

	public async Task AddAsync(Animal entity)
	{
		await context.Animals.Add(entity);
		await context.SaveChanges();
	}

	public async Task UpdateAsync(Animal entity)
	{
		var animal = await context.Animals.FindAsync(entity.Id);

		if (animal == null)
		{
			throw new Exception("Animal not found");
		}
		
		animal.PersonId = entity.PersonId;
		animal.Name = entity.Name;
		animal.Type = entity.Type;

		await context.SaveChanges();
	}

	public async Task DeleteAsync(Animal entity)
	{
		var animal = await context.Animals.FindAsync(entity.Id);

		if (animal == null)
		{
			throw new Exception("Animal not found");
		}

		context.Animals.Remove(animal);
		await context.SaveChanges();
	}
}