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
            this.cMoney = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMonths = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lstType = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cMoney = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstMonths
            // 
            this.lstMonths.FormattingEnabled = true;
            this.lstMonths.ItemHeight = 31;
            this.lstMonths.Location = new System.Drawing.Point(333, 148);
            this.lstMonths.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lstMonths.Name = "lstMonths";
            this.lstMonths.Size = new System.Drawing.Size(457, 35);
            this.lstMonths.TabIndex = 1;
            // 
            // Month
            // 
            this.Month.AutoSize = true;
            this.Month.Location = new System.Drawing.Point(190, 151);
            this.Month.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(108, 32);
            this.Month.TabIndex = 2;
            this.Month.Text = "Months";
            // 
            // btnConsult
            // 
            this.btnConsult.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnConsult.Location = new System.Drawing.Point(817, 137);
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
            this.cMoney,
            this.cAmount});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(38, 256);
            this.listView1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1091, 381);
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
            // cMoney
            // 
            this.cMoney.DisplayIndex = 4;
            this.cMoney.Text = "Money";
            this.cMoney.Width = 90;
            // 
            // cAmount
            // 
            this.cAmount.DisplayIndex = 3;
            this.cAmount.Text = "Amount";
            this.cAmount.Width = 90;
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.Location = new System.Drawing.Point(76, 218);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(0, 32);
            this.lblMonths.TabIndex = 5;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(81, 217);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(0, 32);
            this.lblMonth.TabIndex = 6;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Tan;
            this.btnAccept.Location = new System.Drawing.Point(499, 875);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(227, 73);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(48, 777);
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
            this.label2.Location = new System.Drawing.Point(52, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1089, 92);
            this.label2.TabIndex = 9;
            this.label2.Text = "              Expense report              ";
            // 
            // cMoney
            // 
            this.cMoney.DisplayIndex = 4;
            this.cMoney.Text = "Money";
            this.cMoney.Width = 90;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnExportar.Location = new System.Drawing.Point(817, 259);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(219, 56);
            this.btnExportar.TabIndex = 10;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lstType
            // 
            this.lstType.FormattingEnabled = true;
            this.lstType.ItemHeight = 31;
            this.lstType.Location = new System.Drawing.Point(333, 270);
            this.lstType.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lstType.Name = "lstType";
            this.lstType.Size = new System.Drawing.Size(457, 35);
            this.lstType.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 272);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Archive";
            // 
            // ExpenseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstType);
            this.Controls.Add(this.btnExportar);
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
            this.Size = new System.Drawing.Size(1209, 983);
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
        private System.Windows.Forms.ColumnHeader cMoney;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ListBox lstType;
        private System.Windows.Forms.Label label1;
    }
}
