namespace InterfazLogic
{
    partial class ExpenseReport
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
            this.lstMonths = new System.Windows.Forms.ListBox();
            this.Month = new System.Windows.Forms.Label();
            this.btnConsult = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cCreationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMonths = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstMonths
            // 
            this.lstMonths.FormattingEnabled = true;
            this.lstMonths.ItemHeight = 31;
            this.lstMonths.Location = new System.Drawing.Point(317, 137);
            this.lstMonths.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lstMonths.Name = "lstMonths";
            this.lstMonths.Size = new System.Drawing.Size(457, 66);
            this.lstMonths.TabIndex = 1;
            // 
            // Month
            // 
            this.Month.AutoSize = true;
            this.Month.Location = new System.Drawing.Point(157, 137);
            this.Month.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(108, 32);
            this.Month.TabIndex = 2;
            this.Month.Text = "Months";
            // 
            // btnConsult
            // 
            this.btnConsult.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnConsult.Location = new System.Drawing.Point(806, 137);
            this.btnConsult.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnConsult.Name = "btnConsult";
            this.btnConsult.Size = new System.Drawing.Size(219, 56);
            this.btnConsult.TabIndex = 3;
            this.btnConsult.Text = "Consult";
            this.btnConsult.UseVisualStyleBackColor = false;
            this.btnConsult.Click += new System.EventHandler(this.btnConsult_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.DarkKhaki;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cCreationDate,
            this.cDescription,
            this.cCategory,
            this.cAmount});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(90, 281);
            this.listView1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(995, 358);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // cCreationDate
            // 
            this.cCreationDate.Text = "Date";
            this.cCreationDate.Width = 90;
            // 
            // cDescription
            // 
            this.cDescription.Text = "Description";
            this.cDescription.Width = 90;
            // 
            // cCategory
            // 
            this.cCategory.Text = "Category";
            this.cCategory.Width = 90;
            // 
            // cAmount
            // 
            this.cAmount.Text = "Amount";
            this.cAmount.Width = 90;
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.Location = new System.Drawing.Point(187, 217);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(0, 32);
            this.lblMonths.TabIndex = 5;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(192, 207);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(0, 32);
            this.lblMonth.TabIndex = 6;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Tan;
            this.btnAccept.Location = new System.Drawing.Point(473, 707);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(219, 56);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(64, 658);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(0, 32);
            this.lblTotalAmount.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label2.Font = new System.Drawing.Font("AR CENA", 24F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.Location = new System.Drawing.Point(64, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1089, 92);
            this.label2.TabIndex = 9;
            this.label2.Text = "              Expense report              ";
            // 
            // ExpenseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblMonths);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnConsult);
            this.Controls.Add(this.Month);
            this.Controls.Add(this.lstMonths);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "ExpenseReport";
            this.Size = new System.Drawing.Size(1209, 786);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstMonths;
        private System.Windows.Forms.Label Month;
        private System.Windows.Forms.Button btnConsult;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader cCreationDate;
        private System.Windows.Forms.ColumnHeader cDescription;
        private System.Windows.Forms.ColumnHeader cCategory;
        private System.Windows.Forms.ColumnHeader cAmount;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label2;
    }
}
