using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace UniversityManagementSystem;


public class InsertQueryResult {


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

            choice = UniMain.check_input_int();
            Console.WriteLine();

            switch (choice) {
                
                case 1:

                    Console.WriteLine("Insert all student infos: ");
                    Console.WriteLine("ID: ");
                    stud_id = UniMain.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Name: ");
                    stud_name = UniMain.check_input_string();
                    Console.WriteLine();

                    Console.WriteLine("Surname: ");
                    stud_surname = UniMain.check_input_string();
                    Console.WriteLine();

                    Console.WriteLine("Email: ");
                    stud_email = UniMain.check_input_string();
                    Console.WriteLine();

                    Console.WriteLine("Academic year: ");
                    stud_academic_year = UniMain.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Birth date: ");
                    Console.WriteLine("Year: ");
                    stud_year = UniMain.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Month: ");
                    stud_month = UniMain.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Day: ");
                    stud_day = UniMain.check_input_int();
                    Console.WriteLine();

                    if (stud_id <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(stud_name)) {
                        UniMain.log_error_message("Invalid name! \n");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(stud_surname)) {
                        UniMain.log_error_message("Invalid surname! \n");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(stud_email)) {
                        UniMain.log_error_message("Invalid email! \n");
                        break;
                    }
                    if (stud_academic_year <= 0 || stud_academic_year >= 4) {
                        UniMain.log_error_message("Invalid academic year! \n");
                        break;
                    }
                    if (stud_year <= 1899 || stud_year >= 2006 || stud_month <= 0 || stud_month >= 13 || stud_day <= 0 || stud_day >= 32) {
                        UniMain.log_error_message("Invalid birth date! \n");
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
                        UniMain.log_sql_exception(ex);
                    }

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Student added! \n");
                    }

                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine("Insert the student ID: ");
                    id_search = UniMain.check_input_int();
                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the new name: ");
                    stud_name = UniMain.check_input_string();
                    if (string.IsNullOrWhiteSpace(stud_name)) {
                        UniMain.log_error_message("Invalid name! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE student " +
                            "SET first_name = @stud_name " +
                            "WHERE student_id = @id_search;";

                    rows_affected = execute_update(str_connection, query, nameof(id_search), id_search, nameof(stud_name), stud_name);
                    
                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Student modified! \n");
                    }

                    Console.WriteLine();
                    break;
                
                case 3:
                    Console.WriteLine("Insert the student ID: ");
                    id_search = UniMain.check_input_int();
                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the new surname: ");
                    stud_surname = UniMain.check_input_string();
                    if (string.IsNullOrWhiteSpace(stud_surname)) {
                        UniMain.log_error_message("Invalid surname! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE student " +
                            "SET last_name = @stud_surname " + 
                            "WHERE student_id = @id_search;";

                    rows_affected = execute_update(str_connection, query, nameof(id_search), id_search, nameof(stud_surname), stud_surname);

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Student modified! \n");
                    }

                    Console.WriteLine();
                    break;
                
                case 4:
                    Console.WriteLine("Insert the student ID: ");
                    id_search = UniMain.check_input_int();
                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the new email: ");
                    stud_email = UniMain.check_input_string();
                    if (string.IsNullOrWhiteSpace(stud_email)) {
                        UniMain.log_error_message("Invalid email! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE student " +
                            "SET email = @stud_email " +
                            "WHERE student_id = @id_search;";

                    rows_affected = execute_update(str_connection, query, nameof(id_search), id_search, nameof(stud_email), stud_email);

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Student modified! \n");
                    }

                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine("Insert the student ID: ");
                    id_search = UniMain.check_input_int();
                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the new academic year: ");
                    stud_academic_year = UniMain.check_input_int();
                    if (stud_academic_year <= 0 || stud_academic_year >= 4) {
                        UniMain.log_error_message("Invalid academic year! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE student " +
                            "SET academic_year = @stud_academic_year " +
                            "WHERE student_id = @id_search;";

                    rows_affected = execute_update(str_connection, query, nameof(id_search), id_search, nameof(stud_academic_year), stud_academic_year);

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Student modified! \n");
                    }

                    Console.WriteLine();
                    break;

                case 6:
                    Console.WriteLine("Insert the student ID: ");
                    id_search = UniMain.check_input_int();
                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the new birth year: ");
                    stud_year = UniMain.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Insert the new birth month: ");
                    stud_month = UniMain.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Insert the new birth day: ");
                    stud_day = UniMain.check_input_int();
                    Console.WriteLine();

                    if (stud_year <= 1899 || stud_year >= 2006 || stud_month <= 0 || stud_month >= 13 || stud_day <= 0 || stud_day >= 32) {
                        UniMain.log_error_message("Invalid birth date! \n");
                        break;
                    }
                    Console.WriteLine();

                    stud_birth_date = new MySqlDateTime(new DateTime(stud_year, stud_month, stud_day));

                    query = @"UPDATE student " +
                            "SET birth_date = @stud_birth_date " +
                            "WHERE student_id = @id_search;";

                    rows_affected = execute_update(str_connection, query, nameof(id_search), id_search, nameof(stud_birth_date), stud_birth_date);

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Student modified! \n");
                    }

                    Console.WriteLine();
                    break;

                case 7:
                    Console.WriteLine("Insert the student ID: ");
                    id_search = UniMain.check_input_int();
                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
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
                        UniMain.log_sql_exception(ex);
                    }

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Student removed! \n");
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

            choice = UniMain.check_input_int();
            Console.WriteLine();

            switch (choice) {

                case 1:

                    Console.WriteLine("Insert all professor infos: ");
                    Console.WriteLine("ID: ");
                    prof_id = UniMain.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Name: ");
                    prof_name = UniMain.check_input_string();
                    Console.WriteLine();

                    Console.WriteLine("Surname: ");
                    prof_surname = UniMain.check_input_string();
                    Console.WriteLine();

                    if (prof_id <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(prof_name)) {
                        UniMain.log_error_message("Invalid name! \n");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(prof_surname)) {
                        UniMain.log_error_message("Invalid surname! \n");
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
                        UniMain.log_sql_exception(ex);
                    }

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Professor added! \n");
                    }

                    break;

                case 2:
                    Console.WriteLine("Insert the course ID: ");
                    id_search = UniMain.check_input_int();
                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the professor new name: ");
                    prof_name = UniMain.check_input_string();
                    if (string.IsNullOrWhiteSpace(prof_name)) {
                        UniMain.log_error_message("Invalid name! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE professor " +
                            "SET first_name = @prof_name " +
                            "WHERE professor_id = @id_search;";

                    rows_affected = execute_update(str_connection, query, nameof(id_search), id_search, nameof(prof_name), prof_name);

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Professor modified! \n");
                    }

                    break;

                case 3:
                    Console.WriteLine("Insert the professor ID: ");
                    id_search = UniMain.check_input_int();
                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();
                   
                    query = @"UPDATE professor " +
                            "SET last_name = @prof_surname " +
                            "WHERE professor_id = @id_search;";

                    rows_affected = execute_update(str_connection, query, nameof(id_search), id_search, nameof(prof_surname), prof_surname);

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Professor modified! \n");
                    }

                    break;

                case 4:
                    Console.WriteLine("Insert the professor ID: ");
                    id_search = UniMain.check_input_int();
                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
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
                        UniMain.log_sql_exception(ex);
                    }

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Professor removed! \n");
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

            choice = UniMain.check_input_int();
            Console.WriteLine();

            switch (choice) {

                case 1:

                    Console.WriteLine("Insert all course infos: ");
                    Console.WriteLine("ID: ");
                    course_id = UniMain.check_input_int();
                    Console.WriteLine();

                    Console.WriteLine("Title: ");
                    course_title = UniMain.check_input_string();
                    Console.WriteLine();

                    Console.WriteLine("Academic year: ");
                    course_academic_year = UniMain.check_input_int();
                    Console.WriteLine();

                    if (course_id <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(course_title)) {
                        UniMain.log_error_message("Invalid title! \n");
                        break;
                    }
                    if (course_academic_year <= 0 || course_academic_year >= 4) {
                        UniMain.log_error_message("Invalid academic year! \n");
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
                        UniMain.log_sql_exception(ex);
                    }

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Course added! \n");
                    }

                    break;

                case 2:
                    Console.WriteLine("Insert the course ID: ");
                    id_search = UniMain.check_input_int();
                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the new course title: ");
                    course_title = UniMain.check_input_string();
                    if (string.IsNullOrWhiteSpace(course_title)) {
                        UniMain.log_error_message("Invalid title! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE course " +
                            "SET title = @course_title " +
                            "WHERE course_id = @id_search;";

                    rows_affected = execute_update(str_connection, query, nameof(id_search), id_search, nameof(course_title), course_title);

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Course modified! \n");
                    }

                    break;

                case 3:
                    Console.WriteLine("Insert the course ID: ");
                    id_search = UniMain.check_input_int();
                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Insert the new academic year: ");
                    course_academic_year = UniMain.check_input_int();
                    if (course_academic_year <= 0 || course_academic_year >= 4) {
                        UniMain.log_error_message("Invalid academic year! \n");
                        break;
                    }
                    Console.WriteLine();

                    query = @"UPDATE course " +
                            "SET academic_year = @course_academic_year " +
                            "WHERE course_id = @id_search;";

                    rows_affected = execute_update(str_connection, query, nameof(id_search), id_search, nameof(course_academic_year), course_academic_year);

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Course modified! \n");
                    }

                    break;

                case 4:
                    Console.WriteLine("Insert the course ID: ");
                    id_search = UniMain.check_input_int();
                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
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
                        UniMain.log_sql_exception(ex);
                    }

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }
                    else {
                        UniMain.log_message("Course removed! \n");
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



    static int execute_update(string str_connection, string query, 
                              string parameter_id_name, int parameter_id, 
                              string parameter_name, int parameter) {

        int rows_affected = 0;
        try {
            using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    command.Parameters.Add("@" + parameter_id_name, MySqlDbType.Int32).Value = parameter_id;
                    command.Parameters.Add("@" + parameter_name, MySqlDbType.Int32).Value = parameter;
                    rows_affected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        catch (MySqlException ex) {
            UniMain.log_sql_exception(ex);
        }

        return rows_affected;
    }

    static int execute_update(string str_connection, string query,
                              string parameter_id_name, int parameter_id,
                              string parameter_name, string parameter) {

        int rows_affected = 0;
        try {
            using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    command.Parameters.Add("@" + parameter_id_name, MySqlDbType.Int32).Value = parameter_id;
                    command.Parameters.Add("@" + parameter_name, MySqlDbType.VarChar).Value = parameter;
                    rows_affected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        catch (MySqlException ex) {
            UniMain.log_sql_exception(ex);
        }

        return rows_affected;
    }

    static int execute_update(string str_connection, string query,
                              string parameter_id_name, int parameter_id,
                              string parameter_name, MySqlDateTime parameter) {

        int rows_affected = 0;
        try {
            using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    command.Parameters.Add("@" + parameter_id_name, MySqlDbType.Int32).Value = parameter_id;
                    command.Parameters.Add("@" + parameter_name, MySqlDbType.Date).Value = parameter;
                    rows_affected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        catch (MySqlException ex) {
            UniMain.log_sql_exception(ex);
        }

        return rows_affected;
    }

    
}
