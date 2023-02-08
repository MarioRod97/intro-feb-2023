using System.ComponentModel.Design;
using System.Text;

namespace CSharpSyntax;

public class CreatingAndInitializingTypes
{
    string thingy = "Birds";

    [Fact]
    public void UsingLiteralsToCreateInstancesOfTypes()
    {
        // Below are all examples of local variables
        // Local Variables - variables that are declared inside a method, or property
        
        // Initializing
        string firstName = "Tony";
        int age = 25;

        // Below are a few examples of commented lines of code
        // char middle = 'A';
        // bool isVendor = false;
        // bool isLegalAgeToDrink = true;

        Taco food = new Taco();

        Assert.Equal("Tony", firstName);
        Assert.Equal(25, age);
    }

    [Fact]
    public void ImplicitlyTypedLocalVariables()
    {
        // var can be used for local variables ONLY
        // You MUST initialize the variables
        var age = 25;

        var myName = "Jeff";

        var favoriteFood = new Taco();

        var myPay = 25.60m;
    }

    [Fact]
    public void CurlyBracesCreateScopes()
    {
        Assert.Equal("Birds", thingy);
        
        var message = "";
        var age = 22;
        
        if (age >= 21)
        {
            message = "Old enough";
        }

        // Alternate to above
        if (age <= 21)
            message = "Too young";

        Assert.Equal("Old Enough", message);
    }

    [Fact]
    public void MutableStringsWithStringBuilders()
    {
        var message = new StringBuilder();

        foreach(var num in Enumerable.Range(1,10000))
        {
            message.Append(num.ToString() + ", ");
        }

        Assert.True(message.ToString().StartsWith("1, 2, 3, 4"));

        var myName = "Jeffrey";
    }

    [Fact]
    public void MoreAboutStrings()
    {
        var name = "Bob"; var age = 33; var message = "The name is " + name + " and the age is " + age + ".";
        var message2 = string.Format("The name is {0} and the age is {1} (again, name: {0})", name, age);
        var pay = 120_000.00M;
        var m3 = $"{name} makes {pay:c} a year";
    }

    [Fact]
    public void DoingConversionsOnTypes()
    {
        string myPay = "10000.83";

        if (decimal.TryParse(myPay, out decimal payAsNumber))
        {
            Assert.Equal(10_000.83M, payAsNumber);
        }
        else
        {
            Assert.True(false); // it should blow up here.

        }

        var birthdate = DateTime.Parse("04/20/1969");
        
        Assert.Equal(4, birthdate.Month);
        Assert.Equal(20, birthdate.Day);
        Assert.Equal(1969, birthdate.Year);
    }
}

    public class Taco { }
