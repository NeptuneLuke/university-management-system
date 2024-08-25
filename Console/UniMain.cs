using BetterConsoleTables;
using MySql.Data.MySqlClient;

namespace UniversityManagementSystem;

public class UniMain {

    private static void Main(string[] args) {

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

        Util.log_message("Connecting to the server... \n");

        try {
            MySqlConnection try_connection = new MySqlConnection(str_connection);
            try_connection.Open();
            if (try_connection.State == System.Data.ConnectionState.Open) {
                Util.log_message("Connection succesful! \n");
            }
            try_connection.Close();
        }
        catch (MySqlException ex) {
            Util.log_sql_exception(ex);
            return;
        }

        main_menu(str_connection);

        Util.log_message(new string [] { "Closing connection to the server... ",
                            "Connection closed!  ", 
                            "Closing application... "});
    }

    private static string connection_menu() {

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

            Util.log_error_message(new[] { "Server or Database details are incorrect!",
                                      "Closing application... "});
            return "INVALID DETAILS";
        }

        return $"server={server};" +
               $"uid={username};" +
               $"pwd={password};" +
               $"database={database};";
    }

    private static void main_menu(string str_connection) {

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

            choice = Util.check_input_int();
            Console.WriteLine();

            switch (choice) {

                case 1:
                    Student.menu_show_student(str_connection);
                    Console.WriteLine();
                    break;
                case 2:
                    Professor.menu_show_professor(str_connection);
                    Console.WriteLine();
                    break;
                case 3:
                    Course.menu_show_course(str_connection);
                    Console.WriteLine();
                    break;
                case 4:
                    Student.menu_modify_student(str_connection);
                    Console.WriteLine();
                    break;
                case 5:
                    Professor.menu_modify_professor(str_connection);
                    Console.WriteLine();
                    break;
                case 6:
                    Course.menu_modify_course(str_connection);
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
}
