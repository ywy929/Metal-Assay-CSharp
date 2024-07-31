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
            this.NewFormCodeButton = new System.Windows.Forms.Button();
            this.NewFormCodeLabel = new System.Windows.Forms.Label();
            this.NewDateLabel = new System.Windows.Forms.Label();
            this.NewCustomerLabel = new System.Windows.Forms.Label();
            this.NewItemcodeLabel = new System.Windows.Forms.Label();
            this.NewSampleWeightLabel = new System.Windows.Forms.Label();
            this.NewItemcodeTextbox = new System.Windows.Forms.TextBox();
            this.NewSampleWeightTextbox = new System.Windows.Forms.TextBox();
            this.NewFormCodeContent = new System.Windows.Forms.Label();
            this.NewDateContent = new System.Windows.Forms.Label();
            this.NewCustomerListbox = new System.Windows.Forms.ListBox();
            this.NewCustomerTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NewFormCodeButton
            // 
            this.NewFormCodeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFormCodeButton.Location = new System.Drawing.Point(12, 12);
            this.NewFormCodeButton.Name = "NewFormCodeButton";
            this.NewFormCodeButton.Size = new System.Drawing.Size(173, 37);
            this.NewFormCodeButton.TabIndex = 0;
            this.NewFormCodeButton.Text = "New FormCode";
            this.NewFormCodeButton.UseVisualStyleBackColor = true;
            this.NewFormCodeButton.Click += new System.EventHandler(this.NewFormCodeButton_Click);
            // 
            // NewFormCodeLabel
            // 
            this.NewFormCodeLabel.AutoSize = true;
            this.NewFormCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFormCodeLabel.Location = new System.Drawing.Point(12, 71);
            this.NewFormCodeLabel.Name = "NewFormCodeLabel";
            this.NewFormCodeLabel.Size = new System.Drawing.Size(114, 25);
            this.NewFormCodeLabel.TabIndex = 1;
            this.NewFormCodeLabel.Text = "Formcode:";
            // 
            // NewDateLabel
            // 
            this.NewDateLabel.AutoSize = true;
            this.NewDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewDateLabel.Location = new System.Drawing.Point(12, 122);
            this.NewDateLabel.Name = "NewDateLabel";
            this.NewDateLabel.Size = new System.Drawing.Size(63, 25);
            this.NewDateLabel.TabIndex = 2;
            this.NewDateLabel.Text = "Date:";
            // 
            // NewCustomerLabel
            // 
            this.NewCustomerLabel.AutoSize = true;
            this.NewCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCustomerLabel.Location = new System.Drawing.Point(12, 173);
            this.NewCustomerLabel.Name = "NewCustomerLabel";
            this.NewCustomerLabel.Size = new System.Drawing.Size(110, 25);
            this.NewCustomerLabel.TabIndex = 3;
            this.NewCustomerLabel.Text = "Customer:";
            // 
            // NewItemcodeLabel
            // 
            this.NewItemcodeLabel.AutoSize = true;
            this.NewItemcodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewItemcodeLabel.Location = new System.Drawing.Point(12, 224);
            this.NewItemcodeLabel.Name = "NewItemcodeLabel";
            this.NewItemcodeLabel.Size = new System.Drawing.Size(109, 25);
            this.NewItemcodeLabel.TabIndex = 4;
            this.NewItemcodeLabel.Text = "ItemCode:";
            // 
            // NewSampleWeightLabel
            // 
            this.NewSampleWeightLabel.AutoSize = true;
            this.NewSampleWeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSampleWeightLabel.Location = new System.Drawing.Point(12, 275);
            this.NewSampleWeightLabel.Name = "NewSampleWeightLabel";
            this.NewSampleWeightLabel.Size = new System.Drawing.Size(189, 25);
            this.NewSampleWeightLabel.TabIndex = 5;
            this.NewSampleWeightLabel.Text = "Sample Weight(g):";
            // 
            // NewItemcodeTextbox
            // 
            this.NewItemcodeTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NewItemcodeTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewItemcodeTextbox.Location = new System.Drawing.Point(128, 221);
            this.NewItemcodeTextbox.Name = "NewItemcodeTextbox";
            this.NewItemcodeTextbox.Size = new System.Drawing.Size(436, 31);
            this.NewItemcodeTextbox.TabIndex = 7;
            this.NewItemcodeTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewItemcodeTextbox_KeyDown);
            // 
            // NewSampleWeightTextbox
            // 
            this.NewSampleWeightTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSampleWeightTextbox.Location = new System.Drawing.Point(207, 272);
            this.NewSampleWeightTextbox.Name = "NewSampleWeightTextbox";
            this.NewSampleWeightTextbox.Size = new System.Drawing.Size(214, 31);
            this.NewSampleWeightTextbox.TabIndex = 8;
            this.NewSampleWeightTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewSampleWeightTextbox_KeyDown);
            this.NewSampleWeightTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Decimal_Validation);
            // 
            // NewFormCodeContent
            // 
            this.NewFormCodeContent.AutoSize = true;
            this.NewFormCodeContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFormCodeContent.Location = new System.Drawing.Point(132, 71);
            this.NewFormCodeContent.Name = "NewFormCodeContent";
            this.NewFormCodeContent.Size = new System.Drawing.Size(0, 25);
            this.NewFormCodeContent.TabIndex = 10;
            // 
            // NewDateContent
            // 
            this.NewDateContent.AutoSize = true;
            this.NewDateContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewDateContent.Location = new System.Drawing.Point(81, 122);
            this.NewDateContent.Name = "NewDateContent";
            this.NewDateContent.Size = new System.Drawing.Size(0, 25);
            this.NewDateContent.TabIndex = 11;
            // 
            // NewCustomerListbox
            // 
            this.NewCustomerListbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCustomerListbox.FormattingEnabled = true;
            this.NewCustomerListbox.ItemHeight = 20;
            this.NewCustomerListbox.Location = new System.Drawing.Point(127, 210);
            this.NewCustomerListbox.Name = "NewCustomerListbox";
            this.NewCustomerListbox.Size = new System.Drawing.Size(437, 124);
            this.NewCustomerListbox.TabIndex = 34;
            this.NewCustomerListbox.Visible = false;
            this.NewCustomerListbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewCustomerListbox_KeyDown);
            this.NewCustomerListbox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NewCustomerListbox_MouseDoubleClick);
            // 
            // NewCustomerTextbox
            // 
            this.NewCustomerTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCustomerTextbox.Location = new System.Drawing.Point(128, 173);
            this.NewCustomerTextbox.Name = "NewCustomerTextbox";
            this.NewCustomerTextbox.Size = new System.Drawing.Size(436, 31);
            this.NewCustomerTextbox.TabIndex = 33;
            this.NewCustomerTextbox.TextChanged += new System.EventHandler(this.NewCustomerTextbox_TextChanged);
            this.NewCustomerTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewCustomerTextbox_KeyDown);
            this.NewCustomerTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewCustomerTextbox_KeyPress);
            // 
            // NewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 354);
            this.Controls.Add(this.NewCustomerListbox);
            this.Controls.Add(this.NewCustomerTextbox);
            this.Controls.Add(this.NewDateContent);
            this.Controls.Add(this.NewFormCodeContent);
            this.Controls.Add(this.NewSampleWeightTextbox);
            this.Controls.Add(this.NewItemcodeTextbox);
            this.Controls.Add(this.NewSampleWeightLabel);
            this.Controls.Add(this.NewItemcodeLabel);
            this.Controls.Add(this.NewCustomerLabel);
            this.Controls.Add(this.NewDateLabel);
            this.Controls.Add(this.NewFormCodeLabel);
            this.Controls.Add(this.NewFormCodeButton);
            this.Name = "NewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Shown += new System.EventHandler(this.NewForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewFormCodeButton;
        private System.Windows.Forms.Label NewFormCodeLabel;
        private System.Windows.Forms.Label NewDateLabel;
        private System.Windows.Forms.Label NewCustomerLabel;
        private System.Windows.Forms.Label NewItemcodeLabel;
        private System.Windows.Forms.Label NewSampleWeightLabel;
        private System.Windows.Forms.TextBox NewItemcodeTextbox;
        private System.Windows.Forms.TextBox NewSampleWeightTextbox;
        private System.Windows.Forms.Label NewFormCodeContent;
        private System.Windows.Forms.Label NewDateContent;
        private System.Windows.Forms.ListBox NewCustomerListbox;
        private System.Windows.Forms.TextBox NewCustomerTextbox;
    }
}