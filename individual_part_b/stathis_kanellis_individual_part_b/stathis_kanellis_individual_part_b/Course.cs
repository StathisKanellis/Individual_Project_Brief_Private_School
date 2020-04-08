using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stathis_kanellis_individual_part_b
{
    class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Stream { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Course(int id, string title, string stream, string type, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Title = title;
            Stream = stream;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
        }

        public static void InsertCourses()
        {
            string check = "y";
            while (check == "y")
            {
                Console.Write("Give Title of Course: ");
                string title = Console.ReadLine();
                title = string.IsNullOrWhiteSpace(title) ? null : Convert.ToString(title);
                while (title == null)
                {
                    Console.Write("Please insert correct value for Title of Course: ");
                    title = Console.ReadLine();
                    title = string.IsNullOrWhiteSpace(title) ? null : Convert.ToString(title);
                }
                Console.Write("Give Stream of Course: ");
                string stream = Console.ReadLine();
                stream = string.IsNullOrWhiteSpace(stream) ? null : Convert.ToString(stream);
                while (stream == null)
                {
                    Console.Write("Please insert correct value for Stream of Course: ");
                    stream = Console.ReadLine();
                    stream = string.IsNullOrWhiteSpace(stream) ? null : Convert.ToString(stream);
                }
                Console.Write("Give Type of Course: ");
                string type = Console.ReadLine();
                type = string.IsNullOrWhiteSpace(type) ? null : Convert.ToString(type);
                while (type == null)
                {
                    Console.Write("Please insert correct value for Type of Course: ");
                    type = Console.ReadLine();
                    type = string.IsNullOrWhiteSpace(type) ? null : Convert.ToString(type);
                }
                Console.Write("Give Start Date of Course (yyyy/mm/dd): ");
                DateTime startDate;
                while (!DateTime.TryParse(Console.ReadLine(), out startDate))
                {
                    Console.Write("Please input correct date to check (yyyy/mm/dd): ");
                }
                Console.Write("Give End Date of Course (yyyy/mm/dd): ");
                DateTime endDate;
                while (!DateTime.TryParse(Console.ReadLine(), out endDate))
                {
                    Console.Write("Please input correct date to check (yyyy/mm/dd): ");
                }

                Services.SetCourse(title, stream, type, startDate, endDate);

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
            List<Course> courses = Services.GetAllCourses();
            Console.WriteLine($"|{"ID",3} | {"TITLE",5} | {"STREAM",6} | {"TYPE  ",9} | {"START DATE",10} | {"END DATE",10} |");
            Console.WriteLine("=============================================================");
            foreach (var item in courses)
            {
                Console.WriteLine($"|{item.Id,3} | {item.Title,5} | {item.Stream,6} | {item.Type,9} | {item.StartDate.ToString("d"),10} | {item.EndDate.ToString("d"),10} |");
            }
            Console.WriteLine();
        }
    }
}
