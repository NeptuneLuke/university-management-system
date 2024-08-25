namespace UniversityManagementSystem {
    partial class CourseForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseForm));
            panel_title = new Panel();
            picturebox_icon = new PictureBox();
            label_title = new Label();
            panel_connect = new Panel();
            button_delete_course_professor = new Button();
            button_insert_course_professor = new Button();
            button_update_course_professor = new Button();
            button_search_course_professor = new Button();
            label_professor_id = new Label();
            label_course_id_2 = new Label();
            textbox_professor_id = new TextBox();
            textbox_course_id_2 = new TextBox();
            label_professor_course_title = new Label();
            data_gridview_course_professor = new DataGridView();
            course_id_2 = new DataGridViewTextBoxColumn();
            professor_id = new DataGridViewTextBoxColumn();
            picturebox_exit = new PictureBox();
            button_exit = new Button();
            button_delete_course_student = new Button();
            button_insert_course_student = new Button();
            button_update_course_student = new Button();
            button_search_course_student = new Button();
            label_student_id = new Label();
            label_course_id_1 = new Label();
            textbox_student_id = new TextBox();
            textbox_course_id_1 = new TextBox();
            label_student_course_title = new Label();
            data_gridview_course_student = new DataGridView();
            course_id_1 = new DataGridViewTextBoxColumn();
            student_id = new DataGridViewTextBoxColumn();
            button_delete_course = new Button();
            button_insert_course = new Button();
            button_update_course = new Button();
            button_search_course = new Button();
            label_course_title = new Label();
            label_academic_year = new Label();
            label_field_title = new Label();
            label_id = new Label();
            textbox_field_title = new TextBox();
            numeric_scroll = new NumericUpDown();
            textbox_id = new TextBox();
            id = new DataGridViewTextBoxColumn();
            title = new DataGridViewTextBoxColumn();
            academic_year = new DataGridViewTextBoxColumn();
            panel_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturebox_icon).BeginInit();
            panel_connect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)data_gridview_course_professor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picturebox_exit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)data_gridview_course_student).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numeric_scroll).BeginInit();
            SuspendLayout();
            // 
            // panel_title
            // 
            panel_title.BackColor = Color.FromArgb(170, 0, 0);
            panel_title.Controls.Add(picturebox_icon);
            panel_title.Controls.Add(label_title);
            panel_title.Dock = DockStyle.Top;
            panel_title.Location = new Point(0, 0);
            panel_title.Name = "panel_title";
            panel_title.Size = new Size(1284, 80);
            panel_title.TabIndex = 2;
            // 
            // picturebox_icon
            // 
            picturebox_icon.Image = Properties.Resources.icons8_university_64_white;
            picturebox_icon.Location = new Point(12, 12);
            picturebox_icon.Name = "picturebox_icon";
            picturebox_icon.Size = new Size(64, 64);
            picturebox_icon.TabIndex = 1;
            picturebox_icon.TabStop = false;
            // 
            // label_title
            // 
            label_title.AutoSize = true;
            label_title.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label_title.ForeColor = Color.White;
            label_title.Location = new Point(90, 12);
            label_title.Name = "label_title";
            label_title.Size = new Size(525, 46);
            label_title.TabIndex = 0;
            label_title.Text = "University Management System";
            // 
            // panel_connect
            // 
            panel_connect.BackColor = Color.DarkRed;
            panel_connect.Controls.Add(button_delete_course_professor);
            panel_connect.Controls.Add(button_insert_course_professor);
            panel_connect.Controls.Add(button_update_course_professor);
            panel_connect.Controls.Add(button_search_course_professor);
            panel_connect.Controls.Add(label_professor_id);
            panel_connect.Controls.Add(label_course_id_2);
            panel_connect.Controls.Add(textbox_professor_id);
            panel_connect.Controls.Add(textbox_course_id_2);
            panel_connect.Controls.Add(label_professor_course_title);
            panel_connect.Controls.Add(data_gridview_course_professor);
            panel_connect.Controls.Add(picturebox_exit);
            panel_connect.Controls.Add(button_exit);
            panel_connect.Controls.Add(button_delete_course_student);
            panel_connect.Controls.Add(button_insert_course_student);
            panel_connect.Controls.Add(button_update_course_student);
            panel_connect.Controls.Add(button_search_course_student);
            panel_connect.Controls.Add(label_student_id);
            panel_connect.Controls.Add(label_course_id_1);
            panel_connect.Controls.Add(textbox_student_id);
            panel_connect.Controls.Add(textbox_course_id_1);
            panel_connect.Controls.Add(label_student_course_title);
            panel_connect.Controls.Add(data_gridview_course_student);
            panel_connect.Controls.Add(button_delete_course);
            panel_connect.Controls.Add(button_insert_course);
            panel_connect.Controls.Add(button_update_course);
            panel_connect.Controls.Add(button_search_course);
            panel_connect.Controls.Add(label_course_title);
            panel_connect.Controls.Add(label_academic_year);
            panel_connect.Controls.Add(label_field_title);
            panel_connect.Controls.Add(label_id);
            panel_connect.Controls.Add(textbox_field_title);
            panel_connect.Controls.Add(numeric_scroll);
            panel_connect.Controls.Add(textbox_id);
            panel_connect.Dock = DockStyle.Fill;
            panel_connect.Location = new Point(0, 80);
            panel_connect.Name = "panel_connect";
            panel_connect.Size = new Size(1284, 536);
            panel_connect.TabIndex = 7;
            // 
            // button_delete_course_professor
            // 
            button_delete_course_professor.BackColor = Color.Red;
            button_delete_course_professor.FlatStyle = FlatStyle.Popup;
            button_delete_course_professor.Location = new Point(705, 500);
            button_delete_course_professor.Name = "button_delete_course_professor";
            button_delete_course_professor.Size = new Size(130, 30);
            button_delete_course_professor.TabIndex = 39;
            button_delete_course_professor.Text = "DELETE PROFESSOR";
            button_delete_course_professor.UseVisualStyleBackColor = false;
            // 
            // button_insert_course_professor
            // 
            button_insert_course_professor.BackColor = Color.Chartreuse;
            button_insert_course_professor.FlatStyle = FlatStyle.Popup;
            button_insert_course_professor.Location = new Point(705, 459);
            button_insert_course_professor.Name = "button_insert_course_professor";
            button_insert_course_professor.Size = new Size(130, 30);
            button_insert_course_professor.TabIndex = 38;
            button_insert_course_professor.Text = "INSERT PROFESSOR";
            button_insert_course_professor.UseVisualStyleBackColor = false;
            // 
            // button_update_course_professor
            // 
            button_update_course_professor.BackColor = Color.Gold;
            button_update_course_professor.FlatStyle = FlatStyle.Popup;
            button_update_course_professor.Location = new Point(877, 500);
            button_update_course_professor.Name = "button_update_course_professor";
            button_update_course_professor.Size = new Size(130, 30);
            button_update_course_professor.TabIndex = 37;
            button_update_course_professor.Text = "UPDATE PROFESSOR";
            button_update_course_professor.UseVisualStyleBackColor = false;
            // 
            // button_search_course_professor
            // 
            button_search_course_professor.BackColor = Color.Turquoise;
            button_search_course_professor.FlatStyle = FlatStyle.Popup;
            button_search_course_professor.Location = new Point(877, 459);
            button_search_course_professor.Name = "button_search_course_professor";
            button_search_course_professor.Size = new Size(130, 30);
            button_search_course_professor.TabIndex = 36;
            button_search_course_professor.Text = "SEARCH PROFESSOR";
            button_search_course_professor.UseVisualStyleBackColor = false;
            // 
            // label_professor_id
            // 
            label_professor_id.AutoSize = true;
            label_professor_id.Font = new Font("Segoe UI", 10F);
            label_professor_id.ForeColor = Color.White;
            label_professor_id.Location = new Point(705, 395);
            label_professor_id.Name = "label_professor_id";
            label_professor_id.Size = new Size(87, 19);
            label_professor_id.TabIndex = 35;
            label_professor_id.Text = "Professor ID:";
            // 
            // label_course_id_2
            // 
            label_course_id_2.AutoSize = true;
            label_course_id_2.Font = new Font("Segoe UI", 10F);
            label_course_id_2.ForeColor = Color.White;
            label_course_id_2.Location = new Point(705, 365);
            label_course_id_2.Name = "label_course_id_2";
            label_course_id_2.Size = new Size(73, 19);
            label_course_id_2.TabIndex = 34;
            label_course_id_2.Text = "Course ID:";
            // 
            // textbox_professor_id
            // 
            textbox_professor_id.Location = new Point(857, 395);
            textbox_professor_id.Name = "textbox_professor_id";
            textbox_professor_id.Size = new Size(150, 23);
            textbox_professor_id.TabIndex = 33;
            // 
            // textbox_course_id_2
            // 
            textbox_course_id_2.Location = new Point(857, 361);
            textbox_course_id_2.Name = "textbox_course_id_2";
            textbox_course_id_2.Size = new Size(150, 23);
            textbox_course_id_2.TabIndex = 32;
            // 
            // label_professor_course_title
            // 
            label_professor_course_title.AutoSize = true;
            label_professor_course_title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_professor_course_title.ForeColor = Color.White;
            label_professor_course_title.Location = new Point(705, 322);
            label_professor_course_title.Name = "label_professor_course_title";
            label_professor_course_title.Size = new Size(213, 21);
            label_professor_course_title.TabIndex = 31;
            label_professor_course_title.Text = "Courses by professors info:";
            // 
            // data_gridview_course_professor
            // 
            data_gridview_course_professor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data_gridview_course_professor.Columns.AddRange(new DataGridViewColumn[] { course_id_2, professor_id });
            data_gridview_course_professor.Location = new Point(1028, 325);
            data_gridview_course_professor.Name = "data_gridview_course_professor";
            data_gridview_course_professor.Size = new Size(243, 210);
            data_gridview_course_professor.TabIndex = 30;
            // 
            // course_id_2
            // 
            course_id_2.HeaderText = "Course ID";
            course_id_2.Name = "course_id_2";
            course_id_2.ReadOnly = true;
            // 
            // professor_id
            // 
            professor_id.HeaderText = "Professor ID";
            professor_id.Name = "professor_id";
            professor_id.ReadOnly = true;
            // 
            // picturebox_exit
            // 
            picturebox_exit.Image = Properties.Resources.icons8_logout_64;
            picturebox_exit.Location = new Point(1028, 20);
            picturebox_exit.Name = "picturebox_exit";
            picturebox_exit.Size = new Size(64, 64);
            picturebox_exit.TabIndex = 29;
            picturebox_exit.TabStop = false;
            // 
            // button_exit
            // 
            button_exit.BackColor = Color.White;
            button_exit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button_exit.Location = new Point(1100, 32);
            button_exit.Name = "button_exit";
            button_exit.Size = new Size(150, 40);
            button_exit.TabIndex = 28;
            button_exit.Text = "RETURN TO MENU";
            button_exit.UseVisualStyleBackColor = false;
            button_exit.Click += button_exit_Click;
            // 
            // button_delete_course_student
            // 
            button_delete_course_student.BackColor = Color.Red;
            button_delete_course_student.FlatStyle = FlatStyle.Popup;
            button_delete_course_student.Location = new Point(25, 500);
            button_delete_course_student.Name = "button_delete_course_student";
            button_delete_course_student.Size = new Size(120, 30);
            button_delete_course_student.TabIndex = 27;
            button_delete_course_student.Text = "DELETE STUDENT";
            button_delete_course_student.UseVisualStyleBackColor = false;
            // 
            // button_insert_course_student
            // 
            button_insert_course_student.BackColor = Color.Chartreuse;
            button_insert_course_student.FlatStyle = FlatStyle.Popup;
            button_insert_course_student.Location = new Point(25, 459);
            button_insert_course_student.Name = "button_insert_course_student";
            button_insert_course_student.Size = new Size(120, 30);
            button_insert_course_student.TabIndex = 26;
            button_insert_course_student.Text = "INSERT STUDENT";
            button_insert_course_student.UseVisualStyleBackColor = false;
            // 
            // button_update_course_student
            // 
            button_update_course_student.BackColor = Color.Gold;
            button_update_course_student.FlatStyle = FlatStyle.Popup;
            button_update_course_student.Location = new Point(207, 500);
            button_update_course_student.Name = "button_update_course_student";
            button_update_course_student.Size = new Size(120, 30);
            button_update_course_student.TabIndex = 25;
            button_update_course_student.Text = "UPDATE STUDENT";
            button_update_course_student.UseVisualStyleBackColor = false;
            // 
            // button_search_course_student
            // 
            button_search_course_student.BackColor = Color.Turquoise;
            button_search_course_student.FlatStyle = FlatStyle.Popup;
            button_search_course_student.Location = new Point(207, 459);
            button_search_course_student.Name = "button_search_course_student";
            button_search_course_student.Size = new Size(120, 30);
            button_search_course_student.TabIndex = 24;
            button_search_course_student.Text = "SEARCH STUDENT";
            button_search_course_student.UseVisualStyleBackColor = false;
            // 
            // label_student_id
            // 
            label_student_id.AutoSize = true;
            label_student_id.Font = new Font("Segoe UI", 10F);
            label_student_id.ForeColor = Color.White;
            label_student_id.Location = new Point(25, 395);
            label_student_id.Name = "label_student_id";
            label_student_id.Size = new Size(78, 19);
            label_student_id.TabIndex = 23;
            label_student_id.Text = "Student ID:";
            // 
            // label_course_id_1
            // 
            label_course_id_1.AutoSize = true;
            label_course_id_1.Font = new Font("Segoe UI", 10F);
            label_course_id_1.ForeColor = Color.White;
            label_course_id_1.Location = new Point(25, 365);
            label_course_id_1.Name = "label_course_id_1";
            label_course_id_1.Size = new Size(73, 19);
            label_course_id_1.TabIndex = 22;
            label_course_id_1.Text = "Course ID:";
            // 
            // textbox_student_id
            // 
            textbox_student_id.Location = new Point(177, 395);
            textbox_student_id.Name = "textbox_student_id";
            textbox_student_id.Size = new Size(150, 23);
            textbox_student_id.TabIndex = 21;
            // 
            // textbox_course_id_1
            // 
            textbox_course_id_1.Location = new Point(177, 361);
            textbox_course_id_1.Name = "textbox_course_id_1";
            textbox_course_id_1.Size = new Size(150, 23);
            textbox_course_id_1.TabIndex = 20;
            // 
            // label_student_course_title
            // 
            label_student_course_title.AutoSize = true;
            label_student_course_title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_student_course_title.ForeColor = Color.White;
            label_student_course_title.Location = new Point(25, 322);
            label_student_course_title.Name = "label_student_course_title";
            label_student_course_title.Size = new Size(200, 21);
            label_student_course_title.TabIndex = 19;
            label_student_course_title.Text = "Courses by students info:";
            // 
            // data_gridview_course_student
            // 
            data_gridview_course_student.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data_gridview_course_student.Columns.AddRange(new DataGridViewColumn[] { course_id_1, student_id });
            data_gridview_course_student.Location = new Point(348, 325);
            data_gridview_course_student.Name = "data_gridview_course_student";
            data_gridview_course_student.Size = new Size(243, 210);
            data_gridview_course_student.TabIndex = 18;
            // 
            // course_id_1
            // 
            course_id_1.HeaderText = "Course ID";
            course_id_1.Name = "course_id_1";
            course_id_1.ReadOnly = true;
            // 
            // student_id
            // 
            student_id.HeaderText = "Student ID";
            student_id.Name = "student_id";
            student_id.ReadOnly = true;
            // 
            // button_delete_course
            // 
            button_delete_course.BackColor = Color.Red;
            button_delete_course.FlatStyle = FlatStyle.Popup;
            button_delete_course.Location = new Point(25, 229);
            button_delete_course.Name = "button_delete_course";
            button_delete_course.Size = new Size(120, 30);
            button_delete_course.TabIndex = 17;
            button_delete_course.Text = "DELETE COURSE";
            button_delete_course.UseVisualStyleBackColor = false;
            // 
            // button_insert_course
            // 
            button_insert_course.BackColor = Color.Chartreuse;
            button_insert_course.FlatStyle = FlatStyle.Popup;
            button_insert_course.Location = new Point(25, 180);
            button_insert_course.Name = "button_insert_course";
            button_insert_course.Size = new Size(120, 30);
            button_insert_course.TabIndex = 16;
            button_insert_course.Text = "INSERT COURSE";
            button_insert_course.UseVisualStyleBackColor = false;
            // 
            // button_update_course
            // 
            button_update_course.BackColor = Color.Gold;
            button_update_course.FlatStyle = FlatStyle.Popup;
            button_update_course.Location = new Point(207, 229);
            button_update_course.Name = "button_update_course";
            button_update_course.Size = new Size(120, 30);
            button_update_course.TabIndex = 15;
            button_update_course.Text = "UPDATE COURSE";
            button_update_course.UseVisualStyleBackColor = false;
            // 
            // button_search_course
            // 
            button_search_course.BackColor = Color.Turquoise;
            button_search_course.FlatStyle = FlatStyle.Popup;
            button_search_course.Location = new Point(207, 180);
            button_search_course.Name = "button_search_course";
            button_search_course.Size = new Size(120, 30);
            button_search_course.TabIndex = 14;
            button_search_course.Text = "SEARCH COURSE";
            button_search_course.UseVisualStyleBackColor = false;
            // 
            // label_course_title
            // 
            label_course_title.AutoSize = true;
            label_course_title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_course_title.ForeColor = Color.White;
            label_course_title.Location = new Point(25, 20);
            label_course_title.Name = "label_course_title";
            label_course_title.Size = new Size(108, 21);
            label_course_title.TabIndex = 13;
            label_course_title.Text = "Courses info:";
            // 
            // label_academic_year
            // 
            label_academic_year.AutoSize = true;
            label_academic_year.Font = new Font("Segoe UI", 10F);
            label_academic_year.ForeColor = Color.White;
            label_academic_year.Location = new Point(25, 122);
            label_academic_year.Name = "label_academic_year";
            label_academic_year.Size = new Size(100, 19);
            label_academic_year.TabIndex = 11;
            label_academic_year.Text = "Academic year:";
            // 
            // label_field_title
            // 
            label_field_title.AutoSize = true;
            label_field_title.Font = new Font("Segoe UI", 10F);
            label_field_title.ForeColor = Color.White;
            label_field_title.Location = new Point(25, 93);
            label_field_title.Name = "label_field_title";
            label_field_title.Size = new Size(37, 19);
            label_field_title.TabIndex = 8;
            label_field_title.Text = "Title:";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Font = new Font("Segoe UI", 10F);
            label_id.ForeColor = Color.White;
            label_id.Location = new Point(25, 63);
            label_id.Name = "label_id";
            label_id.Size = new Size(26, 19);
            label_id.TabIndex = 7;
            label_id.Text = "ID:";
            // 
            // textbox_field_title
            // 
            textbox_field_title.Location = new Point(177, 89);
            textbox_field_title.Name = "textbox_field_title";
            textbox_field_title.Size = new Size(150, 23);
            textbox_field_title.TabIndex = 6;
            // 
            // numeric_scroll
            // 
            numeric_scroll.Location = new Point(177, 119);
            numeric_scroll.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numeric_scroll.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numeric_scroll.Name = "numeric_scroll";
            numeric_scroll.Size = new Size(150, 23);
            numeric_scroll.TabIndex = 4;
            numeric_scroll.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // textbox_id
            // 
            textbox_id.Location = new Point(177, 59);
            textbox_id.Name = "textbox_id";
            textbox_id.Size = new Size(150, 23);
            textbox_id.TabIndex = 1;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.MinimumWidth = 50;
            id.Name = "id";
            id.ReadOnly = true;
            id.Width = 50;
            // 
            // title
            // 
            title.HeaderText = "Title";
            title.MinimumWidth = 100;
            title.Name = "title";
            title.ReadOnly = true;
            // 
            // academic_year
            // 
            academic_year.HeaderText = "Academic year";
            academic_year.MinimumWidth = 110;
            academic_year.Name = "academic_year";
            academic_year.ReadOnly = true;
            academic_year.Width = 110;
            // 
            // CourseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 616);
            Controls.Add(panel_connect);
            Controls.Add(panel_title);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CourseForm";
            Text = "University Management System";
            panel_title.ResumeLayout(false);
            panel_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picturebox_icon).EndInit();
            panel_connect.ResumeLayout(false);
            panel_connect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)data_gridview_course_professor).EndInit();
            ((System.ComponentModel.ISupportInitialize)picturebox_exit).EndInit();
            ((System.ComponentModel.ISupportInitialize)data_gridview_course_student).EndInit();
            ((System.ComponentModel.ISupportInitialize)numeric_scroll).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_title;
        private PictureBox picturebox_icon;
        private Label label_title;
        private Panel panel_connect;
        private PictureBox picturebox_exit;
        private Button button_exit;
        private Button button_delete_course_student;
        private Button button_insert_course_student;
        private Button button_update_course_student;
        private Button button_search_course_student;
        private Label label_student_id;
        private Label label_course_id_1;
        private TextBox textbox_student_id;
        private TextBox textbox_course_id_1;
        private Label label_student_course_title;
        private DataGridView data_gridview_course_student;
        private Button button_delete_course;
        private Button button_insert_course;
        private Button button_update_course;
        private Button button_search_course;
        private Label label_course_title;
        private Label label_academic_year;
        private Label label_field_title;
        private Label label_id;
        private TextBox textbox_field_title;
        private NumericUpDown numeric_scroll;
        private TextBox textbox_id;
        private Button button_delete_course_professor;
        private Button button_insert_course_professor;
        private Button button_update_course_professor;
        private Button button_search_course_professor;
        private Label label_professor_id;
        private Label label_course_id_2;
        private TextBox textbox_professor_id;
        private TextBox textbox_course_id_2;
        private Label label_professor_course_title;
        private DataGridView data_gridview_course_professor;
        private DataGridViewTextBoxColumn course_id_2;
        private DataGridViewTextBoxColumn professor_id;
        private DataGridViewTextBoxColumn course_id_1;
        private DataGridViewTextBoxColumn student_id;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn title;
        private DataGridViewTextBoxColumn academic_year;
    }
}