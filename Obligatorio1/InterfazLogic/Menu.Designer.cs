namespace InterfazLogic
{
    partial class Menu
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
            this.lblMenu = new System.Windows.Forms.Label();
            this.btnRegisterCategory = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnRegisterExpense = new System.Windows.Forms.Button();
            this.btnRegisterBudget = new System.Windows.Forms.Button();
            this.btnExpenseReport = new System.Windows.Forms.Button();
            this.btnBudgetReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("AR CENA", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.ForeColor = System.Drawing.Color.DarkKhaki;
            this.lblMenu.Location = new System.Drawing.Point(65, 21);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(194, 92);
            this.lblMenu.TabIndex = 1;
            this.lblMenu.Text = "Menu";
            // 
            // btnRegisterCategory
            // 
            this.btnRegisterCategory.BackColor = System.Drawing.Color.Tan;
            this.btnRegisterCategory.Location = new System.Drawing.Point(61, 121);
            this.btnRegisterCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegisterCategory.Name = "btnRegisterCategory";
            this.btnRegisterCategory.Size = new System.Drawing.Size(296, 115);
            this.btnRegisterCategory.TabIndex = 2;
            this.btnRegisterCategory.Text = "Register Category";
            this.btnRegisterCategory.UseVisualStyleBackColor = false;
            this.btnRegisterCategory.Click += new System.EventHandler(this.btnRegisterCategory_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.OldLace;
            this.mainPanel.Location = new System.Drawing.Point(374, 15);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1299, 786);
            this.mainPanel.TabIndex = 7;
            
            // 
            // btnRegisterExpense
            // 
            this.btnRegisterExpense.BackColor = System.Drawing.Color.Tan;
            this.btnRegisterExpense.Location = new System.Drawing.Point(62, 258);
            this.btnRegisterExpense.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegisterExpense.Name = "btnRegisterExpense";
            this.btnRegisterExpense.Size = new System.Drawing.Size(296, 123);
            this.btnRegisterExpense.TabIndex = 8;
            this.btnRegisterExpense.Text = "Register Expense";
            this.btnRegisterExpense.UseVisualStyleBackColor = false;
            this.btnRegisterExpense.Click += new System.EventHandler(this.btnRegisterExpense_Click);
            // 
            // btnRegisterBudget
            // 
            this.btnRegisterBudget.BackColor = System.Drawing.Color.Tan;
            this.btnRegisterBudget.Location = new System.Drawing.Point(61, 401);
            this.btnRegisterBudget.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegisterBudget.Name = "btnRegisterBudget";
            this.btnRegisterBudget.Size = new System.Drawing.Size(296, 123);
            this.btnRegisterBudget.TabIndex = 9;
            this.btnRegisterBudget.Text = "Register Budget";
            this.btnRegisterBudget.UseVisualStyleBackColor = false;
            this.btnRegisterBudget.Click += new System.EventHandler(this.btnRegisterBudget_Click);
            // 
            // btnExpenseReport
            // 
            this.btnExpenseReport.BackColor = System.Drawing.Color.Tan;
            this.btnExpenseReport.Location = new System.Drawing.Point(62, 540);
            this.btnExpenseReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExpenseReport.Name = "btnExpenseReport";
            this.btnExpenseReport.Size = new System.Drawing.Size(296, 117);
            this.btnExpenseReport.TabIndex = 10;
            this.btnExpenseReport.Text = "Expense Report";
            this.btnExpenseReport.UseVisualStyleBackColor = false;
            this.btnExpenseReport.Click += new System.EventHandler(this.btnExpenseReport_Click);
            // 
            // btnBudgetReport
            // 
            this.btnBudgetReport.BackColor = System.Drawing.Color.Tan;
            this.btnBudgetReport.Location = new System.Drawing.Point(61, 674);
            this.btnBudgetReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBudgetReport.Name = "btnBudgetReport";
            this.btnBudgetReport.Size = new System.Drawing.Size(297, 116);
            this.btnBudgetReport.TabIndex = 11;
            this.btnBudgetReport.Text = "Budget Report";
            this.btnBudgetReport.UseVisualStyleBackColor = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1686, 812);
            this.Controls.Add(this.btnBudgetReport);
            this.Controls.Add(this.btnExpenseReport);
            this.Controls.Add(this.btnRegisterBudget);
            this.Controls.Add(this.btnRegisterExpense);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.btnRegisterCategory);
            this.Controls.Add(this.lblMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Button btnRegisterCategory;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnRegisterExpense;
        private System.Windows.Forms.Button btnRegisterBudget;
        private System.Windows.Forms.Button btnExpenseReport;
        private System.Windows.Forms.Button btnBudgetReport;
    }
}