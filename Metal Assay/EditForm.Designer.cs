namespace Metal_Assay
{
    partial class EditForm
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
            this.panelInputs = new System.Windows.Forms.Panel();
            this.EditSampleWeightTextbox = new System.Windows.Forms.TextBox();
            this.EditSampleWeightLabel = new System.Windows.Forms.Label();
            this.EditItemcodeTextbox = new System.Windows.Forms.TextBox();
            this.EditItemcodeLabel = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.EditDateLabel = new System.Windows.Forms.Label();
            this.lblDateTitle = new System.Windows.Forms.Label();
            this.EditFormCodeLabel = new System.Windows.Forms.Label();
            this.lblFormCodeTitle = new System.Windows.Forms.Label();
            this.EditCustomerLabel = new System.Windows.Forms.Label();
            this.lblCustomerTitle = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.CancelSaveButton = new System.Windows.Forms.Button();
            this.EditSaveButton = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelInputs.SuspendLayout();
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
            this.panelHeader.Size = new System.Drawing.Size(500, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 80);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Edit Assay";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.panelInputs);
            this.panelMain.Controls.Add(this.panelInfo);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(40, 20, 40, 10);
            this.panelMain.Size = new System.Drawing.Size(500, 335);
            this.panelMain.TabIndex = 1;
            // 
            // panelInputs
            // 
            this.panelInputs.Controls.Add(this.EditSampleWeightTextbox);
            this.panelInputs.Controls.Add(this.EditSampleWeightLabel);
            this.panelInputs.Controls.Add(this.EditItemcodeTextbox);
            this.panelInputs.Controls.Add(this.EditItemcodeLabel);
            this.panelInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInputs.Location = new System.Drawing.Point(40, 120);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panelInputs.Size = new System.Drawing.Size(420, 205);
            this.panelInputs.TabIndex = 1;
            // 
            // EditSampleWeightTextbox
            // 
            this.EditSampleWeightTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditSampleWeightTextbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSampleWeightTextbox.Location = new System.Drawing.Point(0, 97);
            this.EditSampleWeightTextbox.Name = "EditSampleWeightTextbox";
            this.EditSampleWeightTextbox.Size = new System.Drawing.Size(420, 29);
            this.EditSampleWeightTextbox.TabIndex = 1;
            this.EditSampleWeightTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabToNext);
            this.EditSampleWeightTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalValidation);
            // 
            // EditSampleWeightLabel
            // 
            this.EditSampleWeightLabel.AutoSize = true;
            this.EditSampleWeightLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSampleWeightLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EditSampleWeightLabel.Location = new System.Drawing.Point(0, 75);
            this.EditSampleWeightLabel.Name = "EditSampleWeightLabel";
            this.EditSampleWeightLabel.Size = new System.Drawing.Size(120, 19);
            this.EditSampleWeightLabel.TabIndex = 2;
            this.EditSampleWeightLabel.Text = "Sample Weight (g)";
            // 
            // EditItemcodeTextbox
            // 
            this.EditItemcodeTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditItemcodeTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.EditItemcodeTextbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditItemcodeTextbox.Location = new System.Drawing.Point(0, 32);
            this.EditItemcodeTextbox.Name = "EditItemcodeTextbox";
            this.EditItemcodeTextbox.Size = new System.Drawing.Size(420, 29);
            this.EditItemcodeTextbox.TabIndex = 0;
            this.EditItemcodeTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabToNext);
            // 
            // EditItemcodeLabel
            // 
            this.EditItemcodeLabel.AutoSize = true;
            this.EditItemcodeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditItemcodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EditItemcodeLabel.Location = new System.Drawing.Point(0, 10);
            this.EditItemcodeLabel.Name = "EditItemcodeLabel";
            this.EditItemcodeLabel.Size = new System.Drawing.Size(73, 19);
            this.EditItemcodeLabel.TabIndex = 0;
            this.EditItemcodeLabel.Text = "Item Code";
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.EditDateLabel);
            this.panelInfo.Controls.Add(this.lblDateTitle);
            this.panelInfo.Controls.Add(this.EditFormCodeLabel);
            this.panelInfo.Controls.Add(this.lblFormCodeTitle);
            this.panelInfo.Controls.Add(this.EditCustomerLabel);
            this.panelInfo.Controls.Add(this.lblCustomerTitle);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(40, 20);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(420, 100);
            this.panelInfo.TabIndex = 0;
            // 
            // EditDateLabel
            // 
            this.EditDateLabel.AutoSize = true;
            this.EditDateLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditDateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EditDateLabel.Location = new System.Drawing.Point(110, 71);
            this.EditDateLabel.Name = "EditDateLabel";
            this.EditDateLabel.Size = new System.Drawing.Size(40, 19);
            this.EditDateLabel.TabIndex = 5;
            this.EditDateLabel.Text = "Date";
            // 
            // lblDateTitle
            // 
            this.lblDateTitle.AutoSize = true;
            this.lblDateTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDateTitle.Location = new System.Drawing.Point(12, 71);
            this.lblDateTitle.Name = "lblDateTitle";
            this.lblDateTitle.Size = new System.Drawing.Size(41, 19);
            this.lblDateTitle.TabIndex = 4;
            this.lblDateTitle.Text = "Date:";
            // 
            // EditFormCodeLabel
            // 
            this.EditFormCodeLabel.AutoSize = true;
            this.EditFormCodeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditFormCodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EditFormCodeLabel.Location = new System.Drawing.Point(110, 41);
            this.EditFormCodeLabel.Name = "EditFormCodeLabel";
            this.EditFormCodeLabel.Size = new System.Drawing.Size(79, 19);
            this.EditFormCodeLabel.TabIndex = 3;
            this.EditFormCodeLabel.Text = "FormCode";
            // 
            // lblFormCodeTitle
            // 
            this.lblFormCodeTitle.AutoSize = true;
            this.lblFormCodeTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormCodeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFormCodeTitle.Location = new System.Drawing.Point(12, 41);
            this.lblFormCodeTitle.Name = "lblFormCodeTitle";
            this.lblFormCodeTitle.Size = new System.Drawing.Size(80, 19);
            this.lblFormCodeTitle.TabIndex = 2;
            this.lblFormCodeTitle.Text = "Form Code:";
            // 
            // EditCustomerLabel
            // 
            this.EditCustomerLabel.AutoSize = true;
            this.EditCustomerLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCustomerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EditCustomerLabel.Location = new System.Drawing.Point(110, 11);
            this.EditCustomerLabel.Name = "EditCustomerLabel";
            this.EditCustomerLabel.Size = new System.Drawing.Size(73, 19);
            this.EditCustomerLabel.TabIndex = 1;
            this.EditCustomerLabel.Text = "Customer";
            // 
            // lblCustomerTitle
            // 
            this.lblCustomerTitle.AutoSize = true;
            this.lblCustomerTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCustomerTitle.Location = new System.Drawing.Point(12, 11);
            this.lblCustomerTitle.Name = "lblCustomerTitle";
            this.lblCustomerTitle.Size = new System.Drawing.Size(72, 19);
            this.lblCustomerTitle.TabIndex = 0;
            this.lblCustomerTitle.Text = "Customer:";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Controls.Add(this.CancelSaveButton);
            this.panelFooter.Controls.Add(this.EditSaveButton);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 415);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(40, 10, 40, 20);
            this.panelFooter.Size = new System.Drawing.Size(500, 75);
            this.panelFooter.TabIndex = 2;
            // 
            // CancelSaveButton
            // 
            this.CancelSaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CancelSaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelSaveButton.FlatAppearance.BorderSize = 0;
            this.CancelSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelSaveButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelSaveButton.ForeColor = System.Drawing.Color.White;
            this.CancelSaveButton.Location = new System.Drawing.Point(260, 10);
            this.CancelSaveButton.Name = "CancelSaveButton";
            this.CancelSaveButton.Size = new System.Drawing.Size(200, 45);
            this.CancelSaveButton.TabIndex = 3;
            this.CancelSaveButton.Text = "Cancel";
            this.CancelSaveButton.UseVisualStyleBackColor = false;
            this.CancelSaveButton.Click += new System.EventHandler(this.CancelSaveButton_Click);
            this.CancelSaveButton.MouseEnter += new System.EventHandler(this.CancelSaveButton_MouseEnter);
            this.CancelSaveButton.MouseLeave += new System.EventHandler(this.CancelSaveButton_MouseLeave);
            // 
            // EditSaveButton
            // 
            this.EditSaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.EditSaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditSaveButton.FlatAppearance.BorderSize = 0;
            this.EditSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditSaveButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSaveButton.ForeColor = System.Drawing.Color.White;
            this.EditSaveButton.Location = new System.Drawing.Point(40, 10);
            this.EditSaveButton.Name = "EditSaveButton";
            this.EditSaveButton.Size = new System.Drawing.Size(200, 45);
            this.EditSaveButton.TabIndex = 2;
            this.EditSaveButton.Text = "Save";
            this.EditSaveButton.UseVisualStyleBackColor = false;
            this.EditSaveButton.Click += new System.EventHandler(this.EditSaveButton_Click);
            this.EditSaveButton.MouseEnter += new System.EventHandler(this.EditSaveButton_MouseEnter);
            this.EditSaveButton.MouseLeave += new System.EventHandler(this.EditSaveButton_MouseLeave);
            // 
            // EditForm
            // 
            this.AcceptButton = this.EditSaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 490);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Assay - Metal Assay";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelInputs.ResumeLayout(false);
            this.panelInputs.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelInputs;
        private System.Windows.Forms.TextBox EditSampleWeightTextbox;
        private System.Windows.Forms.Label EditSampleWeightLabel;
        private System.Windows.Forms.TextBox EditItemcodeTextbox;
        private System.Windows.Forms.Label EditItemcodeLabel;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label EditDateLabel;
        private System.Windows.Forms.Label lblDateTitle;
        private System.Windows.Forms.Label EditFormCodeLabel;
        private System.Windows.Forms.Label lblFormCodeTitle;
        private System.Windows.Forms.Label EditCustomerLabel;
        private System.Windows.Forms.Label lblCustomerTitle;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button CancelSaveButton;
        private System.Windows.Forms.Button EditSaveButton;
    }
}