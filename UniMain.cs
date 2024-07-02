using MySql.Data.MySqlClient;

namespace UniversityManagementSystem;

public class UniMain {


    public static void Main(string[] args) {

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


    static void main_menu(string str_connection) {

        int choice = 0;

        do {

            Console.WriteLine("Insert a number to select an operation: ");
            Console.WriteLine("1. Show students operations ");
            Console.WriteLine("2. Show professors operations ");
            Console.WriteLine("3. Show courses operations ");
            Console.WriteLine("4. Modify student table ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("5. Clear screen ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("6. Exit application ");
            Console.ResetColor();
            Console.WriteLine();
            
            try {
                choice = (Convert.ToInt32(Console.ReadLine()));
            }
            catch (Exception ex) {
                log_error_message("Input not taken! ");
                log_exception(ex);
            }
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
                    Console.Clear();
                    break;
                case 6:
                    break;
            }

        } while (choice != 6);
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
