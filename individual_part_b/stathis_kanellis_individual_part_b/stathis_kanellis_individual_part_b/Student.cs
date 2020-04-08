using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stathis_kanellis_individual_part_b
{
    class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }
        public int Fees { get; set; }

        public Student(int id, string firstname, string lastname, DateTime birth, int fees)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Birth = birth;
            Fees = fees;
        }

        public static void InsertStudents()
        {
            string check = "y";
            while (check == "y")
            {
                Console.Write("Give FirstName of Student: ");
                string firstname = Console.ReadLine();
                firstname = string.IsNullOrWhiteSpace(firstname) ? null : Convert.ToString(firstname);
                while (firstname == null)
                {
                    Console.Write("Please insert correct value for FirstName of Student: ");
                    firstname = Console.ReadLine();
                    firstname = string.IsNullOrWhiteSpace(firstname) ? null : Convert.ToString(firstname);
                }
                Console.Write("Give LastName of Student: ");
                string lastname = Console.ReadLine();
                lastname = string.IsNullOrWhiteSpace(lastname) ? null : Convert.ToString(lastname);
                while (lastname == null)
                {
                    Console.Write("Please insert correct value for FirstName of Student: ");
                    lastname = Console.ReadLine();
                    lastname = string.IsNullOrWhiteSpace(lastname) ? null : Convert.ToString(lastname);
                }
                Console.Write("Give Date of Birth of Student (yyyy/mm/dd): ");
                DateTime birth;
                while (!DateTime.TryParse(Console.ReadLine(), out birth))
                {
                    Console.Write("Please input correct date to check (yyyy/mm/dd): ");
                }

                Console.Write("Give TuitionFees of Student ( 0 euros - 5000 euros) : ");
                int fees;
            Start:
                while (!int.TryParse(Console.ReadLine(), out fees))
                {
                    Console.Write("Please input correct value: ");
                }
                if (fees < 0 || fees > 5000)
                {
                    Console.Write("Please input correct value: ");
                    goto Start;
                }
                Services.SetStudent(firstname, lastname, birth, fees);

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
            List<Student> students = Services.GetAllStudent();
            Console.WriteLine($"|{"ID",3} | {"FIRST NAME ",12} | {"LAST NAME    ",16} | {"DATE OF BIRTH",10} | {"TUITION FEES",10} |");
            Console.WriteLine("=======================================================================");
            foreach (var item in students)
            {
                Console.WriteLine($"|{item.Id,3} | {item.FirstName,12} | {item.LastName,16} | {item.Birth.ToString("d"),13} | {item.Fees,12} |");
            }
            Console.WriteLine();
        }
    }
}
