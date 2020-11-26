namespace InterfazLogic
{
    partial class EditCurrency
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
            this.lstCurrencies = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnDeletecurrency = new System.Windows.Forms.Button();
            this.BtnEditcurrency = new System.Windows.Forms.Button();
            this.lblcurrencies = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.lblQuotation = new System.Windows.Forms.Label();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.nQuotation = new System.Windows.Forms.NumericUpDown();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSymbol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nQuotation)).BeginInit();
            this.SuspendLayout();
            // 
            // lstCurrencies
            // 
            this.lstCurrencies.FormattingEnabled = true;
            this.lstCurrencies.ItemHeight = 31;
            this.lstCurrencies.Location = new System.Drawing.Point(226, 194);
            this.lstCurrencies.Name = "lstCurrencies";
            this.lstCurrencies.Size = new System.Drawing.Size(588, 97);
            this.lstCurrencies.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 32);
            this.label5.TabIndex = 25;
            this.label5.Text = "Monies";
            // 
            // BtnDeletecurrency
            // 
            this.BtnDeletecurrency.BackColor = System.Drawing.Color.DarkKhaki;
            this.BtnDeletecurrency.Location = new System.Drawing.Point(851, 270);
            this.BtnDeletecurrency.Name = "BtnDeletecurrency";
            this.BtnDeletecurrency.Size = new System.Drawing.Size(233, 62);
            this.BtnDeletecurrency.TabIndex = 28;
            this.BtnDeletecurrency.Text = "Delete Currency";
            this.BtnDeletecurrency.UseVisualStyleBackColor = false;
            this.BtnDeletecurrency.Click += new System.EventHandler(this.BtnDeletecurrency_Click);
            // 
            // BtnEditcurrency
            // 
            this.BtnEditcurrency.BackColor = System.Drawing.Color.DarkKhaki;
            this.BtnEditcurrency.Location = new System.Drawing.Point(851, 178);
            this.BtnEditcurrency.Name = "BtnEditcurrency";
            this.BtnEditcurrency.Size = new System.Drawing.Size(233, 62);
            this.BtnEditcurrency.TabIndex = 27;
            this.BtnEditcurrency.Text = "Edit currency";
            this.BtnEditcurrency.UseVisualStyleBackColor = false;
            this.BtnEditcurrency.Click += new System.EventHandler(this.BtnEditcurrency_Click);
            // 
            // lblcurrencies
            // 
            this.lblcurrencies.AutoSize = true;
            this.lblcurrencies.Location = new System.Drawing.Point(220, 323);
            this.lblcurrencies.Name = "lblcurrencies";
            this.lblcurrencies.Size = new System.Drawing.Size(0, 32);
            this.lblcurrencies.TabIndex = 29;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Tan;
            this.BtnCancel.Location = new System.Drawing.Point(621, 863);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(256, 65);
            this.BtnCancel.TabIndex = 40;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblQuotation
            // 
            this.lblQuotation.AutoSize = true;
            this.lblQuotation.Location = new System.Drawing.Point(220, 787);
            this.lblQuotation.Name = "lblQuotation";
            this.lblQuotation.Size = new System.Drawing.Size(0, 32);
            this.lblQuotation.TabIndex = 39;
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.Location = new System.Drawing.Point(220, 629);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(0, 32);
            this.lblSymbol.TabIndex = 38;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(220, 470);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 32);
            this.lblName.TabIndex = 37;
            // 
            // nQuotation
            // 
            this.nQuotation.DecimalPlaces = 2;
            this.nQuotation.Location = new System.Drawing.Point(226, 711);
            this.nQuotation.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nQuotation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nQuotation.Name = "nQuotation";
            this.nQuotation.Size = new System.Drawing.Size(589, 38);
            this.nQuotation.TabIndex = 36;
            this.nQuotation.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.Tan;
            this.BtnAdd.Location = new System.Drawing.Point(216, 863);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(256, 65);
            this.BtnAdd.TabIndex = 35;
            this.BtnAdd.Text = "Accept";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 711);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 32);
            this.label4.TabIndex = 34;
            this.label4.Text = "Quotation";
            // 
            // tbSymbol
            // 
            this.tbSymbol.BackColor = System.Drawing.Color.White;
            this.tbSymbol.Location = new System.Drawing.Point(225, 561);
            this.tbSymbol.Name = "tbSymbol";
            this.tbSymbol.Size = new System.Drawing.Size(589, 38);
            this.tbSymbol.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 567);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 32);
            this.label3.TabIndex = 32;
            this.label3.Text = "Symbol";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.White;
            this.tbName.Location = new System.Drawing.Point(225, 396);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(589, 38);
            this.tbName.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 32);
            this.label1.TabIndex = 30;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label2.Font = new System.Drawing.Font("AR CENA", 24F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.Location = new System.Drawing.Point(23, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1151, 92);
            this.label2.TabIndex = 41;
            this.label2.Text = "                 Edit currency                ";
            // 
            // EditCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.lblQuotation);
            this.Controls.Add(this.lblSymbol);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.nQuotation);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSymbol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblcurrencies);
            this.Controls.Add(this.BtnDeletecurrency);
            this.Controls.Add(this.BtnEditcurrency);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstCurrencies);
            this.Name = "EditCurrency";
            this.Size = new System.Drawing.Size(1191, 947);
            ((System.ComponentModel.ISupportInitialize)(this.nQuotation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstCurrencies;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnDeletecurrency;
        private System.Windows.Forms.Button BtnEditcurrency;
        private System.Windows.Forms.Label lblcurrencies;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label lblQuotation;
        private System.Windows.Forms.Label lblSymbol;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.NumericUpDown nQuotation;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSymbol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
