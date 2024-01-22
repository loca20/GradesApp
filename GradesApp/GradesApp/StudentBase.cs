namespace GradesApp
{
    public enum Language
    {
        English,
        Polish
    }
    public static class ErrorMessagesEnglish
    {
        public static string IncorrectGrade = "Incorrect grade. You can only add a grade from 1 to 6.";
        public static string IncorrectGradeMultiple = "Incorrect grade. You can only add a grade in multiples of 0.5 (for example: 4.5).";
        public static string StringNotFloat = "This string is not a float.";
        public static string TooLowOrHighGrade = "There is no such grade. The lowest grade is 1 and the highest is 6.";
    }

    public static class ErrorMessagesPolish
    {
        public static string IncorrectGrade = "Nieprawidłowa ocena. Możesz dodać ocenę od 1 do 6.";
        public static string IncorrectGradeMultiple = "Nieprawidłowa ocena. Możesz dodać ocenę tylko w wielokrotnościach 0.5 (na przykład: 4.5).";
        public static string StringNotFloat = "To nie jest liczba rzeczywista.";
        public static string TooLowOrHighGrade = "Nie ma takiej oceny. Najniższą oceną jest 1, a najwyższą 6.";
    }

    public abstract class StudentBase : IStudent

    {
        public StudentBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
           
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public abstract void AddGrade(float grade);
        public abstract void AddGrade(string grade);
        public abstract Statistics GetStatistics();
    }
}
