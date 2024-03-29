﻿namespace GradesApp.Tests
{
    internal class TypeTests
    {
        [Test]
        public void TEST()
        {
            // arrange
            var student1 = GetStudent("Basia", "Makowska");
            var student2 = GetStudent("Basia", "Tarkowska");
            // act


            // assert
            Assert.AreNotEqual(student1, student2);
        }

        private StudentInMemory GetStudent(string name, string surname)
        {
            return new StudentInMemory(name, surname, Language.English);
        }
    }
}
