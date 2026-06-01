namespace DatingAgency
{
    partial class EmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            this.candidate = new System.Windows.Forms.DataGridView();
            this.customer = new System.Windows.Forms.DataGridView();
            this.addcustomer = new System.Windows.Forms.Button();
            this.meeting = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.meetings = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.createMatch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.candidate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meetings)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // candidate
            // 
            this.candidate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.candidate.Location = new System.Drawing.Point(12, 12);
            this.candidate.Name = "candidate";
            this.candidate.RowHeadersWidth = 62;
            this.candidate.RowTemplate.Height = 28;
            this.candidate.Size = new System.Drawing.Size(1543, 265);
            this.candidate.TabIndex = 1;
            // 
            // customer
            // 
            this.customer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customer.Location = new System.Drawing.Point(12, 299);
            this.customer.Name = "customer";
            this.customer.RowHeadersWidth = 62;
            this.customer.RowTemplate.Height = 28;
            this.customer.Size = new System.Drawing.Size(1543, 265);
            this.customer.TabIndex = 2;
            // 
            // addcustomer
            // 
            this.addcustomer.BackColor = System.Drawing.Color.MistyRose;
            this.addcustomer.Location = new System.Drawing.Point(51, 40);
            this.addcustomer.Name = "addcustomer";
            this.addcustomer.Size = new System.Drawing.Size(247, 93);
            this.addcustomer.TabIndex = 3;
            this.addcustomer.Text = "Додати клієнта";
            this.addcustomer.UseVisualStyleBackColor = false;
            this.addcustomer.Click += new System.EventHandler(this.addcustomer_Click);
            // 
            // meeting
            // 
            this.meeting.BackColor = System.Drawing.Color.MistyRose;
            this.meeting.Location = new System.Drawing.Point(317, 40);
            this.meeting.Name = "meeting";
            this.meeting.Size = new System.Drawing.Size(247, 93);
            this.meeting.TabIndex = 4;
            this.meeting.Text = "Організувати зустріч";
            this.meeting.UseVisualStyleBackColor = false;
            this.meeting.Click += new System.EventHandler(this.meeting_Click);
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.MistyRose;
            this.logout.Location = new System.Drawing.Point(1256, 40);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(181, 93);
            this.logout.TabIndex = 5;
            this.logout.Text = "Вийти";
            this.logout.UseVisualStyleBackColor = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.MistyRose;
            this.btnShowAll.Location = new System.Drawing.Point(850, 40);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(247, 93);
            this.btnShowAll.TabIndex = 9;
            this.btnShowAll.Text = "Оновити дані";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // meetings
            // 
            this.meetings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.meetings.Location = new System.Drawing.Point(12, 591);
            this.meetings.Name = "meetings";
            this.meetings.RowHeadersWidth = 62;
            this.meetings.RowTemplate.Height = 28;
            this.meetings.Size = new System.Drawing.Size(1543, 265);
            this.meetings.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.createMatch);
            this.panel1.Controls.Add(this.addcustomer);
            this.panel1.Controls.Add(this.meeting);
            this.panel1.Controls.Add(this.logout);
            this.panel1.Controls.Add(this.btnShowAll);
            this.panel1.Location = new System.Drawing.Point(41, 894);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1473, 168);
            this.panel1.TabIndex = 11;
            // 
            // createMatch
            // 
            this.createMatch.BackColor = System.Drawing.Color.MistyRose;
            this.createMatch.Location = new System.Drawing.Point(584, 40);
            this.createMatch.Name = "createMatch";
            this.createMatch.Size = new System.Drawing.Size(247, 93);
            this.createMatch.TabIndex = 10;
            this.createMatch.Text = "Створити пару";
            this.createMatch.UseVisualStyleBackColor = false;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1567, 1095);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.meetings);
            this.Controls.Add(this.customer);
            this.Controls.Add(this.candidate);
            this.Name = "EmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель працівника";
            ((System.ComponentModel.ISupportInitialize)(this.candidate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meetings)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView candidate;
        private System.Windows.Forms.DataGridView customer;
        private System.Windows.Forms.Button addcustomer;
        private System.Windows.Forms.Button meeting;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.DataGridView meetings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button createMatch;
    }
}