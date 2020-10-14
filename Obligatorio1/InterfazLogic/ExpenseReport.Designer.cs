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
            this.label1 = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(181, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expense report";
            // 
            // lstMonths
            // 
            this.lstMonths.FormattingEnabled = true;
            this.lstMonths.Location = new System.Drawing.Point(72, 55);
            this.lstMonths.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.lstMonths.Name = "lstMonths";
            this.lstMonths.Size = new System.Drawing.Size(174, 30);
            this.lstMonths.TabIndex = 1;
            // 
            // Month
            // 
            this.Month.AutoSize = true;
            this.Month.Location = new System.Drawing.Point(18, 62);
            this.Month.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(42, 13);
            this.Month.TabIndex = 2;
            this.Month.Text = "Months";
            // 
            // btnConsult
            // 
            this.btnConsult.BackColor = System.Drawing.Color.Tan;
            this.btnConsult.Location = new System.Drawing.Point(252, 57);
            this.btnConsult.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnConsult.Name = "btnConsult";
            this.btnConsult.Size = new System.Drawing.Size(107, 22);
            this.btnConsult.TabIndex = 3;
            this.btnConsult.Text = "Consult";
            this.btnConsult.UseVisualStyleBackColor = false;
            this.btnConsult.Click += new System.EventHandler(this.btnConsult_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cCreationDate,
            this.cDescription,
            this.cCategory,
            this.cAmount});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(15, 106);
            this.listView1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(356, 154);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
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
            this.lblMonths.Location = new System.Drawing.Point(70, 91);
            this.lblMonths.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(0, 13);
            this.lblMonths.TabIndex = 5;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(72, 87);
            this.lblMonth.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(10, 13);
            this.lblMonth.TabIndex = 6;
            this.lblMonth.Text = ".";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Tan;
            this.btnAccept.Location = new System.Drawing.Point(261, 270);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(107, 22);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(24, 276);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(0, 13);
            this.lblTotalAmount.TabIndex = 8;
            // 
            // ExpenseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblMonths);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnConsult);
            this.Controls.Add(this.Month);
            this.Controls.Add(this.lstMonths);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "ExpenseReport";
            this.Size = new System.Drawing.Size(429, 322);
            this.Load += new System.EventHandler(this.ExpenseReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
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
    }
}
