using MySql.Data.MySqlClient;

namespace UniversityManagementSystem {

    public partial class EntryForm : Form {

        private string str_connection { get; set; }

        public EntryForm() {
            InitializeComponent();
            label_connection.Text = "";
        }

        private void button_connect_Click(object sender, EventArgs e) {

            label_connection.Text = "";
            label_connection.ForeColor = Color.Black;

            /*
            string server = textbox_server.Text;
            string database = textbox_database.Text;
            string user = textbox_user.Text;
            string password = textbox_password.Text;
            */
            string server = "127.0.0.1";
            string database = "university";
            string user = "root";
            string password = "mysqlpass";


            if (string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(database)
            || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password)) {

                label_connection.ForeColor = Color.Red;
                label_connection.Text += "Server or Database details are incorrect! \n\n";
                MessageBox.Show("Server or Database details are incorrect!", "Connection error!", 
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            str_connection = $"server={server};" +
                                  $"uid={user};" +
                                  $"pwd={password};" +
                                  $"database={database};";

            label_connection.ForeColor = Color.Green;
            label_connection.Text += "Connecting to the server... \n\n";
            try {
                MySqlConnection try_connection = new MySqlConnection(str_connection);
                try_connection.Open();
                if (try_connection.State == System.Data.ConnectionState.Open) {
                    label_connection.Text += "Connection succesful! \n\n";
                }
                try_connection.Close();
            }
            catch (MySqlException ex) {
                label_connection.ForeColor = Color.Red;
                label_connection.Text += "ERROR: " + ex.Code + " - " + ex.Message + "\n\n";
            }

            MenuForm menu_form = new MenuForm(str_connection);
            menu_form.Show();
            Util.str_connection = str_connection;
            this.Hide();
        }
    }
}
