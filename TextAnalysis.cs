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
using Color = System.Drawing.Color;

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
            label2.Text = "";
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
            if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = SaveFileDialog.FileName;
            filename=filename + ".html";
            var htmlReport = ReportCreator.GetHTMLReport(listChapters);
            File.WriteAllText(filename, htmlReport);
            SaveFileDialog.FileName = "";
        }

        private void btnSaveXMLReport_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = SaveFileDialog.FileName;
            filename = filename + ".xml";
            var xmlReport = ReportCreator.GetXMLReport(listChapters);
            xmlReport.Save(filename);
            SaveFileDialog.FileName = "";
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            var message = ReportCreator.GetHTMLReport(listChapters);
            var emailAdress = textBox1.Text.Trim();
            if (!EmailSender.EmailIsValid(emailAdress))
            {
                label2.Text = "Введен некорректный адрес электронной почты отправка не возможна!";
                label2.ForeColor = Color.Red;
            }
            else
            {
                var sendSuccessfully = EmailSender.SendEmail(emailAdress, message);
                if (sendSuccessfully)
                {
                    label2.Text = "Отправка письма произошла успешно";
                    label2.ForeColor = Color.Green;
                }
                else
                {
                    label2.Text = "Письмо не было отправлено. Проверьте адрес электронной почты!";
                    label2.ForeColor = Color.Red;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var emaiAdress = textBox1.Text.Trim();
            if (!EmailSender.EmailIsValid(emaiAdress))
            {
                label2.Text = "Адрес не соответствует формату";
                label2.ForeColor = Color.Red;
            }
            else
            {
                label2.Text = "Адрес соответствует формату";
                label2.ForeColor = Color.Green;
            }
        }
    }
}
