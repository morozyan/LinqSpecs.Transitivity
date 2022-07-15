using LinqSpecs.Transitivity.Tests.Database.Entities;

namespace LinqSpecs.Transitivity.Tests.Database.Specs;

public static class CountrySpecs
{
    public static Specification<Country> ByName(string name)
        => new AdHocSpecification<Country>(c => c.Name == name);
}