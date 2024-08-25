namespace UniversityManagementSystem {
    partial class StudentForm {
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
            ListViewItem listViewItem1 = new ListViewItem("ID");
            ListViewItem listViewItem2 = new ListViewItem("First name");
            ListViewItem listViewItem3 = new ListViewItem("Last name");
            ListViewItem listViewItem4 = new ListViewItem("Email");
            ListViewItem listViewItem5 = new ListViewItem("Academic year");
            ListViewItem listViewItem6 = new ListViewItem("Year");
            ListViewItem listViewItem7 = new ListViewItem("Month");
            ListViewItem listViewItem8 = new ListViewItem("Day");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            panel_title = new Panel();
            picturebox_icon = new PictureBox();
            label_title = new Label();
            panel_database = new Panel();
            label_cs_table_result = new Label();
            radio_button_search_default = new RadioButton();
            label_cs_academic_year = new Label();
            numeric_scroll_cs_academic_year = new NumericUpDown();
            label_cs_course_id = new Label();
            textbox_cs_course_id = new TextBox();
            label_cs_student_id = new Label();
            textbox_cs_student_id = new TextBox();
            radiobutton_search_3 = new RadioButton();
            radiobutton_search_2 = new RadioButton();
            radiobutton_search_1 = new RadioButton();
            label_current_max_id = new Label();
            button_reset_id_counter = new Button();
            button_refresh_student_table = new Button();
            listview_filters = new ListView();
            column_filters = new ColumnHeader();
            numeric_scroll_day = new NumericUpDown();
            numeric_scroll_month = new NumericUpDown();
            numeric_scroll_year = new NumericUpDown();
            button_reset_student_filters = new Button();
            button_exit = new Button();
            button_delete_course_student = new Button();
            button_insert_course_student = new Button();
            button_search_course_student = new Button();
            label_course_student_title = new Label();
            data_gridview_course_student = new DataGridView();
            button_delete_student = new Button();
            button_insert_student = new Button();
            button_update_student = new Button();
            button_search_student = new Button();
            label_student_title = new Label();
            label_birth_date = new Label();
            label_academic_year = new Label();
            label_email = new Label();
            label_last_name = new Label();
            label_first_name = new Label();
            label_id = new Label();
            textbox_first_name = new TextBox();
            textbox_last_name = new TextBox();
            numeric_scroll_academic_year = new NumericUpDown();
            textbox_email = new TextBox();
            textbox_id = new TextBox();
            data_gridview_student = new DataGridView();
            cs_student_id = new DataGridViewTextBoxColumn();
            cs_course_id = new DataGridViewTextBoxColumn();
            cs_course_title = new DataGridViewTextBoxColumn();
            cs_course_academic_year = new DataGridViewTextBoxColumn();
            cs_first_name = new DataGridViewTextBoxColumn();
            cs_last_name = new DataGridViewTextBoxColumn();
            cs_email = new DataGridViewTextBoxColumn();
            student_id = new DataGridViewTextBoxColumn();
            first_name = new DataGridViewTextBoxColumn();
            last_name = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            academic_year = new DataGridViewTextBoxColumn();
            birth_date = new DataGridViewTextBoxColumn();
            panel_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturebox_icon).BeginInit();
            panel_database.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numeric_scroll_cs_academic_year).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numeric_scroll_day).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numeric_scroll_month).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numeric_scroll_year).BeginInit();
            ((System.ComponentModel.ISupportInitialize)data_gridview_course_student).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numeric_scroll_academic_year).BeginInit();
            ((System.ComponentModel.ISupportInitialize)data_gridview_student).BeginInit();
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
            panel_title.Size = new Size(1044, 70);
            panel_title.TabIndex = 1;
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
            // label_title
            // 
            label_title.AutoSize = true;
            label_title.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label_title.ForeColor = Color.White;
            label_title.Location = new Point(92, 5);
            label_title.Name = "label_title";
            label_title.Size = new Size(525, 46);
            label_title.TabIndex = 0;
            label_title.Text = "University Management System";
            // 
            // panel_database
            // 
            panel_database.BackColor = Color.DarkRed;
            panel_database.Controls.Add(label_cs_table_result);
            panel_database.Controls.Add(radio_button_search_default);
            panel_database.Controls.Add(label_cs_academic_year);
            panel_database.Controls.Add(numeric_scroll_cs_academic_year);
            panel_database.Controls.Add(label_cs_course_id);
            panel_database.Controls.Add(textbox_cs_course_id);
            panel_database.Controls.Add(label_cs_student_id);
            panel_database.Controls.Add(textbox_cs_student_id);
            panel_database.Controls.Add(radiobutton_search_3);
            panel_database.Controls.Add(radiobutton_search_2);
            panel_database.Controls.Add(radiobutton_search_1);
            panel_database.Controls.Add(label_current_max_id);
            panel_database.Controls.Add(button_reset_id_counter);
            panel_database.Controls.Add(button_refresh_student_table);
            panel_database.Controls.Add(listview_filters);
            panel_database.Controls.Add(numeric_scroll_day);
            panel_database.Controls.Add(numeric_scroll_month);
            panel_database.Controls.Add(numeric_scroll_year);
            panel_database.Controls.Add(button_reset_student_filters);
            panel_database.Controls.Add(button_exit);
            panel_database.Controls.Add(button_delete_course_student);
            panel_database.Controls.Add(button_insert_course_student);
            panel_database.Controls.Add(button_search_course_student);
            panel_database.Controls.Add(label_course_student_title);
            panel_database.Controls.Add(data_gridview_course_student);
            panel_database.Controls.Add(button_delete_student);
            panel_database.Controls.Add(button_insert_student);
            panel_database.Controls.Add(button_update_student);
            panel_database.Controls.Add(button_search_student);
            panel_database.Controls.Add(label_student_title);
            panel_database.Controls.Add(label_birth_date);
            panel_database.Controls.Add(label_academic_year);
            panel_database.Controls.Add(label_email);
            panel_database.Controls.Add(label_last_name);
            panel_database.Controls.Add(label_first_name);
            panel_database.Controls.Add(label_id);
            panel_database.Controls.Add(textbox_first_name);
            panel_database.Controls.Add(textbox_last_name);
            panel_database.Controls.Add(numeric_scroll_academic_year);
            panel_database.Controls.Add(textbox_email);
            panel_database.Controls.Add(textbox_id);
            panel_database.Controls.Add(data_gridview_student);
            panel_database.Dock = DockStyle.Fill;
            panel_database.Location = new Point(0, 70);
            panel_database.Name = "panel_database";
            panel_database.Size = new Size(1044, 611);
            panel_database.TabIndex = 6;
            // 
            // label_cs_table_result
            // 
            label_cs_table_result.AutoSize = true;
            label_cs_table_result.Font = new Font("Segoe UI", 10F);
            label_cs_table_result.ForeColor = Color.White;
            label_cs_table_result.Location = new Point(197, 379);
            label_cs_table_result.Name = "label_cs_table_result";
            label_cs_table_result.Size = new Size(131, 19);
            label_cs_table_result.TabIndex = 63;
            label_cs_table_result.Text = "Courses by student:";
            // 
            // radio_button_search_default
            // 
            radio_button_search_default.AutoSize = true;
            radio_button_search_default.Font = new Font("Segoe UI", 10F);
            radio_button_search_default.ForeColor = Color.White;
            radio_button_search_default.Location = new Point(458, 489);
            radio_button_search_default.Name = "radio_button_search_default";
            radio_button_search_default.Size = new Size(145, 23);
            radio_button_search_default.TabIndex = 62;
            radio_button_search_default.TabStop = true;
            radio_button_search_default.Text = "All courses-student";
            radio_button_search_default.UseVisualStyleBackColor = true;
            // 
            // label_cs_academic_year
            // 
            label_cs_academic_year.AutoSize = true;
            label_cs_academic_year.Font = new Font("Segoe UI", 10F);
            label_cs_academic_year.ForeColor = Color.White;
            label_cs_academic_year.Location = new Point(670, 462);
            label_cs_academic_year.Name = "label_cs_academic_year";
            label_cs_academic_year.Size = new Size(100, 19);
            label_cs_academic_year.TabIndex = 61;
            label_cs_academic_year.Text = "Academic year:";
            // 
            // numeric_scroll_cs_academic_year
            // 
            numeric_scroll_cs_academic_year.Location = new Point(822, 460);
            numeric_scroll_cs_academic_year.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numeric_scroll_cs_academic_year.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numeric_scroll_cs_academic_year.Name = "numeric_scroll_cs_academic_year";
            numeric_scroll_cs_academic_year.Size = new Size(50, 23);
            numeric_scroll_cs_academic_year.TabIndex = 60;
            numeric_scroll_cs_academic_year.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label_cs_course_id
            // 
            label_cs_course_id.AutoSize = true;
            label_cs_course_id.Font = new Font("Segoe UI", 10F);
            label_cs_course_id.ForeColor = Color.White;
            label_cs_course_id.Location = new Point(670, 433);
            label_cs_course_id.Name = "label_cs_course_id";
            label_cs_course_id.Size = new Size(73, 19);
            label_cs_course_id.TabIndex = 59;
            label_cs_course_id.Text = "Course ID:";
            // 
            // textbox_cs_course_id
            // 
            textbox_cs_course_id.Location = new Point(772, 432);
            textbox_cs_course_id.Name = "textbox_cs_course_id";
            textbox_cs_course_id.Size = new Size(100, 23);
            textbox_cs_course_id.TabIndex = 58;
            // 
            // label_cs_student_id
            // 
            label_cs_student_id.AutoSize = true;
            label_cs_student_id.Font = new Font("Segoe UI", 10F);
            label_cs_student_id.ForeColor = Color.White;
            label_cs_student_id.Location = new Point(670, 404);
            label_cs_student_id.Name = "label_cs_student_id";
            label_cs_student_id.Size = new Size(78, 19);
            label_cs_student_id.TabIndex = 57;
            label_cs_student_id.Text = "Student ID:";
            // 
            // textbox_cs_student_id
            // 
            textbox_cs_student_id.Location = new Point(772, 403);
            textbox_cs_student_id.Name = "textbox_cs_student_id";
            textbox_cs_student_id.Size = new Size(100, 23);
            textbox_cs_student_id.TabIndex = 56;
            // 
            // radiobutton_search_3
            // 
            radiobutton_search_3.AutoSize = true;
            radiobutton_search_3.Font = new Font("Segoe UI", 10F);
            radiobutton_search_3.ForeColor = Color.White;
            radiobutton_search_3.Location = new Point(458, 460);
            radiobutton_search_3.Name = "radiobutton_search_3";
            radiobutton_search_3.Size = new Size(208, 23);
            radiobutton_search_3.TabIndex = 55;
            radiobutton_search_3.TabStop = true;
            radiobutton_search_3.Text = "All courses of year by student";
            radiobutton_search_3.UseVisualStyleBackColor = true;
            // 
            // radiobutton_search_2
            // 
            radiobutton_search_2.AutoSize = true;
            radiobutton_search_2.Font = new Font("Segoe UI", 10F);
            radiobutton_search_2.ForeColor = Color.White;
            radiobutton_search_2.Location = new Point(458, 431);
            radiobutton_search_2.Name = "radiobutton_search_2";
            radiobutton_search_2.Size = new Size(162, 23);
            radiobutton_search_2.TabIndex = 54;
            radiobutton_search_2.TabStop = true;
            radiobutton_search_2.Text = "All students by course";
            radiobutton_search_2.UseVisualStyleBackColor = true;
            // 
            // radiobutton_search_1
            // 
            radiobutton_search_1.AutoSize = true;
            radiobutton_search_1.Font = new Font("Segoe UI", 10F);
            radiobutton_search_1.ForeColor = Color.White;
            radiobutton_search_1.Location = new Point(458, 402);
            radiobutton_search_1.Name = "radiobutton_search_1";
            radiobutton_search_1.Size = new Size(162, 23);
            radiobutton_search_1.TabIndex = 53;
            radiobutton_search_1.TabStop = true;
            radiobutton_search_1.Text = "All courses by student";
            radiobutton_search_1.UseVisualStyleBackColor = true;
            // 
            // label_current_max_id
            // 
            label_current_max_id.AutoSize = true;
            label_current_max_id.Font = new Font("Segoe UI", 10F);
            label_current_max_id.ForeColor = Color.White;
            label_current_max_id.Location = new Point(813, 342);
            label_current_max_id.Name = "label_current_max_id";
            label_current_max_id.Size = new Size(62, 19);
            label_current_max_id.TabIndex = 51;
            label_current_max_id.Text = "Next ID: ";
            // 
            // button_reset_id_counter
            // 
            button_reset_id_counter.BackColor = Color.LavenderBlush;
            button_reset_id_counter.FlatStyle = FlatStyle.Popup;
            button_reset_id_counter.Location = new Point(647, 336);
            button_reset_id_counter.Name = "button_reset_id_counter";
            button_reset_id_counter.Size = new Size(150, 30);
            button_reset_id_counter.TabIndex = 50;
            button_reset_id_counter.Text = "RESET IDs COUNTER";
            button_reset_id_counter.UseVisualStyleBackColor = false;
            button_reset_id_counter.Click += button_reset_id_counter_Click;
            // 
            // button_refresh_student_table
            // 
            button_refresh_student_table.BackColor = Color.LavenderBlush;
            button_refresh_student_table.FlatStyle = FlatStyle.Popup;
            button_refresh_student_table.Location = new Point(931, 300);
            button_refresh_student_table.Name = "button_refresh_student_table";
            button_refresh_student_table.Size = new Size(100, 30);
            button_refresh_student_table.TabIndex = 49;
            button_refresh_student_table.Text = "REFRESH TABLE";
            button_refresh_student_table.UseVisualStyleBackColor = false;
            button_refresh_student_table.Click += button_refresh_student_table_Click;
            // 
            // listview_filters
            // 
            listview_filters.CheckBoxes = true;
            listview_filters.Columns.AddRange(new ColumnHeader[] { column_filters });
            listview_filters.HeaderStyle = ColumnHeaderStyle.None;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            listViewItem5.StateImageIndex = 0;
            listViewItem6.StateImageIndex = 0;
            listViewItem7.StateImageIndex = 0;
            listViewItem8.StateImageIndex = 0;
            listview_filters.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4, listViewItem5, listViewItem6, listViewItem7, listViewItem8 });
            listview_filters.Location = new Point(648, 204);
            listview_filters.Name = "listview_filters";
            listview_filters.Size = new Size(265, 126);
            listview_filters.TabIndex = 47;
            listview_filters.UseCompatibleStateImageBehavior = false;
            listview_filters.View = View.Details;
            // 
            // column_filters
            // 
            column_filters.Width = 150;
            // 
            // numeric_scroll_day
            // 
            numeric_scroll_day.Location = new Point(771, 175);
            numeric_scroll_day.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numeric_scroll_day.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numeric_scroll_day.Name = "numeric_scroll_day";
            numeric_scroll_day.Size = new Size(40, 23);
            numeric_scroll_day.TabIndex = 45;
            numeric_scroll_day.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numeric_scroll_month
            // 
            numeric_scroll_month.Location = new Point(817, 175);
            numeric_scroll_month.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numeric_scroll_month.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numeric_scroll_month.Name = "numeric_scroll_month";
            numeric_scroll_month.Size = new Size(40, 23);
            numeric_scroll_month.TabIndex = 44;
            numeric_scroll_month.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numeric_scroll_year
            // 
            numeric_scroll_year.Location = new Point(863, 175);
            numeric_scroll_year.Maximum = new decimal(new int[] { 2005, 0, 0, 0 });
            numeric_scroll_year.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            numeric_scroll_year.Name = "numeric_scroll_year";
            numeric_scroll_year.Size = new Size(50, 23);
            numeric_scroll_year.TabIndex = 43;
            numeric_scroll_year.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // button_reset_student_filters
            // 
            button_reset_student_filters.BackColor = Color.LavenderBlush;
            button_reset_student_filters.FlatStyle = FlatStyle.Popup;
            button_reset_student_filters.Location = new Point(931, 264);
            button_reset_student_filters.Name = "button_reset_student_filters";
            button_reset_student_filters.Size = new Size(100, 30);
            button_reset_student_filters.TabIndex = 41;
            button_reset_student_filters.Text = "RESET FILTERS";
            button_reset_student_filters.UseVisualStyleBackColor = false;
            button_reset_student_filters.Click += button_reset_student_Click;
            // 
            // button_exit
            // 
            button_exit.BackColor = Color.White;
            button_exit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button_exit.Location = new Point(883, 559);
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
            button_delete_course_student.Location = new Point(671, 572);
            button_delete_course_student.Name = "button_delete_course_student";
            button_delete_course_student.Size = new Size(100, 30);
            button_delete_course_student.TabIndex = 27;
            button_delete_course_student.Text = "DELETE";
            button_delete_course_student.UseVisualStyleBackColor = false;
            button_delete_course_student.Click += button_delete_course_student_Click;
            // 
            // button_insert_course_student
            // 
            button_insert_course_student.BackColor = Color.Chartreuse;
            button_insert_course_student.FlatStyle = FlatStyle.Popup;
            button_insert_course_student.Location = new Point(565, 572);
            button_insert_course_student.Name = "button_insert_course_student";
            button_insert_course_student.Size = new Size(100, 30);
            button_insert_course_student.TabIndex = 26;
            button_insert_course_student.Text = "INSERT";
            button_insert_course_student.UseVisualStyleBackColor = false;
            button_insert_course_student.Click += button_insert_course_student_Click;
            // 
            // button_search_course_student
            // 
            button_search_course_student.BackColor = Color.PaleTurquoise;
            button_search_course_student.FlatStyle = FlatStyle.Popup;
            button_search_course_student.Location = new Point(458, 572);
            button_search_course_student.Name = "button_search_course_student";
            button_search_course_student.Size = new Size(100, 30);
            button_search_course_student.TabIndex = 24;
            button_search_course_student.Text = "SEARCH";
            button_search_course_student.UseVisualStyleBackColor = false;
            button_search_course_student.Click += button_search_course_student_Click;
            // 
            // label_course_student_title
            // 
            label_course_student_title.AutoSize = true;
            label_course_student_title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_course_student_title.ForeColor = Color.White;
            label_course_student_title.Location = new Point(12, 378);
            label_course_student_title.Name = "label_course_student_title";
            label_course_student_title.Size = new Size(179, 21);
            label_course_student_title.TabIndex = 19;
            label_course_student_title.Text = "Courses-students info:";
            // 
            // data_gridview_course_student
            // 
            data_gridview_course_student.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data_gridview_course_student.Location = new Point(12, 402);
            data_gridview_course_student.Name = "data_gridview_course_student";
            data_gridview_course_student.ReadOnly = true;
            data_gridview_course_student.Size = new Size(440, 200);
            data_gridview_course_student.TabIndex = 18;
            // 
            // button_delete_student
            // 
            button_delete_student.BackColor = Color.Red;
            button_delete_student.FlatStyle = FlatStyle.Popup;
            button_delete_student.Location = new Point(931, 169);
            button_delete_student.Name = "button_delete_student";
            button_delete_student.Size = new Size(100, 30);
            button_delete_student.TabIndex = 17;
            button_delete_student.Text = "DELETE";
            button_delete_student.UseVisualStyleBackColor = false;
            button_delete_student.Click += button_delete_student_Click;
            // 
            // button_insert_student
            // 
            button_insert_student.BackColor = Color.Chartreuse;
            button_insert_student.FlatStyle = FlatStyle.Popup;
            button_insert_student.ImageAlign = ContentAlignment.MiddleLeft;
            button_insert_student.Location = new Point(931, 97);
            button_insert_student.Name = "button_insert_student";
            button_insert_student.Size = new Size(100, 30);
            button_insert_student.TabIndex = 16;
            button_insert_student.Text = "INSERT";
            button_insert_student.UseVisualStyleBackColor = false;
            button_insert_student.Click += button_insert_student_Click;
            // 
            // button_update_student
            // 
            button_update_student.BackColor = Color.Gold;
            button_update_student.FlatStyle = FlatStyle.Popup;
            button_update_student.Location = new Point(931, 133);
            button_update_student.Name = "button_update_student";
            button_update_student.Size = new Size(100, 30);
            button_update_student.TabIndex = 15;
            button_update_student.Text = "UPDATE";
            button_update_student.UseVisualStyleBackColor = false;
            button_update_student.Click += button_update_student_Click;
            // 
            // button_search_student
            // 
            button_search_student.BackColor = Color.PaleTurquoise;
            button_search_student.FlatStyle = FlatStyle.Popup;
            button_search_student.Location = new Point(931, 228);
            button_search_student.Name = "button_search_student";
            button_search_student.Size = new Size(100, 30);
            button_search_student.TabIndex = 14;
            button_search_student.Text = "SEARCH";
            button_search_student.UseVisualStyleBackColor = false;
            button_search_student.Click += button_search_student_Click;
            // 
            // label_student_title
            // 
            label_student_title.AutoSize = true;
            label_student_title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_student_title.ForeColor = Color.White;
            label_student_title.Location = new Point(12, 20);
            label_student_title.Name = "label_student_title";
            label_student_title.Size = new Size(116, 21);
            label_student_title.TabIndex = 13;
            label_student_title.Text = "Students info:";
            // 
            // label_birth_date
            // 
            label_birth_date.AutoSize = true;
            label_birth_date.Font = new Font("Segoe UI", 10F);
            label_birth_date.ForeColor = Color.White;
            label_birth_date.Location = new Point(648, 175);
            label_birth_date.Name = "label_birth_date";
            label_birth_date.Size = new Size(117, 19);
            label_birth_date.TabIndex = 12;
            label_birth_date.Text = "Birth date(d/m/y):";
            // 
            // label_academic_year
            // 
            label_academic_year.AutoSize = true;
            label_academic_year.Font = new Font("Segoe UI", 10F);
            label_academic_year.ForeColor = Color.White;
            label_academic_year.Location = new Point(648, 145);
            label_academic_year.Name = "label_academic_year";
            label_academic_year.Size = new Size(100, 19);
            label_academic_year.TabIndex = 11;
            label_academic_year.Text = "Academic year:";
            // 
            // label_email
            // 
            label_email.AutoSize = true;
            label_email.Font = new Font("Segoe UI", 10F);
            label_email.ForeColor = Color.White;
            label_email.Location = new Point(648, 115);
            label_email.Name = "label_email";
            label_email.Size = new Size(44, 19);
            label_email.TabIndex = 10;
            label_email.Text = "Email:";
            // 
            // label_last_name
            // 
            label_last_name.AutoSize = true;
            label_last_name.Font = new Font("Segoe UI", 10F);
            label_last_name.ForeColor = Color.White;
            label_last_name.Location = new Point(648, 85);
            label_last_name.Name = "label_last_name";
            label_last_name.Size = new Size(75, 19);
            label_last_name.TabIndex = 9;
            label_last_name.Text = "Last name:";
            // 
            // label_first_name
            // 
            label_first_name.AutoSize = true;
            label_first_name.Font = new Font("Segoe UI", 10F);
            label_first_name.ForeColor = Color.White;
            label_first_name.Location = new Point(647, 55);
            label_first_name.Name = "label_first_name";
            label_first_name.Size = new Size(76, 19);
            label_first_name.TabIndex = 8;
            label_first_name.Text = "First name:";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Font = new Font("Segoe UI", 10F);
            label_id.ForeColor = Color.White;
            label_id.Location = new Point(648, 25);
            label_id.Name = "label_id";
            label_id.Size = new Size(26, 19);
            label_id.TabIndex = 7;
            label_id.Text = "ID:";
            // 
            // textbox_first_name
            //
            textbox_first_name.Location = new Point(813, 54);
            textbox_first_name.Name = "textbox_first_name";
            textbox_first_name.Size = new Size(100, 23);
            textbox_first_name.TabIndex = 6;
            // 
            // textbox_last_name
            // 
            textbox_last_name.Location = new Point(813, 84);
            textbox_last_name.Name = "textbox_last_name";
            textbox_last_name.Size = new Size(100, 23);
            textbox_last_name.TabIndex = 5;
            // 
            // numeric_scroll_academic_year
            // 
            numeric_scroll_academic_year.Location = new Point(863, 146);
            numeric_scroll_academic_year.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numeric_scroll_academic_year.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numeric_scroll_academic_year.Name = "numeric_scroll_academic_year";
            numeric_scroll_academic_year.Size = new Size(50, 23);
            numeric_scroll_academic_year.TabIndex = 4;
            numeric_scroll_academic_year.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // textbox_email
            // 
            textbox_email.Location = new Point(813, 114);
            textbox_email.Name = "textbox_email";
            textbox_email.Size = new Size(100, 23);
            textbox_email.TabIndex = 2;
            // 
            // textbox_id
            // 
            textbox_id.Location = new Point(883, 24);
            textbox_id.Name = "textbox_id";
            textbox_id.Size = new Size(30, 23);
            textbox_id.TabIndex = 1;
            // 
            // data_gridview_student
            // 
            data_gridview_student.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data_gridview_student.Location = new Point(12, 44);
            data_gridview_student.Name = "data_gridview_student";
            data_gridview_student.ReadOnly = true;
            data_gridview_student.Size = new Size(620, 322);
            data_gridview_student.TabIndex = 0;
            // 
            // cs_student_id
            // 
            cs_student_id.HeaderText = "Student ID";
            cs_student_id.MinimumWidth = 60;
            cs_student_id.Name = "cs_student_id";
            cs_student_id.ReadOnly = true;
            cs_student_id.Width = 60;
            // 
            // cs_course_id
            // 
            cs_course_id.HeaderText = "Course ID";
            cs_course_id.MinimumWidth = 60;
            cs_course_id.Name = "cs_course_id";
            cs_course_id.ReadOnly = true;
            cs_course_id.Width = 60;
            // 
            // cs_course_title
            // 
            cs_course_title.HeaderText = "Title";
            cs_course_title.MinimumWidth = 150;
            cs_course_title.Name = "cs_course_title";
            cs_course_title.ReadOnly = true;
            cs_course_title.Width = 150;
            // 
            // cs_course_academic_year
            // 
            cs_course_academic_year.HeaderText = "Academic year";
            cs_course_academic_year.MinimumWidth = 70;
            cs_course_academic_year.Name = "cs_course_academic_year";
            cs_course_academic_year.ReadOnly = true;
            cs_course_academic_year.Width = 70;
            // 
            // cs_first_name
            // 
            cs_first_name.HeaderText = "First name";
            cs_first_name.MinimumWidth = 100;
            cs_first_name.Name = "cs_first_name";
            cs_first_name.ReadOnly = true;
            // 
            // cs_last_name
            // 
            cs_last_name.HeaderText = "Last name";
            cs_last_name.MinimumWidth = 100;
            cs_last_name.Name = "cs_last_name";
            cs_last_name.ReadOnly = true;
            // 
            // cs_email
            // 
            cs_email.HeaderText = "Email";
            cs_email.MinimumWidth = 155;
            cs_email.Name = "cs_email";
            cs_email.ReadOnly = true;
            cs_email.Width = 155;
            // 
            // student_id
            // 
            student_id.HeaderText = "ID";
            student_id.MinimumWidth = 50;
            student_id.Name = "student_id";
            student_id.ReadOnly = true;
            student_id.Width = 50;
            // 
            // first_name
            // 
            first_name.HeaderText = "First name";
            first_name.MinimumWidth = 100;
            first_name.Name = "first_name";
            first_name.ReadOnly = true;
            // 
            // last_name
            // 
            last_name.HeaderText = "Last name";
            last_name.MinimumWidth = 100;
            last_name.Name = "last_name";
            last_name.ReadOnly = true;
            // 
            // email
            // 
            email.HeaderText = "Email";
            email.MinimumWidth = 155;
            email.Name = "email";
            email.ReadOnly = true;
            email.Width = 155;
            // 
            // academic_year
            // 
            academic_year.HeaderText = "Academic year";
            academic_year.MinimumWidth = 70;
            academic_year.Name = "academic_year";
            academic_year.ReadOnly = true;
            academic_year.Width = 70;
            // 
            // birth_date
            // 
            birth_date.HeaderText = "Birth date";
            birth_date.MinimumWidth = 70;
            birth_date.Name = "birth_date";
            birth_date.ReadOnly = true;
            birth_date.Width = 70;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 681);
            Controls.Add(panel_database);
            Controls.Add(panel_title);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StudentForm";
            Text = "University Management System";
            panel_title.ResumeLayout(false);
            panel_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picturebox_icon).EndInit();
            panel_database.ResumeLayout(false);
            panel_database.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numeric_scroll_cs_academic_year).EndInit();
            ((System.ComponentModel.ISupportInitialize)numeric_scroll_day).EndInit();
            ((System.ComponentModel.ISupportInitialize)numeric_scroll_month).EndInit();
            ((System.ComponentModel.ISupportInitialize)numeric_scroll_year).EndInit();
            ((System.ComponentModel.ISupportInitialize)data_gridview_course_student).EndInit();
            ((System.ComponentModel.ISupportInitialize)numeric_scroll_academic_year).EndInit();
            ((System.ComponentModel.ISupportInitialize)data_gridview_student).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_title;
        private PictureBox picturebox_icon;
        private Label label_title;
        private Panel panel_database;
        private Label label_student_title;
        private DataGridView data_gridview_student;
        private DataGridViewTextBoxColumn student_id;
        private DataGridViewTextBoxColumn first_name;
        private DataGridViewTextBoxColumn last_name;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn academic_year;
        private DataGridViewTextBoxColumn birth_date;
        private Label label_id;
        private Label label_first_name;
        private Label label_last_name;
        private Label label_email;
        private Label label_academic_year;
        private Label label_birth_date;
        private TextBox textbox_id;
        private TextBox textbox_first_name;
        private TextBox textbox_last_name;
        private TextBox textbox_email;
        private NumericUpDown numeric_scroll_academic_year;
        private NumericUpDown numeric_scroll_day;
        private NumericUpDown numeric_scroll_month;
        private NumericUpDown numeric_scroll_year;
        private ListView listview_filters;
        private ColumnHeader column_filters;
        private Button button_reset_id_counter;
        private Label label_current_max_id;
        private Button button_insert_student;
        private Button button_delete_student;
        private Button button_update_student;
        private Button button_search_student;
        private Button button_reset_student_filters;
        private Button button_refresh_student_table;
        private DataGridView data_gridview_course_student;
        private Label label_course_student_title;
        private Button button_search_course_student;
        private Button button_insert_course_student;
        private Button button_delete_course_student;
        private Button button_exit;
        private DataGridViewTextBoxColumn cs_student_id;
        private DataGridViewTextBoxColumn cs_course_id;
        private DataGridViewTextBoxColumn cs_course_title;
        private DataGridViewTextBoxColumn cs_course_academic_year;
        private DataGridViewTextBoxColumn cs_first_name;
        private DataGridViewTextBoxColumn cs_last_name;
        private DataGridViewTextBoxColumn cs_email;
        private RadioButton radiobutton_search_2;
        private RadioButton radiobutton_search_1;
        private Label label_cs_academic_year;
        private NumericUpDown numeric_scroll_cs_academic_year;
        private Label label_cs_course_id;
        private TextBox textbox_cs_course_id;
        private Label label_cs_student_id;
        private TextBox textbox_cs_student_id;
        private RadioButton radiobutton_search_3;
        private RadioButton radio_button_search_default;
        private Label label_cs_table_result;
    }
}