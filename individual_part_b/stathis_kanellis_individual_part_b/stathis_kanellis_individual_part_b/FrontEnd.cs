using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stathis_kanellis_individual_part_b
{
    class FrontEnd
    {
        
        public static void Start()
        {
            Console.Clear();
            ShowMenou();


            string choice = CheckCorrectValueMenu();

            if (choice == "1")
            {
                // Insert Data
                InsertData();
            }
            else if (choice == "2")
            {
                // Export Data
                ExportData();
            }
            else if (choice == "3")
            {
                // Exit
                Exit.CheckToExitProgram();
            }
            
        }

        

        private static void ShowMenou()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("         ___MENU___  ");
            Console.WriteLine("******************************");
            Console.WriteLine(" 1 - Insert Data to DataBase");
            Console.WriteLine(" 2 - Export Data from DataBase");
            Console.WriteLine(" 3 - Exit");
            Console.WriteLine("******************************");
        }

        private static string CheckCorrectValueMenu()
        {
            Console.Write(" Press: ");
            string input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("Please insert correct value");
                Console.Write(" Press: ");
                input = Console.ReadLine();
            }

            return input;
        }

        private static void ShowInsertData()
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("            __INSERT DATA - MENU__ ");
            Console.WriteLine("***********************************************");
            Console.WriteLine(" 1 - Insert Student ");
            Console.WriteLine(" 2 - Insert Trainers ");
            Console.WriteLine(" 3 - Insert Assignmgents ");
            Console.WriteLine(" 4 - Insert Courses ");
            Console.WriteLine(" 5 - Insert Student Per Course ");
            Console.WriteLine(" 6 - Insert Trainers Per Courses ");
            Console.WriteLine(" 7 - Insert Assignments Per Student Per Course ");
            Console.WriteLine(" 8 - EXIT");
            Console.WriteLine("***********************************************");
        }

        private static string CheckCorrectValueInsertMenu()
        {
            Console.Write(" Press: ");
            string input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5"
                && input != "6" && input != "7" && input != "8")
            {
                Console.WriteLine("Please insert correct value");
                Console.Write(" Press: ");
                input = Console.ReadLine();
            }

            return input;
        }

        public static void InsertData()
        {
            ShowInsertData();
            string input = CheckCorrectValueInsertMenu();
            if (input == "1")
            {
                //Insert Students
                Console.WriteLine();
                Student.InsertStudents();
                Student.Output();
                Exit.CheckToExitFolderInput();
            }
            else if (input == "2")
            {
                //Insert Trainers
                Console.WriteLine();
                Trainer.InsertTrainers();
                Trainer.Output();
                Exit.CheckToExitFolderInput();
            }
            else if (input == "3")
            {
                //Insert Assignments
                Console.WriteLine();
                Assignment.InsertAssignment();
                Assignment.Output();
                Exit.CheckToExitFolderInput();
            }
            else if (input == "4")
            {
                //Insert Courses
                Console.WriteLine();
                Course.InsertCourses();
                Course.Output();
                Exit.CheckToExitFolderInput();
            }
            else if (input == "5")
            {
                //Insert Students Per Course
                Console.WriteLine();
                Course.Output();
                StudentPerCourse.OutputInsert();
                StudentPerCourse.InsertStudentPerCourses();
                Console.WriteLine();
                StudentPerCourse.OutputInsert();
                Exit.CheckToExitFolderInput();
            }
            else if (input == "6")
            {
                //Insert Trainers Per Course
                Console.WriteLine();
                Course.Output();
                TrainerPerCourse.OutputInsert();
                TrainerPerCourse.InsertTrainerPerCourses();
                TrainerPerCourse.OutputInsert();
                Exit.CheckToExitFolderInput();
            }
            else if (input == "7")
            {
                //Insert Assignments Per Student Per Course
                Console.WriteLine();
                Exit.CheckToExitFolderInput();
            }
            else if (input == "8")
            {
                //Exit
                Exit.CheckToExitFolderInput();
            }

        }

        private static void ShowExportData()
        {
            Console.WriteLine("*******************************************************");
            Console.WriteLine("                 __EXPORT DATA - MENU__ ");
            Console.WriteLine("*******************************************************");
            Console.WriteLine(" 1  - All Students List");
            Console.WriteLine(" 2  - All Trainers List");
            Console.WriteLine(" 3  - All Assignmgents List");
            Console.WriteLine(" 4  - All Courses List");
            Console.WriteLine(" 5  - All Students Per Course");
            Console.WriteLine(" 6  - All Trainers Per Course");
            Console.WriteLine(" 7  - All Assignments Per Course");
            Console.WriteLine(" 8  - All Assignments Per Course Per Student");
            Console.WriteLine(" 9  - All Students than belong to more than one Courses");
            Console.WriteLine(" 10 - EXIT");
            Console.WriteLine("*******************************************************");
        }

        private static string CheckCorrectValueExporttMenu()
        {
            Console.Write(" Press: ");
            string input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" 
                && input != "6" && input != "7" && input != "8" && input != "9" && input != "10")
            {
                Console.WriteLine("Please insert correct value");
                Console.Write(" Press: ");
                input = Console.ReadLine();
            }

            return input;
        }

        public static void ExportData()
        {
            ShowExportData();
            string input = CheckCorrectValueExporttMenu();
            if (input == "1")
            {
                //Students List
                Student.Output();
                Exit.CheckToExitFolderSyntetic();
            }
            else if (input == "2")
            {
                //Trainers List
                Trainer.Output();
                Exit.CheckToExitFolderSyntetic();
            }
            else if (input == "3")
            {
                //Assignmgents List
                Assignment.Output();
                Exit.CheckToExitFolderSyntetic();
            }
            else if (input == "4")
            {
                //Courses List
                Course.Output();
                Exit.CheckToExitFolderSyntetic();

            }
            else if (input == "5")
            {
                //Students Per Course
                StudentPerCourse.Output();
                Exit.CheckToExitFolderSyntetic();
            }
            else if (input == "6")
            {
                //Trainers Per Course
                TrainerPerCourse.Output();
                Exit.CheckToExitFolderSyntetic();
            }
            else if (input == "7")
            {
                //Assignments Per Course
                AssignmentPerCourse.Output();
                Exit.CheckToExitFolderSyntetic();
            }
            else if (input == "8")
            {
                //Assignments Per Course Per Student
                AssignmentPerCoursePerStudent.Output();
                Exit.CheckToExitFolderSyntetic();
            }
            else if (input == "9")
            {
                //Students than belong to more than one Courses
                StudentCourses.Output();
                Exit.CheckToExitFolderSyntetic();
            }
            else if (input == "10")
            {
                //Exit
                Exit.CheckToExitFolderSyntetic();
            }

        }


    }
}
