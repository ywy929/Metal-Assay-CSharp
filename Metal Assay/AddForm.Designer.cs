namespace Metal_Assay
{
    partial class AddForm
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
            this.AddSampleWeightTextbox = new System.Windows.Forms.TextBox();
            this.AddSampleWeightLabel = new System.Windows.Forms.Label();
            this.AddItemcodeTextbox = new System.Windows.Forms.TextBox();
            this.AddItemcodeLabel = new System.Windows.Forms.Label();
            this.AddDateLabel = new System.Windows.Forms.Label();
            this.lblDateTitle = new System.Windows.Forms.Label();
            this.AddFormCodeContent = new System.Windows.Forms.Label();
            this.AddFormCodeLabel = new System.Windows.Forms.Label();
            this.AddCustomerContent = new System.Windows.Forms.Label();
            this.AddCustomerLabel = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.AddCancelButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
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
            this.panelHeader.Size = new System.Drawing.Size(400, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 80);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Item";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.AddSampleWeightTextbox);
            this.panelMain.Controls.Add(this.AddSampleWeightLabel);
            this.panelMain.Controls.Add(this.AddItemcodeTextbox);
            this.panelMain.Controls.Add(this.AddItemcodeLabel);
            this.panelMain.Controls.Add(this.AddDateLabel);
            this.panelMain.Controls.Add(this.lblDateTitle);
            this.panelMain.Controls.Add(this.AddFormCodeContent);
            this.panelMain.Controls.Add(this.AddFormCodeLabel);
            this.panelMain.Controls.Add(this.AddCustomerContent);
            this.panelMain.Controls.Add(this.AddCustomerLabel);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(40, 20, 40, 10);
            this.panelMain.Size = new System.Drawing.Size(400, 220);
            this.panelMain.TabIndex = 1;
            // 
            // AddCustomerLabel
            // 
            this.AddCustomerLabel.AutoSize = true;
            this.AddCustomerLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCustomerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AddCustomerLabel.Location = new System.Drawing.Point(40, 20);
            this.AddCustomerLabel.Name = "AddCustomerLabel";
            this.AddCustomerLabel.Size = new System.Drawing.Size(68, 19);
            this.AddCustomerLabel.TabIndex = 0;
            this.AddCustomerLabel.Text = "Customer:";
            // 
            // AddCustomerContent
            // 
            this.AddCustomerContent.AutoSize = true;
            this.AddCustomerContent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCustomerContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AddCustomerContent.Location = new System.Drawing.Point(140, 20);
            this.AddCustomerContent.Name = "AddCustomerContent";
            this.AddCustomerContent.Size = new System.Drawing.Size(45, 19);
            this.AddCustomerContent.TabIndex = 1;
            this.AddCustomerContent.Text = "Name";
            // 
            // AddFormCodeLabel
            // 
            this.AddFormCodeLabel.AutoSize = true;
            this.AddFormCodeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFormCodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AddFormCodeLabel.Location = new System.Drawing.Point(40, 45);
            this.AddFormCodeLabel.Name = "AddFormCodeLabel";
            this.AddFormCodeLabel.Size = new System.Drawing.Size(76, 19);
            this.AddFormCodeLabel.TabIndex = 2;
            this.AddFormCodeLabel.Text = "Form Code:";
            // 
            // AddFormCodeContent
            // 
            this.AddFormCodeContent.AutoSize = true;
            this.AddFormCodeContent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFormCodeContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AddFormCodeContent.Location = new System.Drawing.Point(140, 45);
            this.AddFormCodeContent.Name = "AddFormCodeContent";
            this.AddFormCodeContent.Size = new System.Drawing.Size(36, 19);
            this.AddFormCodeContent.TabIndex = 3;
            this.AddFormCodeContent.Text = "0000";
            // 
            // lblDateTitle
            // 
            this.lblDateTitle.AutoSize = true;
            this.lblDateTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDateTitle.Location = new System.Drawing.Point(40, 70);
            this.lblDateTitle.Name = "lblDateTitle";
            this.lblDateTitle.Size = new System.Drawing.Size(38, 19);
            this.lblDateTitle.TabIndex = 4;
            this.lblDateTitle.Text = "Date:";
            // 
            // AddDateLabel
            // 
            this.AddDateLabel.AutoSize = true;
            this.AddDateLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddDateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AddDateLabel.Location = new System.Drawing.Point(140, 70);
            this.AddDateLabel.Name = "AddDateLabel";
            this.AddDateLabel.Size = new System.Drawing.Size(38, 19);
            this.AddDateLabel.TabIndex = 5;
            this.AddDateLabel.Text = "Date";
            // 
            // AddItemcodeLabel
            // 
            this.AddItemcodeLabel.AutoSize = true;
            this.AddItemcodeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddItemcodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AddItemcodeLabel.Location = new System.Drawing.Point(40, 100);
            this.AddItemcodeLabel.Name = "AddItemcodeLabel";
            this.AddItemcodeLabel.Size = new System.Drawing.Size(69, 19);
            this.AddItemcodeLabel.TabIndex = 6;
            this.AddItemcodeLabel.Text = "Item Code";
            // 
            // AddItemcodeTextbox
            // 
            this.AddItemcodeTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddItemcodeTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AddItemcodeTextbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddItemcodeTextbox.Location = new System.Drawing.Point(40, 122);
            this.AddItemcodeTextbox.Name = "AddItemcodeTextbox";
            this.AddItemcodeTextbox.Size = new System.Drawing.Size(320, 29);
            this.AddItemcodeTextbox.TabIndex = 0;
            this.AddItemcodeTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabToNext);
            // 
            // AddSampleWeightLabel
            // 
            this.AddSampleWeightLabel.AutoSize = true;
            this.AddSampleWeightLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSampleWeightLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AddSampleWeightLabel.Location = new System.Drawing.Point(40, 158);
            this.AddSampleWeightLabel.Name = "AddSampleWeightLabel";
            this.AddSampleWeightLabel.Size = new System.Drawing.Size(116, 19);
            this.AddSampleWeightLabel.TabIndex = 8;
            this.AddSampleWeightLabel.Text = "Sample Weight (g)";
            // 
            // AddSampleWeightTextbox
            // 
            this.AddSampleWeightTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddSampleWeightTextbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSampleWeightTextbox.Location = new System.Drawing.Point(40, 180);
            this.AddSampleWeightTextbox.Name = "AddSampleWeightTextbox";
            this.AddSampleWeightTextbox.Size = new System.Drawing.Size(320, 29);
            this.AddSampleWeightTextbox.TabIndex = 1;
            this.AddSampleWeightTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabToNext);
            this.AddSampleWeightTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalValidation);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Controls.Add(this.AddCancelButton);
            this.panelFooter.Controls.Add(this.AddButton);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 300);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(40, 10, 40, 20);
            this.panelFooter.Size = new System.Drawing.Size(400, 75);
            this.panelFooter.TabIndex = 2;
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddButton.FlatAppearance.BorderSize = 0;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.ForeColor = System.Drawing.Color.White;
            this.AddButton.Location = new System.Drawing.Point(40, 10);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(150, 45);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            this.AddButton.MouseEnter += new System.EventHandler(this.AddButton_MouseEnter);
            this.AddButton.MouseLeave += new System.EventHandler(this.AddButton_MouseLeave);
            // 
            // AddCancelButton
            // 
            this.AddCancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.AddCancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddCancelButton.FlatAppearance.BorderSize = 0;
            this.AddCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddCancelButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCancelButton.ForeColor = System.Drawing.Color.White;
            this.AddCancelButton.Location = new System.Drawing.Point(210, 10);
            this.AddCancelButton.Name = "AddCancelButton";
            this.AddCancelButton.Size = new System.Drawing.Size(150, 45);
            this.AddCancelButton.TabIndex = 3;
            this.AddCancelButton.Text = "Cancel";
            this.AddCancelButton.UseVisualStyleBackColor = false;
            this.AddCancelButton.Click += new System.EventHandler(this.AddCancelButton_Click);
            this.AddCancelButton.MouseEnter += new System.EventHandler(this.AddCancelButton_MouseEnter);
            this.AddCancelButton.MouseLeave += new System.EventHandler(this.AddCancelButton_MouseLeave);
            // 
            // AddForm
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 375);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Item - Metal Assay";
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox AddSampleWeightTextbox;
        private System.Windows.Forms.Label AddSampleWeightLabel;
        private System.Windows.Forms.TextBox AddItemcodeTextbox;
        private System.Windows.Forms.Label AddItemcodeLabel;
        private System.Windows.Forms.Label AddDateLabel;
        private System.Windows.Forms.Label lblDateTitle;
        private System.Windows.Forms.Label AddFormCodeContent;
        private System.Windows.Forms.Label AddFormCodeLabel;
        private System.Windows.Forms.Label AddCustomerContent;
        private System.Windows.Forms.Label AddCustomerLabel;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button AddCancelButton;
        private System.Windows.Forms.Button AddButton;
    }
}