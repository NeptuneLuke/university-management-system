using BetterConsoleTables;
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data.Types;

namespace UniversityManagementSystem;

public class Professor {

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

            choice = Util.check_input_int();
            Console.WriteLine();

            switch (choice) {

                case 1:

                    query = "SELECT professor_id AS 'ProfessorID', " +
                            "first_name AS 'Name', last_name AS 'Surname', email AS 'Email'" +
                            "FROM professor;";

                    table_result = Util.execute_select(str_connection, query);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message("No professors found! \n");
                        break;
                    }

                    print_professor(table_result);

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

                    table_result = Util.execute_select(str_connection, query, nameof(str_search), str_search);


                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message($"Course: {str_search} is not already present! \n");
                        break;
                    }

                    print_professor(table_result);

                    Console.WriteLine();
                    break;

                case 3:
                    Console.WriteLine("Insert the name: ");
                    str_search = Util.check_input_string();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        Util.log_error_message("You must write a name! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT professor_id AS 'ProfessorID', " +
                             "first_name AS 'Name', last_name AS 'Surname', email AS 'Email' " +
                             "FROM professor " +
                             "WHERE first_name = @str_search;";

                    table_result = Util.execute_select(str_connection, query, nameof(str_search), str_search);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message($"No professor found with name {str_search}! \n");
                        break;
                    }

                    print_professor(table_result);

                    Console.WriteLine();
                    break;

                case 4:
                    Console.WriteLine("Insert the surname: ");
                    str_search = Util.check_input_string();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        Util.log_error_message("You must write a surname! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT professor_id AS 'ProfessorID', " +
                             "first_name AS 'Name', last_name AS 'Surname', email AS 'Email' " +
                             "FROM professor " +
                             "WHERE last_name = @str_search;";

                    table_result = Util.execute_select(str_connection, query, nameof(str_search), str_search);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message($"No professor found with surname {str_search}! \n");
                        break;
                    }

                    print_professor(table_result);

                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine("Insert the email: ");
                    str_search = Util.check_input_string();
                    if (string.IsNullOrWhiteSpace(str_search)) {
                        Util.log_error_message("You must write an email! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"SELECT professor_id AS 'ProfessorID', " +
                             "first_name AS 'Name', last_name AS 'Surname', email AS 'Email' " +
                             "FROM professor " +
                             "WHERE email = @str_search;";

                    table_result = Util.execute_select(str_connection, query, nameof(str_search), str_search);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message($"No professor found with email {str_search}! \n");
                        break;
                    }

                    print_professor(table_result);

                    Console.WriteLine();
                    break;

                case 6:
                    Console.WriteLine("Insert the academic year: ");
                    num_search = Util.check_input_int();
                    if (num_search <= 0 || num_search >= 4) {
                        Util.log_error_message("Invalid academic year! \n");
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

                    table_result = Util.execute_select(str_connection, query, nameof(num_search), num_search);

                    if (table_result.Rows.Count == 0) {
                        Util.log_error_message($"No professor found that teaches for the academic year {num_search}! \n");
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

    public static void menu_modify_professor(string str_connection) {

        int choice = 0;
        DataTable table_result = new DataTable();
        int rows_affected = 0;
        int id_search = 0;
        string query = "";

        int prof_id = 0;
        string prof_name = "";
        string prof_surname = "";

        do {

            id_search = 0;
            prof_id = 0;
            prof_name = "";
            prof_surname = "";
            table_result.Clear();
            query = "";

            Console.WriteLine("Insert a number to select an operation: ");
            Console.WriteLine("1. Insert a new professor ");
            Console.WriteLine("2. Modify a professor name ");
            Console.WriteLine("3. Modify a professor surname ");
            Console.WriteLine("4. Delete a professor ");
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

                    Console.WriteLine("Insert all professor infos: ");
                    Console.WriteLine("ID: ");
                    prof_id = Util.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Name: ");
                    prof_name = Util.check_input_string();
                    Console.WriteLine();

                    Console.WriteLine("Surname: ");
                    prof_surname = Util.check_input_string();
                    Console.WriteLine();

                    if (prof_id <= 0) {
                        Util.log_error_message("Invalid ID! \n");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(prof_name)) {
                        Util.log_error_message("Invalid name! \n");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(prof_surname)) {
                        Util.log_error_message("Invalid surname! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"INSERT INTO professor " +
                            "VALUES (@prof_id,@prof_name,@prof_surname);";

                    try {
                        using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                            connection.Open();
                            using (MySqlCommand command = new MySqlCommand(query, connection)) {
                                command.Parameters.Add("@prof_id", MySqlDbType.Int32).Value = prof_id;
                                command.Parameters.Add("@prof_name", MySqlDbType.VarChar).Value = prof_name;
                                command.Parameters.Add("@prof_surname", MySqlDbType.VarChar).Value = prof_surname;
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
                        Util.log_message("Professor added! \n");
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

                    Console.WriteLine("Insert the professor new name: ");
                    prof_name = Util.check_input_string();
                    if (string.IsNullOrWhiteSpace(prof_name)) {
                        Util.log_error_message("Invalid name! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE professor " +
                            "SET first_name = @prof_name " +
                            "WHERE professor_id = @id_search;";

                    rows_affected = Util.execute_update(str_connection, query, nameof(id_search), id_search, nameof(prof_name), prof_name);

                    if (rows_affected == 0) {
                        Util.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        Util.log_message("Professor modified! \n");
                    }

                    break;

                case 3:
                    Console.WriteLine("Insert the professor ID: ");
                    id_search = Util.check_input_int();
                    if (id_search <= 0) {
                        Util.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE professor " +
                            "SET last_name = @prof_surname " +
                            "WHERE professor_id = @id_search;";

                    rows_affected = Util.execute_update(str_connection, query, nameof(id_search), id_search, nameof(prof_surname), prof_surname);

                    if (rows_affected == 0) {
                        Util.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        Util.log_message("Professor modified! \n");
                    }

                    break;

                case 4:
                    Console.WriteLine("Insert the professor ID: ");
                    id_search = Util.check_input_int();
                    if (id_search <= 0) {
                        Util.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"DELETE FROM professor " +
                            "WHERE professor_id = @id_search;";

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
                        Util.log_message("Professor removed! \n");
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

    private static void print_professor(DataTable table_result) {

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
}
