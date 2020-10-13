namespace InterfazLogic
{
    partial class AddBudgetForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxCategory = new System.Windows.Forms.ListBox();
            this.numericYear = new System.Windows.Forms.NumericUpDown();
            this.ChangeBudgetCategory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericYear)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(321, 360);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(98, 37);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 360);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Año";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(12, 47);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(132, 21);
            this.comboBoxMonth.TabIndex = 4;
            this.comboBoxMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mes";
            // 
            // listBoxCategory
            // 
            this.listBoxCategory.FormattingEnabled = true;
            this.listBoxCategory.Location = new System.Drawing.Point(12, 159);
            this.listBoxCategory.Name = "listBoxCategory";
            this.listBoxCategory.Size = new System.Drawing.Size(231, 186);
            this.listBoxCategory.TabIndex = 6;
            this.listBoxCategory.SelectedIndexChanged += new System.EventHandler(this.listBoxCategory_SelectedIndexChanged);
            this.listBoxCategory.DoubleClick += new System.EventHandler(this.listBoxCategory_DoubleClick);
            // 
            // numericYear
            // 
            this.numericYear.Location = new System.Drawing.Point(12, 99);
            this.numericYear.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.numericYear.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.numericYear.Name = "numericYear";
            this.numericYear.Size = new System.Drawing.Size(132, 20);
            this.numericYear.TabIndex = 7;
            this.numericYear.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numericYear.ValueChanged += new System.EventHandler(this.numericYear_ValueChanged);
            // 
            // ChangeBudgetCategory
            // 
            this.ChangeBudgetCategory.Location = new System.Drawing.Point(259, 237);
            this.ChangeBudgetCategory.Name = "ChangeBudgetCategory";
            this.ChangeBudgetCategory.Size = new System.Drawing.Size(120, 23);
            this.ChangeBudgetCategory.TabIndex = 8;
            this.ChangeBudgetCategory.Text = "Edit Budget Categoy";
            this.ChangeBudgetCategory.UseVisualStyleBackColor = true;
            this.ChangeBudgetCategory.Click += new System.EventHandler(this.ChangeBudgetCategory_Click);
            // 
            // AddBudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 409);
            this.Controls.Add(this.ChangeBudgetCategory);
            this.Controls.Add(this.numericYear);
            this.Controls.Add(this.listBoxCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonCancel);
            this.Name = "AddBudgetForm";
            this.Text = "Add Budget Form";
            this.Load += new System.EventHandler(this.AddBudgetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxCategory;
        private System.Windows.Forms.NumericUpDown numericYear;
        private System.Windows.Forms.Button ChangeBudgetCategory;
    }
}