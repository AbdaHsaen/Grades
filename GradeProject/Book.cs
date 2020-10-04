using GradeProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeProject
{
    public abstract class Book : NameOfObject , IBook
    {
        
        protected Book(string name) : base(name)
        {
        }

        public abstract event IBook.GradeAddedDelegate gradeAddedDelegate;

        public abstract void AddToTextFileGrades(double grade);

        public abstract Statistics GetFromTextFileStatistics();
       
    }
}
