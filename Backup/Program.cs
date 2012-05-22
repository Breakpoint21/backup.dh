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
            //Process proc = Process.GetCurrentProcess();
            //long mem = proc.PrivateMemorySize64;
            //List<FileInfo> testList = new List<FileInfo>();
            //testList.Add(new FileInfo(@"C:\Users\Pascal\test.txt"));
            //testList.Add(new FileInfo(@"C:\Users\Pascal\Counter.jar"));
            //testList.Add(new FileInfo(@"C:\Users\Pascal\MC.jar"));
            //testList.Add(new FileInfo(@"C:\Users\Pascal\Downloads\two.and.a.half.men.s09e20.hdtv.xvid-fqm.avi"));
            //BackupBuilder builder = new BackupBuilder();
            //builder.BuildBackup(testList);

            //RestoreBuilder restore = new RestoreBuilder();
            //List<string> names = restore.createIndex(@"C:\Users\Pascal\backup.dhbw");
            //foreach (string name in names)
            //{
            //    Console.WriteLine(name);
            //}

            //DirectoryInfo dest = new DirectoryInfo(@"C:\Users\Pascal\Restore");
            //restore.RestoreBackup(@"C:\Users\Pascal\backup.dhbw", dest);

            BackupController controller = new BackupController();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DHBWBackup(controller));
        }
    }
}
