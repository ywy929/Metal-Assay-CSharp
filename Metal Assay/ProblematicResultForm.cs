using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void ProblematicResultForm_Load(object sender, EventArgs e)
        {
        }
    }
}
