using BetterConsoleTables;
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data.Types;

namespace UniversityManagementSystem;

public class Course {

    public static void menu_show_course(string str_connection) {

        int choice = 0;
        DataTable table_result = new DataTable();
        string str_search = "";
        int num_search = 0;

        string query = "";

        do {

            table_result.Clear();
            query = "";

            Console.WriteLine("Insert a number to select an operation: ");
            Console.WriteLine("1. Show all courses ");
            Console.WriteLine("2. Search courses by title ");
            Console.WriteLine("3. Search courses by academic year ");
            Console.WriteLine("4. Search all courses by student ");
            Console.WriteLine("5. Search all students by course ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("6. Clear screen ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("7. Close (or return to previous menu) ");
            Console.ResetColor();
            Console.WriteLine();

            choice = Util.check_input_int();
            Console.WriteLine();

            switch (choice) {

                case 1:

                    query = "SELECT course_id AS 'CourseID', title AS 'Title', academic_year AS 'Academic year' " +
                            "FROM course;";

                    table_result = Util.execute_select(str_connection, query);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message("No courses found! \n");
                        break;
                    }

                    print_course(table_result);

                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine("Insert the title: ");
                    str_search = Util.check_input_string();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        Util.log_error_message("You must write a title! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT course_id AS 'CourseID', title AS 'Title', academic_year AS 'Academic year' " +
                            "FROM course " +
                            "WHERE title = @str_search;";

                    table_result = Util.execute_select(str_connection, query, nameof(str_search), str_search);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message($"No course found with title {str_search}! \n");
                        break;
                    }

                    print_course(table_result);

                    Console.WriteLine();
                    break;

                case 3:
                    Console.WriteLine("Insert the academic year: ");
                    num_search = Util.check_input_int();
                    if (num_search <= 0 || num_search >= 4) {
                        Util.log_error_message("Invalid academic year! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT course_id AS 'CourseID', title AS 'Title', academic_year AS 'Academic year' " +
                            "FROM course " +
                            "WHERE academic_year = @num_search;";

                    table_result = Util.execute_select(str_connection, query, nameof(num_search), num_search);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message($"No course found for the academic year {num_search}! \n");
                        break;
                    }

                    print_course(table_result);

                    Console.WriteLine();
                    break;

                case 4:
                    Console.WriteLine("Insert the student ID: ");
                    num_search = Util.check_input_int();
                    if (num_search <= 0) {
                        Util.log_error_message("Invalid student ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT course.course_id AS 'CourseID', course.title AS 'Title', course.academic_year AS 'Academic year' " +
                            "FROM course " +
                            "JOIN course_student ON course.course_id = course_student.course_id " +
                            "JOIN student ON student.student_id = course_student.student_id " +
                            "WHERE student.student_id = @num_search;";

                    table_result = Util.execute_select(str_connection, query, nameof(num_search), num_search);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message($"No course found by student {num_search}! \n");
                        break;
                    }

                    print_course(table_result);

                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine("Insert the course ID: ");
                    num_search = Util.check_input_int();
                    if (num_search <= 0) {
                        Util.log_error_message("Invalid course ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT student.student_id AS 'StudentID', " +
                             "student.first_name AS 'Name', student.last_name AS 'Surname', " +
                             "student.email AS 'Email' " +
                            "FROM student " +
                            "JOIN course_student ON student.student_id = course_student.student_id " +
                            "JOIN course ON course.course_id = course_student.course_id " +
                            "WHERE course.course_id = @num_search;";

                    table_result = Util.execute_select(str_connection, query, nameof(num_search), num_search);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message($"No student found by course {num_search}! \n");
                        break;
                    }

                    Student.print_student_short(table_result);

                    Console.WriteLine();
                    break;

                case 6:
                    Console.Clear();
                    break;

                case 7:
                    break;
            }

        } while (choice != 7);

    }

    public static void menu_modify_course(string str_connection) {

        int choice = 0;
        DataTable table_result = new DataTable();
        int rows_affected = 0;
        int id_search = 0;
        string query = "";

        int course_id = 0;
        string course_title = "";
        int course_academic_year = 0;

        do {

            id_search = 0;
            course_id = 0;
            course_title = "";
            course_academic_year = 0;
            table_result.Clear();
            query = "";

            Console.WriteLine("Insert a number to select an operation: ");
            Console.WriteLine("1. Insert a new course ");
            Console.WriteLine("2. Modify a course title ");
            Console.WriteLine("3. Modify a course academic year ");
            Console.WriteLine("4. Delete a course ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("5. Clear screen ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("6. Close (or return to previous menu) ");
            Console.ResetColor();
            Console.WriteLine();

            choice = Util.check_input_int();
            Console.WriteLine();

            switch (choice) {

                case 1:

                    Console.WriteLine("Insert all course infos: ");
                    Console.WriteLine("ID: ");
                    course_id = Util.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Title: ");
                    course_title = Util.check_input_string();
                    Console.WriteLine();

                    Console.WriteLine("Academic year: ");
                    course_academic_year = Util.check_input_int();
                    Console.WriteLine();

                    if (course_id <= 0) {
                        Util.log_error_message("Invalid ID! \n");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(course_title)) {
                        Util.log_error_message("Invalid title! \n");
                        break;
                    }
                    if (course_academic_year <= 0 || course_academic_year >= 4) {
                        Util.log_error_message("Invalid academic year! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"INSERT INTO course " +
                            "VALUES (@course_id,@course_title,@course_academic_year);";

                    try {
                        using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                            connection.Open();
                            using (MySqlCommand command = new MySqlCommand(query, connection)) {
                                command.Parameters.Add("@course_id", MySqlDbType.Int32).Value = course_id;
                                command.Parameters.Add("@course_title", MySqlDbType.VarChar).Value = course_title;
                                command.Parameters.Add("@course_academic_year", MySqlDbType.Int32).Value = course_academic_year;
                                rows_affected = command.ExecuteNonQuery();
                            }
                            connection.Close();
                        }
                    }
                    catch (MySqlException ex) {
                        Util.log_sql_exception(ex);
                    }

                    if (rows_affected == 0) {
                        Util.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        Util.log_message("Course added! \n");
                    }

                    break;

                case 2:
                    Console.WriteLine("Insert the course ID: ");
                    id_search = Util.check_input_int();
                    if (id_search <= 0) {
                        Util.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the new course title: ");
                    course_title = Util.check_input_string();
                    if (string.IsNullOrWhiteSpace(course_title)) {
                        Util.log_error_message("Invalid title! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE course " +
                            "SET title = @course_title " +
                            "WHERE course_id = @id_search;";

                    rows_affected = Util.execute_update(str_connection, query, nameof(id_search), id_search, nameof(course_title), course_title);

                    if (rows_affected == 0) {
                        Util.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        Util.log_message("Course modified! \n");
                    }

                    break;

                case 3:
                    Console.WriteLine("Insert the course ID: ");
                    id_search = Util.check_input_int();
                    if (id_search <= 0) {
                        Util.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the new academic year: ");
                    course_academic_year = Util.check_input_int();
                    if (course_academic_year <= 0 || course_academic_year >= 4) {
                        Util.log_error_message("Invalid academic year! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE course " +
                            "SET academic_year = @course_academic_year " +
                            "WHERE course_id = @id_search;";

                    rows_affected = Util.execute_update(str_connection, query, nameof(id_search), id_search, nameof(course_academic_year), course_academic_year);

                    if (rows_affected == 0) {
                        Util.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        Util.log_message("Course modified! \n");
                    }

                    break;

                case 4:
                    Console.WriteLine("Insert the course ID: ");
                    id_search = Util.check_input_int();
                    if (id_search <= 0) {
                        Util.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"DELETE FROM course " +
                            "WHERE course_id = @id_search;";

                    try {
                        using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                            connection.Open();
                            using (MySqlCommand command = new MySqlCommand(query, connection)) {
                                command.Parameters.Add("@id_search", MySqlDbType.Int32).Value = id_search;
                                rows_affected = command.ExecuteNonQuery();
                            }
                            connection.Close();
                        }
                    }
                    catch (MySqlException ex) {
                        Util.log_sql_exception(ex);
                    }

                    if (rows_affected == 0) {
                        Util.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        Util.log_message("Course removed! \n");
                    }

                    break;

                case 5:
                    Console.Clear();
                    break;

                case 6:
                    break;
            }

        } while (choice != 6);

    }

    private static void print_course(DataTable table_result) {

        Table table = new Table();
        table.Config = TableConfiguration.Unicode();

        for (int i = 0; i < table_result.Columns.Count; ++i) {
            table.AddColumn(table_result.Columns[i].ColumnName);
        }

        for (int i = 0; i < table_result.Rows.Count; ++i) {
            table.AddRow(table_result.Rows[i][0].ToString(), table_result.Rows[i][1].ToString(), table_result.Rows[i][2].ToString());
        }
        Console.Write(table.ToString());
    }
}
