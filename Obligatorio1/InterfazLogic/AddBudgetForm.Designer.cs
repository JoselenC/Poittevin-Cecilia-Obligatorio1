namespace InterfazLogic
{
    partial class AddBudgetForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxCategory = new System.Windows.Forms.ListBox();
            this.numericYear = new System.Windows.Forms.NumericUpDown();
            this.ChangeBudgetCategory = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericYear)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.DarkKhaki;
            this.buttonCancel.Location = new System.Drawing.Point(510, 704);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(241, 60);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkKhaki;
            this.button2.Location = new System.Drawing.Point(163, 703);
            this.button2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(241, 61);
            this.button2.TabIndex = 1;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 271);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Year";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(293, 168);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(345, 39);
            this.comboBoxMonth.TabIndex = 4;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 175);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Month";
            // 
            // listBoxCategory
            // 
            this.listBoxCategory.FormattingEnabled = true;
            this.listBoxCategory.ItemHeight = 31;
            this.listBoxCategory.Location = new System.Drawing.Point(152, 344);
            this.listBoxCategory.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.listBoxCategory.Name = "listBoxCategory";
            this.listBoxCategory.Size = new System.Drawing.Size(609, 314);
            this.listBoxCategory.TabIndex = 6;
            this.listBoxCategory.SelectedIndexChanged += new System.EventHandler(this.listBoxCategory_SelectedIndexChanged);
            this.listBoxCategory.DoubleClick += new System.EventHandler(this.listBoxCategory_DoubleClick);
            // 
            // numericYear
            // 
            this.numericYear.Location = new System.Drawing.Point(293, 265);
            this.numericYear.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numericYear.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.numericYear.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.numericYear.Name = "numericYear";
            this.numericYear.Size = new System.Drawing.Size(352, 38);
            this.numericYear.TabIndex = 7;
            this.numericYear.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numericYear.ValueChanged += new System.EventHandler(this.numericYear_ValueChanged);
            // 
            // ChangeBudgetCategory
            // 
            this.ChangeBudgetCategory.BackColor = System.Drawing.Color.DarkKhaki;
            this.ChangeBudgetCategory.Location = new System.Drawing.Point(869, 344);
            this.ChangeBudgetCategory.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ChangeBudgetCategory.Name = "ChangeBudgetCategory";
            this.ChangeBudgetCategory.Size = new System.Drawing.Size(320, 55);
            this.ChangeBudgetCategory.TabIndex = 8;
            this.ChangeBudgetCategory.Text = "Edit budget categoy";
            this.ChangeBudgetCategory.UseVisualStyleBackColor = false;
            this.ChangeBudgetCategory.Click += new System.EventHandler(this.ChangeBudgetCategory_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Font = new System.Drawing.Font("AR CENA", 24F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label3.Location = new System.Drawing.Point(123, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1089, 92);
            this.label3.TabIndex = 10;
            this.label3.Text = "              Expense report              ";
            // 
            // AddBudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChangeBudgetCategory);
            this.Controls.Add(this.numericYear);
            this.Controls.Add(this.listBoxCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonCancel);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "AddBudgetForm";
            this.Size = new System.Drawing.Size(1261, 811);
            this.Load += new System.EventHandler(this.AddBudgetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxCategory;
        private System.Windows.Forms.NumericUpDown numericYear;
        private System.Windows.Forms.Button ChangeBudgetCategory;
        private System.Windows.Forms.Label label3;
    }
}