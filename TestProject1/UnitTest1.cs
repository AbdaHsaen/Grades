using GradeProject;
using System;
using Xunit;


namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var book = new InMemoryBook("");
            book.AddGrades(93.2);
            book.AddGrades(88.2);
            book.AddGrades(63.2);
            //Act

            var result = book.GetStatistics();

            //Assert

            Assert.Equal(81.5, result.Average, 1);
            Assert.Equal(63.2, result.Low, 1);
            Assert.Equal(93.2, result.High, 1);
            Assert.Equal('B', result.GBA);
        }
    }
}