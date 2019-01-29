namespace SportSchoolDesktopApp.Forms
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_FromName = new System.Windows.Forms.Label();
            this.groupBox_Session = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listBox_Students = new System.Windows.Forms.ListBox();
            this.label_SessionTime = new System.Windows.Forms.Label();
            this.label_SessionTrainer = new System.Windows.Forms.Label();
            this.label_SessionGroup = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Action = new System.Windows.Forms.Button();
            this.label_StudentId = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_ChooseStudent = new System.Windows.Forms.Button();
            this.label_StudentSubShort = new System.Windows.Forms.Label();
            this.label_StudentFullName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label_VisitsInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_Session.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_FromName
            // 
            this.label_FromName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FromName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_FromName.Location = new System.Drawing.Point(12, 9);
            this.label_FromName.Name = "label_FromName";
            this.label_FromName.Size = new System.Drawing.Size(612, 27);
            this.label_FromName.TabIndex = 1;
            this.label_FromName.Text = "Название формы";
            this.label_FromName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox_Session
            // 
            this.groupBox_Session.Controls.Add(this.label9);
            this.groupBox_Session.Controls.Add(this.listBox_Students);
            this.groupBox_Session.Controls.Add(this.label_SessionTime);
            this.groupBox_Session.Controls.Add(this.label_SessionTrainer);
            this.groupBox_Session.Controls.Add(this.label_SessionGroup);
            this.groupBox_Session.Controls.Add(this.label4);
            this.groupBox_Session.Controls.Add(this.label3);
            this.groupBox_Session.Controls.Add(this.label2);
            this.groupBox_Session.Location = new System.Drawing.Point(12, 39);
            this.groupBox_Session.Name = "groupBox_Session";
            this.groupBox_Session.Size = new System.Drawing.Size(294, 339);
            this.groupBox_Session.TabIndex = 2;
            this.groupBox_Session.TabStop = false;
            this.groupBox_Session.Text = "Занятие";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(6, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(282, 24);
            this.label9.TabIndex = 9;
            this.label9.Text = "Зарегистрированые ученики";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox_Students
            // 
            this.listBox_Students.FormattingEnabled = true;
            this.listBox_Students.Location = new System.Drawing.Point(6, 134);
            this.listBox_Students.Name = "listBox_Students";
            this.listBox_Students.Size = new System.Drawing.Size(282, 199);
            this.listBox_Students.TabIndex = 8;
            // 
            // label_SessionTime
            // 
            this.label_SessionTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_SessionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_SessionTime.Location = new System.Drawing.Point(66, 66);
            this.label_SessionTime.Name = "label_SessionTime";
            this.label_SessionTime.Size = new System.Drawing.Size(222, 24);
            this.label_SessionTime.TabIndex = 7;
            this.label_SessionTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_SessionTrainer
            // 
            this.label_SessionTrainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_SessionTrainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_SessionTrainer.Location = new System.Drawing.Point(66, 43);
            this.label_SessionTrainer.Name = "label_SessionTrainer";
            this.label_SessionTrainer.Size = new System.Drawing.Size(222, 24);
            this.label_SessionTrainer.TabIndex = 6;
            this.label_SessionTrainer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_SessionGroup
            // 
            this.label_SessionGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_SessionGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_SessionGroup.Location = new System.Drawing.Point(66, 20);
            this.label_SessionGroup.Name = "label_SessionGroup";
            this.label_SessionGroup.Size = new System.Drawing.Size(222, 24);
            this.label_SessionGroup.TabIndex = 5;
            this.label_SessionGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Время:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тренер:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Группа:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label_VisitsInfo);
            this.groupBox2.Controls.Add(this.button_Action);
            this.groupBox2.Controls.Add(this.label_StudentId);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.button_ChooseStudent);
            this.groupBox2.Controls.Add(this.label_StudentSubShort);
            this.groupBox2.Controls.Add(this.label_StudentFullName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(312, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 339);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ученик";
            // 
            // button_Action
            // 
            this.button_Action.Enabled = false;
            this.button_Action.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Action.Location = new System.Drawing.Point(6, 269);
            this.button_Action.Name = "button_Action";
            this.button_Action.Size = new System.Drawing.Size(303, 64);
            this.button_Action.TabIndex = 15;
            this.button_Action.Text = "Отметить ученика";
            this.button_Action.UseVisualStyleBackColor = true;
            this.button_Action.Click += new System.EventHandler(this.button_Action_Click);
            // 
            // label_StudentId
            // 
            this.label_StudentId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_StudentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_StudentId.Location = new System.Drawing.Point(82, 58);
            this.label_StudentId.Name = "label_StudentId";
            this.label_StudentId.Size = new System.Drawing.Size(102, 24);
            this.label_StudentId.TabIndex = 13;
            this.label_StudentId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 24);
            this.label8.TabIndex = 12;
            this.label8.Text = "Ид:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_ChooseStudent
            // 
            this.button_ChooseStudent.Location = new System.Drawing.Point(190, 58);
            this.button_ChooseStudent.Name = "button_ChooseStudent";
            this.button_ChooseStudent.Size = new System.Drawing.Size(120, 23);
            this.button_ChooseStudent.TabIndex = 4;
            this.button_ChooseStudent.Text = "Выбрать ученика";
            this.button_ChooseStudent.UseVisualStyleBackColor = true;
            this.button_ChooseStudent.Click += new System.EventHandler(this.button_ChooseStudent_Click);
            // 
            // label_StudentSubShort
            // 
            this.label_StudentSubShort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_StudentSubShort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_StudentSubShort.Location = new System.Drawing.Point(82, 104);
            this.label_StudentSubShort.Name = "label_StudentSubShort";
            this.label_StudentSubShort.Size = new System.Drawing.Size(227, 134);
            this.label_StudentSubShort.TabIndex = 11;
            this.label_StudentSubShort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_StudentFullName
            // 
            this.label_StudentFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_StudentFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_StudentFullName.Location = new System.Drawing.Point(82, 81);
            this.label_StudentFullName.Name = "label_StudentFullName";
            this.label_StudentFullName.Size = new System.Drawing.Size(227, 24);
            this.label_StudentFullName.TabIndex = 10;
            this.label_StudentFullName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 33);
            this.label5.TabIndex = 8;
            this.label5.Text = "Необходимо поднести карту к смарт-ридеру, либо нажать на кнопку «Выбрать ученика»" +
    "";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 24);
            this.label12.TabIndex = 5;
            this.label12.Text = "Абонемент:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(6, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 24);
            this.label13.TabIndex = 4;
            this.label13.Text = "ФИО:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_VisitsInfo
            // 
            this.label_VisitsInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_VisitsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_VisitsInfo.Location = new System.Drawing.Point(82, 237);
            this.label_VisitsInfo.Name = "label_VisitsInfo";
            this.label_VisitsInfo.Size = new System.Drawing.Size(227, 28);
            this.label_VisitsInfo.TabIndex = 16;
            this.label_VisitsInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Посещений:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 390);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox_Session);
            this.Controls.Add(this.label_FromName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterForm_FormClosed);
            this.groupBox_Session.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_FromName;
        private System.Windows.Forms.GroupBox groupBox_Session;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listBox_Students;
        private System.Windows.Forms.Label label_SessionTime;
        private System.Windows.Forms.Label label_SessionTrainer;
        private System.Windows.Forms.Label label_SessionGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_StudentId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_ChooseStudent;
        private System.Windows.Forms.Label label_StudentSubShort;
        private System.Windows.Forms.Label label_StudentFullName;
        private System.Windows.Forms.Button button_Action;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_VisitsInfo;
    }
}