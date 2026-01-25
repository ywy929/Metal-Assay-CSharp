namespace Metal_Assay
{
    partial class ResultForm
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
            this.panelMain.Location = new System.Drawing.Point(0, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30, 20, 30, 10);
            this.panelMain.Size = new System.Drawing.Size(600, 455);
            this.panelMain.TabIndex = 1;
            //
            // panelResult
            //
            this.panelResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelResult.Controls.Add(this.ResultBigResultContentLabel);
            this.panelResult.Controls.Add(this.ResultBigResultLabel);
            this.panelResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResult.Location = new System.Drawing.Point(30, 280);
            this.panelResult.Name = "panelResult";
            this.panelResult.Padding = new System.Windows.Forms.Padding(20);
            this.panelResult.Size = new System.Drawing.Size(540, 165);
            this.panelResult.TabIndex = 2;
            //
            // ResultBigResultContentLabel
            //
            this.ResultBigResultContentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultBigResultContentLabel.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultBigResultContentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ResultBigResultContentLabel.Location = new System.Drawing.Point(20, 65);
            this.ResultBigResultContentLabel.Name = "ResultBigResultContentLabel";
            this.ResultBigResultContentLabel.Size = new System.Drawing.Size(500, 80);
            this.ResultBigResultContentLabel.TabIndex = 1;
            this.ResultBigResultContentLabel.Text = "999.9";
            this.ResultBigResultContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // ResultBigResultLabel
            //
            this.ResultBigResultLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ResultBigResultLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultBigResultLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultBigResultLabel.Location = new System.Drawing.Point(20, 20);
            this.ResultBigResultLabel.Name = "ResultBigResultLabel";
            this.ResultBigResultLabel.Size = new System.Drawing.Size(500, 45);
            this.ResultBigResultLabel.TabIndex = 0;
            this.ResultBigResultLabel.Text = "FINAL RESULT";
            this.ResultBigResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panelCalculation.Location = new System.Drawing.Point(30, 130);
            this.panelCalculation.Name = "panelCalculation";
            this.panelCalculation.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelCalculation.Size = new System.Drawing.Size(540, 150);
            this.panelCalculation.TabIndex = 1;
            //
            // ResultFinalResultTextbox
            //
            this.ResultFinalResultTextbox.BackColor = System.Drawing.Color.White;
            this.ResultFinalResultTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultFinalResultTextbox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultFinalResultTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ResultFinalResultTextbox.Location = new System.Drawing.Point(405, 85);
            this.ResultFinalResultTextbox.Name = "ResultFinalResultTextbox";
            this.ResultFinalResultTextbox.ReadOnly = true;
            this.ResultFinalResultTextbox.Size = new System.Drawing.Size(115, 32);
            this.ResultFinalResultTextbox.TabIndex = 7;
            this.ResultFinalResultTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // ResultEqualsLabel
            //
            this.ResultEqualsLabel.AutoSize = true;
            this.ResultEqualsLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultEqualsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultEqualsLabel.Location = new System.Drawing.Point(356, 85);
            this.ResultEqualsLabel.Name = "ResultEqualsLabel";
            this.ResultEqualsLabel.Size = new System.Drawing.Size(31, 32);
            this.ResultEqualsLabel.TabIndex = 6;
            this.ResultEqualsLabel.Text = "=";
            //
            // ResultLossTextbox
            //
            this.ResultLossTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultLossTextbox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultLossTextbox.Location = new System.Drawing.Point(226, 85);
            this.ResultLossTextbox.Name = "ResultLossTextbox";
            this.ResultLossTextbox.Size = new System.Drawing.Size(115, 32);
            this.ResultLossTextbox.TabIndex = 1;
            this.ResultLossTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ResultLossTextbox.TextChanged += new System.EventHandler(this.ResultLossTextbox_TextChanged);
            this.ResultLossTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ResultLossTextbox_KeyPress);
            //
            // ResultMinusLabel
            //
            this.ResultMinusLabel.AutoSize = true;
            this.ResultMinusLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultMinusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultMinusLabel.Location = new System.Drawing.Point(185, 85);
            this.ResultMinusLabel.Name = "ResultMinusLabel";
            this.ResultMinusLabel.Size = new System.Drawing.Size(26, 32);
            this.ResultMinusLabel.TabIndex = 4;
            this.ResultMinusLabel.Text = "-";
            //
            // ResultPreresultTextbox
            //
            this.ResultPreresultTextbox.BackColor = System.Drawing.Color.White;
            this.ResultPreresultTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultPreresultTextbox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultPreresultTextbox.Location = new System.Drawing.Point(55, 85);
            this.ResultPreresultTextbox.Name = "ResultPreresultTextbox";
            this.ResultPreresultTextbox.ReadOnly = true;
            this.ResultPreresultTextbox.Size = new System.Drawing.Size(115, 32);
            this.ResultPreresultTextbox.TabIndex = 0;
            this.ResultPreresultTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // ResultResultLabel
            //
            this.ResultResultLabel.AutoSize = true;
            this.ResultResultLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultResultLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultResultLabel.Location = new System.Drawing.Point(405, 60);
            this.ResultResultLabel.Name = "ResultResultLabel";
            this.ResultResultLabel.Size = new System.Drawing.Size(46, 19);
            this.ResultResultLabel.TabIndex = 2;
            this.ResultResultLabel.Text = "Result";
            //
            // ResultLossLabel
            //
            this.ResultLossLabel.AutoSize = true;
            this.ResultLossLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultLossLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultLossLabel.Location = new System.Drawing.Point(226, 60);
            this.ResultLossLabel.Name = "ResultLossLabel";
            this.ResultLossLabel.Size = new System.Drawing.Size(35, 19);
            this.ResultLossLabel.TabIndex = 1;
            this.ResultLossLabel.Text = "Loss";
            //
            // lblPreResultLabel
            //
            this.lblPreResultLabel.AutoSize = true;
            this.lblPreResultLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreResultLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPreResultLabel.Location = new System.Drawing.Point(55, 60);
            this.lblPreResultLabel.Name = "lblPreResultLabel";
            this.lblPreResultLabel.Size = new System.Drawing.Size(70, 19);
            this.lblPreResultLabel.TabIndex = 0;
            this.lblPreResultLabel.Text = "Pre-result";
            //
            // panelInfo
            //
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelInfo.Controls.Add(this.ResultItemcodeContentLabel);
            this.panelInfo.Controls.Add(this.ResultItemCodeLabel);
            this.panelInfo.Controls.Add(this.ResultCustomerContentLabel);
            this.panelInfo.Controls.Add(this.ResultCustomerLabel);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(30, 20);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.panelInfo.Size = new System.Drawing.Size(540, 110);
            this.panelInfo.TabIndex = 0;
            //
            // ResultItemcodeContentLabel
            //
            this.ResultItemcodeContentLabel.AutoSize = true;
            this.ResultItemcodeContentLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultItemcodeContentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ResultItemcodeContentLabel.Location = new System.Drawing.Point(130, 70);
            this.ResultItemcodeContentLabel.Name = "ResultItemcodeContentLabel";
            this.ResultItemcodeContentLabel.Size = new System.Drawing.Size(51, 20);
            this.ResultItemcodeContentLabel.TabIndex = 3;
            this.ResultItemcodeContentLabel.Text = "label1";
            //
            // ResultItemCodeLabel
            //
            this.ResultItemCodeLabel.AutoSize = true;
            this.ResultItemCodeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultItemCodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultItemCodeLabel.Location = new System.Drawing.Point(20, 70);
            this.ResultItemCodeLabel.Name = "ResultItemCodeLabel";
            this.ResultItemCodeLabel.Size = new System.Drawing.Size(77, 19);
            this.ResultItemCodeLabel.TabIndex = 2;
            this.ResultItemCodeLabel.Text = "Item Code:";
            //
            // ResultCustomerContentLabel
            //
            this.ResultCustomerContentLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultCustomerContentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ResultCustomerContentLabel.Location = new System.Drawing.Point(130, 15);
            this.ResultCustomerContentLabel.Name = "ResultCustomerContentLabel";
            this.ResultCustomerContentLabel.Size = new System.Drawing.Size(390, 50);
            this.ResultCustomerContentLabel.TabIndex = 1;
            this.ResultCustomerContentLabel.Text = "label1";
            //
            // ResultCustomerLabel
            //
            this.ResultCustomerLabel.AutoSize = true;
            this.ResultCustomerLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultCustomerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResultCustomerLabel.Location = new System.Drawing.Point(20, 15);
            this.ResultCustomerLabel.Name = "ResultCustomerLabel";
            this.ResultCustomerLabel.Size = new System.Drawing.Size(72, 19);
            this.ResultCustomerLabel.TabIndex = 0;
            this.ResultCustomerLabel.Text = "Customer:";
            //
            // panelFooter
            //
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Controls.Add(this.ResultOKButton);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 525);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(30, 10, 30, 20);
            this.panelFooter.Size = new System.Drawing.Size(600, 75);
            this.panelFooter.TabIndex = 2;
            //
            // ResultOKButton
            //
            this.ResultOKButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.ResultOKButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResultOKButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultOKButton.FlatAppearance.BorderSize = 0;
            this.ResultOKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResultOKButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultOKButton.ForeColor = System.Drawing.Color.White;
            this.ResultOKButton.Location = new System.Drawing.Point(30, 10);
            this.ResultOKButton.Name = "ResultOKButton";
            this.ResultOKButton.Size = new System.Drawing.Size(540, 45);
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
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Final Result - Metal Assay";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResultForm_FormClosed);
            this.Load += new System.EventHandler(this.ResultForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelResult.ResumeLayout(false);
            this.panelCalculation.ResumeLayout(false);
            this.panelCalculation.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

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
