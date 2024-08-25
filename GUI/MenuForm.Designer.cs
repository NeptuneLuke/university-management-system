namespace UniversityManagementSystem {
    partial class MenuForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            label_menu_title = new Label();
            button_student = new Button();
            picturebox_student_icon = new PictureBox();
            button_professor = new Button();
            picturebox_professor_icon = new PictureBox();
            button_course = new Button();
            picturebox_course_icon = new PictureBox();
            button_exit = new Button();
            picturebox_exit = new PictureBox();
            panel_connect = new Panel();
            label_title = new Label();
            picturebox_icon = new PictureBox();
            panel_title = new Panel();
            ((System.ComponentModel.ISupportInitialize)picturebox_student_icon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picturebox_professor_icon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picturebox_course_icon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picturebox_exit).BeginInit();
            panel_connect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturebox_icon).BeginInit();
            panel_title.SuspendLayout();
            SuspendLayout();
            // 
            // label_menu_title
            // 
            label_menu_title.AutoSize = true;
            label_menu_title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_menu_title.ForeColor = Color.White;
            label_menu_title.Location = new Point(90, 17);
            label_menu_title.Name = "label_menu_title";
            label_menu_title.Size = new Size(172, 21);
            label_menu_title.TabIndex = 8;
            label_menu_title.Text = "Choose a table to use";
            // 
            // button_student
            // 
            button_student.BackColor = Color.White;
            button_student.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button_student.Location = new Point(165, 60);
            button_student.Name = "button_student";
            button_student.Size = new Size(150, 40);
            button_student.TabIndex = 11;
            button_student.Text = "STUDENTS TABLE";
            button_student.UseVisualStyleBackColor = false;
            button_student.Click += button_student_Click;
            // 
            // picturebox_student_icon
            // 
            picturebox_student_icon.Image = Properties.Resources.icons8_graduation_cap_64;
            picturebox_student_icon.Location = new Point(90, 50);
            picturebox_student_icon.Name = "picturebox_student_icon";
            picturebox_student_icon.Size = new Size(64, 64);
            picturebox_student_icon.TabIndex = 15;
            picturebox_student_icon.TabStop = false;
            // 
            // button_professor
            // 
            button_professor.BackColor = Color.White;
            button_professor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button_professor.Location = new Point(165, 136);
            button_professor.Name = "button_professor";
            button_professor.Size = new Size(150, 40);
            button_professor.TabIndex = 16;
            button_professor.Text = "PROFESSORS TABLE";
            button_professor.UseVisualStyleBackColor = false;
            button_professor.Click += button_professor_Click;
            // 
            // picturebox_professor_icon
            // 
            picturebox_professor_icon.Image = Properties.Resources.icons8_teacher_64;
            picturebox_professor_icon.Location = new Point(90, 126);
            picturebox_professor_icon.Name = "picturebox_professor_icon";
            picturebox_professor_icon.Size = new Size(64, 64);
            picturebox_professor_icon.TabIndex = 17;
            picturebox_professor_icon.TabStop = false;
            // 
            // button_course
            // 
            button_course.BackColor = Color.White;
            button_course.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button_course.Location = new Point(165, 212);
            button_course.Name = "button_course";
            button_course.Size = new Size(150, 40);
            button_course.TabIndex = 18;
            button_course.Text = "COURSES TABLE";
            button_course.UseVisualStyleBackColor = false;
            button_course.Click += button_course_Click;
            // 
            // picturebox_course_icon
            // 
            picturebox_course_icon.Image = Properties.Resources.icons8_literature_64;
            picturebox_course_icon.Location = new Point(90, 202);
            picturebox_course_icon.Name = "picturebox_course_icon";
            picturebox_course_icon.Size = new Size(64, 64);
            picturebox_course_icon.TabIndex = 19;
            picturebox_course_icon.TabStop = false;
            // 
            // button_exit
            // 
            button_exit.BackColor = Color.White;
            button_exit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button_exit.Location = new Point(622, 267);
            button_exit.Name = "button_exit";
            button_exit.Size = new Size(150, 40);
            button_exit.TabIndex = 20;
            button_exit.Text = "EXIT DATABASE";
            button_exit.UseVisualStyleBackColor = false;
            button_exit.Click += button_exit_Click;
            // 
            // picturebox_exit
            // 
            picturebox_exit.Image = Properties.Resources.icons8_logout_64;
            picturebox_exit.Location = new Point(550, 255);
            picturebox_exit.Name = "picturebox_exit";
            picturebox_exit.Size = new Size(64, 64);
            picturebox_exit.TabIndex = 21;
            picturebox_exit.TabStop = false;
            // 
            // panel_connect
            // 
            panel_connect.BackColor = Color.DarkRed;
            panel_connect.Controls.Add(picturebox_exit);
            panel_connect.Controls.Add(button_exit);
            panel_connect.Controls.Add(picturebox_course_icon);
            panel_connect.Controls.Add(button_course);
            panel_connect.Controls.Add(picturebox_professor_icon);
            panel_connect.Controls.Add(button_professor);
            panel_connect.Controls.Add(picturebox_student_icon);
            panel_connect.Controls.Add(button_student);
            panel_connect.Controls.Add(label_menu_title);
            panel_connect.Dock = DockStyle.Fill;
            panel_connect.Location = new Point(0, 70);
            panel_connect.Name = "panel_connect";
            panel_connect.Size = new Size(784, 341);
            panel_connect.TabIndex = 5;
            // 
            // label_title
            // 
            label_title.AutoSize = true;
            label_title.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label_title.ForeColor = Color.White;
            label_title.Location = new Point(90, 5);
            label_title.Name = "label_title";
            label_title.Size = new Size(525, 46);
            label_title.TabIndex = 0;
            label_title.Text = "University Management System";
            // 
            // picturebox_icon
            // 
            picturebox_icon.Image = Properties.Resources.icons8_university_64_white;
            picturebox_icon.Location = new Point(12, 5);
            picturebox_icon.Name = "picturebox_icon";
            picturebox_icon.Size = new Size(64, 64);
            picturebox_icon.TabIndex = 1;
            picturebox_icon.TabStop = false;
            // 
            // panel_title
            // 
            panel_title.BackColor = Color.FromArgb(170, 0, 0);
            panel_title.Controls.Add(picturebox_icon);
            panel_title.Controls.Add(label_title);
            panel_title.Dock = DockStyle.Top;
            panel_title.Location = new Point(0, 0);
            panel_title.Name = "panel_title";
            panel_title.Size = new Size(784, 70);
            panel_title.TabIndex = 4;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 411);
            Controls.Add(panel_connect);
            Controls.Add(panel_title);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MenuForm";
            Text = "University Management System";
            ((System.ComponentModel.ISupportInitialize)picturebox_student_icon).EndInit();
            ((System.ComponentModel.ISupportInitialize)picturebox_professor_icon).EndInit();
            ((System.ComponentModel.ISupportInitialize)picturebox_course_icon).EndInit();
            ((System.ComponentModel.ISupportInitialize)picturebox_exit).EndInit();
            panel_connect.ResumeLayout(false);
            panel_connect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picturebox_icon).EndInit();
            panel_title.ResumeLayout(false);
            panel_title.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label_menu_title;
        private Button button_student;
        private PictureBox picturebox_student_icon;
        private Button button_professor;
        private PictureBox picturebox_professor_icon;
        private Button button_course;
        private PictureBox picturebox_course_icon;
        private Button button_exit;
        private PictureBox picturebox_exit;
        private Panel panel_connect;
        private Label label_title;
        private PictureBox picturebox_icon;
        private Panel panel_title;
    }
}