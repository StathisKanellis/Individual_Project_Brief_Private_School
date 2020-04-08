using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stathis_kanellis_individual_part_b
{
    class Assignment
    {
        public int Id { get; set; }
        public int? IdCourse { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? SubTime { get; set; }
        public int OralMark { get; set; }
        public int TotalMark { get; set; }

        public Assignment(int id, int? idcourse, string title, string description, DateTime? subtime, int oralmark, int totalmark)
        {
            Id = id;
            IdCourse = idcourse;
            Title = title;
            Description = description;
            SubTime = subtime;
            OralMark = oralmark;
            TotalMark = totalmark;
        }

        public static void InsertAssignment()
        {
            string check = "y";
            while (check == "y")
            {
                Console.Write("Give Title of Assignment: ");
                string title = Console.ReadLine();
                title = string.IsNullOrWhiteSpace(title) ? null : Convert.ToString(title);
                while (title == null)
                {
                    Console.Write("Please insert correct value for Title of Assignment: ");
                    title = Console.ReadLine();
                    title = string.IsNullOrWhiteSpace(title) ? null : Convert.ToString(title);
                }
                Console.Write("Give Description of Assignment: ");
                string description = Console.ReadLine();
                description = string.IsNullOrWhiteSpace(description) ? null : Convert.ToString(description);
                while (description == null)
                {
                    Console.Write("Please insert correct value for Description of Assignment: ");
                    description = Console.ReadLine();
                    description = string.IsNullOrWhiteSpace(description) ? null : Convert.ToString(description);
                }
                Console.Write("Give Oral Mark of Assignment (0 - 100): ");
                int oralMark;
            Start1:
                while (!int.TryParse(Console.ReadLine(), out oralMark))
                {
                    Console.Write("Please input correct value: ");
                }
                if (oralMark < 0 || oralMark > 100)
                {
                    Console.Write("Please input correct value: ");
                    goto Start1;
                }
                Console.Write("Give Total Mark of Assignment: ");
                int totalMark;
            Start2:
                while (!int.TryParse(Console.ReadLine(), out totalMark))
                {
                    Console.Write("Please input correct value: ");
                }
                if (totalMark < 0 || totalMark > 100)
                {
                    Console.Write("Please input correct value: ");
                    goto Start2;
                }

                Services.SetAssignments(title, description, oralMark, totalMark);

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
            List<Assignment> assignments = Services.GetAllAssignments();
            Console.WriteLine($"|{"ID",3} | {"TITLE            ",30} | {"DESCRIPTION   ",16} | {"SUB DATE TIME",10} | {"ORAL MARK",10} | {"TOTAL MARK",10} |");
            Console.WriteLine("====================================================================================================");
            foreach (var item in assignments)
            {
                Console.WriteLine($"|{item.Id,3} | {item.Title,30} | {item.Description,16} | {item.SubTime?.ToString("d"),13} | {item.OralMark,10} | {item.TotalMark,10} |");
            }
            Console.WriteLine();
        }
    }
}
