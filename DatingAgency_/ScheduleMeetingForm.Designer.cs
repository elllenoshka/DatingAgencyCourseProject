namespace DatingAgency
{
    partial class ScheduleMeetingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleMeetingForm));
            this.dvdcustomer = new System.Windows.Forms.DataGridView();
            this.dvdcandidate = new System.Windows.Forms.DataGridView();
            this.datetime = new System.Windows.Forms.DateTimePicker();
            this.savemeet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.formatC = new System.Windows.Forms.ComboBox();
            this.locationT = new System.Windows.Forms.TextBox();
            this.resultC = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.notesT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dvdcustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvdcandidate)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvdcustomer
            // 
            this.dvdcustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvdcustomer.Location = new System.Drawing.Point(12, 12);
            this.dvdcustomer.Name = "dvdcustomer";
            this.dvdcustomer.RowHeadersWidth = 62;
            this.dvdcustomer.RowTemplate.Height = 28;
            this.dvdcustomer.Size = new System.Drawing.Size(1050, 228);
            this.dvdcustomer.TabIndex = 3;
            // 
            // dvdcandidate
            // 
            this.dvdcandidate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvdcandidate.Location = new System.Drawing.Point(12, 272);
            this.dvdcandidate.Name = "dvdcandidate";
            this.dvdcandidate.RowHeadersWidth = 62;
            this.dvdcandidate.RowTemplate.Height = 28;
            this.dvdcandidate.Size = new System.Drawing.Size(1050, 228);
            this.dvdcandidate.TabIndex = 4;
            // 
            // datetime
            // 
            this.datetime.CustomFormat = "dd.MM.yyyy HH:mm";
            this.datetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetime.Location = new System.Drawing.Point(137, 323);
            this.datetime.Name = "datetime";
            this.datetime.ShowUpDown = true;
            this.datetime.Size = new System.Drawing.Size(303, 26);
            this.datetime.TabIndex = 5;
            // 
            // savemeet
            // 
            this.savemeet.BackColor = System.Drawing.Color.MistyRose;
            this.savemeet.Location = new System.Drawing.Point(137, 385);
            this.savemeet.Name = "savemeet";
            this.savemeet.Size = new System.Drawing.Size(240, 62);
            this.savemeet.TabIndex = 6;
            this.savemeet.Text = "Зберегти зустріч";
            this.savemeet.UseVisualStyleBackColor = false;
            this.savemeet.Click += new System.EventHandler(this.savemeet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Формат:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Місце:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Статус:";
            // 
            // formatC
            // 
            this.formatC.FormattingEnabled = true;
            this.formatC.Location = new System.Drawing.Point(137, 39);
            this.formatC.Name = "formatC";
            this.formatC.Size = new System.Drawing.Size(303, 28);
            this.formatC.TabIndex = 10;
            // 
            // locationT
            // 
            this.locationT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.locationT.Location = new System.Drawing.Point(137, 96);
            this.locationT.Name = "locationT";
            this.locationT.Size = new System.Drawing.Size(303, 26);
            this.locationT.TabIndex = 11;
            // 
            // resultC
            // 
            this.resultC.FormattingEnabled = true;
            this.resultC.Location = new System.Drawing.Point(137, 154);
            this.resultC.Name = "resultC";
            this.resultC.Size = new System.Drawing.Size(303, 28);
            this.resultC.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Примітки:";
            // 
            // notesT
            // 
            this.notesT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notesT.Location = new System.Drawing.Point(137, 210);
            this.notesT.Multiline = true;
            this.notesT.Name = "notesT";
            this.notesT.Size = new System.Drawing.Size(303, 71);
            this.notesT.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 328);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Дата та час:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.formatC);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.datetime);
            this.panel1.Controls.Add(this.notesT);
            this.panel1.Controls.Add(this.savemeet);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.resultC);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.locationT);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(1133, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 474);
            this.panel1.TabIndex = 16;
            // 
            // ScheduleMeetingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1629, 537);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dvdcandidate);
            this.Controls.Add(this.dvdcustomer);
            this.Name = "ScheduleMeetingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Організація зустрічі";
            ((System.ComponentModel.ISupportInitialize)(this.dvdcustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvdcandidate)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvdcustomer;
        private System.Windows.Forms.DataGridView dvdcandidate;
        private System.Windows.Forms.DateTimePicker datetime;
        private System.Windows.Forms.Button savemeet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox formatC;
        private System.Windows.Forms.TextBox locationT;
        private System.Windows.Forms.ComboBox resultC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox notesT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
    }
}