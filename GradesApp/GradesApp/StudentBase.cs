namespace GradesApp
{
    public enum Language
    {
        English,
        Polish
    }
    public abstract class StudentBase : IStudent
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public event GradeAddedDelegate GradeAdded;
        public void GradeAddedInfoDelegate()
        {
            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }

        private Language language;
        public StudentBase(string name, string surname, Language language)
        {
            this.Name = name;
            this.Surname = surname;
            this.language = language;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public abstract void AddGrade(float grade);
        public abstract void AddGrade(string grade);
        public abstract Statistics GetStatistics();

        public void ValidateStringGrade(string grade)
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
                    string errorMessage = (language == Language.Polish) ? StaticVariable.ErrorMessages.Polish.TooLowOrHighGrade : StaticVariable.ErrorMessages.English.TooLowOrHighGrade;
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
                    string errorMessage = (language == Language.Polish) ? StaticVariable.ErrorMessages.Polish.TooLowOrHighGrade : StaticVariable.ErrorMessages.English.TooLowOrHighGrade;
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
                        string errorMessage = (language == Language.Polish) ? StaticVariable.ErrorMessages.Polish.IncorrectGradeMultiple : StaticVariable.ErrorMessages.English.IncorrectGradeMultiple;
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
                string errorMessage = (language == Language.Polish) ? StaticVariable.ErrorMessages.Polish.StringNotFloat : StaticVariable.ErrorMessages.English.StringNotFloat;
                throw new Exception(errorMessage);
            }
        }

    }
}
