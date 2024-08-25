using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityManagementSystem {

    public partial class ProfessorForm : Form {

        private string str_connection { get; set; }
        private DataTable table_professor, table_course_professor;
        private bool already_inserted { get; set; }

        public ProfessorForm(string connection) {
            this.str_connection = connection;
            InitializeComponent();
            table_professor = new DataTable();
            table_course_professor = new DataTable();
            InitProfessorTable();         // get the professor table (SELECT * FROM professor)
            InitCourseProfessorTable();   // get the course-professor table (SELECT * FROM course_professor)
            init_id_counter(Util.get_current_max_id(Util.Tables.Professor));
            init_label_cp_result();
        }

        /* ------------------------------------------ */

        private void InitProfessorTable() {

            // Get the entire student table
            table_professor.Clear();
            string query = "SELECT professor_id AS 'Professor ID', first_name AS 'Name', last_name AS 'Surname', " +
                           "email AS 'Email' " +
                           "FROM professor;";
            table_professor = Util.execute_select(query);

            if (table_professor.Rows.Count == 0) {
                MessageBox.Show("No professors found!", "Query warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Fills the DataGridView with the DataTable
            data_gridview_professor.Columns.Clear();
            data_gridview_professor.Columns.AddRange(
                new DataGridViewColumn[] { professor_id, first_name, last_name, email });
            for (int i = 0; i < table_professor.Columns.Count; ++i) {
                data_gridview_professor.Columns[i].DataPropertyName = table_professor.Columns[i].ColumnName;
            }
            data_gridview_professor.DataSource = table_professor;
            data_gridview_professor.Refresh();
        }

        private void InitCourseProfessorTable() {

            // Get the entire course_student table
            table_course_professor.Clear();
            table_course_professor.Columns.Clear();
            string query = "SELECT course_id AS 'Course ID', professor_id AS 'Professor ID' " +
                           "FROM course_professor;";
            table_course_professor = Util.execute_select(query);

            if (table_course_professor.Rows.Count == 0) {
                MessageBox.Show("No courses by professors found!", "Query warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Fills the DataGridView with the DataTable
            data_gridview_course_professor.Columns.Clear();
            data_gridview_course_professor.Columns.AddRange(
                new DataGridViewColumn[] { cp_course_id, cp_professor_id });
            for (int i = 0; i < table_course_professor.Columns.Count; ++i) {
                data_gridview_course_professor.Columns[i].DataPropertyName = table_course_professor.Columns[i].ColumnName;
            }
            data_gridview_course_professor.DataSource = table_course_professor;
            data_gridview_course_professor.Refresh();
        }

        private void button_exit_Click(object sender, EventArgs e) {
            MenuForm menu_form = new MenuForm(str_connection);
            menu_form.Show();
            this.Hide();
        }

        /* ------------------------------------------ */

        private void button_insert_professor_Click(object sender, EventArgs e) {

            // Get the input
            bool auto_id = true;    // if ID is not specified, auto increment it
            int id = 0;
            try {
                id = (Convert.ToInt32(textbox_id.Text));
            }
            catch (Exception ex) {
                auto_id = true;
            }
            string name = textbox_first_name.Text;
            string surname = textbox_last_name.Text;
            string email = textbox_email.Text;

            // Check if input is valid
            if (id <= 0) {
                MessageBox.Show("IDs must start from 1", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else {
                auto_id = false;
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(email)) {
                MessageBox.Show("You can't insert empty values.", "Input error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Build the query if the ID is specified or not
            string query = @"INSERT INTO professor (professor_id, first_name, last_name, email) " +
                            "VALUES (@id,@name,@surname,@email);";

            if (auto_id == false) {
                query = @"INSERT INTO student (first_name, last_name, email) " +
                            "VALUES (@name,@surname,@email);";
            }

            // Set up the command
            int rows_affected = 0;
            try {
                using (MySqlConnection connection = new MySqlConnection(str_connection)) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection)) {
                        if (auto_id == true) {
                            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                        }
                        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                        command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
                        command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
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
                MessageBox.Show("Professor not added!", "Query warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            already_inserted = true;
            MessageBox.Show("Professor added!", "Query succesful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void init_id_counter(int max_id) {
            label_current_max_id.Text = "Next ID: " + max_id;
        }
        
        /* ------------------------------------------ */

        private void init_label_cp_result() {
            label_cp_table_result.Text = "";
        }

    }
}
