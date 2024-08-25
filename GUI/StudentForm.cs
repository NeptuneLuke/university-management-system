using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Data;
using System.Diagnostics.Metrics;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;

namespace UniversityManagementSystem {

    public partial class StudentForm : Form {

        private string str_connection { get; set; }
        private DataTable table_student, table_course_student;
        private bool already_inserted { get; set; }

        public StudentForm(string connection) {
            this.str_connection = connection;
            InitializeComponent();
            table_student = new DataTable();
            table_course_student = new DataTable();
            InitStudentTable();         // get the student table (SELECT * FROM student)
            InitCourseStudentTable();   // get the course-student table (SELECT * FROM course_student)
            init_id_counter(Util.get_current_max_id(Util.Tables.Student));
            init_label_cs_result();
        }

        /* ------------------------------------------ */

        private void InitStudentTable() {

            // Get the entire student table
            table_student.Clear();
            table_student.Columns.Clear();
            string query = "SELECT student_id AS 'Student ID', first_name AS 'Name', last_name AS 'Surname', " +
                           "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                           "FROM student;";
            table_student = Util.execute_select(query);

            if (table_student.Rows.Count == 0) {
                MessageBox.Show("No students found!", "Query warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Fills the DataGridView with the DataTable
            data_gridview_student.AutoGenerateColumns = false;
            data_gridview_student.Columns.Clear();
            data_gridview_student.Columns.AddRange(
                new DataGridViewColumn[] { student_id, first_name, last_name, email, academic_year, birth_date });
            for (int i = 0; i < table_student.Columns.Count; ++i) {
                data_gridview_student.Columns[i].DataPropertyName = table_student.Columns[i].ColumnName;
            }
            data_gridview_student.DataSource = table_student;
            data_gridview_student.Refresh();
        }

        private void InitCourseStudentTable() {

            // Get the entire course_student table
            table_course_student.Clear();
            table_course_student.Columns.Clear();
            string query = "SELECT course_id AS 'Course ID', student_id AS 'Student ID' " +
                           "FROM course_student;";
            table_course_student = Util.execute_select(query);

            if (table_course_student.Rows.Count == 0) {
                MessageBox.Show("No courses by students found!", "Query warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Fills the DataGridView with the DataTable
            data_gridview_course_student.Columns.Clear();
            data_gridview_course_student.Columns.AddRange(
                new DataGridViewColumn[] { cs_course_id, cs_student_id });
            for (int i = 0; i < table_course_student.Columns.Count; ++i) {
                data_gridview_course_student.Columns[i].DataPropertyName = table_course_student.Columns[i].ColumnName;
            }
            data_gridview_course_student.DataSource = table_course_student;
            data_gridview_course_student.Refresh();
        }

        private void button_exit_Click(object sender, EventArgs e) {

            MenuForm menu_form = new MenuForm(str_connection);
            menu_form.Show();
            this.Hide();
        }

        /* ------------------------------------------ */
        
        private void button_search_student_Click(object sender, EventArgs e) {

            // Show or not the entire student table
            int refresh_student_table = 0;
            for (int i = 0; i < listview_filters.Items.Count; ++i) {
                if (listview_filters.Items[i].Checked == false) {
                    refresh_student_table++;
                }
            }
            if (refresh_student_table == listview_filters.Items.Count) {
                button_refresh_student_table.PerformClick();
                return;
            }

            // Get all the values from the input
            int id = 0;
            try {
                id = (Convert.ToInt32(textbox_id.Text));
            }
            catch (Exception ex) {
                if (listview_filters.Items[0].Checked) {
                    MessageBox.Show("Invalid ID value!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            string name = textbox_first_name.Text;
            string surname = textbox_last_name.Text;
            string email = textbox_email.Text;
            int academic_year = ((int)numeric_scroll_academic_year.Value);
            int birth_year = ((int)numeric_scroll_year.Value);
            int birth_month = ((int)numeric_scroll_month.Value);
            int birth_day = ((int)numeric_scroll_day.Value);

            // Check the input
            if (string.IsNullOrWhiteSpace(name) && listview_filters.Items[1].Checked) {
                MessageBox.Show("Invalid first name!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(surname) && listview_filters.Items[2].Checked) {
                MessageBox.Show("Invalid last name!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(email) && listview_filters.Items[3].Checked) {
                MessageBox.Show("Invalid email!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Set the basic query
            string query = @"SELECT student_id AS 'StudentID', first_name AS 'Name', last_name AS 'Surname', " +
                           "email AS 'Email', academic_year AS 'Academic year', birth_date AS 'Birth date' " +
                           "FROM student ";

            MySqlConnection connection = new MySqlConnection(str_connection);

            // Add the parameters of the parameterized query to a list
            List<MySqlParameter> parameter_list = new List<MySqlParameter>();
            int count_filters = 0;
            string query_parameters = "";   // stores only the parameters

            // Build the parameterized query
            if (listview_filters.Items[0].Checked) {
                query_parameters += @"student_id = @id AND ";
                parameter_list.Add(new MySqlParameter("@id", id));
                count_filters++;
            }
            if (listview_filters.Items[1].Checked) {
                query_parameters += @"first_name = @name AND ";
                parameter_list.Add(new MySqlParameter("@name", name));
                count_filters++;
            }
            if (listview_filters.Items[2].Checked) {
                query_parameters += @"last_name = @surname AND ";
                parameter_list.Add(new MySqlParameter("@surname", surname));
                count_filters++;
            }
            if (listview_filters.Items[3].Checked) {
                query_parameters += @"email = @email AND ";
                parameter_list.Add(new MySqlParameter("@email", email));
                count_filters++;
            }
            if (listview_filters.Items[4].Checked) {
                query_parameters += @"academic_year = @academic_year AND ";
                parameter_list.Add(new MySqlParameter("@academic_year", academic_year));
                count_filters++;
            }
            if (listview_filters.Items[5].Checked) {
                query_parameters += @"birth_date LIKE CONCAT('', @birth_year, '%') AND ";
                parameter_list.Add(new MySqlParameter("@birth_year", birth_year));
                count_filters++;
            }
            if (listview_filters.Items[6].Checked) {
                string birth_month_str = "";
                if (birth_month <= 9) {
                    birth_month_str = birth_month.ToString("00");
                    query_parameters += @"birth_date LIKE CONCAT('____-', @birth_month_str, '-%') AND ";
                    parameter_list.Add(new MySqlParameter("@birth_month_str", birth_month_str));
                }
                else {
                    query_parameters += @"birth_date LIKE CONCAT('____-', @birth_month, '-%') AND ";
                    parameter_list.Add(new MySqlParameter("@birth_month", birth_month));
                }
                count_filters++;
            }
            if (listview_filters.Items[7].Checked) {
                string birth_day_str = "";
                if (birth_day <= 9) {
                    birth_day_str = birth_month.ToString("00");
                    query_parameters += @"birth_date LIKE CONCAT('%', @birth_day_str, '') AND ";
                    parameter_list.Add(new MySqlParameter("@birth_day_str", birth_day_str));
                }
                else {
                    query_parameters += @"birth_date LIKE CONCAT('%', @birth_day, '') AND ";
                    parameter_list.Add(new MySqlParameter("@birth_day", birth_day));
                }
                count_filters++;
            }

            // If not filters are checked break
            if (count_filters == 0) {
                return;
            }

            // Else build the query
            query_parameters = query_parameters.TrimEnd('A', 'N', 'D', ' ');
            query += "WHERE " + query_parameters + ";";

            // Clear the table and set up the query command
            table_student.Clear();
            MySqlParameter[] parameter_array = parameter_list.ToArray();    //  paramater_list must be an array
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddRange(parameter_array);                   //  parameters are passed to the command
            try {
                connection.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command)) {
                    adapter.Fill(table_student);
                }
                connection.Close();
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message, "Query error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // No results from the query
            if (table_student.Rows.Count == 0) {
                MessageBox.Show("No students found!", "Query warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Fills the DataGridView with the results
            for (int i = 0; i < table_student.Columns.Count; ++i) {
                data_gridview_student.Columns[i].DataPropertyName = table_student.Columns[i].ColumnName;
            }
            data_gridview_student.DataSource = table_student;
            data_gridview_student.Refresh();
        }

        private void button_insert_student_Click(object sender, EventArgs e) {

            // Get the input
            bool auto_id = true;    // if ID is not specified, auto increment it
            int id = 0;
            try {
                id = (Convert.ToInt32(textbox_id.Text));
                label_id.Text = "inserito";
                auto_id = false;
            }
            catch (Exception ex) {
                label_id.Text = "automatico";
                auto_id = true;
            }
            string name = textbox_first_name.Text;
            string surname = textbox_last_name.Text;
            string email = textbox_email.Text;
            int academic_year = ((int)numeric_scroll_academic_year.Value);
            int birth_year = ((int)numeric_scroll_year.Value);
            int birth_month = ((int)numeric_scroll_month.Value);
            int birth_day = ((int)numeric_scroll_day.Value);
            MySqlDateTime birth_date = new MySqlDateTime(
                new DateTime(birth_year, birth_month, birth_day));

            // Check if input is valid
            if (id <= 0 && auto_id == false) {
                MessageBox.Show("IDs must start from 1", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(email)) {
                MessageBox.Show("You can't insert empty values.", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Build the query if the ID is specified or not
            string query = @"INSERT INTO student (student_id, first_name, last_name, email, academic_year, birth_date) " +
                            "VALUES (@id,@name,@surname,@email,@academic_year,@birth_date);";

            if (auto_id == true) {
                query = @"INSERT INTO student (first_name, last_name, email, academic_year, birth_date) " +
                            "VALUES (@name,@surname,@email,@academic_year,@birth_date);";
            }

            // Set up the command
            int rows_affected = 0;
            try {
                using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection)) {
                        if (auto_id == false) {
                            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                        }
                        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                        command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
                        command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                        command.Parameters.Add("@academic_year", MySqlDbType.Int32).Value = academic_year;
                        command.Parameters.Add("@birth_date", MySqlDbType.Date).Value = birth_date;
                        rows_affected = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message, "Query error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Show result
            if (rows_affected == 0) {
                MessageBox.Show("Student not added!", "Query warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Student added!", "Query succesful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            already_inserted = true;
        }

        private void button_update_student_Click(object sender, EventArgs e) {

            // Get the input
            int id = 0;
            try {
                id = (Convert.ToInt32(textbox_id.Text));
            }
            catch (Exception ex) {
                MessageBox.Show("Invalid ID value!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            string name = textbox_first_name.Text;
            string surname = textbox_last_name.Text;
            string email = textbox_email.Text;
            int academic_year = ((int)numeric_scroll_academic_year.Value);
            int birth_year = ((int)numeric_scroll_year.Value);
            int birth_month = ((int)numeric_scroll_month.Value);
            int birth_day = ((int)numeric_scroll_day.Value);
            MySqlDateTime birth_date = new MySqlDateTime(
               new DateTime(birth_year, birth_month, birth_day));

            // Check if input is valid
            if (id <= 0) {
                MessageBox.Show("IDs must start from 1", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (id > Util.get_current_max_id(Util.Tables.Student)) {
                MessageBox.Show("Invalid ID", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Build the parameterized query
            int counter_fields = 0;
            string query = @"UPDATE student ";
            string query_parameters = "";
            if (!string.IsNullOrWhiteSpace(name)) {
                query_parameters += @"first_name = @name, ";
                counter_fields++;
            }
            if (!string.IsNullOrWhiteSpace(surname)) {
                query_parameters += @"last_name = @surname, ";
                counter_fields++;
            }
            if (!string.IsNullOrWhiteSpace(email)) {
                query_parameters += @"email = @email, ";
                counter_fields++;
            }
            query_parameters += @"academic_year = @academic_year, ";
            query_parameters += @"birth_date = @birth_date ";


            // If no filters are checked, break
            if (counter_fields == 0) {
                return;
            }

            // Build the query
            query += "SET " + query_parameters + @"WHERE student_id = @id;";

            // Set up the command
            int rows_affected = 0;
            try {
                using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection)) {
                        command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                        command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
                        command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                        command.Parameters.Add("@academic_year", MySqlDbType.Int32).Value = academic_year;
                        command.Parameters.Add("@birth_date", MySqlDbType.Date).Value = birth_date;
                        rows_affected = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message, "Query error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Show result
            if (rows_affected == 0) {
                MessageBox.Show("Student not updated!", "Query warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Student updated!", "Query succesful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_delete_student_Click(object sender, EventArgs e) {

            // Get the input
            int id = 0;
            try {
                id = (Convert.ToInt32(textbox_id.Text));
            }
            catch (Exception ex) {
                MessageBox.Show("Invalid ID value!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if input is valid
            if (id <= 0) {
                MessageBox.Show("IDs must start from 1", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int max_id = Util.get_current_max_id(Util.Tables.Student);
            if (id > max_id - 1) {
                MessageBox.Show("ID " + id + " does not exist!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Build the query
            string query = @"DELETE FROM student " +
                            "WHERE student_id = @id;";

            // Get the values
            int rows_affected = Util.execute_query(query, id, nameof(id));

            // Show result 
            if (rows_affected == 0) {
                MessageBox.Show("Student not deleted!", "Query warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Student deleted!", "Query succesful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void button_reset_student_Click(object sender, EventArgs e) {

            textbox_id.Text = "";
            textbox_first_name.Text = "";
            textbox_last_name.Text = "";
            textbox_email.Text = "";
            numeric_scroll_academic_year.Value = 1;
            numeric_scroll_year.Value = 2000;
            numeric_scroll_month.Value = 1;
            numeric_scroll_day.Value = 1;
        }

        private void button_refresh_student_table_Click(object sender, EventArgs e) {
            InitStudentTable();
            int max_id = Util.get_current_max_id(Util.Tables.Student);
            label_current_max_id.Text = "Next ID: " + max_id;
        }

        private void button_reset_id_counter_Click(object sender, EventArgs e) {

            // If no student is already inserted, break
            if (!already_inserted) {
                return;
            }

            int max_id = Util.get_current_max_id(Util.Tables.Student);
            string query = @"ALTER TABLE student AUTO_INCREMENT = @max_id";
            Util.execute_command(query, max_id, nameof(max_id));

            MessageBox.Show("Command executed!", "Query succesful!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            label_current_max_id.Text = "Next ID: " + max_id;
        }

        private void init_id_counter(int max_id) {
            label_current_max_id.Text = "Next ID: " + max_id;
        }
        
        /* ------------------------------------------ */

        private void button_insert_course_student_Click(object sender, EventArgs e) {

            // Get the input
            int course_id = 0;
            try {
                course_id = (Convert.ToInt32(textbox_cs_course_id.Text));
            }
            catch (Exception ex) {
                MessageBox.Show("Invalid ID value!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int student_id = 0;
            try {
                student_id = (Convert.ToInt32(textbox_cs_student_id.Text));
            }
            catch (Exception ex) {
                MessageBox.Show("Invalid ID value!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if input is valid
            int max_course_id = Util.get_current_max_id(Util.Tables.Course);
            int max_student_id = Util.get_current_max_id(Util.Tables.Student);
            if (course_id <= 0 || student_id <= 0) {
                MessageBox.Show("IDs must start from 1", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (course_id > max_course_id - 1) {
                MessageBox.Show("Course ID " + course_id + " does not exist!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (student_id > max_student_id - 1) {
                MessageBox.Show("Course ID " + student_id + " does not exist!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Build the query
            string query = @"INSERT INTO course_student (course_id, student_id) " +
                            "VALUES (@course_id, @student_id);";

            // Set up the command
            int rows_affected = 0;
            try {
                using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection)) {
                        command.Parameters.Add("@course_id", MySqlDbType.Int32).Value = course_id;
                        command.Parameters.Add("@student_id", MySqlDbType.Int32).Value = student_id;
                        rows_affected = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message, "Query error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Show result
            if (rows_affected == 0) {
                MessageBox.Show("Record not added!", "Query warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Record added!", "Query succesful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_delete_course_student_Click(object sender, EventArgs e) {

            // Get the input
            int course_id = 0;
            try {
                course_id = (Convert.ToInt32(textbox_cs_course_id.Text));
            }
            catch (Exception ex) {
                MessageBox.Show("Invalid ID value!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int student_id = 0;
            try {
                student_id = (Convert.ToInt32(textbox_cs_student_id.Text));
            }
            catch (Exception ex) {
                MessageBox.Show("Invalid ID value!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if input is valid
            int max_course_id = Util.get_current_max_id(Util.Tables.Course);
            int max_student_id = Util.get_current_max_id(Util.Tables.Student);
            if (course_id <= 0 || student_id <= 0) {
                MessageBox.Show("IDs must start from 1", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (course_id > max_course_id - 1) {
                MessageBox.Show("Course ID " + course_id + " does not exist!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (student_id > max_student_id - 1) {
                MessageBox.Show("Course ID " + student_id + " does not exist!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Build the query
            string query = @"DELETE FROM course_student " +
                            "WHERE course_id = @course_id AND student_id = @student_id;";

            // Set up the command
            int rows_affected = 0;
            try {
                using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection)) {
                        command.Parameters.Add("@course_id", MySqlDbType.Int32).Value = course_id;
                        command.Parameters.Add("@student_id", MySqlDbType.Int32).Value = student_id;
                        rows_affected = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message, "Query error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Show result
            if (rows_affected == 0) {
                MessageBox.Show("Record not deleted!", "Query warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Record deleted!", "Query succesful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_search_course_student_Click(object sender, EventArgs e) {

            // Get the search type
            // Check if input is valid
            // Build the query
            int student_id = 0;
            int course_id = 0;
            int academic_year = 1;
            string query = "";

            if (radiobutton_search_1.Checked) {
                int max_id = Util.get_current_max_id(Util.Tables.Student);
                try {
                    student_id = (Convert.ToInt32(textbox_cs_student_id.Text));
                }
                catch (Exception ex) {
                    MessageBox.Show("Invalid ID value!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (student_id <= 0) {
                    MessageBox.Show("IDs must start from 1", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (student_id > max_id - 1) {
                    MessageBox.Show("Invalid ID", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Build the query if the ID is specified or not
                query = @"SELECT course.course_id AS 'Course ID', course.title AS 'Title', course.academic_year AS 'Academic year' " +
                         "FROM course " +
                         "JOIN course_student ON course.course_id = course_student.course_id " +
                         "JOIN student ON student.student_id = course_student.student_id " +
                         "WHERE course_student.student_id = @student_id;";

                // Set up the command
                table_course_student.Clear();
                table_course_student.Columns.Clear();
                table_course_student = Util.execute_select(query, student_id, nameof(student_id));

                // Show result
                if (table_course_student.Rows.Count == 0) {
                    MessageBox.Show("No courses by student: " + student_id + " found!", "Query warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                label_cs_table_result.Text = "Courses by student: " + student_id;

                // Fills the DataGridView with the DataTable
                data_gridview_course_student.Columns.Clear();
                data_gridview_course_student.Columns.AddRange(
                    new DataGridViewColumn[] { cs_course_id, cs_course_title, cs_course_academic_year });
                for (int i = 0; i < table_course_student.Columns.Count; ++i) {
                    data_gridview_course_student.Columns[i].DataPropertyName = table_course_student.Columns[i].ColumnName;
                }
                data_gridview_course_student.DataSource = table_course_student;
                data_gridview_course_student.Refresh();

                return;
            }
            else if (radiobutton_search_2.Checked) {
                int max_id = Util.get_current_max_id(Util.Tables.Course);
                try {
                    course_id = (Convert.ToInt32(textbox_cs_course_id.Text));
                }
                catch (Exception ex) {
                    MessageBox.Show("Invalid ID value!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (course_id <= 0) {
                    MessageBox.Show("IDs must start from 1", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (course_id > max_id - 1) {
                    MessageBox.Show("Invalid ID", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Build the query if the ID is specified or not
                query = @"SELECT student.student_id AS 'Student ID', student.first_name AS 'Name', " +
                         "student.last_name AS 'Surname', student.email AS 'Email' " +
                         "FROM student " +
                         "JOIN course_student ON student.student_id = course_student.student_id " +
                         "JOIN course ON course.course_id = course_student.course_id " +
                         "WHERE course_student.course_id = @course_id;";

                // Set up the command
                table_course_student.Clear();
                table_course_student.Columns.Clear();
                table_course_student = Util.execute_select(query, course_id, nameof(course_id));

                // Show result
                if (table_course_student.Rows.Count == 0) {
                    MessageBox.Show("No students by course: " + course_id + " found!", "Query warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                label_cs_table_result.Text = "Students by course: " + course_id;

                // Fills the DataGridView with the DataTable
                data_gridview_course_student.Columns.Clear();
                data_gridview_course_student.Columns.AddRange(
                    new DataGridViewColumn[] { cs_student_id, cs_first_name, cs_last_name, cs_email });
                for (int i = 0; i < table_course_student.Columns.Count; ++i) {
                    data_gridview_course_student.Columns[i].DataPropertyName = table_course_student.Columns[i].ColumnName;
                }
                data_gridview_course_student.DataSource = table_course_student;
                data_gridview_course_student.Refresh();

                return;
            }
            else if (radiobutton_search_3.Checked) {
                int max_student_id = Util.get_current_max_id(Util.Tables.Student);

                try {
                    student_id = (Convert.ToInt32(textbox_cs_student_id.Text));
                }
                catch (Exception ex) {
                    MessageBox.Show("Invalid ID value!", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (student_id <= 0) {
                    MessageBox.Show("IDs must start from 1", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (student_id > max_student_id - 1) {
                    MessageBox.Show("Invalid ID", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                academic_year = (int)numeric_scroll_cs_academic_year.Value;

                // Build the query if the ID is specified or not
                query = @"SELECT course.course_id AS 'Course ID', course.title AS 'Title', course.academic_year AS 'Academic year' " +
                         "FROM course " +
                         "JOIN course_student ON course.course_id = course_student.course_id " +
                         "JOIN student ON student.student_id = course_student.student_id " +
                         "WHERE course_student.student_id = @student_id AND " +
                         "course.academic_year = @academic_year;";

                // Set up the command
                table_course_student.Clear();
                table_course_student.Columns.Clear();
                try {
                    using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(query, connection)) {

                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command)) {
                                command.Parameters.Add($"@student_id", MySqlDbType.Int32).Value = student_id;
                                command.Parameters.Add($"@academic_year", MySqlDbType.Int32).Value = academic_year;
                                adapter.Fill(table_course_student);
                            }
                        }
                        connection.Close();
                    }
                }
                catch (MySqlException ex) {
                    MessageBox.Show(ex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Show result
                if (table_course_student.Rows.Count == 0) {
                    MessageBox.Show("No courses by student: " + student_id + " and year:" + academic_year + " found!", "Query warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                label_cs_table_result.Text = "Courses by student: " + student_id + 
                    " , year: " + academic_year;

                // Fills the DataGridView with the DataTable
                data_gridview_course_student.Columns.Clear();
                data_gridview_course_student.Columns.AddRange(
                    new DataGridViewColumn[] { cs_course_id, cs_course_title, cs_course_academic_year });
                for (int i = 0; i < table_course_student.Columns.Count; ++i) {
                    data_gridview_course_student.Columns[i].DataPropertyName = table_course_student.Columns[i].ColumnName;
                }
                data_gridview_course_student.DataSource = table_course_student;
                data_gridview_course_student.Refresh();

                return;
            }
            else if (radio_button_search_default.Checked) {
                InitCourseStudentTable();
                label_cs_table_result.Text = "";
            }

        }

        private void init_label_cs_result() {
            label_cs_table_result.Text = "";
        }

    }
}
