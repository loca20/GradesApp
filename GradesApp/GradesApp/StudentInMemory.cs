namespace GradesApp
{
    public class StudentInMemory : StudentBase
    {
        private List<float> grades = new List<float>();
        private Language language;
        public StudentInMemory(string name, string surname, Language language) 
            : base(name, surname)
        {
            this.language = language;
        }
        
              public override void AddGrade(float grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                
                   this.grades.Add(grade);
                    GradeAddedInfoDelegate();
                
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
                            this.AddGrade(float.Parse(grade[0].ToString()) + 0.5f);
                            break;
                        case '-':
                            this.AddGrade(float.Parse(grade[0].ToString()) - 0.5f);
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
                            this.AddGrade(float.Parse(grade[1].ToString()) + 0.5f);
                            break;
                        case '-':
                            this.AddGrade(float.Parse(grade[1].ToString()) - 0.5f);
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
                        this.AddGrade(float.Parse(grade[0].ToString()) + 0.5f);
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
            var statistics = new Statistics();
            statistics.language = this.language;

            foreach (var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }

            return statistics;
        }
    }
}
