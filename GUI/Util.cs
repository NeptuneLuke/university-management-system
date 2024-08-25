using MySql.Data.MySqlClient;
using System.Data;

namespace UniversityManagementSystem {

    internal static class Util {

        internal static string str_connection { get; set; }
        internal enum Tables{Student, Course, Professor}

        internal static int get_current_max_id(Tables table) {

            int max_id = 0;
            string query = "";

            switch (table) {

                case Tables.Student:
                    query = "SELECT MAX(student_id) " +
                            "FROM student;";
                    DataTable table_result = new DataTable();
                    table_result = execute_select(query);
                    max_id = (int) table_result.Rows[0][0];
                    max_id++;
                    break;

                case Tables.Course:
                    query = "SELECT MAX(course_id) " +
                            "FROM course;";
                    table_result = execute_select(query);
                    max_id = (int) table_result.Rows[0][0];
                    max_id++;
                    break;

                case Tables.Professor:
                    query = "SELECT MAX(professor_id) " +
                            "FROM professor;";
                    table_result = execute_select(query);
                    max_id = (int)table_result.Rows[0][0];
                    max_id++;
                    break;
            }

            return max_id;
        }

        // SQL SELECT query
        internal static DataTable execute_select(string query) {

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
                MessageBox.Show(ex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table_result;
        }

        // SQL SELECT query with Int parameter
        internal static DataTable execute_select(string query, int parameter, string name_parameter) {

            DataTable table_result = new DataTable();
            try {
                using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection)) {

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command)) {
                            command.Parameters.Add($"@{name_parameter}", MySqlDbType.Int32).Value = parameter;
                            adapter.Fill(table_result);
                        }
                    }
                    connection.Close();
                }
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table_result;
        }

        // SQL queries for INSERT and DELETE
        internal static int execute_query(string query, int parameter, string name_parameter) {

            int rows_affected = 0;
            try {
                using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection)) {
                        command.Parameters.Add($"@{name_parameter}", MySqlDbType.Int32).Value = parameter;
                        rows_affected = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message, "Query error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return rows_affected;
        }

        // Other SQL commands like ALTER
        internal static void execute_command(string query, int parameter, string name_parameter) {

            try {
                using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection)) {

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command)) {
                            command.Parameters.Add($"@{name_parameter}", MySqlDbType.Int32).Value = parameter;
                            command.ExecuteNonQuery();
                        }
                    }
                    connection.Close();
                }
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
