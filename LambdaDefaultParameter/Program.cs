//Microsoft documentation: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/lambda-method-group-defaults

//we can also define directly the age value in the lambda expression
var lambda = (int age = 25) => $"You are {age} years old";

//lambda(25); // You are 25 years old