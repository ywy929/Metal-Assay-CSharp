namespace Metal_Assay
{
    partial class NewForm
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
            this.panelInput = new System.Windows.Forms.Panel();
            this.NewCustomerListbox = new System.Windows.Forms.ListBox();
            this.NewSampleWeightTextbox = new System.Windows.Forms.TextBox();
            this.NewSampleWeightLabel = new System.Windows.Forms.Label();
            this.NewItemcodeTextbox = new System.Windows.Forms.TextBox();
            this.NewItemcodeLabel = new System.Windows.Forms.Label();
            this.NewCustomerTextbox = new System.Windows.Forms.TextBox();
            this.NewCustomerLabel = new System.Windows.Forms.Label();
            this.lblInputHeader = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.NewDateContent = new System.Windows.Forms.Label();
            this.NewDateLabel = new System.Windows.Forms.Label();
            this.NewFormCodeContent = new System.Windows.Forms.Label();
            this.NewFormCodeLabel = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.NewFormCodeButton = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelInput.SuspendLayout();
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
            this.lblTitle.Text = "New Assay Record";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.panelInput);
            this.panelMain.Controls.Add(this.panelInfo);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30, 20, 30, 10);
            this.panelMain.Size = new System.Drawing.Size(600, 380);
            this.panelMain.TabIndex = 1;
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelInput.Controls.Add(this.NewCustomerListbox);
            this.panelInput.Controls.Add(this.NewSampleWeightTextbox);
            this.panelInput.Controls.Add(this.NewSampleWeightLabel);
            this.panelInput.Controls.Add(this.NewItemcodeTextbox);
            this.panelInput.Controls.Add(this.NewItemcodeLabel);
            this.panelInput.Controls.Add(this.NewCustomerTextbox);
            this.panelInput.Controls.Add(this.NewCustomerLabel);
            this.panelInput.Controls.Add(this.lblInputHeader);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput.Location = new System.Drawing.Point(30, 130);
            this.panelInput.Name = "panelInput";
            this.panelInput.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelInput.Size = new System.Drawing.Size(540, 240);
            this.panelInput.TabIndex = 1;
            // 
            // NewCustomerListbox
            // 
            this.NewCustomerListbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewCustomerListbox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCustomerListbox.FormattingEnabled = true;
            this.NewCustomerListbox.ItemHeight = 20;
            this.NewCustomerListbox.Location = new System.Drawing.Point(20, 98);
            this.NewCustomerListbox.Name = "NewCustomerListbox";
            this.NewCustomerListbox.Size = new System.Drawing.Size(500, 122);
            this.NewCustomerListbox.TabIndex = 1;
            this.NewCustomerListbox.Visible = false;
            this.NewCustomerListbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewCustomerListbox_KeyDown);
            this.NewCustomerListbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NewCustomerListbox_MouseDoubleClick);
            // 
            // NewSampleWeightTextbox
            // 
            this.NewSampleWeightTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewSampleWeightTextbox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSampleWeightTextbox.Location = new System.Drawing.Point(20, 207);
            this.NewSampleWeightTextbox.Name = "NewSampleWeightTextbox";
            this.NewSampleWeightTextbox.Size = new System.Drawing.Size(240, 27);
            this.NewSampleWeightTextbox.TabIndex = 3;
            this.NewSampleWeightTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewSampleWeightTextbox_KeyDown);
            this.NewSampleWeightTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Decimal_Validation);
            // 
            // NewSampleWeightLabel
            // 
            this.NewSampleWeightLabel.AutoSize = true;
            this.NewSampleWeightLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSampleWeightLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewSampleWeightLabel.Location = new System.Drawing.Point(20, 182);
            this.NewSampleWeightLabel.Name = "NewSampleWeightLabel";
            this.NewSampleWeightLabel.Size = new System.Drawing.Size(123, 19);
            this.NewSampleWeightLabel.TabIndex = 6;
            this.NewSampleWeightLabel.Text = "Sample Weight (g):";
            // 
            // NewItemcodeTextbox
            // 
            this.NewItemcodeTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewItemcodeTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NewItemcodeTextbox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewItemcodeTextbox.Location = new System.Drawing.Point(20, 143);
            this.NewItemcodeTextbox.Name = "NewItemcodeTextbox";
            this.NewItemcodeTextbox.Size = new System.Drawing.Size(240, 27);
            this.NewItemcodeTextbox.TabIndex = 2;
            this.NewItemcodeTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewItemcodeTextbox_KeyDown);
            // 
            // NewItemcodeLabel
            // 
            this.NewItemcodeLabel.AutoSize = true;
            this.NewItemcodeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewItemcodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewItemcodeLabel.Location = new System.Drawing.Point(20, 118);
            this.NewItemcodeLabel.Name = "NewItemcodeLabel";
            this.NewItemcodeLabel.Size = new System.Drawing.Size(76, 19);
            this.NewItemcodeLabel.TabIndex = 4;
            this.NewItemcodeLabel.Text = "Item Code:";
            // 
            // NewCustomerTextbox
            // 
            this.NewCustomerTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewCustomerTextbox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCustomerTextbox.Location = new System.Drawing.Point(20, 70);
            this.NewCustomerTextbox.Name = "NewCustomerTextbox";
            this.NewCustomerTextbox.Size = new System.Drawing.Size(500, 27);
            this.NewCustomerTextbox.TabIndex = 0;
            this.NewCustomerTextbox.TextChanged += new System.EventHandler(this.NewCustomerTextbox_TextChanged);
            this.NewCustomerTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewCustomerTextbox_KeyDown);
            this.NewCustomerTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewCustomerTextbox_KeyPress);
            // 
            // NewCustomerLabel
            // 
            this.NewCustomerLabel.AutoSize = true;
            this.NewCustomerLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCustomerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewCustomerLabel.Location = new System.Drawing.Point(20, 45);
            this.NewCustomerLabel.Name = "NewCustomerLabel";
            this.NewCustomerLabel.Size = new System.Drawing.Size(72, 19);
            this.NewCustomerLabel.TabIndex = 2;
            this.NewCustomerLabel.Text = "Customer:";
            // 
            // lblInputHeader
            // 
            this.lblInputHeader.AutoSize = true;
            this.lblInputHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.lblInputHeader.Location = new System.Drawing.Point(20, 15);
            this.lblInputHeader.Name = "lblInputHeader";
            this.lblInputHeader.Size = new System.Drawing.Size(95, 21);
            this.lblInputHeader.TabIndex = 0;
            this.lblInputHeader.Text = "Item Detail";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelInfo.Controls.Add(this.NewDateContent);
            this.panelInfo.Controls.Add(this.NewDateLabel);
            this.panelInfo.Controls.Add(this.NewFormCodeContent);
            this.panelInfo.Controls.Add(this.NewFormCodeLabel);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(30, 20);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelInfo.Size = new System.Drawing.Size(540, 110);
            this.panelInfo.TabIndex = 0;
            // 
            // NewDateContent
            // 
            this.NewDateContent.AutoSize = true;
            this.NewDateContent.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewDateContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.NewDateContent.Location = new System.Drawing.Point(130, 70);
            this.NewDateContent.Name = "NewDateContent";
            this.NewDateContent.Size = new System.Drawing.Size(0, 20);
            this.NewDateContent.TabIndex = 3;
            // 
            // NewDateLabel
            // 
            this.NewDateLabel.AutoSize = true;
            this.NewDateLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewDateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewDateLabel.Location = new System.Drawing.Point(20, 70);
            this.NewDateLabel.Name = "NewDateLabel";
            this.NewDateLabel.Size = new System.Drawing.Size(41, 19);
            this.NewDateLabel.TabIndex = 2;
            this.NewDateLabel.Text = "Date:";
            // 
            // NewFormCodeContent
            // 
            this.NewFormCodeContent.AutoSize = true;
            this.NewFormCodeContent.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFormCodeContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.NewFormCodeContent.Location = new System.Drawing.Point(130, 40);
            this.NewFormCodeContent.Name = "NewFormCodeContent";
            this.NewFormCodeContent.Size = new System.Drawing.Size(0, 20);
            this.NewFormCodeContent.TabIndex = 1;
            // 
            // NewFormCodeLabel
            // 
            this.NewFormCodeLabel.AutoSize = true;
            this.NewFormCodeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFormCodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NewFormCodeLabel.Location = new System.Drawing.Point(20, 40);
            this.NewFormCodeLabel.Name = "NewFormCodeLabel";
            this.NewFormCodeLabel.Size = new System.Drawing.Size(80, 19);
            this.NewFormCodeLabel.TabIndex = 0;
            this.NewFormCodeLabel.Text = "Form Code:";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Controls.Add(this.NewFormCodeButton);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 450);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(30, 10, 30, 20);
            this.panelFooter.Size = new System.Drawing.Size(600, 75);
            this.panelFooter.TabIndex = 2;
            // 
            // NewFormCodeButton
            // 
            this.NewFormCodeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.NewFormCodeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewFormCodeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewFormCodeButton.FlatAppearance.BorderSize = 0;
            this.NewFormCodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewFormCodeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFormCodeButton.ForeColor = System.Drawing.Color.White;
            this.NewFormCodeButton.Location = new System.Drawing.Point(30, 10);
            this.NewFormCodeButton.Name = "NewFormCodeButton";
            this.NewFormCodeButton.Size = new System.Drawing.Size(540, 45);
            this.NewFormCodeButton.TabIndex = 0;
            this.NewFormCodeButton.Text = "NEW FORM CODE";
            this.NewFormCodeButton.UseVisualStyleBackColor = false;
            this.NewFormCodeButton.Click += new System.EventHandler(this.NewFormCodeButton_Click);
            this.NewFormCodeButton.MouseEnter += new System.EventHandler(this.NewFormCodeButton_MouseEnter);
            this.NewFormCodeButton.MouseLeave += new System.EventHandler(this.NewFormCodeButton_MouseLeave);
            // 
            // NewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 525);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Assay Record - Metal Assay";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Shown += new System.EventHandler(this.NewForm_Shown);
            this.panelHeader.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.ListBox NewCustomerListbox;
        private System.Windows.Forms.TextBox NewSampleWeightTextbox;
        private System.Windows.Forms.Label NewSampleWeightLabel;
        private System.Windows.Forms.TextBox NewItemcodeTextbox;
        private System.Windows.Forms.Label NewItemcodeLabel;
        private System.Windows.Forms.TextBox NewCustomerTextbox;
        private System.Windows.Forms.Label NewCustomerLabel;
        private System.Windows.Forms.Label lblInputHeader;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label NewDateContent;
        private System.Windows.Forms.Label NewDateLabel;
        private System.Windows.Forms.Label NewFormCodeContent;
        private System.Windows.Forms.Label NewFormCodeLabel;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button NewFormCodeButton;
    }
}
