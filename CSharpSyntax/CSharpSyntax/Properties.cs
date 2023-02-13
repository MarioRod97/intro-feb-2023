using System.Security.Principal;
namespace CSharpSyntax;

public class Properties
{
    [Fact]
    public void ObjectInitializers()
    {
        var account = new Account()
        {
            AccountNumber = 1000,

            Name = "Sue"
        };

        Assert.Equal("Sue", account.Name);
        Assert.Equal(1000, account.AccountNumber);
    }

    public class Account
    {
        private string _name = "";

        private decimal _balance = 5000M;

        public required string Name // Property - they can get, set (or any other combination)
        {
            get { return _name; }
            init { _name = value; }
        }
        // This isn't really a language thing. It is a compiler directive that says:
        // Create a backing field for the account number.
        // Create the "get and set" methods to mutate and access that backing field.
        public required int AccountNumber { get; init; }

        // This is a bit smelly according to Jeff
        public decimal Balance
        {
            get { return _balance; }

        }

        public void Deposit(decimal amount)
        {

            // AccountNumber += 1;
            _balance += amount;
        }
    }
}