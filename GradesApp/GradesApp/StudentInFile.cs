namespace GradesApp
{
    internal class StudentInFile : StudentBase
    {
        private string fileName;
        private Language language;
        public StudentInFile(string name, string surname, Language language, string fileName)
            : base(name, surname, language)
        {
            this.language = language;
            this.fileName = fileName;
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 1 && grade <= 6)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);
                    GradeAddedInfoDelegate();
                }
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
            var gradesFromFile = this.ReadGradesFromFile();
            var result = this.CountStatistics(gradesFromFile);
            result.language = this.language;
            return result;
        }

        private List<float> ReadGradesFromFile()
        {
            var grades = new List<float>();
            if (File.Exists(fileName))
            {
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

            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }

            return statistics;
        }
    }
}