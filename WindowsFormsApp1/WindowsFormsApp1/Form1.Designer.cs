namespace WindowsFormsApp1
{
    partial class Form1
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
            this.btnSayHello = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblRes = new System.Windows.Forms.Label();
            this.lblOuput = new System.Windows.Forms.Label();
            this.lblAnimals = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSayHello
            // 
            this.btnSayHello.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnSayHello.ForeColor = System.Drawing.Color.Red;
            this.btnSayHello.Location = new System.Drawing.Point(51, 74);
            this.btnSayHello.Name = "btnSayHello";
            this.btnSayHello.Size = new System.Drawing.Size(100, 27);
            this.btnSayHello.TabIndex = 0;
            this.btnSayHello.Text = "Say Hello";
            this.btnSayHello.UseVisualStyleBackColor = true;
            this.btnSayHello.Click += new System.EventHandler(this.btnSayHello_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(51, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblRes.ForeColor = System.Drawing.Color.Blue;
            this.lblRes.Location = new System.Drawing.Point(48, 116);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(0, 20);
            this.lblRes.TabIndex = 2;
            // 
            // lblOuput
            // 
            this.lblOuput.AutoSize = true;
            this.lblOuput.Location = new System.Drawing.Point(236, 48);
            this.lblOuput.Name = "lblOuput";
            this.lblOuput.Size = new System.Drawing.Size(35, 13);
            this.lblOuput.TabIndex = 3;
            this.lblOuput.Text = "label1";
            // 
            // lblAnimals
            // 
            this.lblAnimals.AutoSize = true;
            this.lblAnimals.Location = new System.Drawing.Point(364, 48);
            this.lblAnimals.Name = "lblAnimals";
            this.lblAnimals.Size = new System.Drawing.Size(0, 13);
            this.lblAnimals.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 217);
            this.Controls.Add(this.lblAnimals);
            this.Controls.Add(this.lblOuput);
            this.Controls.Add(this.lblRes);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSayHello);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSayHello;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.Label lblOuput;
        private System.Windows.Forms.Label lblAnimals;
    }
}

