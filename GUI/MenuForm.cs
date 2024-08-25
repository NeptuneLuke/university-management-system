

namespace UniversityManagementSystem {

    public partial class MenuForm : Form {

        private string str_connection { get; set; }

        public MenuForm(string connection) {
            this.str_connection = connection;
            InitializeComponent();
        }

        private void button_course_Click(object sender, EventArgs e) {

            CourseForm course_form = new CourseForm(str_connection);
            course_form.Show();
            this.Hide();
        }

        private void button_professor_Click(object sender, EventArgs e) {

            ProfessorForm professor_form = new ProfessorForm(str_connection);
            professor_form.Show();
            this.Hide();
        }

        private void button_student_Click(object sender, EventArgs e) {

            StudentForm student_form = new StudentForm(str_connection);
            student_form.Show();
            this.Hide();
        }

        private void button_exit_Click(object sender, EventArgs e) {

            EntryForm entry_form = new EntryForm();
            entry_form.Show();
            this.Hide();
        }
    }
}
