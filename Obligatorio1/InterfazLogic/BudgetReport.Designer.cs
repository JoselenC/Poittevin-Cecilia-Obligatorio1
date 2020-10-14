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
            this.SuspendLayout();
            // 
            // cboxMonth
            // 
            this.cboxMonth.FormattingEnabled = true;
            this.cboxMonth.Location = new System.Drawing.Point(12, 14);
            this.cboxMonth.Name = "cboxMonth";
            this.cboxMonth.Size = new System.Drawing.Size(148, 21);
            this.cboxMonth.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(191, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lstVReport
            // 
            this.lstVReport.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lstVReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cCategory,
            this.cPlanned,
            this.cReal,
            this.cDifference});
            this.lstVReport.HideSelection = false;
            this.lstVReport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lstVReport.Location = new System.Drawing.Point(12, 69);
            this.lstVReport.Name = "lstVReport";
            this.lstVReport.Size = new System.Drawing.Size(357, 162);
            this.lstVReport.TabIndex = 4;
            this.lstVReport.UseCompatibleStateImageBehavior = false;
            this.lstVReport.View = System.Windows.Forms.View.Details;
            this.lstVReport.SelectedIndexChanged += new System.EventHandler(this.lstVReport_SelectedIndexChanged);
            // 
            // cCategory
            // 
            this.cCategory.Text = "Category";
            // 
            // cPlanned
            // 
            this.cPlanned.Text = "Planned";
            // 
            // cReal
            // 
            this.cReal.Text = "Real";
            // 
            // cDifference
            // 
            this.cDifference.Text = "Difference";
            // 
            // BudgetReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 273);
            this.Controls.Add(this.lstVReport);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboxMonth);
            this.Name = "BudgetReport";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxMonth;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lstVReport;
        private System.Windows.Forms.ColumnHeader cCategory;
        private System.Windows.Forms.ColumnHeader cPlanned;
        private System.Windows.Forms.ColumnHeader cReal;
        private System.Windows.Forms.ColumnHeader cDifference;
    }
}