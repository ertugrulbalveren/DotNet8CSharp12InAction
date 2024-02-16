//Microsoft documentation: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/ref-readonly-parameters

var userTest = new UserTest();
int x = 5;
userTest.Test(ref x);

Console.WriteLine($"Last Number is {x}");

class UserTest
{
    public void Test(in int number)
    {
        Console.WriteLine($"Number is: {number}");
    }
}