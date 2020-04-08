using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stathis_kanellis_individual_part_b
{
    class StudentPerCourse
    {
        public int Count { get; set; }
        public int? IdCourse { get; set; }
        public string Title { get; set; }
        public string Stream { get; set; }
        public string Type { get; set; }
        public int IdStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public StudentPerCourse(int count, string title, string stream, string type, string firstName, string lastName)
        {
            Count = count;
            Title = title;
            Stream = stream;
            Type = type;
            FirstName = firstName;
            LastName = lastName;
        }

        public StudentPerCourse(int count, int? idCourse, string stream, int idStudent, string firstName, string lastName)
        {
            Count = count;
            IdCourse = idCourse;
            Stream = stream;
            IdStudent = idStudent;
            FirstName = firstName;
            LastName = lastName;
        }

        public static void InsertStudentPerCourses()
        {
            string check = "y";
            while (check == "y")
            {
                Console.Write("Give Student Id: ");
                int studentId;
            Start1:
                while (!int.TryParse(Console.ReadLine(), out studentId))
                {
                    Console.Write("Please input correct value: ");
                }
                if (studentId < 0)
                {
                    Console.Write("Please input positive number: ");
                    goto Start1;
                }
                Console.Write("Give Course Id: ");
                int courseId;
            Start2:
                while (!int.TryParse(Console.ReadLine(), out courseId))
                {
                    Console.Write("Please input correct value: ");
                }
                if (courseId < 0)
                {
                    Console.Write("Please input positive number: ");
                    goto Start2;
                }

                Services.SetStudentPerCourse(studentId, courseId);

                Console.WriteLine("Do you want to continue insert records: y/n? ");
                check = Console.ReadLine();
                while (check != "y" && check != "n")
                {
                    Console.WriteLine("Please insert correct value");
                    Console.Write(" Select: (y/n) ");
                    check = Console.ReadLine();
                }
            }

        }

        public static void Output()
        {
            List<StudentPerCourse> studentPerCourses = Services.GetStudentPerCourses();
            Console.WriteLine($"|{" ",3} | {"TITLE",5} | {"STREAM",6} | {"TYPE  ",9} | {"FIRST NAME ",12} | {"LAST NAME    ",16} |");
            Console.WriteLine("=====================================================================");
            foreach (var item in studentPerCourses)
            {
                Console.WriteLine($"|{item.Count,3} | {item.Title,5} | {item.Stream,6} | {item.Type,9} | {item.FirstName,12} | {item.LastName,16} |");
            }
            Console.WriteLine();
        }

        public static void OutputInsert()
        {
            List<StudentPerCourse> studentPerCourses = Services.GetStudenPerCoursesInsert();
            Console.WriteLine($"|{" ",3} |{"COURSE ID",10} | {"STREAM",6} | {"STUDENT ID",12} | {"FIRST NAME ",12} | {"LAST NAME    ",16} |");
            Console.WriteLine("============================================================================");
            foreach (var item in studentPerCourses)
            {
                Console.WriteLine($"|{item.Count,3} |{item.IdCourse,10} | {item.Stream,6} | {item.IdStudent,12} | {item.FirstName,12} | {item.LastName,16} |");
            }
            Console.WriteLine();
        }
    }
}
