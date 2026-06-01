namespace DatingAgency
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.customer = new System.Windows.Forms.DataGridView();
            this.candidate = new System.Windows.Forms.DataGridView();
            this.meetings = new System.Windows.Forms.DataGridView();
            this.archive = new System.Windows.Forms.DataGridView();
            this.logout = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.employeeDataGridView = new System.Windows.Forms.DataGridView();
            this.btnShowAllData = new System.Windows.Forms.Button();
            this.btnAddCandidate = new System.Windows.Forms.Button();
            this.btnDeleteCandidate = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candidate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meetings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customer
            // 
            this.customer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customer.Location = new System.Drawing.Point(21, 21);
            this.customer.Name = "customer";
            this.customer.RowHeadersWidth = 62;
            this.customer.RowTemplate.Height = 28;
            this.customer.Size = new System.Drawing.Size(1589, 246);
            this.customer.TabIndex = 0;
            // 
            // candidate
            // 
            this.candidate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.candidate.Location = new System.Drawing.Point(21, 286);
            this.candidate.Name = "candidate";
            this.candidate.RowHeadersWidth = 62;
            this.candidate.RowTemplate.Height = 28;
            this.candidate.Size = new System.Drawing.Size(1589, 246);
            this.candidate.TabIndex = 1;
            // 
            // meetings
            // 
            this.meetings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.meetings.Location = new System.Drawing.Point(21, 1092);
            this.meetings.Name = "meetings";
            this.meetings.RowHeadersWidth = 62;
            this.meetings.RowTemplate.Height = 28;
            this.meetings.Size = new System.Drawing.Size(1589, 246);
            this.meetings.TabIndex = 2;
            // 
            // archive
            // 
            this.archive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.archive.Location = new System.Drawing.Point(21, 818);
            this.archive.Name = "archive";
            this.archive.RowHeadersWidth = 62;
            this.archive.RowTemplate.Height = 28;
            this.archive.Size = new System.Drawing.Size(1589, 246);
            this.archive.TabIndex = 3;
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.MistyRose;
            this.logout.Location = new System.Drawing.Point(65, 35);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(221, 96);
            this.logout.TabIndex = 4;
            this.logout.Text = "Вийти";
            this.logout.UseVisualStyleBackColor = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.BackColor = System.Drawing.Color.MistyRose;
            this.btnAddEmployee.Location = new System.Drawing.Point(65, 535);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(221, 96);
            this.btnAddEmployee.TabIndex = 5;
            this.btnAddEmployee.Text = "Додати працівника";
            this.btnAddEmployee.UseVisualStyleBackColor = false;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.BackColor = System.Drawing.Color.MistyRose;
            this.btnDeleteEmployee.Location = new System.Drawing.Point(65, 662);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(221, 122);
            this.btnDeleteEmployee.TabIndex = 6;
            this.btnDeleteEmployee.Text = "Деактивувати / Активувати працівника";
            this.btnDeleteEmployee.UseVisualStyleBackColor = false;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // employeeDataGridView
            // 
            this.employeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeDataGridView.Location = new System.Drawing.Point(21, 548);
            this.employeeDataGridView.Name = "employeeDataGridView";
            this.employeeDataGridView.RowHeadersWidth = 62;
            this.employeeDataGridView.RowTemplate.Height = 28;
            this.employeeDataGridView.Size = new System.Drawing.Size(1589, 246);
            this.employeeDataGridView.TabIndex = 7;
            // 
            // btnShowAllData
            // 
            this.btnShowAllData.BackColor = System.Drawing.Color.MistyRose;
            this.btnShowAllData.Location = new System.Drawing.Point(65, 158);
            this.btnShowAllData.Name = "btnShowAllData";
            this.btnShowAllData.Size = new System.Drawing.Size(221, 96);
            this.btnShowAllData.TabIndex = 8;
            this.btnShowAllData.Text = "Оновити дані";
            this.btnShowAllData.UseVisualStyleBackColor = false;
            this.btnShowAllData.Click += new System.EventHandler(this.btnShowAllData_Click);
            // 
            // btnAddCandidate
            // 
            this.btnAddCandidate.BackColor = System.Drawing.Color.MistyRose;
            this.btnAddCandidate.Location = new System.Drawing.Point(65, 285);
            this.btnAddCandidate.Name = "btnAddCandidate";
            this.btnAddCandidate.Size = new System.Drawing.Size(221, 96);
            this.btnAddCandidate.TabIndex = 9;
            this.btnAddCandidate.Text = "Створити пару";
            this.btnAddCandidate.UseVisualStyleBackColor = false;
            this.btnAddCandidate.Click += new System.EventHandler(this.btnAddCandidate_Click);
            // 
            // btnDeleteCandidate
            // 
            this.btnDeleteCandidate.BackColor = System.Drawing.Color.MistyRose;
            this.btnDeleteCandidate.Location = new System.Drawing.Point(65, 408);
            this.btnDeleteCandidate.Name = "btnDeleteCandidate";
            this.btnDeleteCandidate.Size = new System.Drawing.Size(221, 96);
            this.btnDeleteCandidate.TabIndex = 10;
            this.btnDeleteCandidate.Text = "Видалити пару";
            this.btnDeleteCandidate.UseVisualStyleBackColor = false;
            this.btnDeleteCandidate.Click += new System.EventHandler(this.btnDeleteCandidate_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.BackColor = System.Drawing.Color.MistyRose;
            this.btnArchive.Location = new System.Drawing.Point(65, 819);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(221, 96);
            this.btnArchive.TabIndex = 11;
            this.btnArchive.Text = "Архівувати пару";
            this.btnArchive.UseVisualStyleBackColor = false;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.logout);
            this.panel1.Controls.Add(this.btnArchive);
            this.panel1.Controls.Add(this.btnShowAllData);
            this.panel1.Controls.Add(this.btnDeleteCandidate);
            this.panel1.Controls.Add(this.btnDeleteEmployee);
            this.panel1.Controls.Add(this.btnAddCandidate);
            this.panel1.Controls.Add(this.btnAddEmployee);
            this.panel1.Location = new System.Drawing.Point(1674, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 961);
            this.panel1.TabIndex = 12;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2042, 1361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.employeeDataGridView);
            this.Controls.Add(this.archive);
            this.Controls.Add(this.meetings);
            this.Controls.Add(this.candidate);
            this.Controls.Add(this.customer);
            this.DoubleBuffered = true;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель адміністратора";
            ((System.ComponentModel.ISupportInitialize)(this.customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candidate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meetings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView customer;
        private System.Windows.Forms.DataGridView candidate;
        private System.Windows.Forms.DataGridView meetings;
        private System.Windows.Forms.DataGridView archive;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.DataGridView employeeDataGridView;
        private System.Windows.Forms.Button btnShowAllData;
        private System.Windows.Forms.Button btnAddCandidate;
        private System.Windows.Forms.Button btnDeleteCandidate;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Panel panel1;
    }
}