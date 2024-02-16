

//Microsoft documentation: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/primary-constructors


var student = new Student("John", "Doe");
Console.WriteLine(student.FullName);

var student2 = new Student2("Ertugrul", "Balveren");
Console.WriteLine(student2.FullName);
//Console.WriteLine(student2.firstName); This will not work because it is private

//Old definition
var student3 = new Student3("Demo", "User");
Console.WriteLine(student3.FullName);
Console.WriteLine(student3.FirstName);

public class Student
{
    private string _firstName { get; set; }
    private string _lastName { get; set; }
    public Student(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }

    public string FullName => $"{_firstName} {_lastName}";
}

//New definition

//Please not below for class firstname and lastname are private fields
//but for record they are public properties

//class definition
public class Student2 (string firstName, string lastName)
{
    public string FullName => $"{firstName} {lastName}";
}

//record definition
public record Student3(string FirstName, string LastName)
{
    public string FullName => $"{FirstName} {LastName}";
}

