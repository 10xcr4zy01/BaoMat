namespace BaoMat
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.viInputTxB = new System.Windows.Forms.TextBox();
            this.viKeyTxB = new System.Windows.Forms.TextBox();
            this.encipherBtn = new System.Windows.Forms.Button();
            this.decipherBtn = new System.Windows.Forms.Button();
            this.viOutPutTxB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // viInputTxB
            // 
            this.viInputTxB.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viInputTxB.Location = new System.Drawing.Point(102, 75);
            this.viInputTxB.Name = "viInputTxB";
            this.viInputTxB.Size = new System.Drawing.Size(120, 27);
            this.viInputTxB.TabIndex = 0;
            this.viInputTxB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // viKeyTxB
            // 
            this.viKeyTxB.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viKeyTxB.Location = new System.Drawing.Point(102, 120);
            this.viKeyTxB.Name = "viKeyTxB";
            this.viKeyTxB.Size = new System.Drawing.Size(120, 27);
            this.viKeyTxB.TabIndex = 2;
            // 
            // encipherBtn
            // 
            this.encipherBtn.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.encipherBtn.Location = new System.Drawing.Point(102, 199);
            this.encipherBtn.Name = "encipherBtn";
            this.encipherBtn.Size = new System.Drawing.Size(120, 30);
            this.encipherBtn.TabIndex = 3;
            this.encipherBtn.Text = "Encipher";
            this.encipherBtn.UseVisualStyleBackColor = true;
            this.encipherBtn.Click += new System.EventHandler(this.encipherBtn_Click);
            // 
            // decipherBtn
            // 
            this.decipherBtn.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.decipherBtn.Location = new System.Drawing.Point(102, 163);
            this.decipherBtn.Name = "decipherBtn";
            this.decipherBtn.Size = new System.Drawing.Size(120, 30);
            this.decipherBtn.TabIndex = 4;
            this.decipherBtn.Text = "Decipher";
            this.decipherBtn.UseVisualStyleBackColor = true;
            this.decipherBtn.Click += new System.EventHandler(this.decipherBtn_Click);
            // 
            // viOutPutTxB
            // 
            this.viOutPutTxB.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viOutPutTxB.Location = new System.Drawing.Point(102, 247);
            this.viOutPutTxB.Name = "viOutPutTxB";
            this.viOutPutTxB.Size = new System.Drawing.Size(120, 27);
            this.viOutPutTxB.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Input";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(32, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(32, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(59, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "Vigenere";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 290);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viOutPutTxB);
            this.Controls.Add(this.decipherBtn);
            this.Controls.Add(this.encipherBtn);
            this.Controls.Add(this.viKeyTxB);
            this.Controls.Add(this.viInputTxB);
            this.Name = "Form1";
            this.Text = "BAO MAT VA AN NINH MANG";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox viInputTxB;
        private TextBox viKeyTxB;
        private Button encipherBtn;
        private Button decipherBtn;
        private TextBox viOutPutTxB;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}