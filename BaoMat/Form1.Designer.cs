namespace BaoMat
{
    partial class Vigenere
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // viInputTxB
            // 
            this.viInputTxB.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viInputTxB.Location = new System.Drawing.Point(109, 70);
            this.viInputTxB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viInputTxB.Name = "viInputTxB";
            this.viInputTxB.Size = new System.Drawing.Size(433, 32);
            this.viInputTxB.TabIndex = 0;
            // 
            // viKeyTxB
            // 
            this.viKeyTxB.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viKeyTxB.Location = new System.Drawing.Point(109, 130);
            this.viKeyTxB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viKeyTxB.Name = "viKeyTxB";
            this.viKeyTxB.Size = new System.Drawing.Size(433, 32);
            this.viKeyTxB.TabIndex = 2;
            // 
            // encipherBtn
            // 
            this.encipherBtn.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.encipherBtn.Location = new System.Drawing.Point(209, 232);
            this.encipherBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.encipherBtn.Name = "encipherBtn";
            this.encipherBtn.Size = new System.Drawing.Size(137, 40);
            this.encipherBtn.TabIndex = 3;
            this.encipherBtn.Text = "Encipher";
            this.encipherBtn.UseVisualStyleBackColor = true;
            this.encipherBtn.Click += new System.EventHandler(this.encipherBtn_Click);
            // 
            // decipherBtn
            // 
            this.decipherBtn.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.decipherBtn.Location = new System.Drawing.Point(209, 184);
            this.decipherBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.decipherBtn.Name = "decipherBtn";
            this.decipherBtn.Size = new System.Drawing.Size(137, 40);
            this.decipherBtn.TabIndex = 4;
            this.decipherBtn.Text = "Decipher";
            this.decipherBtn.UseVisualStyleBackColor = true;
            this.decipherBtn.Click += new System.EventHandler(this.decipherBtn_Click);
            // 
            // viOutPutTxB
            // 
            this.viOutPutTxB.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viOutPutTxB.Location = new System.Drawing.Point(100, 284);
            this.viOutPutTxB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.viOutPutTxB.Name = "viOutPutTxB";
            this.viOutPutTxB.Size = new System.Drawing.Size(442, 32);
            this.viOutPutTxB.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(19, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Input";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(29, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(19, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Output";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.viInputTxB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.viKeyTxB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.encipherBtn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.decipherBtn);
            this.groupBox1.Controls.Add(this.viOutPutTxB);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 330);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vigenere";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(387, 388);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "Back to menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Vigenere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 453);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Vigenere";
            this.Text = "BAO MAT VA AN NINH MANG";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
        private GroupBox groupBox1;
        private Button button1;
    }
}