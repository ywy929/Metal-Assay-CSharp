namespace Metal_Assay
{
    partial class SendReportForm
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
            this.panelDateRange = new System.Windows.Forms.Panel();
            this.lblDateRangeTitle = new System.Windows.Forms.Label();
            this.FromLabel = new System.Windows.Forms.Label();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ToLabel = new System.Windows.Forms.Label();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.SendReportButton = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelDateRange.SuspendLayout();
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
            this.lblTitle.Text = "Send Report";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelMain
            //
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.panelDateRange);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(40, 30, 40, 20);
            this.panelMain.Size = new System.Drawing.Size(600, 210);
            this.panelMain.TabIndex = 1;
            //
            // panelDateRange
            //
            this.panelDateRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelDateRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDateRange.Controls.Add(this.lblDateRangeTitle);
            this.panelDateRange.Controls.Add(this.FromLabel);
            this.panelDateRange.Controls.Add(this.fromDateTimePicker);
            this.panelDateRange.Controls.Add(this.ToLabel);
            this.panelDateRange.Controls.Add(this.toDateTimePicker);
            this.panelDateRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDateRange.Location = new System.Drawing.Point(40, 30);
            this.panelDateRange.Name = "panelDateRange";
            this.panelDateRange.Padding = new System.Windows.Forms.Padding(20);
            this.panelDateRange.Size = new System.Drawing.Size(520, 160);
            this.panelDateRange.TabIndex = 0;
            //
            // lblDateRangeTitle
            //
            this.lblDateRangeTitle.AutoSize = true;
            this.lblDateRangeTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateRangeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDateRangeTitle.Location = new System.Drawing.Point(20, 20);
            this.lblDateRangeTitle.Name = "lblDateRangeTitle";
            this.lblDateRangeTitle.Size = new System.Drawing.Size(96, 21);
            this.lblDateRangeTitle.TabIndex = 0;
            this.lblDateRangeTitle.Text = "Date Range";
            //
            // FromLabel
            //
            this.FromLabel.AutoSize = true;
            this.FromLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FromLabel.Location = new System.Drawing.Point(20, 60);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(47, 20);
            this.FromLabel.TabIndex = 1;
            this.FromLabel.Text = "From:";
            //
            // fromDateTimePicker
            //
            this.fromDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDateTimePicker.Location = new System.Drawing.Point(100, 57);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(380, 27);
            this.fromDateTimePicker.TabIndex = 2;
            //
            // ToLabel
            //
            this.ToLabel.AutoSize = true;
            this.ToLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ToLabel.Location = new System.Drawing.Point(20, 105);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(28, 20);
            this.ToLabel.TabIndex = 3;
            this.ToLabel.Text = "To:";
            //
            // toDateTimePicker
            //
            this.toDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDateTimePicker.Location = new System.Drawing.Point(100, 102);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(380, 27);
            this.toDateTimePicker.TabIndex = 4;
            //
            // panelFooter
            //
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Controls.Add(this.SendReportButton);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 280);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(40, 10, 40, 30);
            this.panelFooter.Size = new System.Drawing.Size(600, 90);
            this.panelFooter.TabIndex = 2;
            //
            // SendReportButton
            //
            this.SendReportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.SendReportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendReportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SendReportButton.FlatAppearance.BorderSize = 0;
            this.SendReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendReportButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendReportButton.ForeColor = System.Drawing.Color.White;
            this.SendReportButton.Location = new System.Drawing.Point(40, 10);
            this.SendReportButton.Name = "SendReportButton";
            this.SendReportButton.Size = new System.Drawing.Size(520, 50);
            this.SendReportButton.TabIndex = 0;
            this.SendReportButton.Text = "SEND REPORT";
            this.SendReportButton.UseVisualStyleBackColor = false;
            this.SendReportButton.Click += new System.EventHandler(this.button1_Click);
            this.SendReportButton.MouseEnter += new System.EventHandler(this.SendReportButton_MouseEnter);
            this.SendReportButton.MouseLeave += new System.EventHandler(this.SendReportButton_MouseLeave);
            //
            // SendReportForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 370);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Report - Metal Assay";
            this.panelHeader.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelDateRange.ResumeLayout(false);
            this.panelDateRange.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelDateRange;
        private System.Windows.Forms.Label lblDateRangeTitle;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button SendReportButton;
    }
}
