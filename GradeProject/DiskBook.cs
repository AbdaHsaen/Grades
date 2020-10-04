using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GradeProject
{
    public class DiskBook : Book
    {


        public DiskBook(string name) : base(name)
        {
        }

        public override event IBook.GradeAddedDelegate gradeAddedDelegate;

        public override void AddToTextFileGrades(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                if (grade <= 100 && grade >= 0)
                {
                    writer.WriteLine(grade);
                    if (gradeAddedDelegate != null)
                    {
                        gradeAddedDelegate(this, new EventArgs());
                    }
                }
                else
                    Console.WriteLine("Grade must be between 0 - 100");
            }
        }

        public override Statistics GetFromTextFileStatistics()
        {
            var statistics = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();

                while(line !=null)
                {
                    statistics.Add(double.Parse(line));

                    line = reader.ReadLine();
                }
            }

            return statistics;
        }
    }
}
