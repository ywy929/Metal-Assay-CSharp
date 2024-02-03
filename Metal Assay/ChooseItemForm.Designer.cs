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
            this.ChooseItemFormcodeLabel = new System.Windows.Forms.Label();
            this.ChooseItemCustomerLabel = new System.Windows.Forms.Label();
            this.ChooseItemFormcodeContentLabel = new System.Windows.Forms.Label();
            this.ChooseItemCustomerContentLabel = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ChooseItemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChooseItemFormcodeLabel
            // 
            this.ChooseItemFormcodeLabel.AutoSize = true;
            this.ChooseItemFormcodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseItemFormcodeLabel.Location = new System.Drawing.Point(17, 18);
            this.ChooseItemFormcodeLabel.Name = "ChooseItemFormcodeLabel";
            this.ChooseItemFormcodeLabel.Size = new System.Drawing.Size(85, 20);
            this.ChooseItemFormcodeLabel.TabIndex = 0;
            this.ChooseItemFormcodeLabel.Text = "Formcode:";
            // 
            // ChooseItemCustomerLabel
            // 
            this.ChooseItemCustomerLabel.AutoSize = true;
            this.ChooseItemCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseItemCustomerLabel.Location = new System.Drawing.Point(17, 52);
            this.ChooseItemCustomerLabel.Name = "ChooseItemCustomerLabel";
            this.ChooseItemCustomerLabel.Size = new System.Drawing.Size(82, 20);
            this.ChooseItemCustomerLabel.TabIndex = 1;
            this.ChooseItemCustomerLabel.Text = "Customer:";
            // 
            // ChooseItemFormcodeContentLabel
            // 
            this.ChooseItemFormcodeContentLabel.AutoSize = true;
            this.ChooseItemFormcodeContentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseItemFormcodeContentLabel.Location = new System.Drawing.Point(108, 18);
            this.ChooseItemFormcodeContentLabel.Name = "ChooseItemFormcodeContentLabel";
            this.ChooseItemFormcodeContentLabel.Size = new System.Drawing.Size(51, 20);
            this.ChooseItemFormcodeContentLabel.TabIndex = 2;
            this.ChooseItemFormcodeContentLabel.Text = "label3";
            // 
            // ChooseItemCustomerContentLabel
            // 
            this.ChooseItemCustomerContentLabel.AutoSize = true;
            this.ChooseItemCustomerContentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseItemCustomerContentLabel.Location = new System.Drawing.Point(105, 52);
            this.ChooseItemCustomerContentLabel.Name = "ChooseItemCustomerContentLabel";
            this.ChooseItemCustomerContentLabel.Size = new System.Drawing.Size(51, 20);
            this.ChooseItemCustomerContentLabel.TabIndex = 3;
            this.ChooseItemCustomerContentLabel.Text = "label4";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(21, 92);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(358, 319);
            this.checkedListBox1.TabIndex = 5;
            // 
            // ChooseItemButton
            // 
            this.ChooseItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseItemButton.Location = new System.Drawing.Point(140, 439);
            this.ChooseItemButton.Name = "ChooseItemButton";
            this.ChooseItemButton.Size = new System.Drawing.Size(105, 41);
            this.ChooseItemButton.TabIndex = 6;
            this.ChooseItemButton.Text = "Continue";
            this.ChooseItemButton.UseVisualStyleBackColor = true;
            this.ChooseItemButton.Click += new System.EventHandler(this.ChooseItemButton_Click);
            // 
            // ChooseItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 495);
            this.Controls.Add(this.ChooseItemButton);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.ChooseItemCustomerContentLabel);
            this.Controls.Add(this.ChooseItemFormcodeContentLabel);
            this.Controls.Add(this.ChooseItemCustomerLabel);
            this.Controls.Add(this.ChooseItemFormcodeLabel);
            this.Name = "ChooseItemForm";
            this.Text = "Choose Item";
            this.Load += new System.EventHandler(this.ChooseItemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ChooseItemFormcodeLabel;
        private System.Windows.Forms.Label ChooseItemCustomerLabel;
        private System.Windows.Forms.Label ChooseItemFormcodeContentLabel;
        private System.Windows.Forms.Label ChooseItemCustomerContentLabel;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button ChooseItemButton;
    }
}