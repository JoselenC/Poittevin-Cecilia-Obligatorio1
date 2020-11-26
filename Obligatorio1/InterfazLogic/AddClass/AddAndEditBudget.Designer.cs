namespace InterfazLogic
{
    partial class AddAndEditBudget
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnAccept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstCategory = new System.Windows.Forms.ListBox();
            this.NYear = new System.Windows.Forms.NumericUpDown();
            this.BtnEditBudget = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCategories = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NYear)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Tan;
            this.BtnCancel.Location = new System.Drawing.Point(684, 715);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(227, 73);
            this.BtnCancel.TabIndex = 0;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnAccept
            // 
            this.BtnAccept.BackColor = System.Drawing.Color.Tan;
            this.BtnAccept.Location = new System.Drawing.Point(336, 715);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(227, 73);
            this.BtnAccept.TabIndex = 1;
            this.BtnAccept.Text = "Accept";
            this.BtnAccept.UseVisualStyleBackColor = false;
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
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
            this.nMonth.Location = new System.Drawing.Point(338, 170);
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
            this.lstCategory.Location = new System.Drawing.Point(336, 405);
            this.lstCategory.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lstCategory.Name = "lstCategory";
            this.lstCategory.Size = new System.Drawing.Size(575, 190);
            this.lstCategory.TabIndex = 6;
            this.lstCategory.DoubleClick += new System.EventHandler(this.listBoxCategory_DoubleClick);
            // 
            // NYear
            // 
            this.NYear.Location = new System.Drawing.Point(338, 265);
            this.NYear.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.NYear.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.NYear.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.NYear.Name = "NYear";
            this.NYear.Size = new System.Drawing.Size(589, 38);
            this.NYear.TabIndex = 7;
            this.NYear.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.NYear.ValueChanged += new System.EventHandler(this.NYear_ValueChanged);
            // 
            // BtnEditBudget
            // 
            this.BtnEditBudget.BackColor = System.Drawing.Color.DarkKhaki;
            this.BtnEditBudget.Location = new System.Drawing.Point(954, 405);
            this.BtnEditBudget.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.BtnEditBudget.Name = "BtnEditBudget";
            this.BtnEditBudget.Size = new System.Drawing.Size(283, 55);
            this.BtnEditBudget.TabIndex = 8;
            this.BtnEditBudget.Text = "Edit budget categoy";
            this.BtnEditBudget.UseVisualStyleBackColor = false;
            this.BtnEditBudget.Click += new System.EventHandler(this.ChangeBudgetCategory_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Font = new System.Drawing.Font("AR CENA", 24F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label3.Location = new System.Drawing.Point(28, 25);
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
            this.label4.Location = new System.Drawing.Point(85, 380);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 32);
            this.label4.TabIndex = 12;
            this.label4.Text = "Budget category";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(337, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(328, 34);
            this.label5.TabIndex = 13;
            this.label5.Text = " Category                           ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(592, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(290, 34);
            this.label6.TabIndex = 14;
            this.label6.Text = "Budget                          ";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(332, 226);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(0, 32);
            this.lblMonth.TabIndex = 15;
            // 
            // AddAndEditBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCategories);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnEditBudget);
            this.Controls.Add(this.NYear);
            this.Controls.Add(this.lstCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnCancel);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "AddAndEditBudget";
            this.Size = new System.Drawing.Size(1263, 886);
            ((System.ComponentModel.ISupportInitialize)(this.NYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnAccept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox nMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstCategory;
        private System.Windows.Forms.NumericUpDown NYear;
        private System.Windows.Forms.Button BtnEditBudget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMonth;
    }
}