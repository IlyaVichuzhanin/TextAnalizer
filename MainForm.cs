using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAnalizer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = @"All Files|*.docx;*.doc;*.docm;*.dotx;.*|Word File (.docx ,.doc)|*.docx;*.doc";
            openFileDialog1.ShowDialog();
            var filePath = openFileDialog1.FileName;
            var analiticsForm = new TextAnalysis();
            analiticsForm.FilePath = filePath;
            analiticsForm.ShowDialog();
        }
    }
}
