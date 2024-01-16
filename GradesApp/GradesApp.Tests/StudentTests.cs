namespace GradesApp.Tests
{
    public class StudentTests
    {
        [Test]
        public void CheckMaxValue()
        {
            // arrange
            var student = new Student("Basia", "Makowska");
            student.AddGrade(4);
            student.AddGrade(5);
            student.AddGrade(3);
            // act
            var statistics = student.GetStatistics();

            // assert
            Assert.AreEqual(5, statistics.Max);
        }

        [Test]
        public void CheckMinValue()
        {
            // arrange
            var student = new Student("Basia", "Makowska");
            student.AddGrade(4);
            student.AddGrade(5);
            student.AddGrade(3);
            // act
            var statistics = student.GetStatistics();

            // assert
            Assert.AreEqual(3, statistics.Min);
        }

        [Test]
        public void CheckAverageValue()
        {
            // arrange
            var student = new Student("Basia", "Makowska");
            student.AddGrade(4);
            student.AddGrade(5);
            student.AddGrade(3);
            // act
            var statistics = student.GetStatistics();

            // assert
            Assert.AreEqual(4, statistics.Average);
        }

    }
}
