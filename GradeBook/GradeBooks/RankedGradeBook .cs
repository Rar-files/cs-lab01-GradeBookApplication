using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeight) : base(name, isWeight)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            double countTop = 0;

            if (Students.Count < 5) throw new InvalidOperationException("Number of students less than 5.");

            foreach(Student x in Students)
            {
                if (x.AverageGrade >= averageGrade) countTop++;
            }
            double percyl = countTop / Students.Count * 100;

            if (percyl > 80) return 'F';
            else if (percyl > 60) return 'D';
            else if (percyl > 40) return 'C';
            else if (percyl > 20) return 'B';
            else return 'A';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5) 
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
