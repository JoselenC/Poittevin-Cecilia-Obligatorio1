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
            this.BtnRegistrExpense = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lstcurrency = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label1.Font = new System.Drawing.Font("AR CENA", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1127, 92);
            this.label1.TabIndex = 0;
            this.label1.Text = "              Register expense             ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.OldLace;
            this.label2.Location = new System.Drawing.Point(53, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.OldLace;
            this.label3.Location = new System.Drawing.Point(98, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.OldLace;
            this.label4.Location = new System.Drawing.Point(136, 526);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.OldLace;
            this.label5.Location = new System.Drawing.Point(81, 642);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Category";
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.Color.White;
            this.tbDescription.Location = new System.Drawing.Point(284, 158);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(589, 38);
            this.tbDescription.TabIndex = 5;
            // 
            // dateTime
            // 
            this.dateTime.CalendarMonthBackground = System.Drawing.Color.OldLace;
            this.dateTime.Location = new System.Drawing.Point(284, 520);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(589, 38);
            this.dateTime.TabIndex = 6;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(345, 211);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(0, 32);
            this.lbDescription.TabIndex = 7;
            // 
            // lstCategories
            // 
            this.lstCategories.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstCategories.FormattingEnabled = true;
            this.lstCategories.ItemHeight = 31;
            this.lstCategories.Location = new System.Drawing.Point(284, 642);
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.Size = new System.Drawing.Size(588, 97);
            this.lstCategories.TabIndex = 8;
            // 
            // nAmount
            // 
            this.nAmount.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nAmount.DecimalPlaces = 2;
            this.nAmount.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nAmount.Location = new System.Drawing.Point(284, 389);
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
            this.nAmount.Size = new System.Drawing.Size(589, 38);
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
            this.lblAmount.Location = new System.Drawing.Point(288, 448);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(0, 32);
            this.lblAmount.TabIndex = 10;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(294, 574);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 32);
            this.lblDate.TabIndex = 11;
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Location = new System.Drawing.Point(295, 755);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(0, 32);
            this.lblCategories.TabIndex = 12;
            // 
            // BtnRegistrExpense
            // 
            this.BtnRegistrExpense.BackColor = System.Drawing.Color.Tan;
            this.BtnRegistrExpense.Location = new System.Drawing.Point(284, 846);
            this.BtnRegistrExpense.Name = "BtnRegistrExpense";
            this.BtnRegistrExpense.Size = new System.Drawing.Size(227, 73);
            this.BtnRegistrExpense.TabIndex = 13;
            this.BtnRegistrExpense.Text = "Accept";
            this.BtnRegistrExpense.UseVisualStyleBackColor = false;
            this.BtnRegistrExpense.Click += new System.EventHandler(this.BtnRegistrExpense_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.DarkKhaki;
            this.BtnSearch.Location = new System.Drawing.Point(922, 642);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(207, 55);
            this.BtnSearch.TabIndex = 14;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Tan;
            this.BtnCancel.Location = new System.Drawing.Point(682, 846);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(227, 73);
            this.BtnCancel.TabIndex = 35;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.OldLace;
            this.label6.Location = new System.Drawing.Point(111, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 32);
            this.label6.TabIndex = 36;
            this.label6.Text = "currency";
            // 
            // lstcurrency
            // 
            this.lstcurrency.FormattingEnabled = true;
            this.lstcurrency.ItemHeight = 31;
            this.lstcurrency.Location = new System.Drawing.Point(285, 274);
            this.lstcurrency.Name = "lstcurrency";
            this.lstcurrency.Size = new System.Drawing.Size(587, 35);
            this.lstcurrency.TabIndex = 37;
            // 
            // RegisterExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.lstcurrency);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.BtnRegistrExpense);
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
            this.Size = new System.Drawing.Size(1214, 968);
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
        private System.Windows.Forms.Button BtnRegistrExpense;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstcurrency;
    }
}
