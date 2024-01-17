namespace GradesApp
{
    public class Student
    {
        private List<float> grades = new List<float>();
        public Student(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
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
                Console.WriteLine("Incorrect grade. You can only add a grade from 1 to 6 or +/-.");
            }
        }
        public void AddGrade(double grade)
        {
            if (grade % 0.5 == 0)
            {
                float gradeAsFloat = (float)grade;
                this.AddGrade(gradeAsFloat);
            }
            else
            {
                Console.WriteLine("Incorrect grade. You can only add a grade in multiples of 0.5 (for example: 4.5).");
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
                Console.WriteLine("String is not float.");
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
            
            switch(statistics.Average)
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
