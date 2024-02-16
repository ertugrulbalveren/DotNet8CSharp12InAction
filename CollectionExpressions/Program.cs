//Microsoft documentation: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/collection-expressions

//Old definition
var list = new List<int> { 1, 2, 3, 4, 5 };

//New definition => in this case you can not use var keyword
int[] list2 = [1, 2, 3, 4, 5];

int[] someNumbers = [1, 2, 3, 4];

Span<int> moreNumbers = [6, 7, 8, 9, 10];

List<int> completeNumbers = [..someNumbers, 5, ..moreNumbers];

Console.WriteLine(string.Join(", ", completeNumbers));