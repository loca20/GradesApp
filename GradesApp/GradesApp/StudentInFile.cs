namespace GradesApp
{
    internal class StudentInFile : StudentBase
    {
        private const string fileName = "grades.txt";
        private List<float> grades = new List<float>();
        private Language language;
        public StudentInFile(string name, string surname, Language language) 
            : base(name, surname)
        {
            this.language = language;
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);
                }
            }
            else
            {
                string errorMessage = (language == Language.Polish) ? ErrorMessagesPolish.IncorrectGrade : ErrorMessagesEnglish.IncorrectGrade;
                throw new Exception(errorMessage);
            }
        }

        public override void AddGrade(string grade)
        {
            if (grade.Length == 2 && (grade[1] == '+' || grade[1] == '-'))
            {
                if (grade != "1-" && grade != "6+")
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
                else
                {
                    string errorMessage = (language == Language.Polish) ? ErrorMessagesPolish.TooLowOrHighGrade : ErrorMessagesEnglish.TooLowOrHighGrade;
                    throw new Exception(errorMessage);
                }
            }
            else if (grade.Length == 2 && (grade[0] == '+' || grade[0] == '-'))
            {
                if (grade != "-1" && grade != "+6")
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
                else
                {
                    string errorMessage = (language == Language.Polish) ? ErrorMessagesPolish.TooLowOrHighGrade : ErrorMessagesEnglish.TooLowOrHighGrade;
                    throw new Exception(errorMessage);
                }
            }
            else if (grade.Length == 3 && (grade.Contains(".") || grade.Contains(",")))
            {
                if (float.TryParse(grade[0].ToString(), out float firstDigit) && (firstDigit > 0 && firstDigit < 6))
                {
                    if (grade.Contains(".5") || grade.Contains(",5"))
                    {
                        this.grades.Add(float.Parse(grade[0].ToString()) + 0.5f);
                    }
                    else
                    {
                        string errorMessage = (language == Language.Polish) ? ErrorMessagesPolish.IncorrectGradeMultiple : ErrorMessagesEnglish.IncorrectGradeMultiple;
                        throw new Exception(errorMessage);
                    }
                }
                else
                {
                    Console.WriteLine("to jest to - od 1 do 6");
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

        public override Statistics GetStatistics()
        {
            var gradesFromFile = this.ReadGradesFromFile();
            var result = this.CountStatistics(gradesFromFile);
            return result;
        }

        private List<float> ReadGradesFromFile()
        {
            var grades = new List<float>();
            if(File.Exists(fileName)) {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        grades.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return grades;
        }
        private Statistics CountStatistics(List<float> grades)
        {
            var statistics = new Statistics();
            statistics.Average = 0;
            statistics.Max = float.MinValue;
            statistics.Min = float.MaxValue;

            foreach (var grade in grades)
            {
                statistics.Max = Math.Max(statistics.Max, grade);
                statistics.Min = Math.Min(statistics.Min, grade);
                statistics.Average += grade;
            }
            statistics.Average /= grades.Count;

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