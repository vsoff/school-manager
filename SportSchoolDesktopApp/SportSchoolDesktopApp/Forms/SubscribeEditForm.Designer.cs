namespace SportSchoolDesktopApp.Forms
{
    partial class SubscribeEditForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.numeric_HoursMax = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.box_StartDateYear = new System.Windows.Forms.ComboBox();
            this.box_StartDateDay = new System.Windows.Forms.TextBox();
            this.box_StartDateMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_TypeUnlim = new System.Windows.Forms.RadioButton();
            this.radioButton_TypeLim = new System.Windows.Forms.RadioButton();
            this.button_ChooseGroup = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.box_Group = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_SaveAdd = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.label_FromName = new System.Windows.Forms.Label();
            this.numeric_HoursCur = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Delete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_HoursMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_HoursCur)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.numeric_HoursCur);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numeric_HoursMax);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.box_StartDateYear);
            this.panel1.Controls.Add(this.box_StartDateDay);
            this.panel1.Controls.Add(this.box_StartDateMonth);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButton_TypeUnlim);
            this.panel1.Controls.Add(this.radioButton_TypeLim);
            this.panel1.Controls.Add(this.button_ChooseGroup);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.box_Group);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 286);
            this.panel1.TabIndex = 9;
            // 
            // numeric_HoursMax
            // 
            this.numeric_HoursMax.Location = new System.Drawing.Point(96, 85);
            this.numeric_HoursMax.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numeric_HoursMax.Name = "numeric_HoursMax";
            this.numeric_HoursMax.Size = new System.Drawing.Size(99, 20);
            this.numeric_HoursMax.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(201, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 21);
            this.label6.TabIndex = 32;
            this.label6.Text = "(осталось)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // box_StartDateYear
            // 
            this.box_StartDateYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_StartDateYear.FormattingEnabled = true;
            this.box_StartDateYear.Location = new System.Drawing.Point(332, 111);
            this.box_StartDateYear.Name = "box_StartDateYear";
            this.box_StartDateYear.Size = new System.Drawing.Size(67, 21);
            this.box_StartDateYear.TabIndex = 30;
            // 
            // box_StartDateDay
            // 
            this.box_StartDateDay.Location = new System.Drawing.Point(96, 111);
            this.box_StartDateDay.MaxLength = 2;
            this.box_StartDateDay.Multiline = true;
            this.box_StartDateDay.Name = "box_StartDateDay";
            this.box_StartDateDay.Size = new System.Drawing.Size(65, 21);
            this.box_StartDateDay.TabIndex = 26;
            this.box_StartDateDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // box_StartDateMonth
            // 
            this.box_StartDateMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_StartDateMonth.FormattingEnabled = true;
            this.box_StartDateMonth.Items.AddRange(new object[] {
            "",
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.box_StartDateMonth.Location = new System.Drawing.Point(167, 111);
            this.box_StartDateMonth.Name = "box_StartDateMonth";
            this.box_StartDateMonth.Size = new System.Drawing.Size(159, 21);
            this.box_StartDateMonth.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 23;
            this.label1.Text = "Дата начала";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioButton_TypeUnlim
            // 
            this.radioButton_TypeUnlim.AutoSize = true;
            this.radioButton_TypeUnlim.Location = new System.Drawing.Point(201, 34);
            this.radioButton_TypeUnlim.Name = "radioButton_TypeUnlim";
            this.radioButton_TypeUnlim.Size = new System.Drawing.Size(95, 17);
            this.radioButton_TypeUnlim.TabIndex = 16;
            this.radioButton_TypeUnlim.Text = "Безлимитный";
            this.radioButton_TypeUnlim.UseVisualStyleBackColor = true;
            // 
            // radioButton_TypeLim
            // 
            this.radioButton_TypeLim.AutoSize = true;
            this.radioButton_TypeLim.Checked = true;
            this.radioButton_TypeLim.Location = new System.Drawing.Point(96, 34);
            this.radioButton_TypeLim.Name = "radioButton_TypeLim";
            this.radioButton_TypeLim.Size = new System.Drawing.Size(99, 17);
            this.radioButton_TypeLim.TabIndex = 15;
            this.radioButton_TypeLim.TabStop = true;
            this.radioButton_TypeLim.Text = "Ограниченный";
            this.radioButton_TypeLim.UseVisualStyleBackColor = true;
            // 
            // button_ChooseGroup
            // 
            this.button_ChooseGroup.Location = new System.Drawing.Point(266, 6);
            this.button_ChooseGroup.Name = "button_ChooseGroup";
            this.button_ChooseGroup.Size = new System.Drawing.Size(133, 20);
            this.button_ChooseGroup.TabIndex = 11;
            this.button_ChooseGroup.Text = "Выбрать группу...";
            this.button_ChooseGroup.UseVisualStyleBackColor = true;
            this.button_ChooseGroup.Click += new System.EventHandler(this.button_ChooseGroup_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Группа";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // box_Group
            // 
            this.box_Group.Location = new System.Drawing.Point(96, 6);
            this.box_Group.MaxLength = 30;
            this.box_Group.Name = "box_Group";
            this.box_Group.ReadOnly = true;
            this.box_Group.Size = new System.Drawing.Size(164, 20);
            this.box_Group.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Посещения";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Тип";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_SaveAdd
            // 
            this.button_SaveAdd.Location = new System.Drawing.Point(162, 331);
            this.button_SaveAdd.Name = "button_SaveAdd";
            this.button_SaveAdd.Size = new System.Drawing.Size(150, 23);
            this.button_SaveAdd.TabIndex = 8;
            this.button_SaveAdd.Text = "Сохранить изменения";
            this.button_SaveAdd.UseVisualStyleBackColor = true;
            this.button_SaveAdd.Click += new System.EventHandler(this.button_SaveAdd_Click);
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(318, 331);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(108, 23);
            this.button_Close.TabIndex = 7;
            this.button_Close.Text = "Закрыть";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // label_FromName
            // 
            this.label_FromName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_FromName.Location = new System.Drawing.Point(12, 9);
            this.label_FromName.Name = "label_FromName";
            this.label_FromName.Size = new System.Drawing.Size(414, 27);
            this.label_FromName.TabIndex = 6;
            this.label_FromName.Text = "Редактирование абонемента";
            this.label_FromName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numeric_HoursCur
            // 
            this.numeric_HoursCur.Location = new System.Drawing.Point(96, 58);
            this.numeric_HoursCur.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numeric_HoursCur.Name = "numeric_HoursCur";
            this.numeric_HoursCur.Size = new System.Drawing.Size(99, 20);
            this.numeric_HoursCur.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(201, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 21);
            this.label2.TabIndex = 34;
            this.label2.Text = "(максимум)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(12, 331);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(91, 23);
            this.button_Delete.TabIndex = 10;
            this.button_Delete.Text = "Удалить";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // SubscribeEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 366);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_SaveAdd);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label_FromName);
            this.Name = "SubscribeEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Форма редактирования абонемента";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_HoursMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_HoursCur)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_ChooseGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox box_Group;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_SaveAdd;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Label label_FromName;
        private System.Windows.Forms.RadioButton radioButton_TypeUnlim;
        private System.Windows.Forms.RadioButton radioButton_TypeLim;
        private System.Windows.Forms.TextBox box_StartDateDay;
        private System.Windows.Forms.ComboBox box_StartDateMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox box_StartDateYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numeric_HoursMax;
        private System.Windows.Forms.NumericUpDown numeric_HoursCur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Delete;
    }
}