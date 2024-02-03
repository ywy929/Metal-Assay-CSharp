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
            this.EditSampleWeightTextbox = new System.Windows.Forms.TextBox();
            this.EditItemcodeTextbox = new System.Windows.Forms.TextBox();
            this.EditSampleWeightLabel = new System.Windows.Forms.Label();
            this.EditItemcodeLabel = new System.Windows.Forms.Label();
            this.EditCustomerLabel = new System.Windows.Forms.Label();
            this.EditDateLabel = new System.Windows.Forms.Label();
            this.EditFormCodeLabel = new System.Windows.Forms.Label();
            this.EditSaveButton = new System.Windows.Forms.Button();
            this.CancelSaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EditSampleWeightTextbox
            // 
            this.EditSampleWeightTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSampleWeightTextbox.Location = new System.Drawing.Point(207, 225);
            this.EditSampleWeightTextbox.Name = "EditSampleWeightTextbox";
            this.EditSampleWeightTextbox.Size = new System.Drawing.Size(214, 31);
            this.EditSampleWeightTextbox.TabIndex = 18;
            this.EditSampleWeightTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabToNext);
            this.EditSampleWeightTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalValidation);
            // 
            // EditItemcodeTextbox
            // 
            this.EditItemcodeTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.EditItemcodeTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditItemcodeTextbox.Location = new System.Drawing.Point(128, 173);
            this.EditItemcodeTextbox.Name = "EditItemcodeTextbox";
            this.EditItemcodeTextbox.Size = new System.Drawing.Size(293, 31);
            this.EditItemcodeTextbox.TabIndex = 17;
            this.EditItemcodeTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabToNext);
            // 
            // EditSampleWeightLabel
            // 
            this.EditSampleWeightLabel.AutoSize = true;
            this.EditSampleWeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSampleWeightLabel.Location = new System.Drawing.Point(12, 228);
            this.EditSampleWeightLabel.Name = "EditSampleWeightLabel";
            this.EditSampleWeightLabel.Size = new System.Drawing.Size(189, 25);
            this.EditSampleWeightLabel.TabIndex = 16;
            this.EditSampleWeightLabel.Text = "Sample Weight(g):";
            // 
            // EditItemcodeLabel
            // 
            this.EditItemcodeLabel.AutoSize = true;
            this.EditItemcodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditItemcodeLabel.Location = new System.Drawing.Point(13, 176);
            this.EditItemcodeLabel.Name = "EditItemcodeLabel";
            this.EditItemcodeLabel.Size = new System.Drawing.Size(109, 25);
            this.EditItemcodeLabel.TabIndex = 15;
            this.EditItemcodeLabel.Text = "ItemCode:";
            // 
            // EditCustomerLabel
            // 
            this.EditCustomerLabel.AutoSize = true;
            this.EditCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditCustomerLabel.Location = new System.Drawing.Point(12, 20);
            this.EditCustomerLabel.Name = "EditCustomerLabel";
            this.EditCustomerLabel.Size = new System.Drawing.Size(110, 25);
            this.EditCustomerLabel.TabIndex = 14;
            this.EditCustomerLabel.Text = "Customer:";
            // 
            // EditDateLabel
            // 
            this.EditDateLabel.AutoSize = true;
            this.EditDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditDateLabel.Location = new System.Drawing.Point(12, 124);
            this.EditDateLabel.Name = "EditDateLabel";
            this.EditDateLabel.Size = new System.Drawing.Size(63, 25);
            this.EditDateLabel.TabIndex = 13;
            this.EditDateLabel.Text = "Date:";
            // 
            // EditFormCodeLabel
            // 
            this.EditFormCodeLabel.AutoSize = true;
            this.EditFormCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditFormCodeLabel.Location = new System.Drawing.Point(12, 72);
            this.EditFormCodeLabel.Name = "EditFormCodeLabel";
            this.EditFormCodeLabel.Size = new System.Drawing.Size(114, 25);
            this.EditFormCodeLabel.TabIndex = 12;
            this.EditFormCodeLabel.Text = "Formcode:";
            // 
            // EditSaveButton
            // 
            this.EditSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSaveButton.Location = new System.Drawing.Point(101, 288);
            this.EditSaveButton.Name = "EditSaveButton";
            this.EditSaveButton.Size = new System.Drawing.Size(100, 50);
            this.EditSaveButton.TabIndex = 19;
            this.EditSaveButton.Text = "Save";
            this.EditSaveButton.UseVisualStyleBackColor = true;
            this.EditSaveButton.Click += new System.EventHandler(this.EditSaveButton_Click);
            // 
            // CancelSaveButton
            // 
            this.CancelSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelSaveButton.Location = new System.Drawing.Point(261, 288);
            this.CancelSaveButton.Name = "CancelSaveButton";
            this.CancelSaveButton.Size = new System.Drawing.Size(100, 50);
            this.CancelSaveButton.TabIndex = 20;
            this.CancelSaveButton.Text = "Cancel";
            this.CancelSaveButton.UseVisualStyleBackColor = true;
            this.CancelSaveButton.Click += new System.EventHandler(this.CancelSaveButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 370);
            this.Controls.Add(this.CancelSaveButton);
            this.Controls.Add(this.EditSaveButton);
            this.Controls.Add(this.EditSampleWeightTextbox);
            this.Controls.Add(this.EditItemcodeTextbox);
            this.Controls.Add(this.EditSampleWeightLabel);
            this.Controls.Add(this.EditItemcodeLabel);
            this.Controls.Add(this.EditCustomerLabel);
            this.Controls.Add(this.EditDateLabel);
            this.Controls.Add(this.EditFormCodeLabel);
            this.Name = "Form3";
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox EditSampleWeightTextbox;
        private System.Windows.Forms.TextBox EditItemcodeTextbox;
        private System.Windows.Forms.Label EditSampleWeightLabel;
        private System.Windows.Forms.Label EditItemcodeLabel;
        private System.Windows.Forms.Label EditCustomerLabel;
        private System.Windows.Forms.Label EditDateLabel;
        private System.Windows.Forms.Label EditFormCodeLabel;
        private System.Windows.Forms.Button EditSaveButton;
        private System.Windows.Forms.Button CancelSaveButton;
    }
}