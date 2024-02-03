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
            this.AddCancelButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.AddSampleWeightTextbox = new System.Windows.Forms.TextBox();
            this.AddItemcodeTextbox = new System.Windows.Forms.TextBox();
            this.AddSampleWeightLabel = new System.Windows.Forms.Label();
            this.AddItemcodeLabel = new System.Windows.Forms.Label();
            this.AddCustomerLabel = new System.Windows.Forms.Label();
            this.AddDateLabel = new System.Windows.Forms.Label();
            this.AddFormCodeLabel = new System.Windows.Forms.Label();
            this.AddFormCodeContent = new System.Windows.Forms.Label();
            this.AddCustomerContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddCancelButton
            // 
            this.AddCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCancelButton.Location = new System.Drawing.Point(261, 289);
            this.AddCancelButton.Name = "AddCancelButton";
            this.AddCancelButton.Size = new System.Drawing.Size(100, 50);
            this.AddCancelButton.TabIndex = 29;
            this.AddCancelButton.Text = "Cancel";
            this.AddCancelButton.UseVisualStyleBackColor = true;
            this.AddCancelButton.Click += new System.EventHandler(this.AddCancelButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(101, 289);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(100, 50);
            this.AddButton.TabIndex = 28;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddSampleWeightTextbox
            // 
            this.AddSampleWeightTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSampleWeightTextbox.Location = new System.Drawing.Point(207, 226);
            this.AddSampleWeightTextbox.Name = "AddSampleWeightTextbox";
            this.AddSampleWeightTextbox.Size = new System.Drawing.Size(214, 31);
            this.AddSampleWeightTextbox.TabIndex = 27;
            this.AddSampleWeightTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabToNext);
            this.AddSampleWeightTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalValidation);
            // 
            // AddItemcodeTextbox
            // 
            this.AddItemcodeTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AddItemcodeTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddItemcodeTextbox.Location = new System.Drawing.Point(128, 174);
            this.AddItemcodeTextbox.Name = "AddItemcodeTextbox";
            this.AddItemcodeTextbox.Size = new System.Drawing.Size(293, 31);
            this.AddItemcodeTextbox.TabIndex = 26;
            this.AddItemcodeTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabToNext);
            // 
            // AddSampleWeightLabel
            // 
            this.AddSampleWeightLabel.AutoSize = true;
            this.AddSampleWeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSampleWeightLabel.Location = new System.Drawing.Point(12, 229);
            this.AddSampleWeightLabel.Name = "AddSampleWeightLabel";
            this.AddSampleWeightLabel.Size = new System.Drawing.Size(189, 25);
            this.AddSampleWeightLabel.TabIndex = 25;
            this.AddSampleWeightLabel.Text = "Sample Weight(g):";
            // 
            // AddItemcodeLabel
            // 
            this.AddItemcodeLabel.AutoSize = true;
            this.AddItemcodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddItemcodeLabel.Location = new System.Drawing.Point(13, 177);
            this.AddItemcodeLabel.Name = "AddItemcodeLabel";
            this.AddItemcodeLabel.Size = new System.Drawing.Size(109, 25);
            this.AddItemcodeLabel.TabIndex = 24;
            this.AddItemcodeLabel.Text = "ItemCode:";
            // 
            // AddCustomerLabel
            // 
            this.AddCustomerLabel.AutoSize = true;
            this.AddCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCustomerLabel.Location = new System.Drawing.Point(12, 21);
            this.AddCustomerLabel.Name = "AddCustomerLabel";
            this.AddCustomerLabel.Size = new System.Drawing.Size(110, 25);
            this.AddCustomerLabel.TabIndex = 23;
            this.AddCustomerLabel.Text = "Customer:";
            // 
            // AddDateLabel
            // 
            this.AddDateLabel.AutoSize = true;
            this.AddDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddDateLabel.Location = new System.Drawing.Point(12, 125);
            this.AddDateLabel.Name = "AddDateLabel";
            this.AddDateLabel.Size = new System.Drawing.Size(63, 25);
            this.AddDateLabel.TabIndex = 22;
            this.AddDateLabel.Text = "Date:";
            // 
            // AddFormCodeLabel
            // 
            this.AddFormCodeLabel.AutoSize = true;
            this.AddFormCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFormCodeLabel.Location = new System.Drawing.Point(12, 73);
            this.AddFormCodeLabel.Name = "AddFormCodeLabel";
            this.AddFormCodeLabel.Size = new System.Drawing.Size(114, 25);
            this.AddFormCodeLabel.TabIndex = 21;
            this.AddFormCodeLabel.Text = "Formcode:";
            // 
            // AddFormCodeContent
            // 
            this.AddFormCodeContent.AutoSize = true;
            this.AddFormCodeContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFormCodeContent.Location = new System.Drawing.Point(132, 73);
            this.AddFormCodeContent.Name = "AddFormCodeContent";
            this.AddFormCodeContent.Size = new System.Drawing.Size(114, 25);
            this.AddFormCodeContent.TabIndex = 30;
            this.AddFormCodeContent.Text = "Formcode:";
            // 
            // AddCustomerContent
            // 
            this.AddCustomerContent.AutoSize = true;
            this.AddCustomerContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCustomerContent.Location = new System.Drawing.Point(123, 21);
            this.AddCustomerContent.Name = "AddCustomerContent";
            this.AddCustomerContent.Size = new System.Drawing.Size(110, 25);
            this.AddCustomerContent.TabIndex = 31;
            this.AddCustomerContent.Text = "Customer:";
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 363);
            this.Controls.Add(this.AddCustomerContent);
            this.Controls.Add(this.AddFormCodeContent);
            this.Controls.Add(this.AddCancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AddSampleWeightTextbox);
            this.Controls.Add(this.AddItemcodeTextbox);
            this.Controls.Add(this.AddSampleWeightLabel);
            this.Controls.Add(this.AddItemcodeLabel);
            this.Controls.Add(this.AddCustomerLabel);
            this.Controls.Add(this.AddDateLabel);
            this.Controls.Add(this.AddFormCodeLabel);
            this.Name = "AddForm";
            this.Text = "Add";
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddCancelButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox AddSampleWeightTextbox;
        private System.Windows.Forms.TextBox AddItemcodeTextbox;
        private System.Windows.Forms.Label AddSampleWeightLabel;
        private System.Windows.Forms.Label AddItemcodeLabel;
        private System.Windows.Forms.Label AddCustomerLabel;
        private System.Windows.Forms.Label AddDateLabel;
        private System.Windows.Forms.Label AddFormCodeLabel;
        private System.Windows.Forms.Label AddFormCodeContent;
        private System.Windows.Forms.Label AddCustomerContent;
    }
}