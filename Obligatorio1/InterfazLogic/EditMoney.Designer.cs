namespace InterfazLogic
{
    partial class EditMoney
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
            this.lstMonies = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeleteMoney = new System.Windows.Forms.Button();
            this.btnEditMoney = new System.Windows.Forms.Button();
            this.lblMonies = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblQuotation = new System.Windows.Forms.Label();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.nQuotation = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSymbol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nQuotation)).BeginInit();
            this.SuspendLayout();
            // 
            // lstMonies
            // 
            this.lstMonies.FormattingEnabled = true;
            this.lstMonies.ItemHeight = 31;
            this.lstMonies.Location = new System.Drawing.Point(226, 194);
            this.lstMonies.Name = "lstMonies";
            this.lstMonies.Size = new System.Drawing.Size(588, 97);
            this.lstMonies.TabIndex = 24;
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
            // btnDeleteMoney
            // 
            this.btnDeleteMoney.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnDeleteMoney.Location = new System.Drawing.Point(851, 270);
            this.btnDeleteMoney.Name = "btnDeleteMoney";
            this.btnDeleteMoney.Size = new System.Drawing.Size(220, 62);
            this.btnDeleteMoney.TabIndex = 28;
            this.btnDeleteMoney.Text = "Delete money";
            this.btnDeleteMoney.UseVisualStyleBackColor = false;
            this.btnDeleteMoney.Click += new System.EventHandler(this.btnDeleteMoney_Click_1);
            // 
            // btnEditMoney
            // 
            this.btnEditMoney.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnEditMoney.Location = new System.Drawing.Point(851, 178);
            this.btnEditMoney.Name = "btnEditMoney";
            this.btnEditMoney.Size = new System.Drawing.Size(220, 62);
            this.btnEditMoney.TabIndex = 27;
            this.btnEditMoney.Text = "Edit money";
            this.btnEditMoney.UseVisualStyleBackColor = false;
            this.btnEditMoney.Click += new System.EventHandler(this.btnEditMoney_Click_1);
            // 
            // lblMonies
            // 
            this.lblMonies.AutoSize = true;
            this.lblMonies.Location = new System.Drawing.Point(220, 323);
            this.lblMonies.Name = "lblMonies";
            this.lblMonies.Size = new System.Drawing.Size(0, 32);
            this.lblMonies.TabIndex = 29;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Tan;
            this.btnCancel.Location = new System.Drawing.Point(621, 863);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(256, 65);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Tan;
            this.btnAdd.Location = new System.Drawing.Point(216, 863);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(256, 65);
            this.btnAdd.TabIndex = 35;
            this.btnAdd.Text = "Accept";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.label2.Location = new System.Drawing.Point(28, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1080, 92);
            this.label2.TabIndex = 41;
            this.label2.Text = "                 Edit money                ";
            // 
            // EditMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.label2);
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
            this.Controls.Add(this.lblMonies);
            this.Controls.Add(this.btnDeleteMoney);
            this.Controls.Add(this.btnEditMoney);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstMonies);
            this.Name = "EditMoney";
            this.Size = new System.Drawing.Size(1191, 947);
            ((System.ComponentModel.ISupportInitialize)(this.nQuotation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstMonies;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDeleteMoney;
        private System.Windows.Forms.Button btnEditMoney;
        private System.Windows.Forms.Label lblMonies;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblQuotation;
        private System.Windows.Forms.Label lblSymbol;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.NumericUpDown nQuotation;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSymbol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
