namespace SportSchoolDesktopApp.Forms
{
    partial class ReportForm
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
            this.buttonChooseTarget = new System.Windows.Forms.Button();
            this.textBoxCurrentTarget = new System.Windows.Forms.TextBox();
            this.label_FromName = new System.Windows.Forms.Label();
            this.radioTrainer = new System.Windows.Forms.RadioButton();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.radioStudent = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelWhoIs = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCreateReport = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxReport = new System.Windows.Forms.TextBox();
            this.buttonSaveReport = new System.Windows.Forms.Button();
            this.buttonCreateReportDetailed = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonChooseTarget
            // 
            this.buttonChooseTarget.Location = new System.Drawing.Point(343, 39);
            this.buttonChooseTarget.Name = "buttonChooseTarget";
            this.buttonChooseTarget.Size = new System.Drawing.Size(141, 22);
            this.buttonChooseTarget.TabIndex = 0;
            this.buttonChooseTarget.Text = "Выбрать...";
            this.buttonChooseTarget.UseVisualStyleBackColor = true;
            this.buttonChooseTarget.Click += new System.EventHandler(this.buttonChooseTarget_Click);
            // 
            // textBoxCurrentTarget
            // 
            this.textBoxCurrentTarget.Location = new System.Drawing.Point(109, 40);
            this.textBoxCurrentTarget.Name = "textBoxCurrentTarget";
            this.textBoxCurrentTarget.ReadOnly = true;
            this.textBoxCurrentTarget.Size = new System.Drawing.Size(228, 20);
            this.textBoxCurrentTarget.TabIndex = 1;
            // 
            // label_FromName
            // 
            this.label_FromName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FromName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_FromName.Location = new System.Drawing.Point(12, 9);
            this.label_FromName.Name = "label_FromName";
            this.label_FromName.Size = new System.Drawing.Size(507, 27);
            this.label_FromName.TabIndex = 15;
            this.label_FromName.Text = "Составление отчётов";
            this.label_FromName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioTrainer
            // 
            this.radioTrainer.Checked = true;
            this.radioTrainer.Location = new System.Drawing.Point(109, 12);
            this.radioTrainer.Name = "radioTrainer";
            this.radioTrainer.Size = new System.Drawing.Size(91, 24);
            this.radioTrainer.TabIndex = 16;
            this.radioTrainer.Text = "по тренеру";
            this.radioTrainer.UseVisualStyleBackColor = true;
            this.radioTrainer.CheckedChanged += new System.EventHandler(this.radioTrainer_CheckedChanged);
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(131, 67);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(159, 20);
            this.dtStart.TabIndex = 20;
            this.dtStart.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(325, 67);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(159, 20);
            this.dtEnd.TabIndex = 21;
            this.dtEnd.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // radioStudent
            // 
            this.radioStudent.Location = new System.Drawing.Point(206, 12);
            this.radioStudent.Name = "radioStudent";
            this.radioStudent.Size = new System.Drawing.Size(93, 24);
            this.radioStudent.TabIndex = 22;
            this.radioStudent.Text = "по ученику";
            this.radioStudent.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(109, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "С";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(296, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "по";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelWhoIs
            // 
            this.labelWhoIs.Location = new System.Drawing.Point(12, 40);
            this.labelWhoIs.Name = "labelWhoIs";
            this.labelWhoIs.Size = new System.Drawing.Size(91, 20);
            this.labelWhoIs.TabIndex = 25;
            this.labelWhoIs.Text = "Тренер:";
            this.labelWhoIs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Границы отчёта:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Отчёт";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonCreateReport
            // 
            this.buttonCreateReport.Location = new System.Drawing.Point(178, 54);
            this.buttonCreateReport.Name = "buttonCreateReport";
            this.buttonCreateReport.Size = new System.Drawing.Size(113, 23);
            this.buttonCreateReport.TabIndex = 28;
            this.buttonCreateReport.Text = "Создать отчёт";
            this.buttonCreateReport.UseVisualStyleBackColor = true;
            this.buttonCreateReport.Click += new System.EventHandler(this.buttonCreateReport_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(415, 351);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(104, 23);
            this.buttonClose.TabIndex = 29;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(17, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(502, 306);
            this.tabControl1.TabIndex = 30;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.radioTrainer);
            this.tabPage1.Controls.Add(this.dtStart);
            this.tabPage1.Controls.Add(this.textBoxCurrentTarget);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dtEnd);
            this.tabPage1.Controls.Add(this.labelWhoIs);
            this.tabPage1.Controls.Add(this.buttonChooseTarget);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.radioStudent);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(494, 280);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Настройки отчёта";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.textBoxReport);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(494, 280);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Отчёт";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonCreateReportDetailed);
            this.panel1.Controls.Add(this.buttonCreateReport);
            this.panel1.Location = new System.Drawing.Point(14, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 174);
            this.panel1.TabIndex = 29;
            // 
            // textBoxReport
            // 
            this.textBoxReport.BackColor = System.Drawing.Color.White;
            this.textBoxReport.Location = new System.Drawing.Point(6, 6);
            this.textBoxReport.Multiline = true;
            this.textBoxReport.Name = "textBoxReport";
            this.textBoxReport.ReadOnly = true;
            this.textBoxReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxReport.Size = new System.Drawing.Size(482, 268);
            this.textBoxReport.TabIndex = 0;
            // 
            // buttonSaveReport
            // 
            this.buttonSaveReport.Enabled = false;
            this.buttonSaveReport.Location = new System.Drawing.Point(280, 351);
            this.buttonSaveReport.Name = "buttonSaveReport";
            this.buttonSaveReport.Size = new System.Drawing.Size(129, 23);
            this.buttonSaveReport.TabIndex = 1;
            this.buttonSaveReport.Text = "Сохранить отчёт";
            this.buttonSaveReport.UseVisualStyleBackColor = true;
            this.buttonSaveReport.Click += new System.EventHandler(this.buttonSaveReport_Click);
            // 
            // buttonCreateReportDetailed
            // 
            this.buttonCreateReportDetailed.Location = new System.Drawing.Point(139, 83);
            this.buttonCreateReportDetailed.Name = "buttonCreateReportDetailed";
            this.buttonCreateReportDetailed.Size = new System.Drawing.Size(191, 23);
            this.buttonCreateReportDetailed.TabIndex = 29;
            this.buttonCreateReportDetailed.Text = "Создать детальный отчёт";
            this.buttonCreateReportDetailed.UseVisualStyleBackColor = true;
            this.buttonCreateReportDetailed.Click += new System.EventHandler(this.buttonCreateReportDetailed_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 386);
            this.Controls.Add(this.buttonSaveReport);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label_FromName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReportForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonChooseTarget;
        private System.Windows.Forms.TextBox textBoxCurrentTarget;
        private System.Windows.Forms.Label label_FromName;
        private System.Windows.Forms.RadioButton radioTrainer;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.RadioButton radioStudent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelWhoIs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCreateReport;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxReport;
        private System.Windows.Forms.Button buttonSaveReport;
        private System.Windows.Forms.Button buttonCreateReportDetailed;
    }
}