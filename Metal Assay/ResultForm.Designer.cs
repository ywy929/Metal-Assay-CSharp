namespace Metal_Assay
{
    partial class ResultForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelResult = new System.Windows.Forms.Panel();
            this.ResultBigResultContentLabel = new System.Windows.Forms.Label();
            this.ResultBigResultLabel = new System.Windows.Forms.Label();
            this.panelCalculation = new System.Windows.Forms.Panel();
            this.ResultFinalResultTextbox = new System.Windows.Forms.TextBox();
            this.ResultEqualsLabel = new System.Windows.Forms.Label();
            this.ResultLossTextbox = new System.Windows.Forms.TextBox();
            this.ResultMinusLabel = new System.Windows.Forms.Label();
            this.ResultPreresultTextbox = new System.Windows.Forms.TextBox();
            this.ResultResultLabel = new System.Windows.Forms.Label();
            this.ResultLossLabel = new System.Windows.Forms.Label();
            this.lblPreResultLabel = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.ResultItemcodeContentLabel = new System.Windows.Forms.Label();
            this.ResultItemCodeLabel = new System.Windows.Forms.Label();
            this.ResultCustomerContentLabel = new System.Windows.Forms.Label();
            this.ResultCustomerLabel = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.ResultOKButton = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelResult.SuspendLayout();
            this.panelCalculation.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(400, 40);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Final Result";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.panelResult);
            this.panelMain.Controls.Add(this.panelCalculation);
            this.panelMain.Controls.Add(this.panelInfo);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(15, 10, 15, 5);
            this.panelMain.Size = new System.Drawing.Size(400, 215);
            this.panelMain.TabIndex = 1;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelInfo.Controls.Add(this.ResultItemcodeContentLabel);
            this.panelInfo.Controls.Add(this.ResultItemCodeLabel);
            this.panelInfo.Controls.Add(this.ResultCustomerContentLabel);
            this.panelInfo.Controls.Add(this.ResultCustomerLabel);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(15, 10);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.panelInfo.Size = new System.Drawing.Size(370, 40);
            this.panelInfo.TabIndex = 0;
            // 
            // ResultCustomerLabel
            // 
            this.ResultCustomerLabel.AutoSize = true;
            this.ResultCustomerLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ResultCustomerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultCustomerLabel.Location = new System.Drawing.Point(10, 10);
            this.ResultCustomerLabel.Name = "ResultCustomerLabel";
            this.ResultCustomerLabel.Size = new System.Drawing.Size(79, 20);
            this.ResultCustomerLabel.TabIndex = 0;
            this.ResultCustomerLabel.Text = "Customer:";
            // 
            // ResultCustomerContentLabel
            // 
            this.ResultCustomerContentLabel.AutoSize = true;
            this.ResultCustomerContentLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ResultCustomerContentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ResultCustomerContentLabel.Location = new System.Drawing.Point(90, 10);
            this.ResultCustomerContentLabel.Name = "ResultCustomerContentLabel";
            this.ResultCustomerContentLabel.Size = new System.Drawing.Size(51, 20);
            this.ResultCustomerContentLabel.TabIndex = 1;
            this.ResultCustomerContentLabel.Text = "label1";
            // 
            // ResultItemCodeLabel
            // 
            this.ResultItemCodeLabel.AutoSize = true;
            this.ResultItemCodeLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ResultItemCodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultItemCodeLabel.Location = new System.Drawing.Point(200, 10);
            this.ResultItemCodeLabel.Name = "ResultItemCodeLabel";
            this.ResultItemCodeLabel.Size = new System.Drawing.Size(43, 20);
            this.ResultItemCodeLabel.TabIndex = 2;
            this.ResultItemCodeLabel.Text = "Item:";
            // 
            // ResultItemcodeContentLabel
            // 
            this.ResultItemcodeContentLabel.AutoSize = true;
            this.ResultItemcodeContentLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ResultItemcodeContentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ResultItemcodeContentLabel.Location = new System.Drawing.Point(245, 10);
            this.ResultItemcodeContentLabel.Name = "ResultItemcodeContentLabel";
            this.ResultItemcodeContentLabel.Size = new System.Drawing.Size(51, 20);
            this.ResultItemcodeContentLabel.TabIndex = 3;
            this.ResultItemcodeContentLabel.Text = "label1";
            // 
            // panelCalculation
            // 
            this.panelCalculation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelCalculation.Controls.Add(this.ResultFinalResultTextbox);
            this.panelCalculation.Controls.Add(this.ResultEqualsLabel);
            this.panelCalculation.Controls.Add(this.ResultLossTextbox);
            this.panelCalculation.Controls.Add(this.ResultMinusLabel);
            this.panelCalculation.Controls.Add(this.ResultPreresultTextbox);
            this.panelCalculation.Controls.Add(this.ResultResultLabel);
            this.panelCalculation.Controls.Add(this.ResultLossLabel);
            this.panelCalculation.Controls.Add(this.lblPreResultLabel);
            this.panelCalculation.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCalculation.Location = new System.Drawing.Point(15, 50);
            this.panelCalculation.Name = "panelCalculation";
            this.panelCalculation.Padding = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.panelCalculation.Size = new System.Drawing.Size(370, 62);
            this.panelCalculation.TabIndex = 1;
            // 
            // lblPreResultLabel
            // 
            this.lblPreResultLabel.AutoSize = true;
            this.lblPreResultLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPreResultLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPreResultLabel.Location = new System.Drawing.Point(15, 6);
            this.lblPreResultLabel.Name = "lblPreResultLabel";
            this.lblPreResultLabel.Size = new System.Drawing.Size(57, 15);
            this.lblPreResultLabel.TabIndex = 0;
            this.lblPreResultLabel.Text = "Pre-result";
            // 
            // ResultLossLabel
            // 
            this.ResultLossLabel.AutoSize = true;
            this.ResultLossLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ResultLossLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultLossLabel.Location = new System.Drawing.Point(140, 6);
            this.ResultLossLabel.Name = "ResultLossLabel";
            this.ResultLossLabel.Size = new System.Drawing.Size(30, 15);
            this.ResultLossLabel.TabIndex = 1;
            this.ResultLossLabel.Text = "Loss";
            // 
            // ResultResultLabel
            // 
            this.ResultResultLabel.AutoSize = true;
            this.ResultResultLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ResultResultLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultResultLabel.Location = new System.Drawing.Point(270, 6);
            this.ResultResultLabel.Name = "ResultResultLabel";
            this.ResultResultLabel.Size = new System.Drawing.Size(39, 15);
            this.ResultResultLabel.TabIndex = 2;
            this.ResultResultLabel.Text = "Result";
            // 
            // ResultPreresultTextbox
            // 
            this.ResultPreresultTextbox.BackColor = System.Drawing.Color.White;
            this.ResultPreresultTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultPreresultTextbox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ResultPreresultTextbox.Location = new System.Drawing.Point(15, 25);
            this.ResultPreresultTextbox.Name = "ResultPreresultTextbox";
            this.ResultPreresultTextbox.ReadOnly = true;
            this.ResultPreresultTextbox.Size = new System.Drawing.Size(80, 27);
            this.ResultPreresultTextbox.TabIndex = 0;
            this.ResultPreresultTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ResultMinusLabel
            // 
            this.ResultMinusLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ResultMinusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultMinusLabel.Location = new System.Drawing.Point(100, 25);
            this.ResultMinusLabel.Name = "ResultMinusLabel";
            this.ResultMinusLabel.Size = new System.Drawing.Size(30, 27);
            this.ResultMinusLabel.TabIndex = 4;
            this.ResultMinusLabel.Text = "-";
            this.ResultMinusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResultLossTextbox
            // 
            this.ResultLossTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultLossTextbox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ResultLossTextbox.Location = new System.Drawing.Point(135, 25);
            this.ResultLossTextbox.Name = "ResultLossTextbox";
            this.ResultLossTextbox.Size = new System.Drawing.Size(80, 27);
            this.ResultLossTextbox.TabIndex = 1;
            this.ResultLossTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ResultLossTextbox.TextChanged += new System.EventHandler(this.ResultLossTextbox_TextChanged);
            this.ResultLossTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ResultLossTextbox_KeyPress);
            // 
            // ResultEqualsLabel
            // 
            this.ResultEqualsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ResultEqualsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultEqualsLabel.Location = new System.Drawing.Point(220, 25);
            this.ResultEqualsLabel.Name = "ResultEqualsLabel";
            this.ResultEqualsLabel.Size = new System.Drawing.Size(30, 27);
            this.ResultEqualsLabel.TabIndex = 6;
            this.ResultEqualsLabel.Text = "=";
            this.ResultEqualsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResultFinalResultTextbox
            // 
            this.ResultFinalResultTextbox.BackColor = System.Drawing.Color.White;
            this.ResultFinalResultTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultFinalResultTextbox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ResultFinalResultTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ResultFinalResultTextbox.Location = new System.Drawing.Point(255, 25);
            this.ResultFinalResultTextbox.Name = "ResultFinalResultTextbox";
            this.ResultFinalResultTextbox.ReadOnly = true;
            this.ResultFinalResultTextbox.Size = new System.Drawing.Size(80, 27);
            this.ResultFinalResultTextbox.TabIndex = 7;
            this.ResultFinalResultTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelResult
            // 
            this.panelResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelResult.Controls.Add(this.ResultBigResultContentLabel);
            this.panelResult.Controls.Add(this.ResultBigResultLabel);
            this.panelResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResult.Location = new System.Drawing.Point(15, 112);
            this.panelResult.Name = "panelResult";
            this.panelResult.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.panelResult.Size = new System.Drawing.Size(370, 98);
            this.panelResult.TabIndex = 2;
            // 
            // ResultBigResultLabel
            // 
            this.ResultBigResultLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ResultBigResultLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.ResultBigResultLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultBigResultLabel.Location = new System.Drawing.Point(8, 5);
            this.ResultBigResultLabel.Name = "ResultBigResultLabel";
            this.ResultBigResultLabel.Size = new System.Drawing.Size(354, 22);
            this.ResultBigResultLabel.TabIndex = 0;
            this.ResultBigResultLabel.Text = "FINAL RESULT";
            this.ResultBigResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResultBigResultContentLabel
            // 
            this.ResultBigResultContentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultBigResultContentLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.ResultBigResultContentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ResultBigResultContentLabel.Location = new System.Drawing.Point(8, 27);
            this.ResultBigResultContentLabel.Name = "ResultBigResultContentLabel";
            this.ResultBigResultContentLabel.Size = new System.Drawing.Size(354, 66);
            this.ResultBigResultContentLabel.TabIndex = 1;
            this.ResultBigResultContentLabel.Text = "999.9";
            this.ResultBigResultContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Controls.Add(this.ResultOKButton);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 215);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(15, 5, 15, 10);
            this.panelFooter.Size = new System.Drawing.Size(400, 45);
            this.panelFooter.TabIndex = 2;
            // 
            // ResultOKButton
            // 
            this.ResultOKButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ResultOKButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResultOKButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultOKButton.FlatAppearance.BorderSize = 0;
            this.ResultOKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResultOKButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.ResultOKButton.ForeColor = System.Drawing.Color.White;
            this.ResultOKButton.Location = new System.Drawing.Point(15, 5);
            this.ResultOKButton.Name = "ResultOKButton";
            this.ResultOKButton.Size = new System.Drawing.Size(370, 30);
            this.ResultOKButton.TabIndex = 0;
            this.ResultOKButton.Text = "CONFIRM RESULT";
            this.ResultOKButton.UseVisualStyleBackColor = false;
            this.ResultOKButton.Click += new System.EventHandler(this.ResultOKButton_Click);
            this.ResultOKButton.MouseEnter += new System.EventHandler(this.ResultOKButton_MouseEnter);
            this.ResultOKButton.MouseLeave += new System.EventHandler(this.ResultOKButton_MouseLeave);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Final Result - Metal Assay";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResultForm_FormClosed);
            this.Load += new System.EventHandler(this.ResultForm_Load);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.Label ResultBigResultContentLabel;
        private System.Windows.Forms.Label ResultBigResultLabel;
        private System.Windows.Forms.Panel panelCalculation;
        private System.Windows.Forms.TextBox ResultFinalResultTextbox;
        private System.Windows.Forms.Label ResultEqualsLabel;
        private System.Windows.Forms.TextBox ResultLossTextbox;
        private System.Windows.Forms.Label ResultMinusLabel;
        private System.Windows.Forms.TextBox ResultPreresultTextbox;
        private System.Windows.Forms.Label ResultResultLabel;
        private System.Windows.Forms.Label ResultLossLabel;
        private System.Windows.Forms.Label lblPreResultLabel;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label ResultItemcodeContentLabel;
        private System.Windows.Forms.Label ResultItemCodeLabel;
        private System.Windows.Forms.Label ResultCustomerContentLabel;
        private System.Windows.Forms.Label ResultCustomerLabel;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button ResultOKButton;
    }
}