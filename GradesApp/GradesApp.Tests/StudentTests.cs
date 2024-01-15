namespace GradesApp.Tests
{
    public class Tests
    {
        [Test]
        public void CheckSumOperation()
        {
            // arrange
            var student = new Student("Ania", "Kos");
            student.AddGrades(5);
            student.AddGrades(4);

            // act
            var result = student.Result;

            // assert
            Assert.AreEqual(9, result);
        }
    }
}