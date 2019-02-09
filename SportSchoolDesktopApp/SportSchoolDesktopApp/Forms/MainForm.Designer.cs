namespace SportSchoolDesktopApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonStudents = new System.Windows.Forms.Button();
            this.buttonTrainers = new System.Windows.Forms.Button();
            this.buttonSchedule = new System.Windows.Forms.Button();
            this.buttonReports = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.системаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cardEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSubscription = new System.Windows.Forms.Button();
            this.buttonGroups = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.grid_Schedule = new System.Windows.Forms.DataGridView();
            this.Time1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hall3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Schedule = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_WeekDay = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Schedule)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStudents
            // 
            this.buttonStudents.Location = new System.Drawing.Point(3, 50);
            this.buttonStudents.Name = "buttonStudents";
            this.buttonStudents.Size = new System.Drawing.Size(181, 42);
            this.buttonStudents.TabIndex = 3;
            this.buttonStudents.Text = "Ученики";
            this.buttonStudents.UseVisualStyleBackColor = true;
            this.buttonStudents.Click += new System.EventHandler(this.buttonStudents_Click);
            // 
            // buttonTrainers
            // 
            this.buttonTrainers.Location = new System.Drawing.Point(3, 98);
            this.buttonTrainers.Name = "buttonTrainers";
            this.buttonTrainers.Size = new System.Drawing.Size(181, 42);
            this.buttonTrainers.TabIndex = 4;
            this.buttonTrainers.Text = "Тренеры";
            this.buttonTrainers.UseVisualStyleBackColor = true;
            this.buttonTrainers.Click += new System.EventHandler(this.buttonTrainers_Click);
            // 
            // buttonSchedule
            // 
            this.buttonSchedule.Location = new System.Drawing.Point(3, 146);
            this.buttonSchedule.Name = "buttonSchedule";
            this.buttonSchedule.Size = new System.Drawing.Size(181, 42);
            this.buttonSchedule.TabIndex = 5;
            this.buttonSchedule.Text = "Занятия";
            this.buttonSchedule.UseVisualStyleBackColor = true;
            this.buttonSchedule.Click += new System.EventHandler(this.buttonSchedule_Click);
            // 
            // buttonReports
            // 
            this.buttonReports.Location = new System.Drawing.Point(3, 276);
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.Size = new System.Drawing.Size(181, 42);
            this.buttonReports.TabIndex = 6;
            this.buttonReports.Text = "Отчётность";
            this.buttonReports.UseVisualStyleBackColor = true;
            this.buttonReports.Click += new System.EventHandler(this.buttonReports_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 40);
            this.label1.TabIndex = 7;
            this.label1.Text = "Добавление и редактироание информации";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.системаToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(743, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // системаToolStripMenuItem
            // 
            this.системаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cardEditToolStripMenuItem});
            this.системаToolStripMenuItem.Name = "системаToolStripMenuItem";
            this.системаToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.системаToolStripMenuItem.Text = "Система";
            // 
            // cardEditToolStripMenuItem
            // 
            this.cardEditToolStripMenuItem.Name = "cardEditToolStripMenuItem";
            this.cardEditToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.cardEditToolStripMenuItem.Text = "Выдать карту";
            this.cardEditToolStripMenuItem.Click += new System.EventHandler(this.cardEditToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // buttonSubscription
            // 
            this.buttonSubscription.Location = new System.Drawing.Point(3, 324);
            this.buttonSubscription.Name = "buttonSubscription";
            this.buttonSubscription.Size = new System.Drawing.Size(181, 42);
            this.buttonSubscription.TabIndex = 9;
            this.buttonSubscription.Text = "Продлить абонемент";
            this.buttonSubscription.UseVisualStyleBackColor = true;
            this.buttonSubscription.Click += new System.EventHandler(this.buttonSubscription_Click);
            // 
            // buttonGroups
            // 
            this.buttonGroups.Location = new System.Drawing.Point(3, 194);
            this.buttonGroups.Name = "buttonGroups";
            this.buttonGroups.Size = new System.Drawing.Size(181, 42);
            this.buttonGroups.TabIndex = 10;
            this.buttonGroups.Text = "Группы";
            this.buttonGroups.UseVisualStyleBackColor = true;
            this.buttonGroups.Click += new System.EventHandler(this.buttonGroups_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(3, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Другие функции";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grid_Schedule
            // 
            this.grid_Schedule.AllowUserToAddRows = false;
            this.grid_Schedule.AllowUserToDeleteRows = false;
            this.grid_Schedule.AllowUserToResizeColumns = false;
            this.grid_Schedule.AllowUserToResizeRows = false;
            this.grid_Schedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_Schedule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_Schedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Schedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time1,
            this.Name2,
            this.Hall3,
            this.Count4,
            this.button_Schedule});
            this.grid_Schedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_Schedule.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid_Schedule.Location = new System.Drawing.Point(189, 54);
            this.grid_Schedule.MultiSelect = false;
            this.grid_Schedule.Name = "grid_Schedule";
            this.grid_Schedule.RowHeadersVisible = false;
            this.grid_Schedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_Schedule.Size = new System.Drawing.Size(554, 351);
            this.grid_Schedule.TabIndex = 12;
            this.grid_Schedule.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_Schedule_CellMouseUp);
            // 
            // Time1
            // 
            this.Time1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Time1.HeaderText = "Время";
            this.Time1.Name = "Time1";
            this.Time1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Time1.Width = 70;
            // 
            // Name2
            // 
            this.Name2.HeaderText = "Название";
            this.Name2.Name = "Name2";
            this.Name2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Hall3
            // 
            this.Hall3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Hall3.HeaderText = "Зал";
            this.Hall3.Name = "Hall3";
            this.Hall3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Hall3.Width = 60;
            // 
            // Count4
            // 
            this.Count4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Count4.HeaderText = "Кол-во учеников";
            this.Count4.Name = "Count4";
            this.Count4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Count4.Width = 60;
            // 
            // button_Schedule
            // 
            this.button_Schedule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.button_Schedule.HeaderText = "Регистрация";
            this.button_Schedule.Name = "button_Schedule";
            this.button_Schedule.Width = 150;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonStudents);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonTrainers);
            this.panel1.Controls.Add(this.buttonGroups);
            this.panel1.Controls.Add(this.buttonSchedule);
            this.panel1.Controls.Add(this.buttonSubscription);
            this.panel1.Controls.Add(this.buttonReports);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 381);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.comboBox_WeekDay);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(189, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 30);
            this.panel2.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(413, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 21);
            this.button1.TabIndex = 2;
            this.button1.Text = "Обновить расписание";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "День недели";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox_WeekDay
            // 
            this.comboBox_WeekDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_WeekDay.FormattingEnabled = true;
            this.comboBox_WeekDay.Items.AddRange(new object[] {
            "Понедельник",
            "Вторник",
            "Среда",
            "Четверг",
            "Пятница",
            "Суббота",
            "Воскресенье"});
            this.comboBox_WeekDay.Location = new System.Drawing.Point(90, 3);
            this.comboBox_WeekDay.Name = "comboBox_WeekDay";
            this.comboBox_WeekDay.Size = new System.Drawing.Size(163, 21);
            this.comboBox_WeekDay.TabIndex = 0;
            this.comboBox_WeekDay.SelectedIndexChanged += new System.EventHandler(this.comboBox_WeekDay_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 405);
            this.Controls.Add(this.grid_Schedule);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система учёта занятий";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Schedule)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStudents;
        private System.Windows.Forms.Button buttonTrainers;
        private System.Windows.Forms.Button buttonSchedule;
        private System.Windows.Forms.Button buttonReports;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button buttonSubscription;
        private System.Windows.Forms.Button buttonGroups;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grid_Schedule;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_WeekDay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem системаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cardEditToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hall3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count4;
        private System.Windows.Forms.DataGridViewButtonColumn button_Schedule;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}

