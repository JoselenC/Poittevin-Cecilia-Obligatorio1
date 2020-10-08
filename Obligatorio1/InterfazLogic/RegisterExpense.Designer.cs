namespace InterfazLogic
{
    partial class RegisterExpense
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lstCategories = new System.Windows.Forms.ListBox();
            this.nAmount = new System.Windows.Forms.NumericUpDown();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCategories = new System.Windows.Forms.Label();
            this.btnRegistrExpense = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(447, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register Expense";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label2.Location = new System.Drawing.Point(46, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label3.Location = new System.Drawing.Point(46, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label4.Location = new System.Drawing.Point(46, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label5.Location = new System.Drawing.Point(46, 472);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Category";
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.Color.OldLace;
            this.tbDescription.Location = new System.Drawing.Point(330, 153);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(451, 38);
            this.tbDescription.TabIndex = 5;
            // 
            // dateTime
            // 
            this.dateTime.CalendarMonthBackground = System.Drawing.Color.OldLace;
            this.dateTime.Location = new System.Drawing.Point(333, 359);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(447, 38);
            this.dateTime.TabIndex = 6;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(327, 194);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(23, 32);
            this.lbDescription.TabIndex = 7;
            this.lbDescription.Text = ".";
            // 
            // lstCategories
            // 
            this.lstCategories.BackColor = System.Drawing.Color.OldLace;
            this.lstCategories.FormattingEnabled = true;
            this.lstCategories.ItemHeight = 31;
            this.lstCategories.Location = new System.Drawing.Point(334, 469);
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.Size = new System.Drawing.Size(446, 35);
            this.lstCategories.TabIndex = 8;
            // 
            // nAmount
            // 
            this.nAmount.BackColor = System.Drawing.Color.OldLace;
            this.nAmount.DecimalPlaces = 2;
            this.nAmount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nAmount.Location = new System.Drawing.Point(336, 261);
            this.nAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nAmount.Name = "nAmount";
            this.nAmount.Size = new System.Drawing.Size(268, 38);
            this.nAmount.TabIndex = 9;
            this.nAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(327, 302);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(23, 32);
            this.lblAmount.TabIndex = 10;
            this.lblAmount.Text = ".";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(330, 411);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(23, 32);
            this.lblDate.TabIndex = 11;
            this.lblDate.Text = ".";
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Location = new System.Drawing.Point(328, 519);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(23, 32);
            this.lblCategories.TabIndex = 12;
            this.lblCategories.Text = ".";
            // 
            // btnRegistrExpense
            // 
            this.btnRegistrExpense.BackColor = System.Drawing.Color.Tan;
            this.btnRegistrExpense.Location = new System.Drawing.Point(756, 555);
            this.btnRegistrExpense.Name = "btnRegistrExpense";
            this.btnRegistrExpense.Size = new System.Drawing.Size(302, 55);
            this.btnRegistrExpense.TabIndex = 13;
            this.btnRegistrExpense.Text = "RegisterExpense";
            this.btnRegistrExpense.UseVisualStyleBackColor = false;
            this.btnRegistrExpense.Click += new System.EventHandler(this.btnRegistrExpense_Click);
            // 
            // RegisterExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Controls.Add(this.btnRegistrExpense);
            this.Controls.Add(this.lblCategories);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.nAmount);
            this.Controls.Add(this.lstCategories);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegisterExpense";
            this.Size = new System.Drawing.Size(1120, 636);
            ((System.ComponentModel.ISupportInitialize)(this.nAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.ListBox lstCategories;
        private System.Windows.Forms.NumericUpDown nAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.Button btnRegistrExpense;
    }
}
