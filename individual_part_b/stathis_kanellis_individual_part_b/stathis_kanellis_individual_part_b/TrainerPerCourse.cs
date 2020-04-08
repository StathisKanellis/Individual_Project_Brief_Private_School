using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stathis_kanellis_individual_part_b
{
    class TrainerPerCourse
    {
        public int Count { get; set; }
        public int? IdCourse { get; set; }
        public string Title { get; set; }
        public string Stream { get; set; }
        public string Type { get; set; }
        public int IdTrainer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public TrainerPerCourse(int count, string title, string stream, string type, string firstName, string lastName)
        {
            Count = count;
            Title = title;
            Stream = stream;
            Type = type;
            FirstName = firstName;
            LastName = lastName;
        }

        public TrainerPerCourse(int count, int? idCourse, string stream, int idTrainer, string firstName, string lastName)
        {
            Count = count;
            IdCourse = idCourse;
            Stream = stream;
            IdTrainer = idTrainer;
            FirstName = firstName;
            LastName = lastName;
        }

        public static void InsertTrainerPerCourses()
        {
            string check = "y";
            while (check == "y")
            {
                Console.Write("Give Course Id: ");
                int courseId;
            Start1:
                while (!int.TryParse(Console.ReadLine(), out courseId))
                {
                    Console.Write("Please input correct value: ");
                }
                if (courseId < 0)
                {
                    Console.Write("Please input positive number: ");
                    goto Start1;
                }
                Console.Write("Give Trainer Id: ");
                int trainerId;
            Start2:
                while (!int.TryParse(Console.ReadLine(), out trainerId))
                {
                    Console.Write("Please input correct value: ");
                }
                if (trainerId < 0)
                {
                    Console.Write("Please input positive number: ");
                    goto Start2;
                }

                Services.SetStudentPerCourse(courseId, trainerId);

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
            List<TrainerPerCourse> trainerPerCourses = Services.GetTrainerPerCourses();
            Console.WriteLine($"|{" ",3} | {"TITLE",5} | {"STREAM",6} | {"TYPE  ",9} | {"FIRST NAME ",12} | {"LAST NAME    ",16} |");
            Console.WriteLine("=====================================================================");
            foreach (var item in trainerPerCourses)
            {
                Console.WriteLine($"|{item.Count,3} | {item.Title,5} | {item.Stream,6} | {item.Type,9} | {item.FirstName,12} | {item.LastName,16} |");
            }
            Console.WriteLine();
        }

        public static void OutputInsert()
        {
            List<TrainerPerCourse> trainerPerCourses = Services.GetTrainerPerCoursesInsert();
            Console.WriteLine($"|{" ",3} |{"COURSE ID",10} | {"STREAM",6} | {"TRAINER ID",12} | {"FIRST NAME ",12} | {"LAST NAME    ",16} |");
            Console.WriteLine("============================================================================");
            foreach (var item in trainerPerCourses)
            {
                Console.WriteLine($"|{item.Count,3} |{item.IdCourse,10} | {item.Stream,6} | {item.IdTrainer,12} | {item.FirstName,12} | {item.LastName,16} |");
            }
            Console.WriteLine();
        }
    }
}
