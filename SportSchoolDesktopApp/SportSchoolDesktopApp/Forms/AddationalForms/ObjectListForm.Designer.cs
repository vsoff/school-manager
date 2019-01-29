namespace SportSchoolDesktopApp.Forms
{
    partial class ObjectListForm
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
            this.button_Choose = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.label_FormName = new System.Windows.Forms.Label();
            this.listBox_Result = new System.Windows.Forms.ListBox();
            this.textBox_Find = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Find = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Choose
            // 
            this.button_Choose.Enabled = false;
            this.button_Choose.Location = new System.Drawing.Point(12, 334);
            this.button_Choose.Name = "button_Choose";
            this.button_Choose.Size = new System.Drawing.Size(172, 23);
            this.button_Choose.TabIndex = 14;
            this.button_Choose.Text = "Выбрать";
            this.button_Choose.UseVisualStyleBackColor = true;
            this.button_Choose.Click += new System.EventHandler(this.button_Choose_Click);
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(450, 334);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(87, 23);
            this.button_Close.TabIndex = 13;
            this.button_Close.Text = "Закрыть";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // label_FormName
            // 
            this.label_FormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_FormName.Location = new System.Drawing.Point(12, 6);
            this.label_FormName.Name = "label_FormName";
            this.label_FormName.Size = new System.Drawing.Size(525, 26);
            this.label_FormName.TabIndex = 12;
            this.label_FormName.Text = "Название";
            this.label_FormName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // listBox_Result
            // 
            this.listBox_Result.FormattingEnabled = true;
            this.listBox_Result.Location = new System.Drawing.Point(12, 64);
            this.listBox_Result.Name = "listBox_Result";
            this.listBox_Result.Size = new System.Drawing.Size(525, 264);
            this.listBox_Result.TabIndex = 11;
            this.listBox_Result.SelectedIndexChanged += new System.EventHandler(this.listBox_Result_SelectedIndexChanged);
            // 
            // textBox_Find
            // 
            this.textBox_Find.Location = new System.Drawing.Point(57, 38);
            this.textBox_Find.Name = "textBox_Find";
            this.textBox_Find.Size = new System.Drawing.Size(399, 20);
            this.textBox_Find.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Поиск";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_Find
            // 
            this.button_Find.Location = new System.Drawing.Point(462, 38);
            this.button_Find.Name = "button_Find";
            this.button_Find.Size = new System.Drawing.Size(75, 20);
            this.button_Find.TabIndex = 8;
            this.button_Find.Text = "Найти";
            this.button_Find.UseVisualStyleBackColor = true;
            this.button_Find.Click += new System.EventHandler(this.button_Find_Click);
            // 
            // ObjectListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 364);
            this.Controls.Add(this.button_Choose);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label_FormName);
            this.Controls.Add(this.listBox_Result);
            this.Controls.Add(this.textBox_Find);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Find);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObjectListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ObjectListForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Choose;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Label label_FormName;
        private System.Windows.Forms.ListBox listBox_Result;
        private System.Windows.Forms.TextBox textBox_Find;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Find;
    }
}