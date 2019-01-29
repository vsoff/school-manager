namespace SportSchoolDesktopApp.Forms
{
    partial class SearchForm
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
            this.button_Find = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Find = new System.Windows.Forms.TextBox();
            this.listBox_Result = new System.Windows.Forms.ListBox();
            this.label_FormName = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Find
            // 
            this.button_Find.Location = new System.Drawing.Point(462, 38);
            this.button_Find.Name = "button_Find";
            this.button_Find.Size = new System.Drawing.Size(75, 20);
            this.button_Find.TabIndex = 0;
            this.button_Find.Text = "Найти";
            this.button_Find.UseVisualStyleBackColor = true;
            this.button_Find.Click += new System.EventHandler(this.button_Find_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Поиск";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_Find
            // 
            this.textBox_Find.Location = new System.Drawing.Point(57, 38);
            this.textBox_Find.Name = "textBox_Find";
            this.textBox_Find.Size = new System.Drawing.Size(399, 20);
            this.textBox_Find.TabIndex = 2;
            // 
            // listBox_Result
            // 
            this.listBox_Result.FormattingEnabled = true;
            this.listBox_Result.Location = new System.Drawing.Point(12, 64);
            this.listBox_Result.Name = "listBox_Result";
            this.listBox_Result.Size = new System.Drawing.Size(525, 264);
            this.listBox_Result.TabIndex = 3;
            this.listBox_Result.SelectedIndexChanged += new System.EventHandler(this.listBox_Result_SelectedIndexChanged);
            // 
            // label_FormName
            // 
            this.label_FormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_FormName.Location = new System.Drawing.Point(12, 6);
            this.label_FormName.Name = "label_FormName";
            this.label_FormName.Size = new System.Drawing.Size(525, 26);
            this.label_FormName.TabIndex = 4;
            this.label_FormName.Text = "Название";
            this.label_FormName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(450, 334);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(87, 23);
            this.button_Close.TabIndex = 5;
            this.button_Close.Text = "Закрыть";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(12, 334);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(92, 23);
            this.button_Add.TabIndex = 6;
            this.button_Add.Text = "Добавить...";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Enabled = false;
            this.button_Edit.Location = new System.Drawing.Point(110, 334);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(148, 23);
            this.button_Edit.TabIndex = 7;
            this.button_Edit.Text = "Редактировать...";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 364);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label_FormName);
            this.Controls.Add(this.listBox_Result);
            this.Controls.Add(this.textBox_Find);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Find);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SearchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Find;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Find;
        private System.Windows.Forms.ListBox listBox_Result;
        private System.Windows.Forms.Label label_FormName;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Edit;
    }
}