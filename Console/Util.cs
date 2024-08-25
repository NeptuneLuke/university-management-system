using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Data;

namespace UniversityManagementSystem;

public class Util {

    public static DataTable execute_select(string str_connection, string query) {

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
            Util.log_sql_exception(ex);
        }

        return table_result;
    }

    public static DataTable execute_select(string str_connection, string query, string parameter_name, string parameter) {

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
            Util.log_sql_exception(ex);
        }

        return table_result;
    }

    public static DataTable execute_select(string str_connection, string query, string parameter_name, int parameter) {

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
            Util.log_sql_exception(ex);
        }

        return table_result;
    }

    public static int execute_update(string str_connection, string query,
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
            Util.log_sql_exception(ex);
        }

        return rows_affected;
    }

    public static int execute_update(string str_connection, string query,
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
            Util.log_sql_exception(ex);
        }

        return rows_affected;
    }

    public static int execute_update(string str_connection, string query,
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
            Util.log_sql_exception(ex);
        }

        return rows_affected;
    }


    public static int check_input_int() {
        int input = 0;
        try {
            input = (Convert.ToInt32(Console.ReadLine()));
        }
        catch (Exception ex) {
            log_error_message("Input not taken! ");
            log_exception(ex);
        }
        return input;
    }

    public static string check_input_string() {
        string input = "";
        input = Console.ReadLine();
        input = input.Trim();
        return input;
    }


    public static void log_exception(Exception ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ERROR]: {ex.Message}");
        Console.ResetColor();
        Console.WriteLine();
    }

    public static void log_sql_exception(MySqlException ex) {
        Console.ForegroundColor = ConsoleColor.Red;
        if (ex.Code != 0) {
            Console.WriteLine("Unable to execute the command!");
        }
        Console.WriteLine($"[ERROR]: {ex.Code} - {ex.Message}");
        Console.ResetColor();
        Console.WriteLine();
    }

    public static void log_error_message(string message) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void log_error_message(string[] messages) {
        Console.ForegroundColor = ConsoleColor.Red;
        for (int i = 0; i < messages.Length; ++i) {
            Console.WriteLine(messages[i]);
        }
        Console.ResetColor();
    }

    public static void log_message(string message) {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void log_message(string[] messages) {
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < messages.Length; ++i) {
            Console.WriteLine(messages[i]);
        }
        Console.ResetColor();
    }
}
