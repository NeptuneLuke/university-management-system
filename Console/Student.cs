using BetterConsoleTables;
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data.Types;

namespace UniversityManagementSystem;

public class Student {

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

            choice = Util.check_input_int();
            Console.WriteLine();

            switch (choice) {

                case 1:

                    query = "SELECT student_id AS 'StudentID', first_name AS 'Name', last_name AS 'Surname', " +
                            "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                            "FROM student;";

                    table_result = Util.execute_select(str_connection, query);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message("No students found! \n");
                        break;
                    }

                    print_student(table_result);

                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine("Insert the course title: ");
                    str_search = Util.check_input_string();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        Util.log_error_message("You must write a course title! \n");
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

                    table_result = Util.execute_select(str_connection, query, nameof(str_search), str_search);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message($"Course: {str_search} is not already present! \n");
                        break;
                    }

                    print_student(table_result);

                    Console.WriteLine();
                    break;

                case 3:
                    Console.WriteLine("Insert the name: ");
                    Util.check_input_string();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        Util.log_error_message("You must write a name! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT student_id AS 'StudentID', first_name AS 'Name', last_name AS 'Surname', " +
                            "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                            "FROM student " +
                            "WHERE first_name = @str_search;";

                    table_result = Util.execute_select(str_connection, query, nameof(str_search), str_search);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message($"No student found with name {str_search}! \n");
                        break;
                    }

                    print_student(table_result);

                    Console.WriteLine();
                    break;

                case 4:
                    Console.WriteLine("Insert the surname: ");
                    Util.check_input_string();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        Util.log_error_message("You must write a surname! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT student_id AS 'StudentID', first_name AS 'Name', last_name AS 'Surname', " +
                            "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                            "FROM student " +
                            "WHERE last_name = @str_search;";

                    table_result = Util.execute_select(str_connection, query, nameof(str_search), str_search);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message($"No student found with surname {str_search}! \n");
                        break;
                    }

                    print_student(table_result);

                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine("Insert the academic year: ");
                    num_search = Util.check_input_int();
                    if (num_search <= 0 || num_search >= 4) {
                        Util.log_error_message("Invalid academic year! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT student_id AS 'StudentID', first_name AS 'Name', last_name AS 'Surname', " +
                            "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                            "FROM student " +
                            "WHERE academic_year = @num_search;";

                    table_result = Util.execute_select(str_connection, query, nameof(num_search), num_search);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message($"No student of the academic year {num_search} found! \n");
                        break;
                    }

                    print_student(table_result);

                    Console.WriteLine();
                    break;

                case 6:
                    Console.WriteLine("Insert the birth year: ");
                    num_search = Util.check_input_int();
                    if (num_search <= 1899 || num_search >= 2006) {
                        Util.log_error_message("Invalid year! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT student_id AS 'StudentID', first_name AS 'Name', last_name AS 'Surname', " +
                            "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                            "FROM student " +
                            "WHERE birth_date LIKE CONCAT(@num_search, '-__-__');";

                    table_result = Util.execute_select(str_connection, query, nameof(num_search), num_search);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message($"No student with birth year {num_search} found! \n");
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

    public static void menu_modify_student(string str_connection) {

        int choice = 0;
        DataTable table_result = new DataTable();
        int rows_affected = 0;
        int id_search = 0;
        string query = "";

        int stud_id = 0;
        string stud_name = "";
        string stud_surname = "";
        string stud_email = "";
        int stud_academic_year = 0;
        int stud_year = 0;
        int stud_month = 0;
        int stud_day = 0;
        MySqlDateTime stud_birth_date;

        do {

            id_search = 0;
            stud_id = 0;
            stud_name = "";
            stud_surname = "";
            stud_email = "";
            stud_academic_year = 0;
            stud_year = 0;
            stud_month = 0;
            stud_day = 0;
            table_result.Clear();
            query = "";

            Console.WriteLine("Insert a number to select an operation: ");
            Console.WriteLine("1. Insert a new student ");
            Console.WriteLine("2. Modify a student name ");
            Console.WriteLine("3. Modify a student surname ");
            Console.WriteLine("4. Modify a student email ");
            Console.WriteLine("5. Modify a student academic year ");
            Console.WriteLine("6. Modify a student birth date ");
            Console.WriteLine("7. Delete a student ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("8. Clear screen ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("9. Close (or return to previous menu) ");
            Console.ResetColor();
            Console.WriteLine();

            choice = Util.check_input_int();
            Console.WriteLine();

            switch (choice) {

                case 1:

                    Console.WriteLine("Insert all student infos: ");
                    Console.WriteLine("ID: ");
                    stud_id = Util.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Name: ");
                    stud_name = Util.check_input_string();
                    Console.WriteLine();

                    Console.WriteLine("Surname: ");
                    stud_surname = Util.check_input_string();
                    Console.WriteLine();

                    Console.WriteLine("Email: ");
                    stud_email = Util.check_input_string();
                    Console.WriteLine();

                    Console.WriteLine("Academic year: ");
                    stud_academic_year = Util.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Birth date: ");
                    Console.WriteLine("Year: ");
                    stud_year = Util.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Month: ");
                    stud_month = Util.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Day: ");
                    stud_day = Util.check_input_int();
                    Console.WriteLine();

                    if (stud_id <= 0) {
                        Util.log_error_message("Invalid ID! \n");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(stud_name)) {
                        Util.log_error_message("Invalid name! \n");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(stud_surname)) {
                        Util.log_error_message("Invalid surname! \n");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(stud_email)) {
                        Util.log_error_message("Invalid email! \n");
                        break;
                    }
                    if (stud_academic_year <= 0 || stud_academic_year >= 4) {
                        Util.log_error_message("Invalid academic year! \n");
                        break;
                    }
                    if (stud_year <= 1899 || stud_year >= 2006 || stud_month <= 0 || stud_month >= 13 || stud_day <= 0 || stud_day >= 32) {
                        Util.log_error_message("Invalid birth date! \n");
                        break;
                    }
                    Console.WriteLine();

                    stud_birth_date = new MySqlDateTime(new DateTime(stud_year, stud_month, stud_day));

                    query = @"INSERT INTO student " +
                            "VALUES (@stud_id,@stud_name,@stud_surname,@stud_email,@stud_academic_year,@stud_birth_date);";

                    try {
                        using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                            connection.Open();
                            using (MySqlCommand command = new MySqlCommand(query, connection)) {
                                command.Parameters.Add("@stud_id", MySqlDbType.Int32).Value = stud_id;
                                command.Parameters.Add("@stud_name", MySqlDbType.VarChar).Value = stud_name;
                                command.Parameters.Add("@stud_surname", MySqlDbType.VarChar).Value = stud_surname;
                                command.Parameters.Add("@stud_email", MySqlDbType.VarChar).Value = stud_email;
                                command.Parameters.Add("@stud_academic_year", MySqlDbType.Int32).Value = stud_academic_year;
                                command.Parameters.Add("@stud_birth_date", MySqlDbType.Date).Value = stud_birth_date;
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
                        Util.log_message("Student added! \n");
                    }

                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine("Insert the student ID: ");
                    id_search = Util.check_input_int();
                    if (id_search <= 0) {
                        Util.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the new name: ");
                    stud_name = Util.check_input_string();
                    if (string.IsNullOrWhiteSpace(stud_name)) {
                        Util.log_error_message("Invalid name! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE student " +
                            "SET first_name = @stud_name " +
                            "WHERE student_id = @id_search;";

                    rows_affected = Util.execute_update(str_connection, query, nameof(id_search), id_search, nameof(stud_name), stud_name);

                    if (rows_affected == 0) {
                        Util.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        Util.log_message("Student modified! \n");
                    }

                    Console.WriteLine();
                    break;

                case 3:
                    Console.WriteLine("Insert the student ID: ");
                    id_search = Util.check_input_int();
                    if (id_search <= 0) {
                        Util.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the new surname: ");
                    stud_surname = Util.check_input_string();
                    if (string.IsNullOrWhiteSpace(stud_surname)) {
                        Util.log_error_message("Invalid surname! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE student " +
                            "SET last_name = @stud_surname " +
                            "WHERE student_id = @id_search;";

                    rows_affected = Util.execute_update(str_connection, query, nameof(id_search), id_search, nameof(stud_surname), stud_surname);

                    if (rows_affected == 0) {
                        Util.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        Util.log_message("Student modified! \n");
                    }

                    Console.WriteLine();
                    break;

                case 4:
                    Console.WriteLine("Insert the student ID: ");
                    id_search = Util.check_input_int();
                    if (id_search <= 0) {
                        Util.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the new email: ");
                    stud_email = Util.check_input_string();
                    if (string.IsNullOrWhiteSpace(stud_email)) {
                        Util.log_error_message("Invalid email! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE student " +
                            "SET email = @stud_email " +
                            "WHERE student_id = @id_search;";

                    rows_affected = Util.execute_update(str_connection, query, nameof(id_search), id_search, nameof(stud_email), stud_email);

                    if (rows_affected == 0) {
                        Util.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        Util.log_message("Student modified! \n");
                    }

                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine("Insert the student ID: ");
                    id_search = Util.check_input_int();
                    if (id_search <= 0) {
                        Util.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the new academic year: ");
                    stud_academic_year = Util.check_input_int();
                    if (stud_academic_year <= 0 || stud_academic_year >= 4) {
                        Util.log_error_message("Invalid academic year! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE student " +
                            "SET academic_year = @stud_academic_year " +
                            "WHERE student_id = @id_search;";

                    rows_affected = Util.execute_update(str_connection, query, nameof(id_search), id_search, nameof(stud_academic_year), stud_academic_year);

                    if (rows_affected == 0) {
                        Util.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        Util.log_message("Student modified! \n");
                    }

                    Console.WriteLine();
                    break;

                case 6:
                    Console.WriteLine("Insert the student ID: ");
                    id_search = Util.check_input_int();
                    if (id_search <= 0) {
                        Util.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the new birth year: ");
                    stud_year = Util.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Insert the new birth month: ");
                    stud_month = Util.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Insert the new birth day: ");
                    stud_day = Util.check_input_int();
                    Console.WriteLine();

                    if (stud_year <= 1899 || stud_year >= 2006 || stud_month <= 0 || stud_month >= 13 || stud_day <= 0 || stud_day >= 32) {
                        Util.log_error_message("Invalid birth date! \n");
                        break;
                    }
                    Console.WriteLine();

                    stud_birth_date = new MySqlDateTime(new DateTime(stud_year, stud_month, stud_day));

                    query = @"UPDATE student " +
                            "SET birth_date = @stud_birth_date " +
                            "WHERE student_id = @id_search;";

                    rows_affected = Util.execute_update(str_connection, query, nameof(id_search), id_search, nameof(stud_birth_date), stud_birth_date);

                    if (rows_affected == 0) {
                        Util.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        Util.log_message("Student modified! \n");
                    }

                    Console.WriteLine();
                    break;

                case 7:
                    Console.WriteLine("Insert the student ID: ");
                    id_search = Util.check_input_int();
                    if (id_search <= 0) {
                        Util.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"DELETE FROM student " +
                            "WHERE student_id = @id_search;";

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
                        Util.log_message("Student removed! \n");
                    }

                    break;

                case 8:
                    Console.Clear();
                    break;

                case 9:
                    break;
            }

        } while (choice != 9);

    }

    public static void print_student(DataTable table_result) {

        Table table = new Table();
        table.Config = TableConfiguration.Unicode();

        for (int i = 0; i < table_result.Columns.Count; ++i) {
            table.AddColumn(table_result.Columns[i].ColumnName);
        }

        for (int i = 0; i < table_result.Rows.Count; ++i) {
            table.AddRow(table_result.Rows[i][0].ToString(), table_result.Rows[i][1].ToString(), table_result.Rows[i][2].ToString(),
                table_result.Rows[i][3].ToString(), table_result.Rows[i][4].ToString(), table_result.Rows[i][5].ToString().Substring(0, 10));
        }
        Console.Write(table.ToString());
    }

    public static void print_student_short(DataTable table_result) {

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
}
