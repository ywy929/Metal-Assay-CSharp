namespace Metal_Assay
{
    partial class PreviewForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.PreviewCancelButton = new System.Windows.Forms.Button();
            this.PreviewOtherButton = new System.Windows.Forms.Button();
            this.PreviewActionButton = new System.Windows.Forms.Button();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.PreviewNextButton = new System.Windows.Forms.Button();
            this.PreviewBackButton = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.panelNavigation.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(700, 70);
            this.panelHeader.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(700, 70);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PDF Preview";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // panelMain
            //
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelMain.Controls.Add(this.pictureBox1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30);
            this.panelMain.Size = new System.Drawing.Size(700, 730);
            this.panelMain.TabIndex = 1;
            //
            // pictureBox1
            //
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(30, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 670);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            //
            // panelFooter
            //
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Controls.Add(this.PreviewCancelButton);
            this.panelFooter.Controls.Add(this.PreviewOtherButton);
            this.panelFooter.Controls.Add(this.PreviewActionButton);
            this.panelFooter.Controls.Add(this.panelNavigation);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 800);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Padding = new System.Windows.Forms.Padding(30, 15, 30, 20);
            this.panelFooter.Size = new System.Drawing.Size(700, 80);
            this.panelFooter.TabIndex = 2;
            //
            // PreviewCancelButton
            //
            this.PreviewCancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.PreviewCancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewCancelButton.FlatAppearance.BorderSize = 0;
            this.PreviewCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewCancelButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewCancelButton.ForeColor = System.Drawing.Color.White;
            this.PreviewCancelButton.Location = new System.Drawing.Point(565, 15);
            this.PreviewCancelButton.Name = "PreviewCancelButton";
            this.PreviewCancelButton.Size = new System.Drawing.Size(105, 45);
            this.PreviewCancelButton.TabIndex = 3;
            this.PreviewCancelButton.Text = "CANCEL";
            this.PreviewCancelButton.UseVisualStyleBackColor = false;
            this.PreviewCancelButton.Click += new System.EventHandler(this.PreviewCancelButton_Click_1);
            this.PreviewCancelButton.MouseEnter += new System.EventHandler(this.PreviewCancelButton_MouseEnter);
            this.PreviewCancelButton.MouseLeave += new System.EventHandler(this.PreviewCancelButton_MouseLeave);
            //
            // PreviewOtherButton
            //
            this.PreviewOtherButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.PreviewOtherButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewOtherButton.Enabled = false;
            this.PreviewOtherButton.FlatAppearance.BorderSize = 0;
            this.PreviewOtherButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewOtherButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewOtherButton.ForeColor = System.Drawing.Color.White;
            this.PreviewOtherButton.Location = new System.Drawing.Point(375, 15);
            this.PreviewOtherButton.Name = "PreviewOtherButton";
            this.PreviewOtherButton.Size = new System.Drawing.Size(170, 45);
            this.PreviewOtherButton.TabIndex = 2;
            this.PreviewOtherButton.Text = "OTHER";
            this.PreviewOtherButton.UseVisualStyleBackColor = false;
            this.PreviewOtherButton.Click += new System.EventHandler(this.PreviewOtherButton_Click);
            this.PreviewOtherButton.MouseEnter += new System.EventHandler(this.PreviewOtherButton_MouseEnter);
            this.PreviewOtherButton.MouseLeave += new System.EventHandler(this.PreviewOtherButton_MouseLeave);
            //
            // PreviewActionButton
            //
            this.PreviewActionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.PreviewActionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewActionButton.FlatAppearance.BorderSize = 0;
            this.PreviewActionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewActionButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewActionButton.ForeColor = System.Drawing.Color.White;
            this.PreviewActionButton.Location = new System.Drawing.Point(255, 15);
            this.PreviewActionButton.Name = "PreviewActionButton";
            this.PreviewActionButton.Size = new System.Drawing.Size(105, 45);
            this.PreviewActionButton.TabIndex = 1;
            this.PreviewActionButton.Text = "SAVE";
            this.PreviewActionButton.UseVisualStyleBackColor = false;
            this.PreviewActionButton.Click += new System.EventHandler(this.PreviewActionButton_Click);
            this.PreviewActionButton.MouseEnter += new System.EventHandler(this.PreviewActionButton_MouseEnter);
            this.PreviewActionButton.MouseLeave += new System.EventHandler(this.PreviewActionButton_MouseLeave);
            //
            // panelNavigation
            //
            this.panelNavigation.Controls.Add(this.PreviewNextButton);
            this.panelNavigation.Controls.Add(this.PreviewBackButton);
            this.panelNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNavigation.Location = new System.Drawing.Point(30, 15);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(110, 45);
            this.panelNavigation.TabIndex = 0;
            //
            // PreviewNextButton
            //
            this.PreviewNextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.PreviewNextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewNextButton.Enabled = false;
            this.PreviewNextButton.FlatAppearance.BorderSize = 0;
            this.PreviewNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewNextButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewNextButton.ForeColor = System.Drawing.Color.White;
            this.PreviewNextButton.Location = new System.Drawing.Point(55, 0);
            this.PreviewNextButton.Name = "PreviewNextButton";
            this.PreviewNextButton.Size = new System.Drawing.Size(45, 45);
            this.PreviewNextButton.TabIndex = 1;
            this.PreviewNextButton.Text = ">";
            this.PreviewNextButton.UseVisualStyleBackColor = false;
            this.PreviewNextButton.Click += new System.EventHandler(this.PreviewNextButton_Click);
            this.PreviewNextButton.MouseEnter += new System.EventHandler(this.PreviewNextButton_MouseEnter);
            this.PreviewNextButton.MouseLeave += new System.EventHandler(this.PreviewNextButton_MouseLeave);
            //
            // PreviewBackButton
            //
            this.PreviewBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(165)))), ((int)(((byte)(32)))));
            this.PreviewBackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviewBackButton.Enabled = false;
            this.PreviewBackButton.FlatAppearance.BorderSize = 0;
            this.PreviewBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewBackButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewBackButton.ForeColor = System.Drawing.Color.White;
            this.PreviewBackButton.Location = new System.Drawing.Point(0, 0);
            this.PreviewBackButton.Name = "PreviewBackButton";
            this.PreviewBackButton.Size = new System.Drawing.Size(45, 45);
            this.PreviewBackButton.TabIndex = 0;
            this.PreviewBackButton.Text = "<";
            this.PreviewBackButton.UseVisualStyleBackColor = false;
            this.PreviewBackButton.Click += new System.EventHandler(this.PreviewBackButton_Click);
            this.PreviewBackButton.MouseEnter += new System.EventHandler(this.PreviewBackButton_MouseEnter);
            this.PreviewBackButton.MouseLeave += new System.EventHandler(this.PreviewBackButton_MouseLeave);
            //
            // PreviewForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 880);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF Preview - Metal Assay";
            this.Load += new System.EventHandler(this.PreviewForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelNavigation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelFooter;
        public System.Windows.Forms.Button PreviewCancelButton;
        public System.Windows.Forms.Button PreviewOtherButton;
        public System.Windows.Forms.Button PreviewActionButton;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.Button PreviewNextButton;
        private System.Windows.Forms.Button PreviewBackButton;
    }
}
