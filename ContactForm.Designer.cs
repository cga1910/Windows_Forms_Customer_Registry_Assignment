namespace Assignment_05
{
    partial class ContactForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.lblLastname = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEmailPrivate = new System.Windows.Forms.TextBox();
            this.txtEmailBusiness = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhoneCell = new System.Windows.Forms.TextBox();
            this.txtPhoneHome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbAddressCountry = new System.Windows.Forms.ComboBox();
            this.txtAddressZip = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAddressCity = new System.Windows.Forms.TextBox();
            this.txtAddressStreet = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtLastname);
            this.groupBox1.Controls.Add(this.txtFirstname);
            this.groupBox1.Controls.Add(this.lblLastname);
            this.groupBox1.Controls.Add(this.lblFirstName);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // txtLastname
            // 
            this.txtLastname.Location = new System.Drawing.Point(117, 63);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(289, 20);
            this.txtLastname.TabIndex = 2;
            this.txtLastname.TextChanged += new System.EventHandler(this.txtLastname_TextChanged);
            this.txtLastname.Leave += new System.EventHandler(this.txtLastname_Leave);
            // 
            // txtFirstname
            // 
            this.txtFirstname.BackColor = System.Drawing.SystemColors.Window;
            this.txtFirstname.Location = new System.Drawing.Point(117, 32);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(289, 20);
            this.txtFirstname.TabIndex = 1;
            this.txtFirstname.TextChanged += new System.EventHandler(this.txtFirstname_TextChanged);
            this.txtFirstname.Leave += new System.EventHandler(this.txtFirstname_Leave);
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.Location = new System.Drawing.Point(30, 66);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(56, 13);
            this.lblLastname.TabIndex = 1;
            this.lblLastname.Text = "Last name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(30, 35);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(55, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEmailPrivate);
            this.groupBox2.Controls.Add(this.txtEmailBusiness);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtPhoneCell);
            this.groupBox2.Controls.Add(this.txtPhoneHome);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(432, 172);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Email and phone";
            // 
            // txtEmailPrivate
            // 
            this.txtEmailPrivate.Location = new System.Drawing.Point(117, 128);
            this.txtEmailPrivate.Name = "txtEmailPrivate";
            this.txtEmailPrivate.Size = new System.Drawing.Size(289, 20);
            this.txtEmailPrivate.TabIndex = 7;
            // 
            // txtEmailBusiness
            // 
            this.txtEmailBusiness.Location = new System.Drawing.Point(117, 97);
            this.txtEmailBusiness.Name = "txtEmailBusiness";
            this.txtEmailBusiness.Size = new System.Drawing.Size(289, 20);
            this.txtEmailBusiness.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Email, private";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Email, business";
            // 
            // txtPhoneCell
            // 
            this.txtPhoneCell.Location = new System.Drawing.Point(117, 65);
            this.txtPhoneCell.Name = "txtPhoneCell";
            this.txtPhoneCell.Size = new System.Drawing.Size(289, 20);
            this.txtPhoneCell.TabIndex = 5;
            // 
            // txtPhoneHome
            // 
            this.txtPhoneHome.Location = new System.Drawing.Point(117, 34);
            this.txtPhoneHome.Name = "txtPhoneHome";
            this.txtPhoneHome.Size = new System.Drawing.Size(289, 20);
            this.txtPhoneHome.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cell phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Home phone";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbAddressCountry);
            this.groupBox3.Controls.Add(this.txtAddressZip);
            this.groupBox3.Controls.Add(this.lblCountry);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtAddressCity);
            this.groupBox3.Controls.Add(this.txtAddressStreet);
            this.groupBox3.Controls.Add(this.lblCity);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(12, 351);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 176);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Address";
            // 
            // cmbAddressCountry
            // 
            this.cmbAddressCountry.BackColor = System.Drawing.SystemColors.Window;
            this.cmbAddressCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddressCountry.FormattingEnabled = true;
            this.cmbAddressCountry.Location = new System.Drawing.Point(117, 130);
            this.cmbAddressCountry.Name = "cmbAddressCountry";
            this.cmbAddressCountry.Size = new System.Drawing.Size(289, 21);
            this.cmbAddressCountry.TabIndex = 12;
            this.cmbAddressCountry.SelectionChangeCommitted += new System.EventHandler(this.cmbAddressCountry_SelectionChangeCommitted);
            this.cmbAddressCountry.Leave += new System.EventHandler(this.cmbAddressCountry_Leave);
            // 
            // txtAddressZip
            // 
            this.txtAddressZip.Location = new System.Drawing.Point(117, 98);
            this.txtAddressZip.Name = "txtAddressZip";
            this.txtAddressZip.Size = new System.Drawing.Size(289, 20);
            this.txtAddressZip.TabIndex = 11;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(30, 133);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(43, 13);
            this.lblCountry.TabIndex = 17;
            this.lblCountry.Text = "Country";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Zip code";
            // 
            // txtAddressCity
            // 
            this.txtAddressCity.Location = new System.Drawing.Point(117, 66);
            this.txtAddressCity.Name = "txtAddressCity";
            this.txtAddressCity.Size = new System.Drawing.Size(289, 20);
            this.txtAddressCity.TabIndex = 10;
            this.txtAddressCity.TextChanged += new System.EventHandler(this.txtAddressCity_TextChanged);
            this.txtAddressCity.Leave += new System.EventHandler(this.txtAddressCity_Leave);
            // 
            // txtAddressStreet
            // 
            this.txtAddressStreet.BackColor = System.Drawing.SystemColors.Window;
            this.txtAddressStreet.Location = new System.Drawing.Point(117, 35);
            this.txtAddressStreet.Name = "txtAddressStreet";
            this.txtAddressStreet.Size = new System.Drawing.Size(289, 20);
            this.txtAddressStreet.TabIndex = 9;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(30, 69);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(24, 13);
            this.lblCity.TabIndex = 13;
            this.lblCity.Text = "City";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Street";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(353, 540);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 31);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(253, 540);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(91, 31);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(88, 96);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(328, 27);
            this.label1.TabIndex = 15;
            this.label1.Text = "Entering both first and last name is recommended, but not required.";
            // 
            // ContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 585);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "ContactForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContactForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.Label lblLastname;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtEmailPrivate;
        private System.Windows.Forms.TextBox txtEmailBusiness;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhoneCell;
        private System.Windows.Forms.TextBox txtPhoneHome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAddressCountry;
        private System.Windows.Forms.TextBox txtAddressZip;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAddressCity;
        private System.Windows.Forms.TextBox txtAddressStreet;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
    }
}