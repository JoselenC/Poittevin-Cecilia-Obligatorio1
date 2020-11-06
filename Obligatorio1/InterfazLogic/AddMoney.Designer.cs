namespace InterfazLogic
{
    partial class AddMoney
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSymbol = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.nQuotation = new System.Windows.Forms.NumericUpDown();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.lblQuotation = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nQuotation)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label2.Font = new System.Drawing.Font("AR CENA", 24F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.Location = new System.Drawing.Point(39, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1165, 92);
            this.label2.TabIndex = 11;
            this.label2.Text = "              Register money                 ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.White;
            this.tbName.Location = new System.Drawing.Point(373, 194);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(589, 38);
            this.tbName.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 32);
            this.label3.TabIndex = 14;
            this.label3.Text = "Symbol";
            // 
            // tbSymbol
            // 
            this.tbSymbol.BackColor = System.Drawing.Color.White;
            this.tbSymbol.Location = new System.Drawing.Point(367, 376);
            this.tbSymbol.Name = "tbSymbol";
            this.tbSymbol.Size = new System.Drawing.Size(589, 38);
            this.tbSymbol.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 561);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 32);
            this.label4.TabIndex = 17;
            this.label4.Text = "Quotation";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Tan;
            this.btnAdd.Location = new System.Drawing.Point(284, 766);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(256, 65);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Accept";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // nQuotation
            // 
            this.nQuotation.DecimalPlaces = 2;
            this.nQuotation.Location = new System.Drawing.Point(367, 559);
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
            this.nQuotation.TabIndex = 19;
            this.nQuotation.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(367, 282);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 32);
            this.lblName.TabIndex = 20;
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.Location = new System.Drawing.Point(367, 459);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(0, 32);
            this.lblSymbol.TabIndex = 21;
            // 
            // lblQuotation
            // 
            this.lblQuotation.AutoSize = true;
            this.lblQuotation.Location = new System.Drawing.Point(367, 650);
            this.lblQuotation.Name = "lblQuotation";
            this.lblQuotation.Size = new System.Drawing.Size(0, 32);
            this.lblQuotation.TabIndex = 22;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Tan;
            this.btnCancel.Location = new System.Drawing.Point(726, 766);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(256, 65);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblQuotation);
            this.Controls.Add(this.lblSymbol);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.nQuotation);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSymbol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "AddMoney";
            this.Size = new System.Drawing.Size(1247, 878);
            ((System.ComponentModel.ISupportInitialize)(this.nQuotation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSymbol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown nQuotation;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSymbol;
        private System.Windows.Forms.Label lblQuotation;
        private System.Windows.Forms.Button btnCancel;
    }
}
