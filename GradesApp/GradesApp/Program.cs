using GradesApp;

//var student1 = new Student("Ania", "Gil");
//var student2 = new Student("Ola", "Sowa");
//var student3 = new Student("Pati", "Kot");

//student1.AddGrade(5);
//student1.AddGrade(4);
//student1.AddGrade("33");
//student1.AddGrade("Aaaa");
//student1.AddGrade(3.5);
//student1.AddGrade(5);
//student1.AddGrade(5);

Console.WriteLine("Witamy w dzienniku elektronicznym!");
Console.WriteLine("==================================");
Console.WriteLine();
Console.WriteLine("Dodaj ocenę:");

var student = new Student("Anna", "Kos");

while (true)
{
    var input = Console.ReadLine();
    if (input == "q")
    {
        break;
    }
    student.AddGrade(input);
    Console.WriteLine("Dodaj kolejną ocenę:");
}

var statistics = student.GetStatistics();

Console.WriteLine($"Average: {statistics.Average:N2}");
Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");
Console.WriteLine(statistics.AverageWord);