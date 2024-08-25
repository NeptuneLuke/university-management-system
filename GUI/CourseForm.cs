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

    public partial class CourseForm : Form {

        private string str_connection { get; set; }

        public CourseForm(string connection) {
            this.str_connection = connection;
            InitializeComponent();
        }

        private void button_exit_Click(object sender, EventArgs e) {

            MenuForm menu_form = new MenuForm(str_connection);
            menu_form.Show();
            this.Hide();
        }

    }
}
