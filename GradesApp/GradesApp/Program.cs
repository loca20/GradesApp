using GradesApp;

var student1 = new Student("Ania", "Gil");
var student2 = new Student("Ola", "Sowa");
var student3 = new Student("Pati", "Kot");

student1.AddGrade(5);
student1.AddGrade(4);
student1.AddGrade("33");
student1.AddGrade("Aaaa");
student1.AddGrade(5.5);

var statistics = student1.GetStatistics();

Console.WriteLine($"Average: {statistics.Average:N2}");
Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");