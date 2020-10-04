using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GradeProject
{
    public class Statistics
    {
        public double Average {
            get
            {
              return  sum / Count;
            }
        }

        public double High;

        public double Low;

        public char GBA {
            get
            {
                switch (Average)
                {
                    case var x when x >= 90:
                        return 'A';
                
                    case var x when x >= 80:
                        return 'B';
                   
                    case var x when x >= 70:
                        return 'C';
                  
                    case var x when x >= 60:
                        return 'D';
                       
                    default:
                        return 'F';
                }
            }
        }

        private int Count;

        private double sum;

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Count = 0;
            sum = 0.0;
        }

        public void Add(double grade)
        {
            sum += grade;
            Count++;
            High = Math.Max(grade, High);
            Low = Math.Min(grade, Low);
        }
    }
}
