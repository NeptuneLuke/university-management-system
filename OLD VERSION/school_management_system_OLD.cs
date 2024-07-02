/*
using System;
using System.Data;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.Types;
using MySql.Data.MySqlClient;


public class UniversityMS {


    public static void Main(string[] args) {

        string server = "127.0.0.1";
        string database = "university";
        string username = "root";
        string password = "mysqlpass";

        if (string.IsNullOrWhiteSpace(server) && string.IsNullOrWhiteSpace(database)
            && string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password)) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Server or Database details are incorrect!");
            Console.WriteLine("Closing application...");
            Console.ResetColor();
            return;
        }

        string str_connection = $"server={server};" +
                               $"uid={username};" +
                               $"pwd={password};" +
                               $"database={database};";


        MySqlConnection connection = new MySqlConnection(str_connection);
        establish_connection(ref connection,str_connection);
        if (connection != null && connection.State == ConnectionState.Open) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Connected to the server! ");
        }
        else {
            Console.WriteLine("Connection closed! ");
            return;
        }
        Console.ResetColor();
        Console.WriteLine();


        main_menu(ref connection,str_connection);

    }


    static void main_menu(ref MySqlConnection connection, string str_connection) {

        int choice = 0;

        if (establish_connection(ref connection, str_connection) == false) {
            return;
        }


        do {

            Console.WriteLine("Insert a number to select an operation: ");
            Console.WriteLine("1. Show students operations ");
            Console.WriteLine("2. Show professors operations ");
            Console.WriteLine("3. Show courses operations ");
            Console.WriteLine("4. Show exams operations ");
            Console.WriteLine("5. Clear screen ");
            Console.WriteLine("6. Close ");
            Console.WriteLine();

            choice = (Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine();

            switch (choice) {

                case 1:
                    menu_student(ref connection);
                    Console.WriteLine();
                    break;
                case 2:
                    menu_professor(ref connection);
                    Console.WriteLine();
                    break;
                case 3:
                    menu_course(ref connection);
                    Console.WriteLine();
                    break;
                case 4:
                    //menu_exam(ref connection);
                    Console.WriteLine();
                    break;
                case 5:
                    Console.Clear();
                    break;
                case 6:
                    if (connection.State != ConnectionState.Closed) {
                        close_connection(ref connection);
                    }
                    break;
            }

        } while (choice != 6);
    }


    static void menu_student(ref MySqlConnection connection) {

        int choice = 0;
        string str_search = "";
        int num_search = 0;

        string query = "";
        var command = new MySqlCommand();
        command.Connection = connection;
        var adapter = new MySqlDataAdapter(command);
        var table_result = new DataTable();

        do {

            table_result.Clear();
            query = "";
            command.Dispose();
            adapter.Dispose();

            connection = new MySqlConnection();
            command.Connection = connection;
            command.CommandText = query;
            command.Parameters.Clear();


            Console.WriteLine("Insert a number to select an operation: ");
            Console.WriteLine("1. Show all students ");
            Console.WriteLine("2. Search students by course ");
            Console.WriteLine("3. Search students by name ");
            Console.WriteLine("4. Search students by surname ");
            Console.WriteLine("5. Search students by academic year ");
            Console.WriteLine("6. Clear screen ");
            Console.WriteLine("7. Close (or return to previous menu) ");
            Console.WriteLine();

            choice = (Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine();

            switch (choice) {
                case 1:

                    query = "SELECT student_id AS 'StudentID', first_name AS 'Name', last_name AS 'Surname', " +
                            "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                            "FROM student;";
                    command.CommandText = query;
                    execute_command(ref command, ref adapter);
                    adapter.Fill(table_result);

                    if (table_result.Rows.Count == 0) {
                        log_error_message("No students found! \n");
                        break;
                    }

                    print_student_fields(table_result);
                    print_student_query(table_result);

                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("Insert the course title: ");
                    str_search = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        log_error_message("You must write a course title! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT student.student_id AS 'ID', first_name AS 'Name', last_name AS 'Surname', " +
                             "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                             "FROM student " +
                             "JOIN course_student " +
                                 "ON student.student_id = course_student.student_id " +
                             "JOIN course " +
                                 "ON course.course_id = course_student.course_id " +
                             "WHERE course.title = @str_search " + 
                             "GROUP BY student.student_id " + 
                             "ORDER BY student.student_id;";
                    command.CommandText = query;
                    command.Parameters.Add("@str_search", MySqlDbType.VarChar).Value = str_search;
                    execute_command(ref command, ref adapter);
                    adapter.Fill(table_result);


                    if (table_result.Rows.Count == 0) {
                        log_error_message($"Course: {str_search} is not present! \n");
                        break;
                    }

                    print_student_fields(table_result);
                    print_student_query(table_result);

                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Insert the name: ");
                    str_search = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        log_error_message("You must write a name! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT student.student_id AS 'ID', first_name AS 'Name', last_name AS 'Surname', " +
                            "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                            "FROM student " +
                            "WHERE first_name = @str_search;";
                    command.CommandText = query;
                    command.Parameters.Add("@str_search", MySqlDbType.VarChar).Value = str_search;
                    execute_command(ref command, ref adapter);
                    adapter.Fill(table_result);

                    if (table_result.Rows.Count == 0) {
                        log_error_message($"No student found with name {str_search}! \n");
                        break;
                    }

                    print_student_fields(table_result);
                    print_student_query(table_result);

                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("Insert the surname: ");
                    str_search = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        log_error_message("You must write a surname! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT student.student_id AS 'ID', first_name AS 'Name', last_name AS 'Surname', " +
                            "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                            "FROM student " +
                            "WHERE last_name = @str_search;";
                    command.CommandText = query;
                    command.Parameters.Add("@str_search", MySqlDbType.VarChar).Value = str_search;
                    execute_command(ref command, ref adapter);
                    adapter.Fill(table_result);

                    if (table_result.Rows.Count == 0) {
                        log_error_message($"No student found with surname {str_search}! \n");
                        break;
                    }

                    print_student_fields(table_result);
                    print_student_query(table_result);

                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine("Insert the academic_year: ");
                    num_search = (Convert.ToInt32(Console.ReadLine()));
                    if (num_search <= 0 || num_search >= 4) {
                        log_error_message("Year not present! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT student.student_id AS 'ID', first_name AS 'Name', last_name AS 'Surname', " +
                            "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                            "FROM student " +
                            "WHERE academic_year = @num_search;";
                    command.CommandText = query;
                    command.Parameters.Add("@num_search", MySqlDbType.Int32).Value = num_search;
                    execute_command(ref command, ref adapter);
                    adapter.Fill(table_result);

                    if (table_result.Rows.Count == 0) {
                        log_error_message($"No student of the academic year {num_search} found! \n");
                        break;
                    }

                    print_student_fields(table_result);
                    print_student_query(table_result);

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

    static void print_student_fields(DataTable table_result) {

        for (int j = 0; j < table_result.Columns.Count; ++j) {
            if (j == 1) {
                Console.Write($"{table_result.Columns[j].ColumnName.PadRight(15, ' ')}");
            }
            else if (j == 2 || j == 4) {
                Console.Write($"{table_result.Columns[j].ColumnName.PadRight(20, ' ')}");
            }
            else if (j == 3) {
                Console.Write($"{table_result.Columns[j].ColumnName.PadRight(35, ' ')}");
            }
            else {
                Console.Write($"{table_result.Columns[j].ColumnName.PadRight(10, ' ')}");
            }
        }
        Console.Write("\n\n");
    }

    static void print_student_query(DataTable table_result) {

        for (int i = 0; i < table_result.Rows.Count; i++) {
            for (int j = 0; j < table_result.Columns.Count; ++j) {
                var value = table_result.Rows[i][j];
                if (j == 1) {
                    Console.Write($"{value.ToString().PadRight(15, ' ')}");
                    continue;
                }
                else if (j == 2 || j == 4) {
                    Console.Write($"{value.ToString().PadRight(20, ' ')}");
                    continue;
                }
                else if (j == 3) {
                    Console.Write($"{value.ToString().PadRight(35, ' ')}");
                    continue;
                }
                else if (j == 5) {
                    string format_date = value.ToString().Substring(0, 10);
                    Console.Write($"{format_date.PadRight(10, ' ')}");
                    continue;
                }
                else {
                    Console.Write($"{value.ToString().PadRight(10, ' ')}");
                }
            }
            Console.WriteLine();
        }
    }


    static void menu_professor(ref MySqlConnection connection) {

        int choice = 0;
        string str_search = "";
        int num_search = 0;

        string query = "";
        var command = new MySqlCommand();
        command.Connection = connection;
        var adapter = new MySqlDataAdapter(command);
        var table_result = new DataTable();

        do {

            table_result.Clear();
            query = "";
            command.CommandText = query;
            command.Parameters.Clear();

            Console.WriteLine("Insert a number to select an operation: ");
            Console.WriteLine("1. Show all professors ");
            Console.WriteLine("2. Search professors by course ");
            Console.WriteLine("3. Search professors by name ");
            Console.WriteLine("4. Search professors by surname ");
            Console.WriteLine("5. Search professors by year of teaching ");
            Console.WriteLine("6. Clear screen ");
            Console.WriteLine("7. Close (or return to previous menu) ");
            Console.WriteLine();

            choice = (Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine();

            switch (choice) {
                case 1:

                    query = "SELECT professor_id AS 'ProfessorID', first_name AS 'Name', last_name AS 'Surname' " +
                            "FROM professor;";
                    command.CommandText = query;
                    execute_command(ref command, ref adapter);
                    adapter.Fill(table_result);

                    if (table_result.Rows.Count == 0) {
                        log_error_message("No professors found! \n");
                        break;
                    }

                    print_professor_fields(table_result);
                    print_professor_query(table_result);

                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("Insert the course title: ");
                    str_search = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        log_error_message("You must write a course title! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT professor.professor_id AS 'ProfessorID', first_name AS 'Name', last_name AS 'Surname' " +
                             "FROM professor " +
                             "JOIN course_professor " +
                                 "ON professor.professor_id = course_professor.professor_id " +
                             "JOIN course " +
                                 "ON course.course_id = course_professor.course_id " +
                             "WHERE course.title = @str_search " +
                             "GROUP BY professor.professor_id " + 
                             "ORDER BY professor.professor_id;";
                    command.CommandText = query;
                    command.Parameters.Add("@str_search", MySqlDbType.VarChar).Value = str_search;
                    execute_command(ref command, ref adapter);
                    adapter.Fill(table_result);


                    if (table_result.Rows.Count == 0) {
                        log_error_message($"Course: {str_search} is not present! \n");
                        break;
                    }

                    print_professor_fields(table_result);
                    print_professor_query(table_result);

                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Insert the name: ");
                    str_search = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        log_error_message("You must write a name! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT professor_id AS 'ProfessorID', first_name AS 'Name', last_name AS 'Surname' " +
                            "FROM professor " +
                            "WHERE first_name = @str_search;";
                    command.CommandText = query;
                    command.Parameters.Add("@str_search", MySqlDbType.VarChar).Value = str_search;
                    execute_command(ref command, ref adapter);
                    adapter.Fill(table_result);

                    if (table_result.Rows.Count == 0) {
                        log_error_message($"No professor found with name {str_search}! \n");
                        break;
                    }

                    print_professor_fields(table_result);
                    print_professor_query(table_result);

                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("Insert the surname: ");
                    str_search = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        log_error_message("You must write a surname! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT professor_id AS 'ProfessorID', first_name AS 'Name', last_name AS 'Surname' " +
                            "FROM professor " +
                            "WHERE last_name = @str_search;";
                    command.CommandText = query;
                    command.Parameters.Add("@str_search", MySqlDbType.VarChar).Value = str_search;
                    execute_command(ref command, ref adapter);
                    adapter.Fill(table_result);

                    if (table_result.Rows.Count == 0) {
                        log_error_message($"No professor found with surname {str_search}! \n");
                        break;
                    }

                    print_professor_fields(table_result);
                    print_professor_query(table_result);

                    Console.WriteLine();
                    break;
                case 5:
                    Console.WriteLine("Insert the academic year: ");
                    num_search = (Convert.ToInt32(Console.ReadLine()));
                    if (num_search <= 0 || num_search >= 4) {
                        log_error_message("Year not present! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT professor.professor_id AS 'ProfessorID', professor.first_name AS 'Name', professor.last_name AS 'Surname' " +
                            "FROM professor " +
                            "JOIN course_professor " + 
                                "ON professor.professor_id = course_professor.professor_id " + 
                            "JOIN course " +
                                "ON course.course_id = course_professor.course_id " +
                            "WHERE course.academic_year = @num_search " +
                            "GROUP BY professor.professor_id " + 
                            "ORDER BY professor.professor_id;";
                    command.CommandText = query;
                    command.Parameters.Add("@num_search", MySqlDbType.Int32).Value = num_search;
                    execute_command(ref command, ref adapter);
                    adapter.Fill(table_result);

                    if (table_result.Rows.Count == 0) {
                        log_error_message($"No professor found that teaches for the academic year {num_search}! \n");
                        break;
                    }

                    print_professor_fields(table_result);
                    print_professor_query(table_result);

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

    static void print_professor_fields(DataTable table_result) {

        for (int j = 0; j < table_result.Columns.Count; ++j) {
            Console.Write($"{table_result.Columns[j].ColumnName.PadRight(15, ' ')}");
        }
        Console.Write("\n\n");
    }

    static void print_professor_query(DataTable table_result) {

        for (int i = 0; i < table_result.Rows.Count; i++) {
            for (int j = 0; j < table_result.Columns.Count; ++j) {
                var value = table_result.Rows[i][j];
                Console.Write($"{value.ToString().PadRight(15, ' ')}");
            }
            Console.WriteLine();
        }
    }


    static void menu_course(ref MySqlConnection connection) {

        int choice = 0;
        string str_search = "";
        int num_search = 0;

        string query = "";
        var command = new MySqlCommand();
        command.Connection = connection;
        var adapter = new MySqlDataAdapter(command);
        var table_result = new DataTable();

        do {

            table_result.Clear();
            query = "";
            command.CommandText = query;
            command.Parameters.Clear();

            Console.WriteLine("Insert a number to select an operation: ");
            Console.WriteLine("1. Show all courses ");
            Console.WriteLine("2. Search courses by title ");
            Console.WriteLine("3. Search courses by academic year ");
            Console.WriteLine("4. Clear screen ");
            Console.WriteLine("5. Close (or return to previous menu) ");
            Console.WriteLine();

            choice = (Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine();

            switch (choice) {
                case 1:

                    query = "SELECT course_id AS 'CourseID', title AS 'Title', academic_year AS 'Academic year' " +
                            "FROM course;";
                    command.CommandText = query;
                    execute_command(ref command, ref adapter);
                    adapter.Fill(table_result);

                    if (table_result.Rows.Count == 0) {
                        log_error_message("No courses found! \n");
                        break;
                    }

                    print_course_fields(table_result);
                    print_course_query(table_result);

                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("Insert the title: ");
                    str_search = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        log_error_message("You must write a title! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT course_id AS 'CourseID', title AS 'Title', academic_year AS 'Academic year' " +
                            "FROM course " +
                            "WHERE title = @str_search;";
                    command.CommandText = query;
                    command.Parameters.Add("@str_search", MySqlDbType.VarChar).Value = str_search;
                    execute_command(ref command, ref adapter);
                    adapter.Fill(table_result);

                    if (table_result.Rows.Count == 0) {
                        log_error_message($"No course found with title {str_search}! \n");
                        break;
                    }

                    print_course_fields(table_result);
                    print_course_query(table_result);

                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Insert the academic year: ");
                    num_search = (Convert.ToInt32(Console.ReadLine()));
                    if (num_search <= 0 || num_search >= 4) {
                        log_error_message("Year not present! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT course_id AS 'CourseID', title AS 'Title', academic_year AS 'Academic year' " +
                            "FROM course " +
                            "WHERE academic_year = @num_search;";
                    command.CommandText = query;
                    command.Parameters.Add("@num_search", MySqlDbType.Int32).Value = num_search;
                    execute_command(ref command, ref adapter);
                    adapter.Fill(table_result);

                    if (table_result.Rows.Count == 0) {
                        log_error_message($"No course found for the academic year {num_search}! \n");
                        break;
                    }

                    print_course_fields(table_result);
                    print_course_query(table_result);

                    Console.WriteLine();
                    break;
                case 4:
                    Console.Clear();
                    break;
                case 5:
                    break;
            }

        } while (choice != 5);

    }

    static void print_course_fields(DataTable table_result) {

        for (int j = 0; j < table_result.Columns.Count; ++j) {
            if (j == 1 || j == 2) {
                Console.Write($"{table_result.Columns[j].ColumnName.PadRight(25, ' ')}");
            }
            else {
                Console.Write($"{table_result.Columns[j].ColumnName.PadRight(15, ' ')}");
            }
        }
        Console.Write("\n\n");

    }
    
    static void print_course_query(DataTable table_result) {
        
        for (int i = 0; i < table_result.Rows.Count; i++) {
            for (int j = 0; j < table_result.Columns.Count; ++j) {
                var value = table_result.Rows[i][j];
                if (j == 1 || j == 2) {
                    Console.Write($"{value.ToString().PadRight(25, ' ')}");
                }
                else {
                    Console.Write($"{value.ToString().PadRight(15, ' ')}");
                }
            }
            Console.WriteLine();
        }
    }



    static bool establish_connection(ref MySqlConnection connection, string str_connection) {
        
        if (connection.State == ConnectionState.Open 
            || connection.State == ConnectionState.Executing 
            || connection.State == ConnectionState.Connecting ) {

            return false;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Connecting to the server...");
        try {
            connection.Open();
        }
        catch (MySqlException ex) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unable to open a connection to the server!");
            Console.Write($"[ERROR]: {ex.Code} - {ex.Message}");
        }
        Console.ResetColor();

        return true;
    }

    static void close_connection(ref MySqlConnection connection) {

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Closing the connection... ");
        connection.Close();
        Console.WriteLine("Connection closed! ");
        Console.ResetColor();
    }

    static void execute_command(ref MySqlCommand command, ref MySqlDataAdapter adapter) {

        try {
            adapter = new MySqlDataAdapter(command);
        }
        catch (MySqlException ex) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Unable to execute the command!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[ERROR]: {ex.Code} - {ex.Message}");
            Console.ResetColor();
            Console.WriteLine();
        }
    }

    static void log_error_message(string message) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    
}


/*
try {

    using (MySqlConnection connection = new MySqlConnection(str_connection)) {

        connection.Open();

        using (MySqlCommand command = new MySqlCommand(query, connection)) {
            
			// riga sotto questa è opzionale!
			command.Parameters.Add("@num_search", MySqlDbType.Int32).Value = num_search;

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command)) {

                adapter.Fill(table_result);
            }
        }
    }
}
catch (MySqlException ex) {
    log_sql_exception(ex);
}
*/