using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Features;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TextAnalizer
{
    public partial class TextAnalysis : Form
    {
        public TextAnalysis()
        {
            InitializeComponent();
            SaveFileDialog = new SaveFileDialog();
        }

        private List<ChapterVM> ChapterVMs { get; set; }
        public string FilePath { get; set; }
        public FileInfo FileInfo { get; set; }
        private SaveFileDialog SaveFileDialog;

        private void TextAnalysis_Load(object sender, EventArgs e)
        {
            WordprocessingDocument wordDocument = WordprocessingDocument.Open(FilePath, false);
            var chapterExtractor = new ChapterExtractor(wordDocument);
            label1.Text = chapterExtractor.GetChapterDiscription();
            ChapterVMs = chapterExtractor.GetChapterVMs();
            DisplayChapters();
        }
        public void DisplayChapters()
        {
            listChapters.Items.Clear();
            foreach (ChapterVM chapter in ChapterVMs)
            {
                var listViewItem = new ListViewItem(chapter.Number);
                listViewItem.SubItems.Add(chapter.Title);
                listViewItem.SubItems.Add(chapter.NumberOfParagraphs);
                listViewItem.SubItems.Add(chapter.NumberOfCharacters);
                listChapters.Items.Add(listViewItem);
            }
        }

        private void listChapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listChapters.SelectedItems.Count >= 1)
            {
                var chapterNumber = listChapters.SelectedItems[0].Text;
                chapterTextBox.Text = ChapterVMs.FirstOrDefault(x => x.Number == chapterNumber).ChapterText;
            }

        }

        private void btnSaveHTMLReport_Click(object sender, EventArgs e)
        {


        }

        private void btnSaveXMLReport_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = SaveFileDialog.FileName;
            ReportCreator.ExportListItemToXML(listChapters, filename);
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            EmailSender.SendEmail();
        }
    }
}
