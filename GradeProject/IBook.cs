using System;
using System.Collections.Generic;
using System.Text;

namespace GradeProject
{
   public interface IBook
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        abstract void AddToTextFileGrades(double grade);
      
        string Name { get; }
      
        Statistics GetFromTextFileStatistics();
      
        event GradeAddedDelegate gradeAddedDelegate;

    }
}
