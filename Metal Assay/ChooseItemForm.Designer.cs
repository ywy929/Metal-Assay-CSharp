namespace Metal_Assay
{
    partial class ChooseItemForm
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.ChooseItemCustomerContentLabel = new System.Windows.Forms.Label();
            this.ChooseItemFormcodeContentLabel = new System.Windows.Forms.Label();
            this.ChooseItemCustomerLabel = new System.Windows.Forms.Label();
            this.ChooseItemFormcodeLabel = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.ChooseItemButton = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelInfo.SuspendLayout();
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
            this.panelHeader.Size = new System.Drawing.Size(450, 70);
            this.panelHeader.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(450, 70);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Select Items";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelMain
            //
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.checkedListBox1);
            this.panelMain.Controls.Add(this.panelInfo);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelMain.Size = new System.Drawing.Size(450, 445);
            this.panelMain.TabIndex = 1;
            //
            // checkedListBox1
            //
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(20, 95);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(410, 335);
            this.checkedListBox1.TabIndex = 1;
            //
            // panelInfo
            //
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelInfo.Controls.Add(this.ChooseItemCustomerContentLabel);
            this.panelInfo.Controls.Add(this.ChooseItemFormcodeContentLabel);
            this.panelInfo.Controls.Add(this.ChooseItemCustomerLabel);
            this.panelInfo.Controls.Add(this.ChooseItemFormcodeLabel);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(20, 15);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelInfo.Size = new System.Drawing.Size(410, 80);
            this.panelInfo.TabIndex = 0;
            //
            // ChooseItemCustomerContentLabel
            //
            this.ChooseItemCustomerContentLabel.AutoSize = true;
            this.ChooseItemCustomerContentLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseItemCustomerContentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ChooseItemCustomerContentLabel.Location = new System.Drawing.Point(130, 45);
            this.ChooseItemCustomerContentLabel.Name = "ChooseItemCustomerContentLabel";
            this.ChooseItemCustomerContentLabel.Size = new System.Drawing.Size(51, 20);
            this.ChooseItemCustomerContentLabel.TabIndex = 3;
            this.ChooseItemCustomerContentLabel.Text = "label4";
            //
            // ChooseItemFormcodeContentLabel
            //
            this.ChooseItemFormcodeContentLabel.AutoSize = true;
            this.ChooseItemFormcodeContentLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseItemFormcodeContentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ChooseItemFormcodeContentLabel.Location = new System.Drawing.Point(130, 15);
            this.ChooseItemFormcodeContentLabel.Name = "ChooseItemFormcodeContentLabel";
            this.ChooseItemFormcodeContentLabel.Size = new System.Drawing.Size(51, 20);
            this.ChooseItemFormcodeContentLabel.TabIndex = 2;
            this.ChooseItemFormcodeContentLabel.Text = "label3";
            //
            // ChooseItemCustomerLabel
            //
            this.ChooseItemCustomerLabel.AutoSize = true;
            this.ChooseItemCustomerLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseItemCustomerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ChooseItemCustomerLabel.Location = new System.Drawing.Point(15, 45);
            this.ChooseItemCustomerLabel.Name = "ChooseItemCustomerLabel";
            this.ChooseItemCustomerLabel.Size = new System.Drawing.Size(76, 20);
            this.ChooseItemCustomerLabel.TabIndex = 1;
            this.ChooseItemCustomerLabel.Text = "Customer:";
            //
            // ChooseItemFormcodeLabel
            //
            this.ChooseItemFormcodeLabel.AutoSize = true;
            this.ChooseItemFormcodeLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseItemFormcodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ChooseItemFormcodeLabel.Location = new System.Drawing.Point(15, 15);
            this.ChooseItemFormcodeLabel.Name = "ChooseItemFormcodeLabel";
            this.ChooseItemFormcodeLabel.Size = new System.Drawing.Size(85, 20);
            this.ChooseItemFormcodeLabel.TabIndex = 0;
            this.ChooseItemFormcodeLabel.Text = "Form Code:";
            //
            // panelFooter
            //
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Controls.Add(this.ChooseItemButton);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 515);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.panelFooter.Size = new System.Drawing.Size(450, 75);
            this.panelFooter.TabIndex = 2;
            //
            // ChooseItemButton
            //
            this.ChooseItemButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ChooseItemButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChooseItemButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseItemButton.FlatAppearance.BorderSize = 0;
            this.ChooseItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseItemButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseItemButton.ForeColor = System.Drawing.Color.White;
            this.ChooseItemButton.Location = new System.Drawing.Point(20, 10);
            this.ChooseItemButton.Name = "ChooseItemButton";
            this.ChooseItemButton.Size = new System.Drawing.Size(410, 45);
            this.ChooseItemButton.TabIndex = 0;
            this.ChooseItemButton.Text = "CONTINUE";
            this.ChooseItemButton.UseVisualStyleBackColor = false;
            this.ChooseItemButton.Click += new System.EventHandler(this.ChooseItemButton_Click);
            this.ChooseItemButton.MouseEnter += new System.EventHandler(this.ChooseItemButton_MouseEnter);
            this.ChooseItemButton.MouseLeave += new System.EventHandler(this.ChooseItemButton_MouseLeave);
            //
            // ChooseItemForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 590);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Items - Metal Assay";
            this.Load += new System.EventHandler(this.ChooseItemForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label ChooseItemCustomerContentLabel;
        private System.Windows.Forms.Label ChooseItemFormcodeContentLabel;
        private System.Windows.Forms.Label ChooseItemCustomerLabel;
        private System.Windows.Forms.Label ChooseItemFormcodeLabel;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button ChooseItemButton;
    }
}
