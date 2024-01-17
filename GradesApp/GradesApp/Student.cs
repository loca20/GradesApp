namespace GradesApp
{
    public enum Language
    {
        English,
        Polish
    }
    public static class ErrorMessagesEnglish
    {
        public static string IncorrectGrade = "Incorrect grade. You can only add a grade from 1 to 6 or +/-.";
        public static string IncorrectGradeMultiple = "Incorrect grade. You can only add a grade in multiples of 0.5 (for example: 4.5).";
        public static string StringNotFloat = "This string is not a float.";
    }

    public static class ErrorMessagesPolish
    {
        public static string IncorrectGrade = "Nieprawidłowa ocena. Możesz dodać ocenę od 1 do 6 lub +/-.";
        public static string IncorrectGradeMultiple = "Nieprawidłowa ocena. Możesz dodać ocenę tylko w wielokrotnościach 0.5 (na przykład: 4.5).";
        public static string StringNotFloat = "Ten ciąg znaków nie jest liczbą rzeczywistą.";
    }
    public class Student
    {
        private List<float> grades = new List<float>();
        private Language language;
        public Student(string name, string surname, Language language)
        {
            this.Name = name;
            this.Surname = surname;
            this.language = language;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public void AddGrade(float grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                this.grades.Add(grade);
            }
            else
            {
                string errorMessage = (language == Language.Polish) ? ErrorMessagesPolish.IncorrectGrade : ErrorMessagesEnglish.IncorrectGrade;
                throw new Exception(errorMessage);
            }
        }
       
        public void AddGrade(string grade)
        {
            if (grade.Length == 2 && (grade[1] == '+' || grade[1] == '-'))
            {
                switch (grade[1])
                {
                    case '+':
                        this.grades.Add(float.Parse(grade[0].ToString()) + 0.5f);
                        break;
                    case '-':
                        this.grades.Add(float.Parse(grade[0].ToString()) - 0.5f);
                        break;
                }
            }
            else if (grade.Length == 2 && (grade[0] == '+' || grade[0] == '-'))
            {
                switch (grade[0])
                {
                    case '+':
                        this.grades.Add(float.Parse(grade[1].ToString()) + 0.5f);
                        break;
                    case '-':
                        this.grades.Add(float.Parse(grade[1].ToString()) - 0.5f);
                        break;
                }
            }
            else if (float.TryParse(grade, out float result))
            {
                this.AddGrade(result);
            }
            else
            {
                string errorMessage = (language == Language.Polish) ? ErrorMessagesPolish.StringNotFloat : ErrorMessagesEnglish.StringNotFloat;
                throw new Exception(errorMessage);
            }
        }

        public Statistics GetStatistics()
        {
            var statistics = new Statistics();
            statistics.Average = 0;
            statistics.Max = float.MinValue;
            statistics.Min = float.MaxValue;

            foreach (var grade in this.grades)
            {
                statistics.Max = Math.Max(statistics.Max, grade);
                statistics.Min = Math.Min(statistics.Min, grade);
                statistics.Average += grade;
            }
            statistics.Average /= this.grades.Count;

            switch (statistics.Average)
            {
                case var average when average >= 5.61:
                    statistics.AverageWord = "celujący";
                    break;
                case var average when average >= 4.76:
                    statistics.AverageWord = "bardzo dobry";
                    break;
                case var average when average >= 3.76:
                    statistics.AverageWord = "dobry";
                    break;
                case var average when average >= 2.76:
                    statistics.AverageWord = "dostateczny";
                    break;
                case var average when average >= 1.76:
                    statistics.AverageWord = "mierny";
                    break;
                default:
                    statistics.AverageWord = "niedostateczny";
                    break;
            }

            return statistics;
        }
    }
}
