using GradesApp;

Student student1 = new Student("Ania", "Gil");
Student student2 = new Student("Ola", "Sowa");
Student student3 = new Student("Pati", "Kot");

student1.AddGrades(5);
student1.AddGrades(4);
student1.AddGrades(5);

student2.AddGrades(4);
student2.AddGrades(4);
student2.AddGrades(3);

student3.AddGrades(2);
student3.AddGrades(3);
student3.AddGrades(3);

var result1 = student1.Result;
var result2 = student2.Result;
var result3 = student3.Result;

int maxResult = 0;
Student studentWithMaxResult = null;

List<Student> students = new List<Student>()
{
    student1, student2, student3
};

foreach (var student in students)
{
    if(student.Result > maxResult)
    {
        studentWithMaxResult = student;
        maxResult = student.Result;
    }
}

Console.WriteLine(studentWithMaxResult.Name);
Console.WriteLine(maxResult);