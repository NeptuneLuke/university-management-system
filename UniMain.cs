using BetterConsoleTables;
using MySql.Data.MySqlClient;

namespace UniversityManagementSystem;

public class UniMain {


    public static void Main(string[] args) {

        /*
        string server = "127.0.0.1";
        string database = "university";
        string username = "root";
        string password = "mysqlpass";

        if (string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(database)
            || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) {

            log_error_message(new[] { "Server or Database details are incorrect!", 
                                      "Closing application... "});
            return;
        }

        string str_connection = $"server={server};" +
                                $"uid={username};" +
                                $"pwd={password};" +
                                $"database={database};";
        */

        string str_connection = connection_menu();
        if (str_connection == "INVALID DETAILS") {
            return;
        }

        log_message("Connecting to the server... \n");

        try {
            MySqlConnection try_connection = new MySqlConnection(str_connection);
            try_connection.Open();
            if (try_connection.State == System.Data.ConnectionState.Open) {
                log_message("Connection succesful! \n");
            }
            try_connection.Close();
        }
        catch (MySqlException ex) {
            log_sql_exception(ex);
        }

        main_menu(str_connection);

        log_message(new string [] { "Closing connection to the server... ",
                            "Connection closed!  ", 
                            "Closing application... "});
    }


    static string connection_menu() {

        string server;
        string database;
        string username, password;
        
        Console.WriteLine("Insert the server's IP: ");
        server = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Insert the database name: ");
        database = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Insert the username: ");
        username = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Insert the password: ");
        password = Console.ReadLine();
        Console.WriteLine();

        Table table = new Table();
        table.Config = TableConfiguration.Unicode();

        table.AddColumn("Database connection");
        table.AddRow("Server: " + server);
        table.AddRow("Database: " + database);
        table.AddRow("Username: " + username);
        table.AddRow("Password: " + password);
        Console.WriteLine(table.ToString());

        if (string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(database)
            || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) {

            log_error_message(new[] { "Server or Database details are incorrect!",
                                      "Closing application... "});
            return "INVALID DETAILS";
        }

        return $"server={server};" +
               $"uid={username};" +
               $"pwd={password};" +
               $"database={database};";
    }

    static void main_menu(string str_connection) {

        int choice = 0;

        do {

            Console.WriteLine("Insert a number to select an operation: ");
            Console.WriteLine("1. Show students operations ");
            Console.WriteLine("2. Show professors operations ");
            Console.WriteLine("3. Show courses operations ");
            Console.WriteLine("4. Modify students table ");
            Console.WriteLine("5. Modify professors table ");
            Console.WriteLine("6. Modify courses table ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("7. Clear screen ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("8. Exit application ");
            Console.ResetColor();
            Console.WriteLine();

            choice = check_input_int();
            Console.WriteLine();

            switch (choice) {

                case 1:
                    SelectQueryResult.menu_show_student(str_connection);
                    Console.WriteLine();
                    break;
                case 2:
                    SelectQueryResult.menu_show_professor(str_connection);
                    Console.WriteLine();
                    break;
                case 3:
                    SelectQueryResult.menu_show_course(str_connection);
                    Console.WriteLine();
                    break;
                case 4:
                    InsertQueryResult.menu_modify_student(str_connection);
                    Console.WriteLine();
                    break;
                case 5:
                    InsertQueryResult.menu_modify_professor(str_connection);
                    Console.WriteLine();
                    break;
                case 6:
                    InsertQueryResult.menu_modify_course(str_connection);
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
