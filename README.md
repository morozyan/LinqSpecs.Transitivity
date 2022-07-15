# LinqSpecs.Transitivity
tbd

Filtering with duplicated logic:
```c#
var vipClients = _context.Clients.Where(c => c.IsVip).ToList();
var vipClientAccounts = _context.Accounts.Where(a => a.Client.IsVip).ToList();
``` 

Filtering with LinqSpecs and TransitiveSpecification:
```c#
public static class ClientSpecs
{
    public static Specification<Client> IsVip() => new AdHocSpecification<Client>(c => c.IsVip);
}

var clientSpec = ClientSpecs.IsVip();
var accountSpec = new TransitiveSpecification<Account, Client>(a => a.Client, clientSpec);

var vipClients = _context.Clients.Where(clientSpec).ToList();
var vipClientAccounts = _context.Accounts.Where(accountSpec).ToList();
```