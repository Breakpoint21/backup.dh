using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DDDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtSource_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(txtSource.Text, DragDropEffects.All);
        }

        private void txtDest_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Copy;
            } 
        }

        private void txtDest_DragDrop(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData("System.String");
            string content = data as string;
            if (content != null)
            {
                txtDest.Text = content;
            }
        }

        private void txtFile_DragDrop(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData("FileName");
            string[] fileName = data as string[];
            if (fileName != null)
            {
                txtFile.Text = File.OpenText(fileName[0]).ReadToEnd();
            }
        }

        private void txtFile_DragEnter(object sender, DragEventArgs e)
        {
            foreach (string format in e.Data.GetFormats())
            {
                Console.WriteLine(format);
            }
            if (e.Data.GetDataPresent("FileName"))
	        {
                e.Effect = DragDropEffects.Link; 
	        }
            if (e.Data.GetDataPresent("FileNameW"))
            {
                object test = e.Data.GetData("FileNameW");
                Console.WriteLine(e.Data.GetData("FileNameW"));
            }
        }
    }
}
