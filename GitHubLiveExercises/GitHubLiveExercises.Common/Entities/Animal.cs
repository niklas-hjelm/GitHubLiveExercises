namespace GitHubLiveExercises.Common.Interfaces;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public ICollection<Person> Owners { get; set; }
}