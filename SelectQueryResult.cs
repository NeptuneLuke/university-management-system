using System.Data;
using BetterConsoleTables;
using MySql.Data.MySqlClient;

namespace UniversityManagementSystem;


public class SelectQueryResult {


    public static void menu_show_student(string str_connection) {

        int choice = 0;
        DataTable table_result = new DataTable();
        string str_search = "";
        int num_search = 0;

        string query = "";

        do {

            table_result.Clear();
            query = "";

            Console.WriteLine("Insert a number to select an operation: ");
            Console.WriteLine("1. Show all students ");
            Console.WriteLine("2. Search students by course ");
            Console.WriteLine("3. Search students by name ");
            Console.WriteLine("4. Search students by surname ");
            Console.WriteLine("5. Search students by academic year ");
            Console.WriteLine("6. Search students by birth year ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("7. Clear screen ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("8. Close (or return to previous menu) ");
            Console.ResetColor();
            Console.WriteLine();

            choice = UniMain.check_input_int();
            Console.WriteLine();

            switch (choice) {

                case 1:

                    query = "SELECT student_id AS 'StudentID', first_name AS 'Name', last_name AS 'Surname', " +
                            "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                            "FROM student;";

                    table_result = execute_select(str_connection, query);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message("No students found! \n");
                        break;
                    }

                    print_student(table_result);

                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine("Insert the course title: ");
                    str_search = UniMain.check_input_string(); 
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        UniMain.log_error_message("You must write a course title! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT student.student_id AS 'StudentID', first_name AS 'Name', last_name AS 'Surname', " +
                             "email AS 'Email', student.academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                             "FROM student " +
                             "JOIN course_student " +
                                 "ON student.student_id = course_student.student_id " +
                             "JOIN course " +
                                 "ON course.course_id = course_student.course_id " +
                             "WHERE course.title = @str_search " +
                             "GROUP BY student.student_id " +
                             "ORDER BY student.student_id;";

                    table_result = execute_select(str_connection, query, nameof(str_search), str_search);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message($"Course: {str_search} is not already present! \n");
                        break;
                    }

                    print_student(table_result);

                    Console.WriteLine();
                    break;

                case 3:
                    Console.WriteLine("Insert the name: ");
                    UniMain.check_input_string();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        UniMain.log_error_message("You must write a name! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT student_id AS 'StudentID', first_name AS 'Name', last_name AS 'Surname', " +
                            "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                            "FROM student " +
                            "WHERE first_name = @str_search;";

                    table_result = execute_select(str_connection, query, nameof(str_search), str_search);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message($"No student found with name {str_search}! \n");
                        break;
                    }

                    print_student(table_result);

                    Console.WriteLine();
                    break;

                case 4:
                    Console.WriteLine("Insert the surname: ");
                    UniMain.check_input_string();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        UniMain.log_error_message("You must write a surname! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT student_id AS 'StudentID', first_name AS 'Name', last_name AS 'Surname', " +
                            "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                            "FROM student " +
                            "WHERE last_name = @str_search;";

                    table_result = execute_select(str_connection, query, nameof(str_search), str_search);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message($"No student found with surname {str_search}! \n");
                        break;
                    }

                    print_student(table_result);

                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine("Insert the academic year: ");
                    num_search = UniMain.check_input_int();
                    if (num_search <= 0 || num_search >= 4) {
                        UniMain.log_error_message("Invalid academic year! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT student_id AS 'StudentID', first_name AS 'Name', last_name AS 'Surname', " +
                            "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                            "FROM student " +
                            "WHERE academic_year = @num_search;";

                    table_result = execute_select(str_connection, query, nameof(num_search), num_search);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message($"No student of the academic year {num_search} found! \n");
                        break;
                    }

                    print_student(table_result);

                    Console.WriteLine();
                    break;

                case 6:
                    Console.WriteLine("Insert the birth year: ");
                    num_search = UniMain.check_input_int();
                    if (num_search <= 1899 || num_search >= 2006) {
                        UniMain.log_error_message("Invalid year! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT student_id AS 'StudentID', first_name AS 'Name', last_name AS 'Surname', " +
                            "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                            "FROM student " +
                            "WHERE birth_date LIKE CONCAT(@num_search, '-__-__');";

                    table_result = execute_select(str_connection, query, nameof(num_search), num_search);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message($"No student with birth year {num_search} found! \n");
                        break;
                    }

                    print_student(table_result);

                    Console.WriteLine();
                    break;

                case 7:
                    Console.Clear();
                    break;

                case 8:
                    break;
            }

        } while (choice != 8);

    }

    static void print_student(DataTable table_result) {

        Table table = new Table();
        table.Config = TableConfiguration.Unicode();

        for (int i = 0; i < table_result.Columns.Count; ++i) {
            table.AddColumn(table_result.Columns[i].ColumnName);
        }

        for (int i = 0; i < table_result.Rows.Count; ++i) {
            table.AddRow(table_result.Rows[i][0].ToString(), table_result.Rows[i][1].ToString(), table_result.Rows[i][2].ToString(),
                table_result.Rows[i][3].ToString(), table_result.Rows[i][4].ToString(), table_result.Rows[i][5].ToString().Substring(0,10));
        }
        Console.Write(table.ToString());
    }

    static void print_student_short(DataTable table_result) {

        Table table = new Table();
        table.Config = TableConfiguration.Unicode();

        for (int i = 0; i < table_result.Columns.Count; ++i) {
            table.AddColumn(table_result.Columns[i].ColumnName);
        }

        for (int i = 0; i < table_result.Rows.Count; ++i) {
            table.AddRow(table_result.Rows[i][0].ToString(), table_result.Rows[i][1].ToString(), table_result.Rows[i][2].ToString(),
                table_result.Rows[i][3].ToString());
        }
        Console.Write(table.ToString());
    }


    public static void menu_show_professor(string str_connection) {

        int choice = 0;
        DataTable table_result = new DataTable();
        string str_search = "";
        int num_search = 0;

        string query = "";

        do {

            table_result.Clear();
            query = "";

            Console.WriteLine("Insert a number to select an operation: ");
            Console.WriteLine("1. Show all professors ");
            Console.WriteLine("2. Search professors by course ");
            Console.WriteLine("3. Search professors by name ");
            Console.WriteLine("4. Search professors by surname ");
            Console.WriteLine("5. Search professors by email ");
            Console.WriteLine("6. Search professors by year of teaching ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("7. Clear screen ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("8. Close (or return to previous menu) ");
            Console.ResetColor();
            Console.WriteLine();

            choice = UniMain.check_input_int();
            Console.WriteLine();

            switch (choice) {

                case 1:

                    query = "SELECT professor_id AS 'ProfessorID', " +
                            "first_name AS 'Name', last_name AS 'Surname', email AS 'Email'" +
                            "FROM professor;";

                    table_result = execute_select(str_connection, query);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message("No professors found! \n");
                        break;
                    }

                    print_professor(table_result);

                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine("Insert the course title: ");
                    str_search = UniMain.check_input_string();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        UniMain.log_error_message("You must write a course title! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT professor.professor_id AS 'ProfessorID', " +
                             "first_name AS 'Name', last_name AS 'Surname', email AS 'Email' " +
                             "FROM professor " +
                             "JOIN course_professor " +
                                 "ON professor.professor_id = course_professor.professor_id " +
                             "JOIN course " +
                                 "ON course.course_id = course_professor.course_id " +
                             "WHERE course.title = @str_search " +
                             "GROUP BY professor.professor_id " +
                             "ORDER BY professor.professor_id;";

                    table_result = execute_select(str_connection, query, nameof(str_search), str_search);


                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message($"Course: {str_search} is not already present! \n");
                        break;
                    }

                    print_professor(table_result);

                    Console.WriteLine();
                    break;

                case 3:
                    Console.WriteLine("Insert the name: ");
                    str_search = UniMain.check_input_string();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        UniMain.log_error_message("You must write a name! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT professor_id AS 'ProfessorID', " +
                             "first_name AS 'Name', last_name AS 'Surname', email AS 'Email' " +
                             "FROM professor " +
                             "WHERE first_name = @str_search;";

                    table_result = execute_select(str_connection, query, nameof(str_search), str_search);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message($"No professor found with name {str_search}! \n");
                        break;
                    }

                    print_professor(table_result);

                    Console.WriteLine();
                    break;

                case 4:
                    Console.WriteLine("Insert the surname: ");
                    str_search = UniMain.check_input_string();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        UniMain.log_error_message("You must write a surname! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT professor_id AS 'ProfessorID', " +
                             "first_name AS 'Name', last_name AS 'Surname', email AS 'Email' " +
                             "FROM professor " +
                             "WHERE last_name = @str_search;";

                    table_result = execute_select(str_connection, query, nameof(str_search), str_search);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message($"No professor found with surname {str_search}! \n");
                        break;
                    }

                    print_professor(table_result);

                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine("Insert the email: ");
                    str_search = UniMain.check_input_string();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        UniMain.log_error_message("You must write an email! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT professor_id AS 'ProfessorID', " +
                             "first_name AS 'Name', last_name AS 'Surname', email AS 'Email' " +
                             "FROM professor " +
                             "WHERE email = @str_search;";

                    table_result = execute_select(str_connection, query, nameof(str_search), str_search);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message($"No professor found with email {str_search}! \n");
                        break;
                    }

                    print_professor(table_result);

                    Console.WriteLine();
                    break;

                case 6:
                    Console.WriteLine("Insert the academic year: ");
                    num_search = UniMain.check_input_int();
                    if (num_search <= 0 || num_search >= 4) {
                        UniMain.log_error_message("Invalid academic year! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT professor.professor_id AS 'ProfessorID', " +
                             "professor.first_name AS 'Name', professor.last_name AS 'Surname', " +
                             "professor.email AS 'Email'" +
                             "FROM professor " +
                             "JOIN course_professor " +
                                "ON professor.professor_id = course_professor.professor_id " +
                             "JOIN course " +
                                "ON course.course_id = course_professor.course_id " +
                             "WHERE course.academic_year = @num_search " +
                             "GROUP BY professor.professor_id " +
                             "ORDER BY professor.professor_id;";

                    table_result = execute_select(str_connection, query, nameof(num_search), num_search);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message($"No professor found that teaches for the academic year {num_search}! \n");
                        break;
                    }

                    print_professor(table_result);

                    Console.WriteLine();
                    break;

                case 7:
                    Console.Clear();
                    break;

                case 8:
                    break;
            }

        } while (choice != 8);

    }

    static void print_professor(DataTable table_result) {

        Table table = new Table();
        table.Config = TableConfiguration.Unicode();

        for (int i = 0; i < table_result.Columns.Count; ++i) {
            table.AddColumn(table_result.Columns[i].ColumnName);
        }

        for (int i = 0; i < table_result.Rows.Count; ++i) {
            table.AddRow(table_result.Rows[i][0].ToString(), table_result.Rows[i][1].ToString(), 
                table_result.Rows[i][2].ToString(), table_result.Rows[i][3].ToString());
        }
        Console.Write(table.ToString());
    }


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

            choice = UniMain.check_input_int();
            Console.WriteLine();

            switch (choice) {

                case 1:

                    query = "SELECT course_id AS 'CourseID', title AS 'Title', academic_year AS 'Academic year' " +
                            "FROM course;";

                    table_result = execute_select(str_connection, query);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message("No courses found! \n");
                        break;
                    }

                    print_course(table_result);

                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine("Insert the title: ");
                    str_search = UniMain.check_input_string();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        UniMain.log_error_message("You must write a title! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT course_id AS 'CourseID', title AS 'Title', academic_year AS 'Academic year' " +
                            "FROM course " +
                            "WHERE title = @str_search;";

                    table_result = execute_select(str_connection, query, nameof(str_search), str_search);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message($"No course found with title {str_search}! \n");
                        break;
                    }

                    print_course(table_result);

                    Console.WriteLine();
                    break;

                case 3:
                    Console.WriteLine("Insert the academic year: ");
                    num_search = UniMain.check_input_int();
                    if (num_search <= 0 || num_search >= 4) {
                        UniMain.log_error_message("Invalid academic year! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT course_id AS 'CourseID', title AS 'Title', academic_year AS 'Academic year' " +
                            "FROM course " +
                            "WHERE academic_year = @num_search;";

                    table_result = execute_select(str_connection, query, nameof(num_search), num_search);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message($"No course found for the academic year {num_search}! \n");
                        break;
                    }

                    print_course(table_result);

                    Console.WriteLine();
                    break;

                case 4:
                    Console.WriteLine("Insert the student ID: ");
                    num_search = UniMain.check_input_int();
                    if (num_search <= 0) {
                        UniMain.log_error_message("Invalid student ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT course.course_id AS 'CourseID', course.title AS 'Title', course.academic_year AS 'Academic year' " +
                            "FROM course " +
                            "JOIN course_student ON course.course_id = course_student.course_id " +
                            "JOIN student ON student.student_id = course_student.student_id " +
                            "WHERE student.student_id = @num_search;";

                    table_result = execute_select(str_connection, query, nameof(num_search), num_search);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message($"No course found by student {num_search}! \n");
                        break;
                    }

                    print_course(table_result);

                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine("Insert the course ID: ");
                    num_search = UniMain.check_input_int();
                    if (num_search <= 0) {
                        UniMain.log_error_message("Invalid course ID! \n");
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

                    table_result = execute_select(str_connection, query, nameof(num_search), num_search);

                    if (table_result.Rows.Count == 0) {
                        UniMain.log_error_message($"No student found by course {num_search}! \n");
                        break;
                    }

                    print_student_short(table_result);

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

    static void print_course(DataTable table_result) {

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


    static DataTable execute_select(string str_connection, string query) {

        DataTable table_result = new DataTable();
        try {
            using (MySqlConnection connection = new MySqlConnection(str_connection)) {

                using (MySqlCommand command = new MySqlCommand(query, connection)) {

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command)) {
                        adapter.Fill(table_result);
                    }
                }
            }
        }
        catch (MySqlException ex) {
            UniMain.log_sql_exception(ex);
        }

        return table_result;
    }

    static DataTable execute_select(string str_connection, string query, string parameter_name, string parameter) {

        DataTable table_result = new DataTable();
        try {
            using (MySqlConnection connection = new MySqlConnection(str_connection)) {

                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    command.Parameters.Add($"@{parameter_name}", MySqlDbType.VarChar).Value = parameter;

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command)) {
                        adapter.Fill(table_result);
                    }
                }
            }
        }
        catch (MySqlException ex) {
            UniMain.log_sql_exception(ex);
        }

        return table_result;
    }

    static DataTable execute_select(string str_connection, string query, string parameter_name, int parameter) {

        DataTable table_result = new DataTable();
        try {
            using (MySqlConnection connection = new MySqlConnection(str_connection)) {

                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    command.Parameters.Add($"@{parameter_name}", MySqlDbType.Int32).Value = parameter;

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command)) {
                        adapter.Fill(table_result);
                    }
                }
            }
        }
        catch (MySqlException ex) {
            UniMain.log_sql_exception(ex);
        }

        return table_result;
    }

}
