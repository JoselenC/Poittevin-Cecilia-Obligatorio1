namespace InterfazLogic
{
    partial class BudgetReport
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
            this.cboxMonth = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lstVReport = new System.Windows.Forms.ListView();
            this.cCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cPlanned = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cReal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cDifference = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblReport = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            this.SuspendLayout();
            // 
            // cboxMonth
            // 
            this.cboxMonth.FormattingEnabled = true;
            this.cboxMonth.Location = new System.Drawing.Point(272, 137);
            this.cboxMonth.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cboxMonth.Name = "cboxMonth";
            this.cboxMonth.Size = new System.Drawing.Size(589, 39);
            this.cboxMonth.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnSearch.Location = new System.Drawing.Point(893, 171);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(216, 55);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Consult";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lstVReport
            // 
            this.lstVReport.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lstVReport.BackColor = System.Drawing.Color.DarkKhaki;
            this.lstVReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cCategory,
            this.cPlanned,
            this.cReal,
            this.cDifference});
            this.lstVReport.HideSelection = false;
            this.lstVReport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lstVReport.Location = new System.Drawing.Point(147, 292);
            this.lstVReport.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lstVReport.Name = "lstVReport";
            this.lstVReport.Size = new System.Drawing.Size(945, 381);
            this.lstVReport.TabIndex = 4;
            this.lstVReport.UseCompatibleStateImageBehavior = false;
            this.lstVReport.View = System.Windows.Forms.View.Details;
            // 
            // cCategory
            // 
            this.cCategory.Text = "Category";
            this.cCategory.Width = 85;
            // 
            // cPlanned
            // 
            this.cPlanned.Text = "Planned";
            this.cPlanned.Width = 85;
            // 
            // cReal
            // 
            this.cReal.Text = "Real";
            this.cReal.Width = 90;
            // 
            // cDifference
            // 
            this.cDifference.Text = "Difference";
            this.cDifference.Width = 90;
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(272, 190);
            this.numYear.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numYear.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(589, 38);
            this.numYear.TabIndex = 5;
            this.numYear.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.numYear.ValueChanged += new System.EventHandler(this.numYear_ValueChanged);
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
            this.label2.Size = new System.Drawing.Size(1101, 92);
            this.label2.TabIndex = 10;
            this.label2.Text = "                Budget report              ";
            // 
            // lblReport
            // 
            this.lblReport.AutoSize = true;
            this.lblReport.Location = new System.Drawing.Point(105, 248);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(0, 32);
            this.lblReport.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 32);
            this.label3.TabIndex = 13;
            this.label3.Text = "Year";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Tan;
            this.btnAccept.Location = new System.Drawing.Point(506, 708);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(227, 73);
            this.btnAccept.TabIndex = 14;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = false;
            // 
            // BudgetReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.lstVReport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboxMonth);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "BudgetReport";
            this.Size = new System.Drawing.Size(1286, 799);
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxMonth;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lstVReport;
        private System.Windows.Forms.ColumnHeader cCategory;
        private System.Windows.Forms.ColumnHeader cPlanned;
        private System.Windows.Forms.ColumnHeader cReal;
        private System.Windows.Forms.ColumnHeader cDifference;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAccept;
    }
}