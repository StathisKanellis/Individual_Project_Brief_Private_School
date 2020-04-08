using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stathis_kanellis_individual_part_b
{
    class AssignmentPerCourse
    {
        public int Count { get; set; }
        public string TitleCourse { get; set; }
        public string Stream { get; set; }
        public string TitleAssign { get; set; }
        public string Description { get; set; }

        public AssignmentPerCourse(int count, string titleCourse, string stream, string titleAssign, string description)
        {
            Count = count;
            TitleCourse = titleCourse;
            Stream = stream;
            TitleAssign = titleAssign;
            Description = description;
        }

        public static void Output()
        {
            List<AssignmentPerCourse> assignmentPerCourses = Services.GetAssignmentPerCourses();
            Console.WriteLine($"|{" ",3} | {"TITLE COURSE  ",14} | {"STREAM",6} | {"TITLE ASSIGNMENT     ",29} | {"DESCRIPTION  ",16} |");
            Console.WriteLine("===================================================================================");
            foreach (var item in assignmentPerCourses)
            {
                Console.WriteLine($"|{item.Count,3} | {item.TitleCourse,14} | {item.Stream,6} | {item.TitleAssign,29} | {item.Description,16} |");
            }
            Console.WriteLine();
        }
    }
}
