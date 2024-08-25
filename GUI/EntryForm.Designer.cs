namespace UniversityManagementSystem {
    partial class EntryForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryForm));
            panel_title = new Panel();
            picturebox_icon = new PictureBox();
            label_title = new Label();
            panel_connect = new Panel();
            panel_connection = new Panel();
            label_connection = new Label();
            button_connect = new Button();
            label_connection_title = new Label();
            label_connect_title = new Label();
            textbox_password = new TextBox();
            textbox_user = new TextBox();
            textbox_database = new TextBox();
            textbox_server = new TextBox();
            label_password = new Label();
            label_user = new Label();
            label_database = new Label();
            label_server = new Label();
            panel_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picturebox_icon).BeginInit();
            panel_connect.SuspendLayout();
            panel_connection.SuspendLayout();
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
            panel_title.Size = new Size(634, 80);
            panel_title.TabIndex = 0;
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
            panel_connect.Controls.Add(panel_connection);
            panel_connect.Controls.Add(button_connect);
            panel_connect.Controls.Add(label_connection_title);
            panel_connect.Controls.Add(label_connect_title);
            panel_connect.Controls.Add(textbox_password);
            panel_connect.Controls.Add(textbox_user);
            panel_connect.Controls.Add(textbox_database);
            panel_connect.Controls.Add(textbox_server);
            panel_connect.Controls.Add(label_password);
            panel_connect.Controls.Add(label_user);
            panel_connect.Controls.Add(label_database);
            panel_connect.Controls.Add(label_server);
            panel_connect.Dock = DockStyle.Fill;
            panel_connect.Location = new Point(0, 80);
            panel_connect.Name = "panel_connect";
            panel_connect.Size = new Size(634, 231);
            panel_connect.TabIndex = 2;
            // 
            // panel_connection
            // 
            panel_connection.BackColor = Color.White;
            panel_connection.Controls.Add(label_connection);
            panel_connection.Location = new Point(317, 41);
            panel_connection.Name = "panel_connection";
            panel_connection.Size = new Size(298, 156);
            panel_connection.TabIndex = 12;
            // 
            // label_connection
            // 
            label_connection.AutoSize = true;
            label_connection.Location = new Point(5, 5);
            label_connection.MaximumSize = new Size(290, 0);
            label_connection.Name = "label_connection";
            label_connection.Size = new Size(97, 15);
            label_connection.TabIndex = 0;
            label_connection.Text = "label_connection";
            // 
            // button_connect
            // 
            button_connect.BackColor = Color.White;
            button_connect.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button_connect.Location = new Point(138, 167);
            button_connect.Name = "button_connect";
            button_connect.Size = new Size(150, 30);
            button_connect.TabIndex = 11;
            button_connect.Text = "CONNECT";
            button_connect.UseVisualStyleBackColor = false;
            button_connect.Click += button_connect_Click;
            // 
            // label_connection_title
            // 
            label_connection_title.AutoSize = true;
            label_connection_title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_connection_title.ForeColor = Color.White;
            label_connection_title.Location = new Point(317, 10);
            label_connection_title.Name = "label_connection_title";
            label_connection_title.Size = new Size(133, 21);
            label_connection_title.TabIndex = 9;
            label_connection_title.Text = "Connection info";
            // 
            // label_connect_title
            // 
            label_connect_title.AutoSize = true;
            label_connect_title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label_connect_title.ForeColor = Color.White;
            label_connect_title.Location = new Point(12, 10);
            label_connect_title.Name = "label_connect_title";
            label_connect_title.Size = new Size(179, 21);
            label_connect_title.TabIndex = 8;
            label_connect_title.Text = "Connect to a database";
            // 
            // textbox_password
            // 
            textbox_password.Location = new Point(138, 134);
            textbox_password.Name = "textbox_password";
            textbox_password.Size = new Size(150, 23);
            textbox_password.TabIndex = 7;
            textbox_password.UseSystemPasswordChar = true;
            // 
            // textbox_user
            // 
            textbox_user.Location = new Point(138, 103);
            textbox_user.Name = "textbox_user";
            textbox_user.Size = new Size(150, 23);
            textbox_user.TabIndex = 6;
            // 
            // textbox_database
            // 
            textbox_database.Location = new Point(138, 72);
            textbox_database.Name = "textbox_database";
            textbox_database.Size = new Size(150, 23);
            textbox_database.TabIndex = 5;
            // 
            // textbox_server
            // 
            textbox_server.Location = new Point(138, 41);
            textbox_server.Name = "textbox_server";
            textbox_server.Size = new Size(150, 23);
            textbox_server.TabIndex = 4;
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Segoe UI", 10F);
            label_password.ForeColor = Color.White;
            label_password.Location = new Point(12, 134);
            label_password.Name = "label_password";
            label_password.Size = new Size(70, 19);
            label_password.TabIndex = 3;
            label_password.Text = "Password:";
            // 
            // label_user
            // 
            label_user.AutoSize = true;
            label_user.Font = new Font("Segoe UI", 10F);
            label_user.ForeColor = Color.White;
            label_user.Location = new Point(12, 103);
            label_user.Name = "label_user";
            label_user.Size = new Size(40, 19);
            label_user.TabIndex = 2;
            label_user.Text = "User:";
            // 
            // label_database
            // 
            label_database.AutoSize = true;
            label_database.Font = new Font("Segoe UI", 10F);
            label_database.ForeColor = Color.White;
            label_database.Location = new Point(12, 72);
            label_database.Name = "label_database";
            label_database.Size = new Size(69, 19);
            label_database.TabIndex = 1;
            label_database.Text = "Database:";
            // 
            // label_server
            // 
            label_server.AutoSize = true;
            label_server.Font = new Font("Segoe UI", 10F);
            label_server.ForeColor = Color.WhiteSmoke;
            label_server.Location = new Point(12, 41);
            label_server.Name = "label_server";
            label_server.Size = new Size(50, 19);
            label_server.TabIndex = 0;
            label_server.Text = "Server:";
            // 
            // EntryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 311);
            Controls.Add(panel_connect);
            Controls.Add(panel_title);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "EntryForm";
            Text = "University Management System";
            panel_title.ResumeLayout(false);
            panel_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picturebox_icon).EndInit();
            panel_connect.ResumeLayout(false);
            panel_connect.PerformLayout();
            panel_connection.ResumeLayout(false);
            panel_connection.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_title;
        private Label label_title;
        private PictureBox picturebox_icon;
        private Panel panel_connect;
        private Label label_server;
        private Label label_database;
        private Label label_user;
        private Label label_password;
        private TextBox textbox_server;
        private TextBox textbox_database;
        private TextBox textbox_user;
        private TextBox textbox_password;
        private Label label_connect_title;
        private Label label_connection_title;
        private Button button_connect;
        private Panel panel_connection;
        private Label label_connection;
    }
}
