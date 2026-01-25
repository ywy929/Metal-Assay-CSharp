namespace Metal_Assay
{
    partial class SendToOther
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SendToCustomerButton = new System.Windows.Forms.Button();
            this.CustomerCombobox = new System.Windows.Forms.ComboBox();
            this.lblCustomerInstruction = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SendToAddressButton = new System.Windows.Forms.Button();
            this.OtherTextbox = new System.Windows.Forms.TextBox();
            this.lblAddressInstruction = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(550, 70);
            this.panelHeader.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(550, 70);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Send to Other";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelMain
            //
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.groupBox2);
            this.panelMain.Controls.Add(this.groupBox1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30, 20, 30, 30);
            this.panelMain.Size = new System.Drawing.Size(550, 480);
            this.panelMain.TabIndex = 1;
            //
            // groupBox1
            //
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.groupBox1.Controls.Add(this.lblCustomerInstruction);
            this.groupBox1.Controls.Add(this.SendToCustomerButton);
            this.groupBox1.Controls.Add(this.CustomerCombobox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.groupBox1.Location = new System.Drawing.Point(30, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(15);
            this.groupBox1.Size = new System.Drawing.Size(490, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Send To Existing Customer";
            //
            // lblCustomerInstruction
            //
            this.lblCustomerInstruction.AutoSize = true;
            this.lblCustomerInstruction.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerInstruction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCustomerInstruction.Location = new System.Drawing.Point(20, 40);
            this.lblCustomerInstruction.Name = "lblCustomerInstruction";
            this.lblCustomerInstruction.Size = new System.Drawing.Size(159, 19);
            this.lblCustomerInstruction.TabIndex = 0;
            this.lblCustomerInstruction.Text = "Select Customer Name:";
            //
            // CustomerCombobox
            //
            this.CustomerCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CustomerCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CustomerCombobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomerCombobox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerCombobox.FormattingEnabled = true;
            this.CustomerCombobox.Location = new System.Drawing.Point(20, 65);
            this.CustomerCombobox.Name = "CustomerCombobox";
            this.CustomerCombobox.Size = new System.Drawing.Size(450, 28);
            this.CustomerCombobox.TabIndex = 1;
            //
            // SendToCustomerButton
            //
            this.SendToCustomerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.SendToCustomerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendToCustomerButton.FlatAppearance.BorderSize = 0;
            this.SendToCustomerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendToCustomerButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendToCustomerButton.ForeColor = System.Drawing.Color.White;
            this.SendToCustomerButton.Location = new System.Drawing.Point(175, 125);
            this.SendToCustomerButton.Name = "SendToCustomerButton";
            this.SendToCustomerButton.Size = new System.Drawing.Size(140, 50);
            this.SendToCustomerButton.TabIndex = 2;
            this.SendToCustomerButton.Text = "SEND";
            this.SendToCustomerButton.UseVisualStyleBackColor = false;
            this.SendToCustomerButton.Click += new System.EventHandler(this.button1_Click);
            this.SendToCustomerButton.MouseEnter += new System.EventHandler(this.SendToCustomerButton_MouseEnter);
            this.SendToCustomerButton.MouseLeave += new System.EventHandler(this.SendToCustomerButton_MouseLeave);
            //
            // groupBox2
            //
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.groupBox2.Controls.Add(this.lblAddressInstruction);
            this.groupBox2.Controls.Add(this.SendToAddressButton);
            this.groupBox2.Controls.Add(this.OtherTextbox);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.groupBox2.Location = new System.Drawing.Point(30, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(15);
            this.groupBox2.Size = new System.Drawing.Size(490, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other";
            //
            // lblAddressInstruction
            //
            this.lblAddressInstruction.AutoSize = true;
            this.lblAddressInstruction.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressInstruction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAddressInstruction.Location = new System.Drawing.Point(20, 40);
            this.lblAddressInstruction.Name = "lblAddressInstruction";
            this.lblAddressInstruction.Size = new System.Drawing.Size(150, 19);
            this.lblAddressInstruction.TabIndex = 0;
            this.lblAddressInstruction.Text = "Enter Email or Fax No:";
            //
            // OtherTextbox
            //
            this.OtherTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OtherTextbox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherTextbox.Location = new System.Drawing.Point(20, 65);
            this.OtherTextbox.Name = "OtherTextbox";
            this.OtherTextbox.Size = new System.Drawing.Size(450, 27);
            this.OtherTextbox.TabIndex = 1;
            //
            // SendToAddressButton
            //
            this.SendToAddressButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.SendToAddressButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendToAddressButton.FlatAppearance.BorderSize = 0;
            this.SendToAddressButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendToAddressButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendToAddressButton.ForeColor = System.Drawing.Color.White;
            this.SendToAddressButton.Location = new System.Drawing.Point(175, 125);
            this.SendToAddressButton.Name = "SendToAddressButton";
            this.SendToAddressButton.Size = new System.Drawing.Size(140, 50);
            this.SendToAddressButton.TabIndex = 2;
            this.SendToAddressButton.Text = "SEND";
            this.SendToAddressButton.UseVisualStyleBackColor = false;
            this.SendToAddressButton.Click += new System.EventHandler(this.button2_Click);
            this.SendToAddressButton.MouseEnter += new System.EventHandler(this.SendToAddressButton_MouseEnter);
            this.SendToAddressButton.MouseLeave += new System.EventHandler(this.SendToAddressButton_MouseLeave);
            //
            // SendToOther
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 550);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendToOther";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send to Other - Metal Assay";
            this.Load += new System.EventHandler(this.SendToOther_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCustomerInstruction;
        private System.Windows.Forms.ComboBox CustomerCombobox;
        private System.Windows.Forms.Button SendToCustomerButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblAddressInstruction;
        private System.Windows.Forms.TextBox OtherTextbox;
        private System.Windows.Forms.Button SendToAddressButton;
    }
}
