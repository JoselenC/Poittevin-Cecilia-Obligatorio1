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
            this.lblMenu.Location = new System.Drawing.Point(55, 52);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(86, 32);
            this.lblMenu.TabIndex = 1;
            this.lblMenu.Text = "Menu";
            // 
            // btnRegisterCategory
            // 
            this.btnRegisterCategory.Location = new System.Drawing.Point(61, 125);
            this.btnRegisterCategory.Name = "btnRegisterCategory";
            this.btnRegisterCategory.Size = new System.Drawing.Size(295, 57);
            this.btnRegisterCategory.TabIndex = 2;
            this.btnRegisterCategory.Text = "Register Category";
            this.btnRegisterCategory.UseVisualStyleBackColor = true;
            this.btnRegisterCategory.Click += new System.EventHandler(this.btnRegisterCategory_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(381, 21);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1232, 897);
            this.mainPanel.TabIndex = 7;
            // 
            // btnRegisterExpense
            // 
            this.btnRegisterExpense.Location = new System.Drawing.Point(61, 227);
            this.btnRegisterExpense.Name = "btnRegisterExpense";
            this.btnRegisterExpense.Size = new System.Drawing.Size(295, 57);
            this.btnRegisterExpense.TabIndex = 8;
            this.btnRegisterExpense.Text = "Register Expense";
            this.btnRegisterExpense.UseVisualStyleBackColor = true;
            // 
            // btnRegisterBudget
            // 
            this.btnRegisterBudget.Location = new System.Drawing.Point(61, 333);
            this.btnRegisterBudget.Name = "btnRegisterBudget";
            this.btnRegisterBudget.Size = new System.Drawing.Size(295, 57);
            this.btnRegisterBudget.TabIndex = 9;
            this.btnRegisterBudget.Text = "Register Budget";
            this.btnRegisterBudget.UseVisualStyleBackColor = true;
            // 
            // btnExpenseReport
            // 
            this.btnExpenseReport.Location = new System.Drawing.Point(61, 446);
            this.btnExpenseReport.Name = "btnExpenseReport";
            this.btnExpenseReport.Size = new System.Drawing.Size(295, 57);
            this.btnExpenseReport.TabIndex = 10;
            this.btnExpenseReport.Text = "Expense report";
            this.btnExpenseReport.UseVisualStyleBackColor = true;
            // 
            // btnBudgetReport
            // 
            this.btnBudgetReport.Location = new System.Drawing.Point(59, 554);
            this.btnBudgetReport.Name = "btnBudgetReport";
            this.btnBudgetReport.Size = new System.Drawing.Size(295, 59);
            this.btnBudgetReport.TabIndex = 11;
            this.btnBudgetReport.Text = "BudgetReport";
            this.btnBudgetReport.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1625, 930);
            this.Controls.Add(this.btnBudgetReport);
            this.Controls.Add(this.btnExpenseReport);
            this.Controls.Add(this.btnRegisterBudget);
            this.Controls.Add(this.btnRegisterExpense);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.btnRegisterCategory);
            this.Controls.Add(this.lblMenu);
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