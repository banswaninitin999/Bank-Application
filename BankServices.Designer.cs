namespace Bank_Application
{
    partial class BankServices
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cashwithdraw = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.label1.Location = new System.Drawing.Point(239, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Abc Bank Services";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(285, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select your service";
            // 
            // cashwithdraw
            // 
            this.cashwithdraw.AutoSize = true;
            this.cashwithdraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.cashwithdraw.Location = new System.Drawing.Point(276, 123);
            this.cashwithdraw.Name = "cashwithdraw";
            this.cashwithdraw.Size = new System.Drawing.Size(150, 26);
            this.cashwithdraw.TabIndex = 2;
            this.cashwithdraw.TabStop = true;
            this.cashwithdraw.Text = "Cash Withdraw";
            this.cashwithdraw.UseVisualStyleBackColor = true;
            // 
            // BankServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 418);
            this.Controls.Add(this.cashwithdraw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BankServices";
            this.Text = "BankServices";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton cashwithdraw;
    }
}