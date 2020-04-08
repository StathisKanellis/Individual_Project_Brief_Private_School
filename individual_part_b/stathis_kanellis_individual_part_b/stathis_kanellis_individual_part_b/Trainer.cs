using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stathis_kanellis_individual_part_b
{
    class Trainer
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public Trainer(int id, int? courseId, string firstname, string lastname, string subject)
        {
            Id = id;
            CourseId = courseId;
            FirstName = firstname;
            LastName = lastname;
            Subject = subject;
        }

        public static void InsertTrainers()
        {
            string check = "y";
            while (check == "y")
            {
                Console.Write("Give FirstName of Trainer: ");
                string firstname = Console.ReadLine();
                firstname = string.IsNullOrWhiteSpace(firstname) ? null : Convert.ToString(firstname);
                while (firstname == null)
                {
                    Console.Write("Please insert correct value for FirstName of Trainer: ");
                    firstname = Console.ReadLine();
                    firstname = string.IsNullOrWhiteSpace(firstname) ? null : Convert.ToString(firstname);
                }
                Console.Write("Give LastName of Trainer: ");
                string lastname = Console.ReadLine();
                lastname = string.IsNullOrWhiteSpace(lastname) ? null : Convert.ToString(lastname);
                while (lastname == null)
                {
                    Console.Write("Please insert correct value for LastName of Trainer: ");
                    lastname = Console.ReadLine();
                    lastname = string.IsNullOrWhiteSpace(lastname) ? null : Convert.ToString(lastname);
                }
                Console.Write("Give Subject to Trainer: ");
                string subject = Console.ReadLine();
                subject = string.IsNullOrWhiteSpace(subject) ? null : Convert.ToString(subject);
                while (subject == null)
                {
                    Console.Write("Please insert correct value for Subject of Trainer: ");
                    subject = Console.ReadLine();
                    subject = string.IsNullOrWhiteSpace(subject) ? null : Convert.ToString(subject);
                }

                Services.SetTrainers(firstname, lastname, subject);

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
            List<Trainer> trainers = Services.GetAllTrainers();
            Console.WriteLine($"|{"ID",3} |{"COURSE ID",10} | {"FIRST NAME ",12} | {"LAST NAME    ",16} | {"SUBJECT           ",29} |");
            Console.WriteLine("====================================================================================");
            foreach (var item in trainers)
            {
                Console.WriteLine($"|{item.Id,3} |{item.CourseId,10} | {item.FirstName,12} | {item.LastName,16} | {item.Subject,29} |");
            }
            Console.WriteLine();
        }
    }
}
