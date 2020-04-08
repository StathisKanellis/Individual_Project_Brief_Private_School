using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stathis_kanellis_individual_part_b
{
    class StudentCourses
    {
        public int Count { get; set; }
        public string Student { get; set; }
        public int NumberOfCourses { get; set; }

        public StudentCourses(int count, string student, int numberOfCourses)
        {
            Count = count;
            Student = student;
            NumberOfCourses = numberOfCourses;
        }

        public static void Output()
        {
            List<StudentCourses> studentCourses = Services.GetStudentCourses();
            Console.WriteLine($"|{" ",3} | {"STUDENT        ",24} | {"NUMBER OF COURSE ",18} |");
            Console.WriteLine("======================================================");
            foreach (var item in studentCourses)
            {
                Console.WriteLine($"|{item.Count,3} | {item.Student,24} | {item.NumberOfCourses,18} |");
            }
            Console.WriteLine();
        }
    }
}
