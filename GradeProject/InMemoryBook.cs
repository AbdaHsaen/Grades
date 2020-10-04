using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeProject
{
    public class InMemoryBook : Book
    {
        public List<double> Grades;
       // readonly string Category = "Programming";  // Readonly change only when initialize or in the constructor ..
        public const string Author = "Abdallah";  // the value of constraint never gonna change and its treated like static memeber, call it by the class name ..

        //Delegate
        
        public override event IBook.GradeAddedDelegate gradeAddedDelegate;  // adding event keyword to the delegate gaves it more abitities...

        public InMemoryBook(string name) : base(name) // using the base keyword to pass the constructor parameter to the base class constructor.
        {
            Grades = new List<double>();
            Name = name;
        }

        public override void AddToTextFileGrades(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                Grades.Add(grade);

                gradeAddedDelegate(this, new EventArgs());
            }
            else
                Console.WriteLine("Grade must be between 0 - 100");
        }

        public override Statistics GetFromTextFileStatistics()
        {
            Statistics statistics = new Statistics();

            if (Grades != null && Grades.Count > 0)
            {
                foreach (var grade in Grades)
                {
                    statistics.Add(grade);
                }
            }

            return statistics;
        }
    }
}
