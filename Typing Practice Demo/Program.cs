using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Typing_Practice_Demo.Forms;

namespace Typing_Practice_Demo
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var FormStart = new Form_Login();
            if (!FormStart.IsDisposed) FormStart.Show();
            Application.Run();
        }
    }
}
