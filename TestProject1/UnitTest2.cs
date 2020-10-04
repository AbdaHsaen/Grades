using GradeProject;
using System;
using Xunit;


namespace TestProject1
{
    public class UnitTest2
    {

        #region Delegate

        public delegate string WriteLogMessage(string logMessge);

        public int count = 0;


        [Fact]
        public void Test9()
        {
            var newMessage = new WriteLogMessage(ReturnLogMessage);

            newMessage += ReturnLogMessage2;

            var result = newMessage("Delegate Message");

            Assert.Equal(2, count);
        }

        public string ReturnLogMessage(string Message)
        {
            count++;
            return Message;
        }

        public string ReturnLogMessage2(string Message)
        {
            count++;
            return Message;
        }


        #endregion


        #region ValueTypesTest
        [Fact]
        public void Test6()
        {
            int x = GetInt();
            SetInt(x);

            Assert.Equal(21, x);

            SetInt(ref x);

            Assert.Equal(22, x);
        }

        private void SetInt(int x)
        {
            x = 22;
        }

        private void SetInt(ref int x)
        {
            x = 22;
        }

        private int GetInt()
        {
            return 21;
        }

        #endregion


        #region ReferanceTest
        [Fact]
        public void Test1()
        {
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void Test2()
        {
            var book1 = GetBook("Book1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }

        [Fact]
        public void Test3()
        {
            var book1 = GetBook("Book1");
            SetBookName(book1, "Book3");

            Assert.Equal("Book3", book1.Name);
        }

        [Fact]
        public void Test4()
        {
            var book1 = GetBook("Book1");

            SetNewBookName(book1, "Book3");

            Assert.Equal("Book1", book1.Name);
        }

        [Fact]
        public void Test5()
        {
            var book1 = GetBook("Book1");

            SetNewBookName(ref book1, "Book3");

            Assert.Equal("Book3", book1.Name);
        }

        private void SetNewBookName(ref InMemoryBook book, string Name)
        {
            book = new InMemoryBook(Name);
        }

        private void SetNewBookName(InMemoryBook book, string Name)
        {
            book = new InMemoryBook(Name);
        }

        private void SetBookName(InMemoryBook book, string NewName)
        {
            book.Name = NewName;
        }

        InMemoryBook GetBook(string Name)
        {
            return new InMemoryBook(Name);
        }

        #endregion
    }
}
