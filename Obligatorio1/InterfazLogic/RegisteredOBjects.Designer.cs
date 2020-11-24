namespace InterfazLogic
{
    partial class RegisteredOBjects
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
            this.label3 = new System.Windows.Forms.Label();
            this.lstCatgories = new System.Windows.Forms.ListBox();
            this.l = new System.Windows.Forms.Label();
            this.lstCurrencies = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstExpenses = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCategories = new System.Windows.Forms.Label();
            this.lblCurrencies = new System.Windows.Forms.Label();
            this.lblExpenses = new System.Windows.Forms.Label();
            this.BtnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Font = new System.Drawing.Font("AR CENA", 24F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label3.Location = new System.Drawing.Point(21, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1208, 92);
            this.label3.TabIndex = 11;
            this.label3.Text = "               Registered Objects             ";
            // 
            // lstCatgories
            // 
            this.lstCatgories.FormattingEnabled = true;
            this.lstCatgories.ItemHeight = 31;
            this.lstCatgories.Location = new System.Drawing.Point(354, 192);
            this.lstCatgories.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstCatgories.Name = "lstCatgories";
            this.lstCatgories.Size = new System.Drawing.Size(593, 97);
            this.lstCatgories.TabIndex = 20;
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Location = new System.Drawing.Point(136, 192);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(153, 32);
            this.l.TabIndex = 21;
            this.l.Text = "Categories";
            // 
            // lstCurrencies
            // 
            this.lstCurrencies.FormattingEnabled = true;
            this.lstCurrencies.ItemHeight = 31;
            this.lstCurrencies.Location = new System.Drawing.Point(354, 373);
            this.lstCurrencies.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstCurrencies.Name = "lstCurrencies";
            this.lstCurrencies.Size = new System.Drawing.Size(593, 97);
            this.lstCurrencies.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 32);
            this.label1.TabIndex = 23;
            this.label1.Text = "Currencies";
            // 
            // lstExpenses
            // 
            this.lstExpenses.FormattingEnabled = true;
            this.lstExpenses.ItemHeight = 31;
            this.lstExpenses.Location = new System.Drawing.Point(354, 559);
            this.lstExpenses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstExpenses.Name = "lstExpenses";
            this.lstExpenses.Size = new System.Drawing.Size(593, 97);
            this.lstExpenses.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 559);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 32);
            this.label2.TabIndex = 25;
            this.label2.Text = "Expenses";
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Location = new System.Drawing.Point(348, 307);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(0, 32);
            this.lblCategories.TabIndex = 26;
            // 
            // lblCurrencies
            // 
            this.lblCurrencies.AutoSize = true;
            this.lblCurrencies.Location = new System.Drawing.Point(348, 490);
            this.lblCurrencies.Name = "lblCurrencies";
            this.lblCurrencies.Size = new System.Drawing.Size(0, 32);
            this.lblCurrencies.TabIndex = 27;
            // 
            // lblExpenses
            // 
            this.lblExpenses.AutoSize = true;
            this.lblExpenses.Location = new System.Drawing.Point(348, 676);
            this.lblExpenses.Name = "lblExpenses";
            this.lblExpenses.Size = new System.Drawing.Size(0, 32);
            this.lblExpenses.TabIndex = 28;
            // 
            // BtnAccept
            // 
            this.BtnAccept.BackColor = System.Drawing.Color.Tan;
            this.BtnAccept.Location = new System.Drawing.Point(482, 691);
            this.BtnAccept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(227, 74);
            this.BtnAccept.TabIndex = 29;
            this.BtnAccept.Text = "Accept";
            this.BtnAccept.UseVisualStyleBackColor = false;
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // RegisteredOBjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.BtnAccept);
            this.Controls.Add(this.lblExpenses);
            this.Controls.Add(this.lblCurrencies);
            this.Controls.Add(this.lblCategories);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstExpenses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstCurrencies);
            this.Controls.Add(this.l);
            this.Controls.Add(this.lstCatgories);
            this.Controls.Add(this.label3);
            this.Name = "RegisteredOBjects";
            this.Size = new System.Drawing.Size(1304, 793);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstCatgories;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.ListBox lstCurrencies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstExpenses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.Label lblCurrencies;
        private System.Windows.Forms.Label lblExpenses;
        private System.Windows.Forms.Button BtnAccept;
    }
}
