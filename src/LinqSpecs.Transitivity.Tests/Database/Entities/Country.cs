namespace LinqSpecs.Transitivity.Tests.Database.Entities;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Client> Citizens { get; set; }
}