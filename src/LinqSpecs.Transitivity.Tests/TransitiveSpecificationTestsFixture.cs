using LinqSpecs.Transitivity.Tests.Database;
using LinqSpecs.Transitivity.Tests.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LinqSpecs.Transitivity.Tests;

public class TransitiveSpecificationTestsFixture
{
    public BankDbContext Context { get; }


    public TransitiveSpecificationTestsFixture()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddDbContext<BankDbContext>(opt => opt.UseInMemoryDatabase(Guid.NewGuid().ToString()));

        var sp = serviceCollection.BuildServiceProvider();
        Context = sp.GetService<BankDbContext>();

        FillData(Context);
    }

    private static void FillData(BankDbContext context)
    {
        context.Clients.AddRange(new Client[]
        {
            new Client
            {
                IsVip = true,
                Accounts = new []
                {
                    new Account
                    {
                        Type = Currency.USD,
                        Value = 1000
                    },
                    new Account
                    {
                        Type = Currency.EUR,
                        Value = 456000
                    }
                }
            },
            new Client
            {
                IsVip = false,
                Accounts = new []
                {
                    new Account
                    {
                        Type = Currency.USD,
                        Value = 31000
                    },
                    new Account
                    {
                        Type = Currency.EUR,
                        Value = 45600
                    }
                }
            },
            new Client
            {
                Citizenship = new Country
                {
                     Name = "Canada"
                },
                Accounts = new []
                {
                    new Account
                    {
                        Type = Currency.USD,
                        Value = 410
                    }
                }
            }
        });

        context.SaveChanges();
    }
}