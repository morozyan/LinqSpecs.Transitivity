namespace LinqSpecs.Transitivity.Tests.Database.Entities;

public class Account
{
    public int Id { get; set; }
    public Currency Type { get; set; }
    public decimal Value { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
}