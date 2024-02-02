namespace GradesApp
{
    public class StudentInMemory : StudentBase
    {
        private List<float> grades = new List<float>();
        private Language language;
        public StudentInMemory(string name, string surname, Language language)
            : base(name, surname, language)
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
                string errorMessage = (language == Language.Polish) ? StaticVariable.ErrorMessages.Polish.IncorrectGrade : StaticVariable.ErrorMessages.English.IncorrectGrade;
                throw new Exception(errorMessage);
            }
        }

        public override void AddGrade(string grade)
        {
            ValidateStringGrade(grade);
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
