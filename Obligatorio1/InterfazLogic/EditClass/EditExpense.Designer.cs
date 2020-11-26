namespace InterfazLogic
{
    partial class EditExpense
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
            this.lstExpenses = new System.Windows.Forms.ListBox();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnAccept = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nAmount = new System.Windows.Forms.NumericUpDown();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblExpenses = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.BtnEditCategory = new System.Windows.Forms.Button();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCategories = new System.Windows.Forms.Label();
            this.lstCategories = new System.Windows.Forms.ListBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.lstCurrency = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label1.Font = new System.Drawing.Font("AR CENA", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Location = new System.Drawing.Point(26, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1074, 92);
            this.label1.TabIndex = 1;
            this.label1.Text = "                 Edit expenses            ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.OldLace;
            this.label2.Location = new System.Drawing.Point(87, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Expenses";
            // 
            // lstExpenses
            // 
            this.lstExpenses.FormattingEnabled = true;
            this.lstExpenses.ItemHeight = 31;
            this.lstExpenses.Location = new System.Drawing.Point(262, 146);
            this.lstExpenses.Name = "lstExpenses";
            this.lstExpenses.Size = new System.Drawing.Size(589, 66);
            this.lstExpenses.TabIndex = 3;
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.DarkKhaki;
            this.BtnEdit.Location = new System.Drawing.Point(866, 134);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(219, 55);
            this.BtnEdit.TabIndex = 15;
            this.BtnEdit.Text = "Edit ";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.DarkKhaki;
            this.BtnDelete.Location = new System.Drawing.Point(866, 195);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(219, 55);
            this.BtnDelete.TabIndex = 16;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnAccept
            // 
            this.BtnAccept.BackColor = System.Drawing.Color.Tan;
            this.BtnAccept.Location = new System.Drawing.Point(262, 869);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(227, 73);
            this.BtnAccept.TabIndex = 17;
            this.BtnAccept.Text = "Accept";
            this.BtnAccept.UseVisualStyleBackColor = false;
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.OldLace;
            this.label3.Location = new System.Drawing.Point(87, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 32);
            this.label3.TabIndex = 18;
            this.label3.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.Color.White;
            this.tbDescription.Location = new System.Drawing.Point(262, 289);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(589, 38);
            this.tbDescription.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.OldLace;
            this.label4.Location = new System.Drawing.Point(97, 514);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 32);
            this.label4.TabIndex = 20;
            this.label4.Text = "Amount";
            // 
            // nAmount
            // 
            this.nAmount.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nAmount.DecimalPlaces = 2;
            this.nAmount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nAmount.Location = new System.Drawing.Point(262, 514);
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
            this.nAmount.TabIndex = 21;
            this.nAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dateTime
            // 
            this.dateTime.CalendarMonthBackground = System.Drawing.Color.OldLace;
            this.dateTime.Location = new System.Drawing.Point(262, 638);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(589, 38);
            this.dateTime.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.OldLace;
            this.label5.Location = new System.Drawing.Point(126, 638);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 32);
            this.label5.TabIndex = 23;
            this.label5.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.OldLace;
            this.label6.Location = new System.Drawing.Point(97, 751);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 32);
            this.label6.TabIndex = 24;
            this.label6.Text = "Category";
            // 
            // lblExpenses
            // 
            this.lblExpenses.AutoSize = true;
            this.lblExpenses.Location = new System.Drawing.Point(275, 218);
            this.lblExpenses.Name = "lblExpenses";
            this.lblExpenses.Size = new System.Drawing.Size(0, 32);
            this.lblExpenses.TabIndex = 26;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.BackColor = System.Drawing.Color.White;
            this.lblCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(262, 764);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(361, 38);
            this.lblCategory.TabIndex = 27;
            this.lblCategory.Text = "                                           ";
            // 
            // BtnEditCategory
            // 
            this.BtnEditCategory.BackColor = System.Drawing.Color.DarkKhaki;
            this.BtnEditCategory.Location = new System.Drawing.Point(881, 739);
            this.BtnEditCategory.Name = "BtnEditCategory";
            this.BtnEditCategory.Size = new System.Drawing.Size(219, 55);
            this.BtnEditCategory.TabIndex = 28;
            this.BtnEditCategory.Text = "Edit category";
            this.BtnEditCategory.UseVisualStyleBackColor = false;
            this.BtnEditCategory.Click += new System.EventHandler(this.BtnEditCategory_Click);
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(275, 330);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(0, 32);
            this.lbDescription.TabIndex = 29;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(275, 564);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(0, 32);
            this.lblAmount.TabIndex = 30;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(275, 688);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 32);
            this.lblDate.TabIndex = 31;
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Location = new System.Drawing.Point(258, 822);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(0, 32);
            this.lblCategories.TabIndex = 32;
            // 
            // lstCategories
            // 
            this.lstCategories.FormattingEnabled = true;
            this.lstCategories.ItemHeight = 31;
            this.lstCategories.Location = new System.Drawing.Point(261, 739);
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.Size = new System.Drawing.Size(589, 66);
            this.lstCategories.TabIndex = 33;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Tan;
            this.BtnCancel.Location = new System.Drawing.Point(597, 869);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(227, 73);
            this.BtnCancel.TabIndex = 34;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lstCurrency
            // 
            this.lstCurrency.FormattingEnabled = true;
            this.lstCurrency.ItemHeight = 31;
            this.lstCurrency.Location = new System.Drawing.Point(264, 395);
            this.lstCurrency.Name = "lstCurrency";
            this.lstCurrency.Size = new System.Drawing.Size(586, 35);
            this.lstCurrency.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.OldLace;
            this.label7.Location = new System.Drawing.Point(87, 398);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 32);
            this.label7.TabIndex = 36;
            this.label7.Text = "Currency";
            // 
            // EditExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstCurrency);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.lstCategories);
            this.Controls.Add(this.lblCategories);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.BtnEditCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblExpenses);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.nAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.lstExpenses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditExpense";
            this.Size = new System.Drawing.Size(1171, 969);
            ((System.ComponentModel.ISupportInitialize)(this.nAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstExpenses;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnAccept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nAmount;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblExpenses;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button BtnEditCategory;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.ListBox lstCategories;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ListBox lstCurrency;
        private System.Windows.Forms.Label label7;
    }
}
