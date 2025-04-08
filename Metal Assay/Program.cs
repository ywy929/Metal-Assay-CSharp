using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metal_Assay
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //GlobalConfig.ConnectionString = @"server=192.168.0.36;uid=view1;pwd=Assay123!;database=assay";
            GlobalConfig.ConnectionString = @"server=localhost;uid=root;pwd=Assay123!;database=assay";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
