namespace SportSchoolDesktopApp.Forms
{
    partial class SubscribeForm
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
            this.label_StudentId = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_ChooseStudent = new System.Windows.Forms.Button();
            this.label_StudentFullName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_SubFirst = new System.Windows.Forms.Button();
            this.button_SubLast = new System.Windows.Forms.Button();
            this.button_SubPrev = new System.Windows.Forms.Button();
            this.button_SubNext = new System.Windows.Forms.Button();
            this.label_SubPages = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.listBox_Subscriptions = new System.Windows.Forms.ListBox();
            this.label_FromName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelAbonent_Hours = new System.Windows.Forms.Label();
            this.labelAbonent_Time = new System.Windows.Forms.Label();
            this.labelAbonent_CardType = new System.Windows.Forms.Label();
            this.labelAbonent_BuyTime = new System.Windows.Forms.Label();
            this.labelAbonent_Group = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.labelAbonent_Id = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button_Buy = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_StudentId
            // 
            this.label_StudentId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_StudentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_StudentId.Location = new System.Drawing.Point(61, 58);
            this.label_StudentId.Name = "label_StudentId";
            this.label_StudentId.Size = new System.Drawing.Size(123, 24);
            this.label_StudentId.TabIndex = 13;
            this.label_StudentId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 24);
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
            // label_StudentFullName
            // 
            this.label_StudentFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_StudentFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_StudentFullName.Location = new System.Drawing.Point(61, 81);
            this.label_StudentFullName.Name = "label_StudentFullName";
            this.label_StudentFullName.Size = new System.Drawing.Size(248, 24);
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
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(6, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 24);
            this.label13.TabIndex = 4;
            this.label13.Text = "ФИО:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_SubFirst);
            this.groupBox2.Controls.Add(this.button_SubLast);
            this.groupBox2.Controls.Add(this.button_SubPrev);
            this.groupBox2.Controls.Add(this.button_SubNext);
            this.groupBox2.Controls.Add(this.label_SubPages);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.listBox_Subscriptions);
            this.groupBox2.Controls.Add(this.label_StudentId);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.button_ChooseStudent);
            this.groupBox2.Controls.Add(this.label_StudentFullName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(12, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 312);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ученик";
            // 
            // button_SubFirst
            // 
            this.button_SubFirst.Enabled = false;
            this.button_SubFirst.Location = new System.Drawing.Point(9, 283);
            this.button_SubFirst.Name = "button_SubFirst";
            this.button_SubFirst.Size = new System.Drawing.Size(46, 23);
            this.button_SubFirst.TabIndex = 41;
            this.button_SubFirst.Text = "<<";
            this.button_SubFirst.UseVisualStyleBackColor = true;
            this.button_SubFirst.Click += new System.EventHandler(this.button_SubFirst_Click);
            // 
            // button_SubLast
            // 
            this.button_SubLast.Enabled = false;
            this.button_SubLast.Location = new System.Drawing.Point(264, 283);
            this.button_SubLast.Name = "button_SubLast";
            this.button_SubLast.Size = new System.Drawing.Size(46, 23);
            this.button_SubLast.TabIndex = 40;
            this.button_SubLast.Text = ">>";
            this.button_SubLast.UseVisualStyleBackColor = true;
            this.button_SubLast.Click += new System.EventHandler(this.button_SubLast_Click);
            // 
            // button_SubPrev
            // 
            this.button_SubPrev.Enabled = false;
            this.button_SubPrev.Location = new System.Drawing.Point(61, 283);
            this.button_SubPrev.Name = "button_SubPrev";
            this.button_SubPrev.Size = new System.Drawing.Size(46, 23);
            this.button_SubPrev.TabIndex = 39;
            this.button_SubPrev.Text = "<";
            this.button_SubPrev.UseVisualStyleBackColor = true;
            this.button_SubPrev.Click += new System.EventHandler(this.button_SubPrev_Click);
            // 
            // button_SubNext
            // 
            this.button_SubNext.Enabled = false;
            this.button_SubNext.Location = new System.Drawing.Point(212, 283);
            this.button_SubNext.Name = "button_SubNext";
            this.button_SubNext.Size = new System.Drawing.Size(46, 23);
            this.button_SubNext.TabIndex = 37;
            this.button_SubNext.Text = ">";
            this.button_SubNext.UseVisualStyleBackColor = true;
            this.button_SubNext.Click += new System.EventHandler(this.button_SubNext_Click);
            // 
            // label_SubPages
            // 
            this.label_SubPages.Location = new System.Drawing.Point(113, 283);
            this.label_SubPages.Name = "label_SubPages";
            this.label_SubPages.Size = new System.Drawing.Size(93, 23);
            this.label_SubPages.TabIndex = 38;
            this.label_SubPages.Text = "1 / 1";
            this.label_SubPages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(6, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(303, 24);
            this.label9.TabIndex = 15;
            this.label9.Text = "Абонементы пользователя";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox_Subscriptions
            // 
            this.listBox_Subscriptions.FormattingEnabled = true;
            this.listBox_Subscriptions.Location = new System.Drawing.Point(9, 133);
            this.listBox_Subscriptions.Name = "listBox_Subscriptions";
            this.listBox_Subscriptions.Size = new System.Drawing.Size(300, 147);
            this.listBox_Subscriptions.TabIndex = 14;
            this.listBox_Subscriptions.SelectedIndexChanged += new System.EventHandler(this.listBox_Subscriptions_SelectedIndexChanged);
            // 
            // label_FromName
            // 
            this.label_FromName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FromName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_FromName.Location = new System.Drawing.Point(12, 9);
            this.label_FromName.Name = "label_FromName";
            this.label_FromName.Size = new System.Drawing.Size(636, 27);
            this.label_FromName.TabIndex = 14;
            this.label_FromName.Text = "Просмотр и покупка абонементов";
            this.label_FromName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Edit);
            this.groupBox1.Controls.Add(this.labelAbonent_Hours);
            this.groupBox1.Controls.Add(this.labelAbonent_Time);
            this.groupBox1.Controls.Add(this.labelAbonent_CardType);
            this.groupBox1.Controls.Add(this.labelAbonent_BuyTime);
            this.groupBox1.Controls.Add(this.labelAbonent_Group);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.labelAbonent_Id);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.button_Buy);
            this.groupBox1.Location = new System.Drawing.Point(333, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 312);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Абонемент";
            // 
            // labelAbonent_Hours
            // 
            this.labelAbonent_Hours.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAbonent_Hours.ForeColor = System.Drawing.Color.Green;
            this.labelAbonent_Hours.Location = new System.Drawing.Point(95, 150);
            this.labelAbonent_Hours.Name = "labelAbonent_Hours";
            this.labelAbonent_Hours.Size = new System.Drawing.Size(209, 24);
            this.labelAbonent_Hours.TabIndex = 36;
            this.labelAbonent_Hours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAbonent_Time
            // 
            this.labelAbonent_Time.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAbonent_Time.ForeColor = System.Drawing.Color.Green;
            this.labelAbonent_Time.Location = new System.Drawing.Point(95, 111);
            this.labelAbonent_Time.Name = "labelAbonent_Time";
            this.labelAbonent_Time.Size = new System.Drawing.Size(209, 39);
            this.labelAbonent_Time.TabIndex = 35;
            this.labelAbonent_Time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAbonent_CardType
            // 
            this.labelAbonent_CardType.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAbonent_CardType.ForeColor = System.Drawing.Color.Green;
            this.labelAbonent_CardType.Location = new System.Drawing.Point(95, 87);
            this.labelAbonent_CardType.Name = "labelAbonent_CardType";
            this.labelAbonent_CardType.Size = new System.Drawing.Size(209, 24);
            this.labelAbonent_CardType.TabIndex = 34;
            this.labelAbonent_CardType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAbonent_BuyTime
            // 
            this.labelAbonent_BuyTime.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAbonent_BuyTime.ForeColor = System.Drawing.Color.Green;
            this.labelAbonent_BuyTime.Location = new System.Drawing.Point(95, 63);
            this.labelAbonent_BuyTime.Name = "labelAbonent_BuyTime";
            this.labelAbonent_BuyTime.Size = new System.Drawing.Size(209, 24);
            this.labelAbonent_BuyTime.TabIndex = 33;
            this.labelAbonent_BuyTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAbonent_Group
            // 
            this.labelAbonent_Group.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAbonent_Group.ForeColor = System.Drawing.Color.Green;
            this.labelAbonent_Group.Location = new System.Drawing.Point(95, 39);
            this.labelAbonent_Group.Name = "labelAbonent_Group";
            this.labelAbonent_Group.Size = new System.Drawing.Size(209, 24);
            this.labelAbonent_Group.TabIndex = 32;
            this.labelAbonent_Group.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(6, 151);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 23);
            this.label17.TabIndex = 31;
            this.label17.Text = "Походов:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAbonent_Id
            // 
            this.labelAbonent_Id.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAbonent_Id.ForeColor = System.Drawing.Color.Green;
            this.labelAbonent_Id.Location = new System.Drawing.Point(95, 15);
            this.labelAbonent_Id.Name = "labelAbonent_Id";
            this.labelAbonent_Id.Size = new System.Drawing.Size(209, 24);
            this.labelAbonent_Id.TabIndex = 26;
            this.labelAbonent_Id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(5, 112);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 38);
            this.label14.TabIndex = 24;
            this.label14.Text = "Действует:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(5, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 24);
            this.label10.TabIndex = 22;
            this.label10.Text = "Тип карты:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "Куплен (дата):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Ид:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 24);
            this.label12.TabIndex = 15;
            this.label12.Text = "Группа:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_Buy
            // 
            this.button_Buy.Location = new System.Drawing.Point(161, 283);
            this.button_Buy.Name = "button_Buy";
            this.button_Buy.Size = new System.Drawing.Size(145, 23);
            this.button_Buy.TabIndex = 0;
            this.button_Buy.Text = "Купить...";
            this.button_Buy.UseVisualStyleBackColor = true;
            this.button_Buy.Click += new System.EventHandler(this.button_Buy_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Location = new System.Drawing.Point(9, 283);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(145, 23);
            this.button_Edit.TabIndex = 37;
            this.button_Edit.Text = "Изменить...";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // SubscribeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 360);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_FromName);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubscribeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма просмотра и редактирования абонементов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SubscribeForm_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_StudentId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_ChooseStudent;
        private System.Windows.Forms.Label label_StudentFullName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_FromName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Buy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listBox_Subscriptions;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelAbonent_Id;
        private System.Windows.Forms.Label labelAbonent_Hours;
        private System.Windows.Forms.Label labelAbonent_Time;
        private System.Windows.Forms.Label labelAbonent_CardType;
        private System.Windows.Forms.Label labelAbonent_BuyTime;
        private System.Windows.Forms.Label labelAbonent_Group;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button_SubFirst;
        private System.Windows.Forms.Button button_SubLast;
        private System.Windows.Forms.Button button_SubPrev;
        private System.Windows.Forms.Button button_SubNext;
        private System.Windows.Forms.Label label_SubPages;
        private System.Windows.Forms.Button button_Edit;
    }
}