using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace UniversityManagementSystem {
    partial class ProfessorForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfessorForm));
            cp_course_id = new DataGridViewTextBoxColumn();
            cp_professor_id = new DataGridViewTextBoxColumn();
            cp_course_title = new DataGridViewTextBoxColumn();
            cp_course_academic_year = new DataGridViewTextBoxColumn();
            professor_id = new DataGridViewTextBoxColumn();
            first_name = new DataGridViewTextBoxColumn();
            last_name = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            panel_title = new Panel();
            picturebox_icon = new PictureBox();
            label_title = new Label();
            panel_database = new Panel();
            textbox_email = new TextBox();
            label_email = new Label();
            label_cp_table_result = new Label();
            radio_button_search_default = new RadioButton();
            label_cp_academic_year = new Label();
            numeric_scroll_cp_academic_year = new NumericUpDown();
            label_cp_course_id = new Label();
            textbox_cp_course_id = new TextBox();
            label_cp_professor_id = new Label();
            textbox_cp_professor_id = new TextBox();
            radiobutton_search_3 = new RadioButton();
            radiobutton_search_2 = new RadioButton();
            radiobutton_search_1 = new RadioButton();
            label_current_max_id = new Label();
            button_reset_id_counter = new Button();
            button_refresh_professor_table = new Button();
            listview_filters = new ListView();
            column_filters = new ColumnHeader();
            button_reset_professor_filters = new Button();
            button_exit = new Button();
            button_delete_course_professor = new Button();
            button_insert_course_professor = new Button();
            button_search_course_professor = new Button();
            label_course_professor_title = new Label();
            data_gridview_course_professor = new DataGridView();
            button_delete_professor = new Button();
            button_insert_professor = new Button();
            button_update_professor = new Button();
            button_search_professor = new Button();
            label_professor_title = new Label();
            label_last_name = new Label();
            label_first_name = new Label();
            label_id = new Label();
            textbox_first_name = new TextBox();
            textbox_last_name = new TextBox();
            textbox_id = new TextBox();
            data_gridview_professor = new DataGridView();
            panel_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturebox_icon).BeginInit();
            panel_database.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numeric_scroll_cp_academic_year).BeginInit();
            ((System.ComponentModel.ISupportInitialize)data_gridview_course_professor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)data_gridview_professor).BeginInit();
            SuspendLayout();
            // 
            // cp_course_id
            // 
            cp_course_id.HeaderText = "Course ID";
            cp_course_id.MinimumWidth = 50;
            cp_course_id.Name = "cp_course_id";
            cp_course_id.ReadOnly = true;
            cp_course_id.Width = 50;
            // 
            // cp_professor_id
            // 
            cp_professor_id.HeaderText = "Professor ID";
            cp_professor_id.MinimumWidth = 65;
            cp_professor_id.Name = "cp_professor_id";
            cp_professor_id.ReadOnly = true;
            cp_professor_id.Width = 65;
            // 
            // cp_course_title
            // 
            cp_course_title.HeaderText = "Title";
            cp_course_title.MinimumWidth = 150;
            cp_course_title.Name = "cp_course_title";
            cp_course_title.ReadOnly = true;
            cp_course_title.Width = 150;
            // 
            // cp_course_academic_year
            // 
            cp_course_academic_year.HeaderText = "Academic year";
            cp_course_academic_year.MinimumWidth = 70;
            cp_course_academic_year.Name = "cp_course_academic_year";
            cp_course_academic_year.ReadOnly = true;
            cp_course_academic_year.Width = 70;
            // 
            // professor_id
            // 
            professor_id.HeaderText = "ID";
            professor_id.MinimumWidth = 50;
            professor_id.Name = "professor_id";
            professor_id.ReadOnly = true;
            professor_id.Width = 50;
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
            // panel_title
            // 
            panel_title.BackColor = Color.FromArgb(170, 0, 0);
            panel_title.Controls.Add(picturebox_icon);
            panel_title.Controls.Add(label_title);
            panel_title.Dock = DockStyle.Top;
            panel_title.Location = new Point(0, 0);
            panel_title.Name = "panel_title";
            panel_title.Size = new Size(1044, 70);
            panel_title.TabIndex = 2;
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
            panel_database.Controls.Add(textbox_email);
            panel_database.Controls.Add(label_email);
            panel_database.Controls.Add(label_cp_table_result);
            panel_database.Controls.Add(radio_button_search_default);
            panel_database.Controls.Add(label_cp_academic_year);
            panel_database.Controls.Add(numeric_scroll_cp_academic_year);
            panel_database.Controls.Add(label_cp_course_id);
            panel_database.Controls.Add(textbox_cp_course_id);
            panel_database.Controls.Add(label_cp_professor_id);
            panel_database.Controls.Add(textbox_cp_professor_id);
            panel_database.Controls.Add(radiobutton_search_3);
            panel_database.Controls.Add(radiobutton_search_2);
            panel_database.Controls.Add(radiobutton_search_1);
            panel_database.Controls.Add(label_current_max_id);
            panel_database.Controls.Add(button_reset_id_counter);
            panel_database.Controls.Add(button_refresh_professor_table);
            panel_database.Controls.Add(listview_filters);
            panel_database.Controls.Add(button_reset_professor_filters);
            panel_database.Controls.Add(button_exit);
            panel_database.Controls.Add(button_delete_course_professor);
            panel_database.Controls.Add(button_insert_course_professor);
            panel_database.Controls.Add(button_search_course_professor);
            panel_database.Controls.Add(label_course_professor_title);
            panel_database.Controls.Add(data_gridview_course_professor);
            panel_database.Controls.Add(button_delete_professor);
            panel_database.Controls.Add(button_insert_professor);
            panel_database.Controls.Add(button_update_professor);
            panel_database.Controls.Add(button_search_professor);
            panel_database.Controls.Add(label_professor_title);
            panel_database.Controls.Add(label_last_name);
            panel_database.Controls.Add(label_first_name);
            panel_database.Controls.Add(label_id);
            panel_database.Controls.Add(textbox_first_name);
            panel_database.Controls.Add(textbox_last_name);
            panel_database.Controls.Add(textbox_id);
            panel_database.Controls.Add(data_gridview_professor);
            panel_database.Dock = DockStyle.Fill;
            panel_database.Location = new Point(0, 70);
            panel_database.Name = "panel_database";
            panel_database.Size = new Size(1044, 611);
            panel_database.TabIndex = 7;
            // 
            // textbox_email
            // 
            textbox_email.Location = new Point(813, 134);
            textbox_email.Name = "textbox_email";
            textbox_email.Size = new Size(100, 23);
            textbox_email.TabIndex = 65;
            // 
            // label_email
            // 
            label_email.AutoSize = true;
            label_email.Font = new Font("Segoe UI", 10F);
            label_email.ForeColor = Color.White;
            label_email.Location = new Point(648, 135);
            label_email.Name = "label_email";
            label_email.Size = new Size(44, 19);
            label_email.TabIndex = 64;
            label_email.Text = "Email:";
            // 
            // label_cp_table_result
            // 
            label_cp_table_result.AutoSize = true;
            label_cp_table_result.Font = new Font("Segoe UI", 10F);
            label_cp_table_result.ForeColor = Color.White;
            label_cp_table_result.Location = new Point(205, 339);
            label_cp_table_result.Name = "label_cp_table_result";
            label_cp_table_result.Size = new Size(141, 19);
            label_cp_table_result.TabIndex = 63;
            label_cp_table_result.Text = "Courses by professor:";
            // 
            // radio_button_search_default
            // 
            radio_button_search_default.AutoSize = true;
            radio_button_search_default.Font = new Font("Segoe UI", 10F);
            radio_button_search_default.ForeColor = Color.White;
            radio_button_search_default.Location = new Point(458, 448);
            radio_button_search_default.Name = "radio_button_search_default";
            radio_button_search_default.Size = new Size(155, 23);
            radio_button_search_default.TabIndex = 62;
            radio_button_search_default.TabStop = true;
            radio_button_search_default.Text = "All courses-professor";
            radio_button_search_default.UseVisualStyleBackColor = true;
            // 
            // label_cp_academic_year
            // 
            label_cp_academic_year.AutoSize = true;
            label_cp_academic_year.Font = new Font("Segoe UI", 10F);
            label_cp_academic_year.ForeColor = Color.White;
            label_cp_academic_year.Location = new Point(458, 539);
            label_cp_academic_year.Name = "label_cp_academic_year";
            label_cp_academic_year.Size = new Size(100, 19);
            label_cp_academic_year.TabIndex = 61;
            label_cp_academic_year.Text = "Academic year:";
            // 
            // numeric_scroll_cp_academic_year
            // 
            numeric_scroll_cp_academic_year.Location = new Point(610, 537);
            numeric_scroll_cp_academic_year.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numeric_scroll_cp_academic_year.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numeric_scroll_cp_academic_year.Name = "numeric_scroll_cp_academic_year";
            numeric_scroll_cp_academic_year.Size = new Size(50, 23);
            numeric_scroll_cp_academic_year.TabIndex = 60;
            numeric_scroll_cp_academic_year.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label_cp_course_id
            // 
            label_cp_course_id.AutoSize = true;
            label_cp_course_id.Font = new Font("Segoe UI", 10F);
            label_cp_course_id.ForeColor = Color.White;
            label_cp_course_id.Location = new Point(458, 509);
            label_cp_course_id.Name = "label_cp_course_id";
            label_cp_course_id.Size = new Size(73, 19);
            label_cp_course_id.TabIndex = 59;
            label_cp_course_id.Text = "Course ID:";
            // 
            // textbox_cp_course_id
            // 
            textbox_cp_course_id.Location = new Point(560, 508);
            textbox_cp_course_id.Name = "textbox_cp_course_id";
            textbox_cp_course_id.Size = new Size(100, 23);
            textbox_cp_course_id.TabIndex = 58;
            // 
            // label_cp_professor_id
            // 
            label_cp_professor_id.AutoSize = true;
            label_cp_professor_id.Font = new Font("Segoe UI", 10F);
            label_cp_professor_id.ForeColor = Color.White;
            label_cp_professor_id.Location = new Point(458, 480);
            label_cp_professor_id.Name = "label_cp_professor_id";
            label_cp_professor_id.Size = new Size(87, 19);
            label_cp_professor_id.TabIndex = 57;
            label_cp_professor_id.Text = "Professor ID:";
            // 
            // textbox_cp_professor_id
            // 
            textbox_cp_professor_id.Location = new Point(560, 479);
            textbox_cp_professor_id.Name = "textbox_cp_professor_id";
            textbox_cp_professor_id.Size = new Size(100, 23);
            textbox_cp_professor_id.TabIndex = 56;
            // 
            // radiobutton_search_3
            // 
            radiobutton_search_3.AutoSize = true;
            radiobutton_search_3.Font = new Font("Segoe UI", 10F);
            radiobutton_search_3.ForeColor = Color.White;
            radiobutton_search_3.Location = new Point(458, 419);
            radiobutton_search_3.Name = "radiobutton_search_3";
            radiobutton_search_3.Size = new Size(278, 23);
            radiobutton_search_3.TabIndex = 55;
            radiobutton_search_3.TabStop = true;
            radiobutton_search_3.Text = "All professors of course by academic year";
            radiobutton_search_3.UseVisualStyleBackColor = true;
            // 
            // radiobutton_search_2
            // 
            radiobutton_search_2.AutoSize = true;
            radiobutton_search_2.Font = new Font("Segoe UI", 10F);
            radiobutton_search_2.ForeColor = Color.White;
            radiobutton_search_2.Location = new Point(458, 390);
            radiobutton_search_2.Name = "radiobutton_search_2";
            radiobutton_search_2.Size = new Size(172, 23);
            radiobutton_search_2.TabIndex = 54;
            radiobutton_search_2.TabStop = true;
            radiobutton_search_2.Text = "All professors by course";
            radiobutton_search_2.UseVisualStyleBackColor = true;
            // 
            // radiobutton_search_1
            // 
            radiobutton_search_1.AutoSize = true;
            radiobutton_search_1.Font = new Font("Segoe UI", 10F);
            radiobutton_search_1.ForeColor = Color.White;
            radiobutton_search_1.Location = new Point(458, 361);
            radiobutton_search_1.Name = "radiobutton_search_1";
            radiobutton_search_1.Size = new Size(172, 23);
            radiobutton_search_1.TabIndex = 53;
            radiobutton_search_1.TabStop = true;
            radiobutton_search_1.Text = "All courses by professor";
            radiobutton_search_1.UseVisualStyleBackColor = true;
            // 
            // label_current_max_id
            // 
            label_current_max_id.AutoSize = true;
            label_current_max_id.Font = new Font("Segoe UI", 10F);
            label_current_max_id.ForeColor = Color.White;
            label_current_max_id.Location = new Point(813, 298);
            label_current_max_id.Name = "label_current_max_id";
            label_current_max_id.Size = new Size(62, 19);
            label_current_max_id.TabIndex = 51;
            label_current_max_id.Text = "Next ID: ";
            // 
            // button_reset_id_counter
            // 
            button_reset_id_counter.BackColor = Color.LavenderBlush;
            button_reset_id_counter.FlatStyle = FlatStyle.Popup;
            button_reset_id_counter.Location = new Point(648, 292);
            button_reset_id_counter.Name = "button_reset_id_counter";
            button_reset_id_counter.Size = new Size(150, 30);
            button_reset_id_counter.TabIndex = 50;
            button_reset_id_counter.Text = "RESET IDs COUNTER";
            button_reset_id_counter.UseVisualStyleBackColor = false;
            // 
            // button_refresh_professor_table
            // 
            button_refresh_professor_table.BackColor = Color.LavenderBlush;
            button_refresh_professor_table.FlatStyle = FlatStyle.Popup;
            button_refresh_professor_table.Location = new Point(931, 287);
            button_refresh_professor_table.Name = "button_refresh_professor_table";
            button_refresh_professor_table.Size = new Size(100, 30);
            button_refresh_professor_table.TabIndex = 49;
            button_refresh_professor_table.Text = "REFRESH TABLE";
            button_refresh_professor_table.UseVisualStyleBackColor = false;
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
            listview_filters.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4 });
            listview_filters.Location = new Point(648, 163);
            listview_filters.Name = "listview_filters";
            listview_filters.Size = new Size(265, 81);
            listview_filters.TabIndex = 47;
            listview_filters.UseCompatibleStateImageBehavior = false;
            listview_filters.View = View.Details;
            // 
            // column_filters
            // 
            column_filters.Width = 150;
            // 
            // button_reset_professor_filters
            // 
            button_reset_professor_filters.BackColor = Color.LavenderBlush;
            button_reset_professor_filters.FlatStyle = FlatStyle.Popup;
            button_reset_professor_filters.Location = new Point(931, 251);
            button_reset_professor_filters.Name = "button_reset_professor_filters";
            button_reset_professor_filters.Size = new Size(100, 30);
            button_reset_professor_filters.TabIndex = 41;
            button_reset_professor_filters.Text = "RESET FILTERS";
            button_reset_professor_filters.UseVisualStyleBackColor = false;
            // 
            // button_exit
            // 
            button_exit.BackColor = Color.White;
            button_exit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button_exit.Location = new Point(881, 559);
            button_exit.Name = "button_exit";
            button_exit.Size = new Size(150, 40);
            button_exit.TabIndex = 28;
            button_exit.Text = "RETURN TO MENU";
            button_exit.UseVisualStyleBackColor = false;
            button_exit.Click += button_exit_Click;
            // 
            // button_delete_course_professor
            // 
            button_delete_course_professor.BackColor = Color.Red;
            button_delete_course_professor.FlatStyle = FlatStyle.Popup;
            button_delete_course_professor.Location = new Point(671, 572);
            button_delete_course_professor.Name = "button_delete_course_professor";
            button_delete_course_professor.Size = new Size(100, 30);
            button_delete_course_professor.TabIndex = 27;
            button_delete_course_professor.Text = "DELETE";
            button_delete_course_professor.UseVisualStyleBackColor = false;
            // 
            // button_insert_course_professor
            // 
            button_insert_course_professor.BackColor = Color.Chartreuse;
            button_insert_course_professor.FlatStyle = FlatStyle.Popup;
            button_insert_course_professor.Location = new Point(565, 572);
            button_insert_course_professor.Name = "button_insert_course_professor";
            button_insert_course_professor.Size = new Size(100, 30);
            button_insert_course_professor.TabIndex = 26;
            button_insert_course_professor.Text = "INSERT";
            button_insert_course_professor.UseVisualStyleBackColor = false;
            // 
            // button_search_course_professor
            // 
            button_search_course_professor.BackColor = Color.PaleTurquoise;
            button_search_course_professor.FlatStyle = FlatStyle.Popup;
            button_search_course_professor.Location = new Point(458, 572);
            button_search_course_professor.Name = "button_search_course_professor";
            button_search_course_professor.Size = new Size(100, 30);
            button_search_course_professor.TabIndex = 24;
            button_search_course_professor.Text = "SEARCH";
            button_search_course_professor.UseVisualStyleBackColor = false;
            // 
            // label_course_professor_title
            // 
            label_course_professor_title.AutoSize = true;
            label_course_professor_title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_course_professor_title.ForeColor = Color.White;
            label_course_professor_title.Location = new Point(12, 337);
            label_course_professor_title.Name = "label_course_professor_title";
            label_course_professor_title.Size = new Size(192, 21);
            label_course_professor_title.TabIndex = 19;
            label_course_professor_title.Text = "Courses-professors info:";
            // 
            // data_gridview_course_professor
            // 
            data_gridview_course_professor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data_gridview_course_professor.Location = new Point(12, 362);
            data_gridview_course_professor.Name = "data_gridview_course_professor";
            data_gridview_course_professor.ReadOnly = true;
            data_gridview_course_professor.Size = new Size(440, 240);
            data_gridview_course_professor.TabIndex = 18;
            // 
            // button_delete_professor
            // 
            button_delete_professor.BackColor = Color.Red;
            button_delete_professor.FlatStyle = FlatStyle.Popup;
            button_delete_professor.Location = new Point(931, 115);
            button_delete_professor.Name = "button_delete_professor";
            button_delete_professor.Size = new Size(100, 30);
            button_delete_professor.TabIndex = 17;
            button_delete_professor.Text = "DELETE";
            button_delete_professor.UseVisualStyleBackColor = false;
            // 
            // button_insert_professor
            // 
            button_insert_professor.BackColor = Color.Chartreuse;
            button_insert_professor.FlatStyle = FlatStyle.Popup;
            button_insert_professor.ImageAlign = ContentAlignment.MiddleLeft;
            button_insert_professor.Location = new Point(931, 43);
            button_insert_professor.Name = "button_insert_professor";
            button_insert_professor.Size = new Size(100, 30);
            button_insert_professor.TabIndex = 16;
            button_insert_professor.Text = "INSERT";
            button_insert_professor.UseVisualStyleBackColor = false;
            button_insert_professor.Click += button_insert_professor_Click;
            // 
            // button_update_professor
            // 
            button_update_professor.BackColor = Color.Gold;
            button_update_professor.FlatStyle = FlatStyle.Popup;
            button_update_professor.Location = new Point(931, 79);
            button_update_professor.Name = "button_update_professor";
            button_update_professor.Size = new Size(100, 30);
            button_update_professor.TabIndex = 15;
            button_update_professor.Text = "UPDATE";
            button_update_professor.UseVisualStyleBackColor = false;
            // 
            // button_search_professor
            // 
            button_search_professor.BackColor = Color.PaleTurquoise;
            button_search_professor.FlatStyle = FlatStyle.Popup;
            button_search_professor.Location = new Point(931, 215);
            button_search_professor.Name = "button_search_professor";
            button_search_professor.Size = new Size(100, 30);
            button_search_professor.TabIndex = 14;
            button_search_professor.Text = "SEARCH";
            button_search_professor.UseVisualStyleBackColor = false;
            // 
            // label_professor_title
            // 
            label_professor_title.AutoSize = true;
            label_professor_title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_professor_title.ForeColor = Color.White;
            label_professor_title.Location = new Point(12, 20);
            label_professor_title.Name = "label_professor_title";
            label_professor_title.Size = new Size(127, 21);
            label_professor_title.TabIndex = 13;
            label_professor_title.Text = "Professors info:";
            // 
            // label_last_name
            // 
            label_last_name.AutoSize = true;
            label_last_name.Font = new Font("Segoe UI", 10F);
            label_last_name.ForeColor = Color.White;
            label_last_name.Location = new Point(648, 105);
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
            label_first_name.Location = new Point(647, 75);
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
            label_id.Location = new Point(648, 45);
            label_id.Name = "label_id";
            label_id.Size = new Size(26, 19);
            label_id.TabIndex = 7;
            label_id.Text = "ID:";
            // 
            // textbox_first_name
            // 
            textbox_first_name.Location = new Point(813, 74);
            textbox_first_name.Name = "textbox_first_name";
            textbox_first_name.Size = new Size(100, 23);
            textbox_first_name.TabIndex = 6;
            // 
            // textbox_last_name
            // 
            textbox_last_name.Location = new Point(813, 104);
            textbox_last_name.Name = "textbox_last_name";
            textbox_last_name.Size = new Size(100, 23);
            textbox_last_name.TabIndex = 5;
            // 
            // textbox_id
            // 
            textbox_id.Location = new Point(883, 44);
            textbox_id.Name = "textbox_id";
            textbox_id.Size = new Size(30, 23);
            textbox_id.TabIndex = 1;
            // 
            // data_gridview_professor
            // 
            data_gridview_professor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data_gridview_professor.Location = new Point(12, 44);
            data_gridview_professor.Name = "data_gridview_professor";
            data_gridview_professor.ReadOnly = true;
            data_gridview_professor.Size = new Size(620, 278);
            data_gridview_professor.TabIndex = 0;
            // 
            // ProfessorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 681);
            Controls.Add(panel_database);
            Controls.Add(panel_title);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ProfessorForm";
            Text = "University Management System";
            panel_title.ResumeLayout(false);
            panel_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picturebox_icon).EndInit();
            panel_database.ResumeLayout(false);
            panel_database.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numeric_scroll_cp_academic_year).EndInit();
            ((System.ComponentModel.ISupportInitialize)data_gridview_course_professor).EndInit();
            ((System.ComponentModel.ISupportInitialize)data_gridview_professor).EndInit();
            ResumeLayout(false);
        }

        #endregion
        /*
        private DataGridViewTextBoxColumn course_id_2;
        private DataGridViewTextBoxColumn course_field_title;
        private DataGridViewTextBoxColumn course_academic_year;
        */
        private Panel panel_title;
        private PictureBox picturebox_icon;
        private Label label_title;
        private Panel panel_database;
        private Label label_cp_table_result;
        private RadioButton radio_button_search_default;
        private Label label_cp_academic_year;
        private NumericUpDown numeric_scroll_cp_academic_year;
        private Label label_cp_course_id;
        private Label label_cp_professor_id;
        private TextBox textbox_cp_course_id;
        private TextBox textbox_cp_professor_id;
        private RadioButton radiobutton_search_2;
        private RadioButton radiobutton_search_1;
        private Label label_current_max_id;
        private Button button_reset_id_counter;
        private Button button_refresh_professor_table;
        private ListView listview_filters;
        private ColumnHeader column_filters;
        private Button button_reset_professor_filters;
        private Button button_exit;
        private Button button_delete_course_professor;
        private Button button_insert_course_professor;
        private Button button_search_course_professor;
        private Label label_course_professor_title;
        private DataGridView data_gridview_course_professor;
        private DataGridViewTextBoxColumn cp_course_id;
        private DataGridViewTextBoxColumn cp_professor_id;
        private DataGridViewTextBoxColumn cp_course_title;
        private DataGridViewTextBoxColumn cp_course_academic_year;
        private DataGridViewTextBoxColumn professor_id;
        private DataGridViewTextBoxColumn first_name;
        private DataGridViewTextBoxColumn last_name;
        private DataGridViewTextBoxColumn email;
        private Button button_delete_professor;
        private Button button_insert_professor;
        private Button button_update_professor;
        private Button button_search_professor;
        private Label label_professor_title;
        private Label label_last_name;
        private Label label_first_name;
        private Label label_id;
        private TextBox textbox_first_name;
        private TextBox textbox_last_name;
        private TextBox textbox_id;
        private DataGridView data_gridview_professor;
        private Label label_email;
        private TextBox textbox_email;
        private RadioButton radiobutton_search_3;
    }
}