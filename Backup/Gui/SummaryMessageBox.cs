using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Backup.Gui
{
    public partial class SummaryMessageBox : Form
    {
        public SummaryMessageBox(string Text, string Caption)
        {
            InitializeComponent();
            this.Text = Caption;
            this.txtSummary.Text = Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
