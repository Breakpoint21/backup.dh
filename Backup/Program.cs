using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Backup.Core;
using System.IO;
using System.Diagnostics;
using Backup.Gui;

namespace Backup
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DHBWBackup());
        }
    }
}
