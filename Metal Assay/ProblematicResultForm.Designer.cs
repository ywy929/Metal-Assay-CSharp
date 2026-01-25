namespace Metal_Assay
{
    partial class ProblematicResultForm
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
            this.lblMessage2 = new System.Windows.Forms.Label();
            this.lblMessage1 = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.LowButton = new System.Windows.Forms.Button();
            this.RejectButton = new System.Windows.Forms.Button();
            this.RedoButton = new System.Windows.Forms.Button();
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
            this.lblTitle.Text = "⚠ Result Discrepancy";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelMain
            //
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.lblMessage2);
            this.panelMain.Controls.Add(this.lblMessage1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(40, 30, 40, 20);
            this.panelMain.Size = new System.Drawing.Size(600, 130);
            this.panelMain.TabIndex = 1;
            //
            // lblMessage2
            //
            this.lblMessage2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMessage2.Location = new System.Drawing.Point(40, 60);
            this.lblMessage2.Name = "lblMessage2";
            this.lblMessage2.Size = new System.Drawing.Size(520, 25);
            this.lblMessage2.TabIndex = 1;
            this.lblMessage2.Text = "Please choose one of the actions below to proceed.";
            this.lblMessage2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblMessage1
            //
            this.lblMessage1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.lblMessage1.Location = new System.Drawing.Point(40, 30);
            this.lblMessage1.Name = "lblMessage1";
            this.lblMessage1.Size = new System.Drawing.Size(520, 30);
            this.lblMessage1.TabIndex = 0;
            this.lblMessage1.Text = "Difference between results > 1";
            this.lblMessage1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelFooter
            //
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Controls.Add(this.LowButton);
            this.panelFooter.Controls.Add(this.RejectButton);
            this.panelFooter.Controls.Add(this.RedoButton);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 200);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(40, 10, 40, 30);
            this.panelFooter.Size = new System.Drawing.Size(600, 90);
            this.panelFooter.TabIndex = 2;
            //
            // LowButton
            //
            this.LowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.LowButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LowButton.FlatAppearance.BorderSize = 0;
            this.LowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LowButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LowButton.ForeColor = System.Drawing.Color.White;
            this.LowButton.Location = new System.Drawing.Point(383, 10);
            this.LowButton.Name = "LowButton";
            this.LowButton.Size = new System.Drawing.Size(137, 50);
            this.LowButton.TabIndex = 2;
            this.LowButton.Text = "LOW";
            this.LowButton.UseVisualStyleBackColor = false;
            this.LowButton.Click += new System.EventHandler(this.button3_Click);
            this.LowButton.MouseEnter += new System.EventHandler(this.LowButton_MouseEnter);
            this.LowButton.MouseLeave += new System.EventHandler(this.LowButton_MouseLeave);
            //
            // RejectButton
            //
            this.RejectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.RejectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RejectButton.FlatAppearance.BorderSize = 0;
            this.RejectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RejectButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RejectButton.ForeColor = System.Drawing.Color.White;
            this.RejectButton.Location = new System.Drawing.Point(231, 10);
            this.RejectButton.Name = "RejectButton";
            this.RejectButton.Size = new System.Drawing.Size(137, 50);
            this.RejectButton.TabIndex = 1;
            this.RejectButton.Text = "REJECT";
            this.RejectButton.UseVisualStyleBackColor = false;
            this.RejectButton.Click += new System.EventHandler(this.button1_Click);
            this.RejectButton.MouseEnter += new System.EventHandler(this.RejectButton_MouseEnter);
            this.RejectButton.MouseLeave += new System.EventHandler(this.RejectButton_MouseLeave);
            //
            // RedoButton
            //
            this.RedoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.RedoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RedoButton.FlatAppearance.BorderSize = 0;
            this.RedoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedoButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedoButton.ForeColor = System.Drawing.Color.White;
            this.RedoButton.Location = new System.Drawing.Point(79, 10);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(137, 50);
            this.RedoButton.TabIndex = 0;
            this.RedoButton.Text = "REDO";
            this.RedoButton.UseVisualStyleBackColor = false;
            this.RedoButton.Click += new System.EventHandler(this.button2_Click);
            this.RedoButton.MouseEnter += new System.EventHandler(this.RedoButton_MouseEnter);
            this.RedoButton.MouseLeave += new System.EventHandler(this.RedoButton_MouseLeave);
            //
            // ProblematicResultForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 290);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProblematicResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Result Discrepancy - Metal Assay";
            this.panelHeader.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblMessage2;
        private System.Windows.Forms.Label lblMessage1;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Button LowButton;
        private System.Windows.Forms.Button RejectButton;
        private System.Windows.Forms.Button RedoButton;
    }
}
