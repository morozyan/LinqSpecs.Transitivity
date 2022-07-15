namespace LinqSpecs.Transitivity.Tests.Database.Entities;

public class Client
{
    public int Id { get; set; }
    public ICollection<Account> Accounts { get; set; }
    public bool IsVip { get; set; }

    public int CitizenshipId { get; set; }
    public Country Citizenship { get; set; }
}