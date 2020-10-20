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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstCategory = new System.Windows.Forms.ListBox();
            this.nYear = new System.Windows.Forms.NumericUpDown();
            this.btnEditBudget = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCategories = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nYear)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Tan;
            this.btnCancel.Location = new System.Drawing.Point(755, 695);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(227, 73);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Tan;
            this.btnAccept.Location = new System.Drawing.Point(293, 704);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(227, 73);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 271);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Year";
            // 
            // nMonth
            // 
            this.nMonth.FormattingEnabled = true;
            this.nMonth.Location = new System.Drawing.Point(338, 167);
            this.nMonth.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nMonth.Name = "nMonth";
            this.nMonth.Size = new System.Drawing.Size(589, 39);
            this.nMonth.TabIndex = 4;
            this.nMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 173);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Month";
            // 
            // lstCategory
            // 
            this.lstCategory.FormattingEnabled = true;
            this.lstCategory.ItemHeight = 31;
            this.lstCategory.Location = new System.Drawing.Point(329, 357);
            this.lstCategory.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lstCategory.Name = "lstCategory";
            this.lstCategory.Size = new System.Drawing.Size(598, 221);
            this.lstCategory.TabIndex = 6;
            this.lstCategory.DoubleClick += new System.EventHandler(this.listBoxCategory_DoubleClick);
            // 
            // nYear
            // 
            this.nYear.Location = new System.Drawing.Point(338, 265);
            this.nYear.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nYear.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.nYear.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.nYear.Name = "nYear";
            this.nYear.Size = new System.Drawing.Size(589, 38);
            this.nYear.TabIndex = 7;
            this.nYear.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.nYear.ValueChanged += new System.EventHandler(this.numericYear_ValueChanged);
            // 
            // btnEditBudget
            // 
            this.btnEditBudget.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnEditBudget.Location = new System.Drawing.Point(957, 357);
            this.btnEditBudget.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnEditBudget.Name = "btnEditBudget";
            this.btnEditBudget.Size = new System.Drawing.Size(283, 55);
            this.btnEditBudget.TabIndex = 8;
            this.btnEditBudget.Text = "Edit budget categoy";
            this.btnEditBudget.UseVisualStyleBackColor = false;
            this.btnEditBudget.Click += new System.EventHandler(this.ChangeBudgetCategory_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Font = new System.Drawing.Font("AR CENA", 24F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label3.Location = new System.Drawing.Point(52, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1209, 92);
            this.label3.TabIndex = 10;
            this.label3.Text = "              Add and edit budget             ";
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Location = new System.Drawing.Point(312, 602);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(0, 32);
            this.lblCategories.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 357);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 32);
            this.label4.TabIndex = 12;
            this.label4.Text = "Budget category";
            // 
            // AddBudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCategories);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEditBudget);
            this.Controls.Add(this.nYear);
            this.Controls.Add(this.lstCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "AddBudgetForm";
            this.Size = new System.Drawing.Size(1288, 811);
            ((System.ComponentModel.ISupportInitialize)(this.nYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox nMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstCategory;
        private System.Windows.Forms.NumericUpDown nYear;
        private System.Windows.Forms.Button btnEditBudget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.Label label4;
    }
}