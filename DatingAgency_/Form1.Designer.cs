namespace DatingAgency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.passwrd = new System.Windows.Forms.TextBox();
            this.log = new System.Windows.Forms.Button();
            this.reg = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // email
            // 
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email.Location = new System.Drawing.Point(167, 42);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(264, 26);
            this.email.TabIndex = 2;
            // 
            // passwrd
            // 
            this.passwrd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwrd.Location = new System.Drawing.Point(167, 91);
            this.passwrd.Name = "passwrd";
            this.passwrd.Size = new System.Drawing.Size(264, 26);
            this.passwrd.TabIndex = 3;
            this.passwrd.UseSystemPasswordChar = true;
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.Color.MistyRose;
            this.log.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.log.Location = new System.Drawing.Point(56, 165);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(170, 62);
            this.log.TabIndex = 4;
            this.log.Text = "Увійти";
            this.log.UseVisualStyleBackColor = false;
            this.log.Click += new System.EventHandler(this.log_Click);
            // 
            // reg
            // 
            this.reg.BackColor = System.Drawing.Color.MistyRose;
            this.reg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reg.Location = new System.Drawing.Point(259, 165);
            this.reg.Name = "reg";
            this.reg.Size = new System.Drawing.Size(172, 62);
            this.reg.TabIndex = 5;
            this.reg.Text = "Зареєструватися";
            this.reg.UseVisualStyleBackColor = false;
            this.reg.Click += new System.EventHandler(this.reg_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.reg);
            this.panel1.Controls.Add(this.passwrd);
            this.panel1.Controls.Add(this.log);
            this.panel1.Controls.Add(this.email);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(111, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 267);
            this.panel1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(678, 394);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вхід до системи";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox passwrd;
        private System.Windows.Forms.Button log;
        private System.Windows.Forms.Button reg;
        private System.Windows.Forms.Panel panel1;
    }
}

