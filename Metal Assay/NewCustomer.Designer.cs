namespace Metal_Assay
{
    partial class NewCustomer
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.lblOptionsHeader = new System.Windows.Forms.Label();
            this.CouponComboBox = new System.Windows.Forms.ComboBox();
            this.lblCoupon = new System.Windows.Forms.Label();
            this.BillingComboBox = new System.Windows.Forms.ComboBox();
            this.lblBilling = new System.Windows.Forms.Label();
            this.OrientationComboBox = new System.Windows.Forms.ComboBox();
            this.lblOrientation = new System.Windows.Forms.Label();
            this.panelContactInfo = new System.Windows.Forms.Panel();
            this.lblContactHeader = new System.Windows.Forms.Label();
            this.FaxTextBox = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.CustomerNameTextBox = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.AddCustomerButton = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.panelContactInfo.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(600, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(600, 70);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Customer";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.panelOptions);
            this.panelMain.Controls.Add(this.panelContactInfo);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30, 20, 30, 10);
            this.panelMain.Size = new System.Drawing.Size(600, 430);
            this.panelMain.TabIndex = 1;
            // 
            // panelOptions
            // 
            this.panelOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelOptions.Controls.Add(this.lblOptionsHeader);
            this.panelOptions.Controls.Add(this.CouponComboBox);
            this.panelOptions.Controls.Add(this.lblCoupon);
            this.panelOptions.Controls.Add(this.BillingComboBox);
            this.panelOptions.Controls.Add(this.lblBilling);
            this.panelOptions.Controls.Add(this.OrientationComboBox);
            this.panelOptions.Controls.Add(this.lblOrientation);
            this.panelOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOptions.Location = new System.Drawing.Point(30, 280);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelOptions.Size = new System.Drawing.Size(540, 140);
            this.panelOptions.TabIndex = 1;
            // 
            // lblOptionsHeader
            // 
            this.lblOptionsHeader.AutoSize = true;
            this.lblOptionsHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptionsHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.lblOptionsHeader.Location = new System.Drawing.Point(20, 15);
            this.lblOptionsHeader.Name = "lblOptionsHeader";
            this.lblOptionsHeader.Size = new System.Drawing.Size(70, 21);
            this.lblOptionsHeader.TabIndex = 6;
            this.lblOptionsHeader.Text = "Options";
            // 
            // CouponComboBox
            // 
            this.CouponComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CouponComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CouponComboBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CouponComboBox.FormattingEnabled = true;
            this.CouponComboBox.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.CouponComboBox.Location = new System.Drawing.Point(360, 75);
            this.CouponComboBox.Name = "CouponComboBox";
            this.CouponComboBox.Size = new System.Drawing.Size(160, 28);
            this.CouponComboBox.TabIndex = 5;
            // 
            // lblCoupon
            // 
            this.lblCoupon.AutoSize = true;
            this.lblCoupon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoupon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCoupon.Location = new System.Drawing.Point(360, 50);
            this.lblCoupon.Name = "lblCoupon";
            this.lblCoupon.Size = new System.Drawing.Size(61, 19);
            this.lblCoupon.TabIndex = 4;
            this.lblCoupon.Text = "Coupon:";
            // 
            // BillingComboBox
            // 
            this.BillingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BillingComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BillingComboBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillingComboBox.FormattingEnabled = true;
            this.BillingComboBox.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.BillingComboBox.Location = new System.Drawing.Point(190, 75);
            this.BillingComboBox.Name = "BillingComboBox";
            this.BillingComboBox.Size = new System.Drawing.Size(160, 28);
            this.BillingComboBox.TabIndex = 4;
            // 
            // lblBilling
            // 
            this.lblBilling.AutoSize = true;
            this.lblBilling.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBilling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBilling.Location = new System.Drawing.Point(190, 50);
            this.lblBilling.Name = "lblBilling";
            this.lblBilling.Size = new System.Drawing.Size(48, 19);
            this.lblBilling.TabIndex = 2;
            this.lblBilling.Text = "Billing:";
            // 
            // OrientationComboBox
            // 
            this.OrientationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OrientationComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrientationComboBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrientationComboBox.FormattingEnabled = true;
            this.OrientationComboBox.Items.AddRange(new object[] {
            "BW",
            "PG"});
            this.OrientationComboBox.Location = new System.Drawing.Point(20, 75);
            this.OrientationComboBox.Name = "OrientationComboBox";
            this.OrientationComboBox.Size = new System.Drawing.Size(160, 28);
            this.OrientationComboBox.TabIndex = 3;
            // 
            // lblOrientation
            // 
            this.lblOrientation.AutoSize = true;
            this.lblOrientation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrientation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblOrientation.Location = new System.Drawing.Point(20, 50);
            this.lblOrientation.Name = "lblOrientation";
            this.lblOrientation.Size = new System.Drawing.Size(82, 19);
            this.lblOrientation.TabIndex = 0;
            this.lblOrientation.Text = "Orientation:";
            // 
            // panelContactInfo
            // 
            this.panelContactInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelContactInfo.Controls.Add(this.lblContactHeader);
            this.panelContactInfo.Controls.Add(this.FaxTextBox);
            this.panelContactInfo.Controls.Add(this.lblFax);
            this.panelContactInfo.Controls.Add(this.EmailTextBox);
            this.panelContactInfo.Controls.Add(this.lblEmail);
            this.panelContactInfo.Controls.Add(this.PhoneTextBox);
            this.panelContactInfo.Controls.Add(this.lblPhone);
            this.panelContactInfo.Controls.Add(this.CustomerNameTextBox);
            this.panelContactInfo.Controls.Add(this.lblCustomerName);
            this.panelContactInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContactInfo.Location = new System.Drawing.Point(30, 20);
            this.panelContactInfo.Name = "panelContactInfo";
            this.panelContactInfo.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelContactInfo.Size = new System.Drawing.Size(540, 260);
            this.panelContactInfo.TabIndex = 0;
            // 
            // lblContactHeader
            // 
            this.lblContactHeader.AutoSize = true;
            this.lblContactHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.lblContactHeader.Location = new System.Drawing.Point(20, 15);
            this.lblContactHeader.Name = "lblContactHeader";
            this.lblContactHeader.Size = new System.Drawing.Size(165, 21);
            this.lblContactHeader.TabIndex = 8;
            this.lblContactHeader.Text = "Contact Information";
            // 
            // FaxTextBox
            // 
            this.FaxTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FaxTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FaxTextBox.Location = new System.Drawing.Point(20, 215);
            this.FaxTextBox.Name = "FaxTextBox";
            this.FaxTextBox.Size = new System.Drawing.Size(500, 27);
            this.FaxTextBox.TabIndex = 2;
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFax.Location = new System.Drawing.Point(20, 190);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(32, 19);
            this.lblFax.TabIndex = 6;
            this.lblFax.Text = "Fax:";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EmailTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextBox.Location = new System.Drawing.Point(20, 155);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(500, 27);
            this.EmailTextBox.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmail.Location = new System.Drawing.Point(20, 130);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 19);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PhoneTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneTextBox.Location = new System.Drawing.Point(20, 95);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(500, 27);
            this.PhoneTextBox.TabIndex = 0;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPhone.Location = new System.Drawing.Point(20, 70);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(51, 19);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Phone:";
            // 
            // CustomerNameTextBox
            // 
            this.CustomerNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.CustomerNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustomerNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CustomerNameTextBox.Enabled = false;
            this.CustomerNameTextBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerNameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.CustomerNameTextBox.Location = new System.Drawing.Point(130, 40);
            this.CustomerNameTextBox.Name = "CustomerNameTextBox";
            this.CustomerNameTextBox.Size = new System.Drawing.Size(390, 27);
            this.CustomerNameTextBox.TabIndex = 0;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCustomerName.Location = new System.Drawing.Point(20, 43);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(112, 19);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name:";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Controls.Add(this.AddCustomerButton);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 500);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(30, 10, 30, 20);
            this.panelFooter.Size = new System.Drawing.Size(600, 75);
            this.panelFooter.TabIndex = 2;
            // 
            // AddCustomerButton
            // 
            this.AddCustomerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.AddCustomerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddCustomerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddCustomerButton.FlatAppearance.BorderSize = 0;
            this.AddCustomerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddCustomerButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCustomerButton.ForeColor = System.Drawing.Color.White;
            this.AddCustomerButton.Location = new System.Drawing.Point(30, 10);
            this.AddCustomerButton.Name = "AddCustomerButton";
            this.AddCustomerButton.Size = new System.Drawing.Size(540, 45);
            this.AddCustomerButton.TabIndex = 0;
            this.AddCustomerButton.Text = "ADD CUSTOMER";
            this.AddCustomerButton.UseVisualStyleBackColor = false;
            this.AddCustomerButton.Click += new System.EventHandler(this.AddCustomerButton_Click);
            this.AddCustomerButton.MouseEnter += new System.EventHandler(this.AddCustomerButton_MouseEnter);
            this.AddCustomerButton.MouseLeave += new System.EventHandler(this.AddCustomerButton_MouseLeave);
            // 
            // NewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 575);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Customer - Metal Assay";
            this.Load += new System.EventHandler(this.NewCustomer_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            this.panelContactInfo.ResumeLayout(false);
            this.panelContactInfo.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.ComboBox CouponComboBox;
        private System.Windows.Forms.Label lblCoupon;
        private System.Windows.Forms.ComboBox BillingComboBox;
        private System.Windows.Forms.Label lblBilling;
        private System.Windows.Forms.ComboBox OrientationComboBox;
        private System.Windows.Forms.Label lblOrientation;
        private System.Windows.Forms.Panel panelContactInfo;
        private System.Windows.Forms.TextBox FaxTextBox;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox CustomerNameTextBox;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button AddCustomerButton;
        private System.Windows.Forms.Label lblOptionsHeader;
        private System.Windows.Forms.Label lblContactHeader;
    }
}
