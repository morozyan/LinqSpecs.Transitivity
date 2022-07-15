using LinqSpecs.Transitivity.Tests.Database.Entities;
using LinqSpecs.Transitivity.Tests.Database.Specs;


namespace LinqSpecs.Transitivity.Tests;

public class TransitiveSpecificationTests : IClassFixture<TransitiveSpecificationTestsFixture>
{
    private readonly TransitiveSpecificationTestsFixture _fixture;

    public TransitiveSpecificationTests(TransitiveSpecificationTestsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Should_filter_by_spec_of_property()
    {
        var spec = new TransitiveSpecification<Account, Client>(a => a.Client, ClientSpecs.IsVip());
        
        var accounts = _fixture.Context.Accounts
            .Where(spec).ToList();

        Assert.Equal(2, accounts.Count);
    }


    [Fact]
    public void Should_filter_by_spec_of_transitive_property()
    {
        var spec = new TransitiveSpecification<Account, Country>(a => a.Client.Citizenship, CountrySpecs.ByName("Canada"));
        
        var account = _fixture.Context.Accounts
            .FirstOrDefault(spec);

        Assert.Equal(410, account.Value);
        Assert.Equal(Currency.USD, account.Type);
    }
}