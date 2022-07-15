using LinqSpecs.Transitivity.Tests.Database.Entities;

namespace LinqSpecs.Transitivity.Tests.Database.Specs;

public static class ClientSpecs
{
    public static Specification<Client> IsVip()
        => new AdHocSpecification<Client>(c => c.IsVip);

}