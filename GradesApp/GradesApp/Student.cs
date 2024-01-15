namespace GradesApp
{
    public class Student
    {
        private List<int> grades = new List<int>();
        public Student(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public int Result
        {
            get
            {
                return this.grades.Sum();
            }
        }
        public void AddGrades(int grade)
        {
            this.grades.Add(grade);
        }
    }
}
