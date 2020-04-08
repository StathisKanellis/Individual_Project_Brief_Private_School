using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stathis_kanellis_individual_part_b
{
    class AssignmentPerCoursePerStudent
    {
        public int Count { get; set; }
        public string TitleCourse { get; set; }
        public string Stream { get; set; }
        public string TitleAssign { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AssignmentPerCoursePerStudent(int count, string titleCourse, string stream, string titleAssign, string firstName, string lastName)
        {
            Count = count;
            TitleCourse = titleCourse;
            Stream = stream;
            TitleAssign = titleAssign;
            FirstName = firstName;
            LastName = lastName;
        }

        public static void Output()
        {
            List<AssignmentPerCoursePerStudent> assignmentPerCoursePerStudents = Services.GetAssignmentPerCoursePerStudents();
            Console.WriteLine($"|{" ",3} | {"TITLE COURSE  ",14} | {"STREAM",6} | {"TITLE ASSIGNMENT     ",29} | {"FIRST NAME ",12} | {"LAST NAME    ",16} |");
            Console.WriteLine("==================================================================================================");
            foreach (var item in assignmentPerCoursePerStudents)
            {
                Console.WriteLine($"|{item.Count,3} | {item.TitleCourse,14} | {item.Stream,6} | {item.TitleAssign,29} | {item.FirstName,12} | {item.LastName,16} |");
            }
            Console.WriteLine();
        }
    }
}
