using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace GradeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //InMemoryBook book = new InMemoryBook("Abdallah's Book"); 

                DiskBook book = new DiskBook("Abdallah");

                book.gradeAddedDelegate += OnGradeAdded;

                EnterGrades(book);

                var result = book.GetFromTextFileStatistics();      

                Console.WriteLine("Average  :" + result.Average);
                Console.WriteLine("Low Grade  :" + result.Low);
                Console.WriteLine("High Grade  :" + result.High);
                Console.WriteLine("GBA   :" + result.GBA);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // This code part will always excute
            }
        }

        private static void EnterGrades(IBook book)
        {
            string input = "";
            double grade = 0.0;
            bool IsDouble = false;

            while (input.ToUpper() != "Q")
            {

                Console.WriteLine("Please Enter Grade or Q for exit :");
                input = Console.ReadLine();
                IsDouble = double.TryParse(input, out grade);
                if (IsDouble)
                {
                    book.AddToTextFileGrades(grade);
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e) // delegate event Listener
        {
            Console.WriteLine("Grade Was Added.");
        }
    }
}
