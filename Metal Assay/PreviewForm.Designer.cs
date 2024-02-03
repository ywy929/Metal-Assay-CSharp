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
            this.PreviewActionButton = new System.Windows.Forms.Button();
            this.PreviewBackButton = new System.Windows.Forms.Button();
            this.PreviewNextButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PreviewOtherButton = new System.Windows.Forms.Button();
            this.PreviewCancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PreviewActionButton
            // 
            this.PreviewActionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewActionButton.Location = new System.Drawing.Point(128, 707);
            this.PreviewActionButton.Name = "PreviewActionButton";
            this.PreviewActionButton.Size = new System.Drawing.Size(123, 48);
            this.PreviewActionButton.TabIndex = 1;
            this.PreviewActionButton.Text = "SAVE";
            this.PreviewActionButton.UseVisualStyleBackColor = true;
            this.PreviewActionButton.Click += new System.EventHandler(this.PreviewActionButton_Click);
            // 
            // PreviewBackButton
            // 
            this.PreviewBackButton.Enabled = false;
            this.PreviewBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewBackButton.Location = new System.Drawing.Point(12, 707);
            this.PreviewBackButton.Name = "PreviewBackButton";
            this.PreviewBackButton.Size = new System.Drawing.Size(48, 48);
            this.PreviewBackButton.TabIndex = 3;
            this.PreviewBackButton.Text = "<";
            this.PreviewBackButton.UseVisualStyleBackColor = true;
            this.PreviewBackButton.Click += new System.EventHandler(this.PreviewBackButton_Click);
            // 
            // PreviewNextButton
            // 
            this.PreviewNextButton.Enabled = false;
            this.PreviewNextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewNextButton.Location = new System.Drawing.Point(66, 707);
            this.PreviewNextButton.Name = "PreviewNextButton";
            this.PreviewNextButton.Size = new System.Drawing.Size(48, 48);
            this.PreviewNextButton.TabIndex = 4;
            this.PreviewNextButton.Text = ">";
            this.PreviewNextButton.UseVisualStyleBackColor = true;
            this.PreviewNextButton.Click += new System.EventHandler(this.PreviewNextButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(38, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(488, 667);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // PreviewOtherButton
            // 
            this.PreviewOtherButton.Enabled = false;
            this.PreviewOtherButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewOtherButton.Location = new System.Drawing.Point(274, 707);
            this.PreviewOtherButton.Name = "PreviewOtherButton";
            this.PreviewOtherButton.Size = new System.Drawing.Size(123, 48);
            this.PreviewOtherButton.TabIndex = 6;
            this.PreviewOtherButton.Text = "OTHER";
            this.PreviewOtherButton.UseVisualStyleBackColor = true;
            this.PreviewOtherButton.Click += new System.EventHandler(this.PreviewOtherButton_Click);
            // 
            // PreviewCancelButton
            // 
            this.PreviewCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviewCancelButton.Location = new System.Drawing.Point(420, 707);
            this.PreviewCancelButton.Name = "PreviewCancelButton";
            this.PreviewCancelButton.Size = new System.Drawing.Size(123, 48);
            this.PreviewCancelButton.TabIndex = 7;
            this.PreviewCancelButton.Text = "CANCEL";
            this.PreviewCancelButton.UseVisualStyleBackColor = true;
            this.PreviewCancelButton.Click += new System.EventHandler(this.PreviewCancelButton_Click_1);
            // 
            // PreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 770);
            this.Controls.Add(this.PreviewCancelButton);
            this.Controls.Add(this.PreviewOtherButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PreviewNextButton);
            this.Controls.Add(this.PreviewBackButton);
            this.Controls.Add(this.PreviewActionButton);
            this.Name = "PreviewForm";
            this.Text = "Preview";
            this.Load += new System.EventHandler(this.PreviewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button PreviewActionButton;
        private System.Windows.Forms.Button PreviewBackButton;
        private System.Windows.Forms.Button PreviewNextButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button PreviewOtherButton;
        public System.Windows.Forms.Button PreviewCancelButton;
    }
}