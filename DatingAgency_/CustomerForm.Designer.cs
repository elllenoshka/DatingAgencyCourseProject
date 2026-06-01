namespace DatingAgency
{
    partial class CustomerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            this.partner = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.agemin = new System.Windows.Forms.NumericUpDown();
            this.agemax = new System.Windows.Forms.NumericUpDown();
            this.heightmax = new System.Windows.Forms.NumericUpDown();
            this.heightmin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.filter = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.showAllCandidates = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cityC = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.educationC = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.partner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agemin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agemax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightmin)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // partner
            // 
            this.partner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partner.Location = new System.Drawing.Point(12, 12);
            this.partner.Name = "partner";
            this.partner.RowHeadersWidth = 62;
            this.partner.RowTemplate.Height = 28;
            this.partner.Size = new System.Drawing.Size(1443, 363);
            this.partner.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Мінімальний вік:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Максимальний вік:";
            // 
            // agemin
            // 
            this.agemin.Location = new System.Drawing.Point(170, 24);
            this.agemin.Name = "agemin";
            this.agemin.Size = new System.Drawing.Size(166, 26);
            this.agemin.TabIndex = 5;
            // 
            // agemax
            // 
            this.agemax.Location = new System.Drawing.Point(561, 24);
            this.agemax.Name = "agemax";
            this.agemax.Size = new System.Drawing.Size(166, 26);
            this.agemax.TabIndex = 6;
            // 
            // heightmax
            // 
            this.heightmax.Location = new System.Drawing.Point(561, 66);
            this.heightmax.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.heightmax.Name = "heightmax";
            this.heightmax.Size = new System.Drawing.Size(166, 26);
            this.heightmax.TabIndex = 10;
            // 
            // heightmin
            // 
            this.heightmin.Location = new System.Drawing.Point(170, 62);
            this.heightmin.Name = "heightmin";
            this.heightmin.Size = new System.Drawing.Size(166, 26);
            this.heightmin.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Максимальний зріст:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Мінімальний зріст:";
            // 
            // filter
            // 
            this.filter.BackColor = System.Drawing.Color.MistyRose;
            this.filter.Location = new System.Drawing.Point(28, 107);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(196, 75);
            this.filter.TabIndex = 17;
            this.filter.Text = "Пошук партнерів";
            this.filter.UseVisualStyleBackColor = false;
            this.filter.Click += new System.EventHandler(this.filter_Click);
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.MistyRose;
            this.logout.Location = new System.Drawing.Point(1192, 107);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(159, 75);
            this.logout.TabIndex = 18;
            this.logout.Text = "Вихід";
            this.logout.UseVisualStyleBackColor = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // showAllCandidates
            // 
            this.showAllCandidates.BackColor = System.Drawing.Color.MistyRose;
            this.showAllCandidates.Location = new System.Drawing.Point(255, 107);
            this.showAllCandidates.Name = "showAllCandidates";
            this.showAllCandidates.Size = new System.Drawing.Size(265, 75);
            this.showAllCandidates.TabIndex = 19;
            this.showAllCandidates.Text = "Показати всіх партнерів";
            this.showAllCandidates.UseVisualStyleBackColor = false;
            this.showAllCandidates.Click += new System.EventHandler(this.showAllCandidates_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(797, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Місто:";
            // 
            // cityC
            // 
            this.cityC.FormattingEnabled = true;
            this.cityC.Location = new System.Drawing.Point(869, 26);
            this.cityC.Name = "cityC";
            this.cityC.Size = new System.Drawing.Size(260, 28);
            this.cityC.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(789, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Освіта:";
            // 
            // educationC
            // 
            this.educationC.FormattingEnabled = true;
            this.educationC.Location = new System.Drawing.Point(869, 65);
            this.educationC.Name = "educationC";
            this.educationC.Size = new System.Drawing.Size(260, 28);
            this.educationC.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.logout);
            this.panel1.Controls.Add(this.educationC);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cityC);
            this.panel1.Controls.Add(this.agemin);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.agemax);
            this.panel1.Controls.Add(this.showAllCandidates);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.filter);
            this.panel1.Controls.Add(this.heightmin);
            this.panel1.Controls.Add(this.heightmax);
            this.panel1.Location = new System.Drawing.Point(47, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1387, 211);
            this.panel1.TabIndex = 24;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1472, 639);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.partner);
            this.Name = "CustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель клієнта";
            ((System.ComponentModel.ISupportInitialize)(this.partner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agemin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agemax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightmin)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView partner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown agemin;
        private System.Windows.Forms.NumericUpDown agemax;
        private System.Windows.Forms.NumericUpDown heightmax;
        private System.Windows.Forms.NumericUpDown heightmin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button filter;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button showAllCandidates;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cityC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox educationC;
        private System.Windows.Forms.Panel panel1;
    }
}