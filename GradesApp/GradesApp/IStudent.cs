namespace GradesApp
{
    public interface IStudent
    {
        public string Name { get; }
        public string Surname { get; }

        void AddGrade(float grade);

        void AddGrade(string grade);
        Statistics GetStatistics();
    }
}
