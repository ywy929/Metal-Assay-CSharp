using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metal_Assay
{
    public partial class ProblematicResultForm : Form
    {
        private Main MainForm;
        public ProblematicResultForm(Main mainForm)
        {
            InitializeComponent();
        MainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.SaveProblemLastWeight("REJECT");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm.SaveProblemLastWeight("REDO");
            Close();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm.SaveProblemLastWeight("LOW");
            Close();
        }

        private void RedoButton_MouseEnter(object sender, EventArgs e)
        {
            RedoButton.BackColor = System.Drawing.Color.FromArgb(184, 134, 11); // Darker gold
        }

        private void RedoButton_MouseLeave(object sender, EventArgs e)
        {
            RedoButton.BackColor = System.Drawing.Color.FromArgb(218, 165, 32); // Original gold
        }

        private void RejectButton_MouseEnter(object sender, EventArgs e)
        {
            RejectButton.BackColor = System.Drawing.Color.FromArgb(184, 134, 11); // Darker gold
        }

        private void RejectButton_MouseLeave(object sender, EventArgs e)
        {
            RejectButton.BackColor = System.Drawing.Color.FromArgb(218, 165, 32); // Original gold
        }

        private void LowButton_MouseEnter(object sender, EventArgs e)
        {
            LowButton.BackColor = System.Drawing.Color.FromArgb(184, 134, 11); // Darker gold
        }

        private void LowButton_MouseLeave(object sender, EventArgs e)
        {
            LowButton.BackColor = System.Drawing.Color.FromArgb(218, 165, 32); // Original gold
        }
    }
}
