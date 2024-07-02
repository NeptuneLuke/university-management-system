using System;
using System.Data;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace UniversityManagementSystem;


public class InsertQueryResult {

    public static void menu_modify_student(string str_connection) {

        int choice = 0;
        DataTable table_result = new DataTable();
        int rows_affected = 0;
        int id_search = 0;
        string query = "";

        do {

            table_result.Clear();
            query = "";

            Console.WriteLine("Insert a number to select an operation: ");
            Console.WriteLine("1. Insert a new student ");
            Console.WriteLine("2. Modify a student name ");
            Console.WriteLine("3. Modify a student surname ");
            Console.WriteLine("4. Modify a student email ");
            Console.WriteLine("5. Modify a student academic year ");
            Console.WriteLine("6. Modify a student birth date ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("7. Clear screen ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("8. Close (or return to previous menu) ");
            Console.ResetColor();
            Console.WriteLine();

            try {
                choice = (Convert.ToInt32(Console.ReadLine()));
            }
            catch (Exception ex) {
                UniMain.log_error_message("Input not taken! ");
                UniMain.log_exception(ex);
            }
            Console.WriteLine();

            switch (choice) {
                
                case 1:

                    int stud_id = 0;
                    string stud_name = "";
                    string stud_surname = "";
                    string stud_email = "";
                    int stud_year = 0;
                    int stud_month = 0;
                    int stud_day = 0;
                    int stud_academic_year = 0;

                    Console.WriteLine("Insert all student infos: ");
                    Console.WriteLine("ID: ");
                    try {
                        stud_id = (Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception ex) {
                        UniMain.log_error_message("Input not taken! ");
                        UniMain.log_exception(ex);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Name: ");
                    stud_name = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Surname: ");
                    stud_surname = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Email: ");
                    stud_email = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Academic year: ");
                    try {
                        stud_academic_year = (Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception ex) {
                        UniMain.log_error_message("Input not taken! ");
                        UniMain.log_exception(ex);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Birth date: ");
                    Console.WriteLine("Year: ");
                    try {
                        stud_year = (Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception ex) {
                        UniMain.log_error_message("Input not taken! ");
                        UniMain.log_exception(ex);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Month: ");
                    try {
                        stud_month = (Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception ex) {
                        UniMain.log_error_message("Input not taken! ");
                        UniMain.log_exception(ex);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Day: ");
                    try {
                        stud_day = (Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception ex) {
                        UniMain.log_error_message("Input not taken! ");
                        UniMain.log_exception(ex);
                    }
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

                    query = @"INSERT INTO student " +
                            "VALUES (@stud_id,@stud_name,@stud_surname,@stud_email,@stud_academic_year,@stud_year,@stud_month,@stud_day);";

                    try {
                        using (MySqlConnection connection = new MySqlConnection(str_connection)) {

                            using (MySqlCommand command = new MySqlCommand(query, connection)) {
                                command.Parameters.Add("@stud_id", MySqlDbType.Int32).Value = stud_id;
                                command.Parameters.Add("@stud_name", MySqlDbType.VarChar).Value = stud_name;
                                command.Parameters.Add("@stud_surname", MySqlDbType.VarChar).Value = stud_surname;
                                command.Parameters.Add("@stud_email", MySqlDbType.VarChar).Value = stud_email;
                                command.Parameters.Add("@stud_academic_year", MySqlDbType.Int32).Value = stud_academic_year;
                                command.Parameters.Add("@stud_year", MySqlDbType.Int32).Value = stud_year;
                                command.Parameters.Add("@stud_month", MySqlDbType.Int32).Value = stud_month;
                                command.Parameters.Add("@stud_day", MySqlDbType.Int32).Value = stud_day;
                                rows_affected = command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (MySqlException ex) {
                        UniMain.log_sql_exception(ex);
                    }

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }

                    Console.WriteLine();
                    break;

                case 2:
                    id_search = 0;
                    Console.WriteLine("Insert the student ID: ");
                    try {
                        id_search = (Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception ex) {
                        UniMain.log_error_message("Input not taken! ");
                        UniMain.log_exception(ex);
                    }

                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    stud_name = "";
                    Console.WriteLine("Insert the new student name: ");
                    stud_name = Console.ReadLine();
                    stud_name = stud_name.Trim();
                    if (string.IsNullOrWhiteSpace(stud_name)) {
                        UniMain.log_error_message("You must write a name! \n");
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

                    Console.WriteLine();
                    break;
                
                case 3:
                    id_search = 0;
                    Console.WriteLine("Insert the student ID: ");
                    try {
                        id_search = (Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception ex) {
                       UniMain.log_error_message("Input not taken! ");
                        UniMain.log_exception(ex);
                    }

                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    stud_surname = "";
                    Console.WriteLine("Insert the student new surname: ");
                    stud_surname = Console.ReadLine();
                    stud_surname = stud_surname.Trim();
                    if (string.IsNullOrWhiteSpace(stud_surname)) {
                        UniMain.log_error_message("You must write a surname! \n");
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

                    Console.WriteLine();
                    break;
                
                case 4:
                    id_search = 0;
                    Console.WriteLine("Insert the student ID: ");
                    try {
                        id_search = (Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception ex) {
                        UniMain.log_error_message("Input not taken! ");
                        UniMain.log_exception(ex);
                    }

                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    stud_email = "";
                    Console.WriteLine("Insert the new student email: ");
                    stud_email = Console.ReadLine();
                    stud_email = stud_email.Trim();
                    if (string.IsNullOrWhiteSpace(stud_email)) {
                        UniMain.log_error_message("You must write an email! \n");
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

                    Console.WriteLine();
                    break;

                case 5:
                    id_search = 0;
                    Console.WriteLine("Insert the student ID: ");
                    try {
                        id_search = (Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception ex) {
                        UniMain.log_error_message("Input not taken! ");
                        UniMain.log_exception(ex);
                    }

                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    stud_academic_year = 0;
                    Console.WriteLine("Insert the new academic_year: ");
                    try {
                        stud_academic_year = (Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception ex) {
                        UniMain.log_error_message("Input not taken! ");
                        UniMain.log_exception(ex);
                    }

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

                    Console.WriteLine();
                    break;

                case 6:
                    id_search = 0;
                    Console.WriteLine("Insert the student ID: ");
                    try {
                        id_search = (Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception ex) {
                        UniMain.log_error_message("Input not taken! ");
                        UniMain.log_exception(ex);
                    }

                    if (id_search <= 0) {
                        UniMain.log_error_message("Invalid ID! \n");
                        break;
                    }
                    Console.WriteLine();

                    stud_year = 0;
                    stud_month = 0;
                    stud_day = 0;
                    Console.WriteLine("Insert the new birth year: ");
                    try {
                        stud_year = (Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception ex) {
                        UniMain.log_error_message("Input not taken! ");
                        UniMain.log_exception(ex);
                    }

                    Console.WriteLine("Insert the new birth month: ");
                    try {
                        stud_month = (Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception ex) {
                        UniMain.log_error_message("Input not taken! ");
                        UniMain.log_exception(ex);
                    }

                    Console.WriteLine("Insert the new birth day: ");
                    try {
                        stud_day = (Convert.ToInt32(Console.ReadLine()));
                    }
                    catch (Exception ex) {
                        UniMain.log_error_message("Input not taken! ");
                        UniMain.log_exception(ex);
                    }

                    if (stud_year <= 1899 || stud_year >= 2006 || stud_month <= 0 || stud_month >= 13 || stud_day <= 0 || stud_day >= 32) {
                        UniMain.log_error_message("Invalid birth date! \n");
                        break;
                    }
                    Console.WriteLine();

                    MySqlDateTime stud_birth_date = new MySqlDateTime(new DateTime(stud_year, stud_month, stud_day));

                    query = @"UPDATE student " +
                            "SET birth_date = @stud_birth_date " +
                            "WHERE student_id = @id_search;";

                    rows_affected = execute_update(str_connection, query, nameof(id_search), id_search, nameof(stud_birth_date), stud_birth_date);

                    if (rows_affected == 0) {
                        UniMain.log_error_message("Command not executed! \n");
                        break;
                    }

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


    static int execute_update(string str_connection, string query, 
                              string parameter_id_name, int parameter_id, 
                              string parameter_name, int parameter) {

        int rows_affected = 0;
        try {
            using (MySqlConnection connection = new MySqlConnection(str_connection)) {

                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    command.Parameters.Add("@" + parameter_id_name, MySqlDbType.Int32).Value = parameter_id;
                    command.Parameters.Add("@" + parameter_name, MySqlDbType.Int32).Value = parameter;
                    rows_affected = command.ExecuteNonQuery();
                }
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

                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    command.Parameters.Add("@" + parameter_id_name, MySqlDbType.Int32).Value = parameter_id;
                    command.Parameters.Add("@" + parameter_name, MySqlDbType.VarChar).Value = parameter;
                    rows_affected = command.ExecuteNonQuery();
                }
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

                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    command.Parameters.Add("@" + parameter_id_name, MySqlDbType.Int32).Value = parameter_id;
                    command.Parameters.Add("@" + parameter_name, MySqlDbType.Date).Value = parameter;
                    rows_affected = command.ExecuteNonQuery();
                }
            }
        }
        catch (MySqlException ex) {
            UniMain.log_sql_exception(ex);
        }

        return rows_affected;
    }
}
