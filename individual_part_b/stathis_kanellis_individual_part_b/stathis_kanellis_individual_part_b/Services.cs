using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace stathis_kanellis_individual_part_b
{
    class Services
    {
        public static string ConString = ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString;

        //================================== SET SERVICES ======================================
        //------------- SetStudent
        public static void SetStudent(string firstName, string lastName, DateTime birth, int fees)
        {
            string query = "INSERT INTO Student (FirstName, LastName, DateOfBirth, TuitionFees) " +
                "VALUES(@FirstName, @LastName, @DateOfBirth, @TuitionFees)";
            SqlConnection con = new SqlConnection(ConString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", birth);
            cmd.Parameters.AddWithValue("@TuitionFees", fees);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error Generated. Details: {e.ToString()}");
            }
        }

        //-------------SetTrainers
        public static void SetTrainers(string firstName, string lastName, string subject)
        {
            string query = "INSERT INTO Trainer (FirstName, LastName, Subject) " +
                "VALUES(@FirstName, @LastName, @Subject)";
            SqlConnection con = new SqlConnection(ConString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Subject", subject);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error Generated. Details: {e.ToString()}");
            }
        }
        //-------------SetAssignments
        public static void SetAssignments(string title, string description, int oralMark, int totalMark)
        {
            string query = "INSERT INTO Assignment(Title, Description, OralMark, TotalMark) " +
                "VALUES(@Title, @Description, @OralMark, @TotalMark)";
            SqlConnection con = new SqlConnection(ConString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@OralMark", oralMark);
            cmd.Parameters.AddWithValue("@TotalMark", totalMark);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error Generated. Details: {e.ToString()}");
            }
        }

        //-------------SetCourses
        public static void SetCourse(string title, string stream, string type, DateTime startDate, DateTime endDate)
        {
            string query = "INSERT INTO Course(Title, Stream, Type, StartDate, EndDate) " +
                "VALUES(@Title, @Stream, @Type, @StartDate, @EndDate)";
            SqlConnection con = new SqlConnection(ConString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Stream", stream);
            cmd.Parameters.AddWithValue("@Type", type);
            cmd.Parameters.AddWithValue("@StartDate", startDate);
            cmd.Parameters.AddWithValue("@EndDate", endDate);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error Generated. Details: {e.ToString()}");
            }
        }

        //-------------SetStudentsPerCourse
        public static void SetStudentPerCourse(int studentId, int courseId)
        {
            string query = "INSERT INTO CourseStudent (StudentId,CourseId) VALUES(@StudentId, @CourseId)";
            SqlConnection con = new SqlConnection(ConString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@StudentId", studentId);
            cmd.Parameters.AddWithValue("@CourseId", courseId);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (SqlException e)
            {
                if (e.Number == 547)
                {
                    Console.WriteLine("Error Generated. You input NOT-EXISTENT ID");
                }
            }
        }

        //-------------SetTrainersPerCourse
        public static void SetTrainerPerCourse(int courseId, int trainerId)
        {
            string query = "UPDATE Trainer (CourseId) SET CourseId = @CourseId WHERE TrainerId = @TrainerId";
            //string query = @"UPDATE Trainer SET CourseId = @CourseId WHERE TrainerId = @TrainerId";
            SqlConnection con = new SqlConnection(ConString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@CourseId", SqlDbType.Text).Value = courseId;
            cmd.Parameters.AddWithValue("@TrainerId", SqlDbType.Text).Value = trainerId;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Generated. Details: {e.ToString()}");
            }

        }

        //-------------SetAssignmentsPerStudentPerCourse

        //================================== GET SERVICES ======================================
        //-------------GetAllStudents
        public static List<Student> GetAllStudent()
        {
            List<Student> students = new List<Student>();
            string query = "select * from Student";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader[0]);
                    string firstname = reader[1].ToString();
                    string lastname = reader[2].ToString();
                    DateTime birth = Convert.ToDateTime(reader[3]);
                    int fees = Convert.ToInt32(reader[4]);

                    Student s = new Student(id, firstname, lastname, birth, fees);
                    students.Add(s);

                }
            }

            return students;

        }

        //-------------GetAllTrainers
        public static List<Trainer> GetAllTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();
            string query = "select * from Trainer";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader[0]);
                    int? idcourse = string.IsNullOrWhiteSpace(reader[1].ToString()) ? (int?)null : Convert.ToInt32(reader[1].ToString());
                    string firstname = reader[2].ToString();
                    string lastname = reader[3].ToString();
                    string subject = reader[4].ToString();

                    Trainer t = new Trainer(id, idcourse, firstname, lastname, subject);
                    trainers.Add(t);
                }
            }

            return trainers;
        }

        //-------------GetAllAssignmets
        public static List<Assignment> GetAllAssignments()
        {
            List<Assignment> assignments = new List<Assignment>();
            string query = "select * from Assignment";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader[0]);
                    int? idcourse = string.IsNullOrWhiteSpace(reader[1].ToString()) ? (int?)null : Convert.ToInt32(reader[1].ToString());
                    string title = reader[2].ToString();
                    string description = reader[3].ToString();
                    DateTime? subdate = string.IsNullOrWhiteSpace(reader[4].ToString()) ? (DateTime?)null : Convert.ToDateTime(reader[4].ToString());
                    int oralmark = Convert.ToInt32(reader[5]);
                    int totalmark = Convert.ToInt32(reader[6]);

                    Assignment assig = new Assignment(id, idcourse, title, description, subdate, oralmark, totalmark);
                    assignments.Add(assig);
                }
            }
            return assignments;
        }

        //-------------GetAllCourses
        public static List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            string query = "select * from Course";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader[0]);
                    string title = reader[1].ToString();
                    string stream = reader[2].ToString();
                    string type = reader[3].ToString();
                    DateTime startDate = Convert.ToDateTime(reader[4].ToString());
                    DateTime endDate = Convert.ToDateTime(reader[5].ToString());

                    Course c = new Course(id, title, stream, type, startDate, endDate);
                    courses.Add(c);
                }
            }
            return courses;
        }

        //------------- Get All the Students per Course
        public static List<StudentPerCourse> GetStudentPerCourses()
        {
            List<StudentPerCourse> studentPerCourses = new List<StudentPerCourse>();
            string query = "select Title, Stream, Type, FirstName, LastName from Student s " +
                "inner join CourseStudent cs on cs.StudentId = s.StudentId " +
                "inner join Course c on c.CourseId = cs.CourseId " +
                "order by Title, LastName";
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    string title = reader[0].ToString();
                    string stream = reader[1].ToString();
                    string type = reader[2].ToString();
                    string firstName = reader[3].ToString();
                    string lastName = reader[4].ToString();

                    StudentPerCourse SPC = new StudentPerCourse(count, title, stream, type, firstName, lastName);
                    studentPerCourses.Add(SPC);
                }
            }
            return studentPerCourses;
        }

        //------------- Get All the Trainers per Course
        public static List<TrainerPerCourse> GetTrainerPerCourses()
        {
            List<TrainerPerCourse> trainerPerCourses = new List<TrainerPerCourse>();
            string query = "select Title, Stream, Type, FirstName, LastName from Trainer t " +
                "inner join Course c on t.CourseId = c.CourseId " +
                "order by Title";
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    string title = reader[0].ToString();
                    string stream = reader[1].ToString();
                    string type = reader[2].ToString();
                    string firstName = reader[3].ToString();
                    string lastName = reader[4].ToString();

                    TrainerPerCourse TPC = new TrainerPerCourse(count, title, stream, type, firstName, lastName);
                    trainerPerCourses.Add(TPC);
                }
            }
            return trainerPerCourses;
        }

        //------------- Get All Assignments per Course
        public static List<AssignmentPerCourse> GetAssignmentPerCourses()
        {
            List<AssignmentPerCourse> assignmentPerCourses = new List<AssignmentPerCourse>();
            string query = "select c.Title, c.Stream, a.Title, a.Description from Assignment a " +
                "inner join Course c on c.CourseId = a.CourseId " +
                "order by c.Title";
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    string titleCourse = reader[0].ToString();
                    string stream = reader[1].ToString();
                    string titleAssign = reader[2].ToString();
                    string description = reader[3].ToString();

                    AssignmentPerCourse APC = new AssignmentPerCourse(count, titleCourse, stream, titleAssign, description);
                    assignmentPerCourses.Add(APC);
                }
            }
            return assignmentPerCourses;
        }

        //------------- Get Assignments Per Course Per Student
        public static List<AssignmentPerCoursePerStudent> GetAssignmentPerCoursePerStudents()
        {
            List<AssignmentPerCoursePerStudent> assignmentPerCoursePerStudents = new List<AssignmentPerCoursePerStudent>();
            string query = "select c.Title, Stream, a.Title, FirstName, LastName from Assignment a " +
                "inner join CourseStudent cs on cs.CourseId = a.CourseId " +
                "inner join Course c on c.CourseId = a.CourseId " +
                "inner join Student s on s.StudentId = cs.StudentId " +
                "order by c.Title, LastName";
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    string titleCourse = reader[0].ToString();
                    string stream = reader[1].ToString();
                    string titleAssign = reader[2].ToString();
                    string firstName = reader[3].ToString();
                    string lastName = reader[4].ToString();

                    AssignmentPerCoursePerStudent APCPS = new AssignmentPerCoursePerStudent(count, titleCourse, stream, titleAssign, firstName, lastName);
                    assignmentPerCoursePerStudents.Add(APCPS);
                }
            }
            return assignmentPerCoursePerStudents;
        }

        //------------- Get Students than belong to more than one Courses
        public static List<StudentCourses> GetStudentCourses()
        {
            List<StudentCourses> studentCourses = new List<StudentCourses>();
            string query = "select concat(FirstName,' ', LastName) as Student, " +
                "Count(s.StudentId) as NumberOfCourses from Student s " +
                "inner join CourseStudent cs on cs.StudentId = s.StudentId " +
                "group by LastName, FirstName having Count(s.StudentId) > 1";
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    string student = reader[0].ToString();
                    int numberOfCourses = Convert.ToInt32(reader[1].ToString());

                    StudentCourses SC = new StudentCourses(count, student, numberOfCourses);
                    studentCourses.Add(SC);
                }
            }
            return studentCourses;
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~ Get Students Per Course Insert ~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static List<StudentPerCourse> GetStudenPerCoursesInsert()
        {
            List<StudentPerCourse> studentPerCourses = new List<StudentPerCourse>();
            string query = "select c.CourseId, Stream, s.StudentId, FirstName, LastName from Student s " +
                "left join CourseStudent cs on cs.StudentId = s.StudentId " +
                "left join Course c on c.CourseId = cs.CourseId " +
                "order by c.CourseId";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    int? idCourse = string.IsNullOrWhiteSpace(reader[0].ToString()) ? (int?)null : Convert.ToInt32(reader[0].ToString());
                    string stream = reader[1].ToString();
                    int idStudent = Convert.ToInt32(reader[2]);
                    string firstName = reader[3].ToString();
                    string lastName = reader[4].ToString();

                    StudentPerCourse SPC = new StudentPerCourse(count, idCourse, stream, idStudent, firstName, lastName);
                    studentPerCourses.Add(SPC);
                }
            }
            return studentPerCourses;
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~ Get Trainers Per Course Insert ~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static List<TrainerPerCourse> GetTrainerPerCoursesInsert()
        {
            List<TrainerPerCourse> trainerPerCourses = new List<TrainerPerCourse>();
            string query = "select c.CourseId, Title, Stream, t.TrainerId, FirstName, LastName from Trainer t" +
                " left join Course c on c.CourseId = t.CourseId order by c.CourseId";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    int? idCourse = string.IsNullOrWhiteSpace(reader[0].ToString()) ? (int?)null : Convert.ToInt32(reader[0].ToString());
                    string title = reader[1].ToString();
                    string stream = reader[2].ToString();
                    int idTrainer = Convert.ToInt32(reader[3]);
                    string firstName = reader[4].ToString();
                    string lastName = reader[5].ToString();

                    TrainerPerCourse TPC = new TrainerPerCourse(count, idCourse, stream, idTrainer, firstName, lastName);
                    trainerPerCourses.Add(TPC);
                }
            }
            return trainerPerCourses;
        }


    }

}
