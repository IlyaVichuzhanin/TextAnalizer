namespace TextAnalizer
{
    partial class TextAnalysis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.listChapters = new System.Windows.Forms.ListView();
            this.ChapterNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChapterName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumberOfParagraph = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumOfCharacter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chapterTextBox = new System.Windows.Forms.RichTextBox();
            this.btnSaveXMLReport = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveHTMLReport = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // listChapters
            // 
            this.listChapters.BackColor = System.Drawing.Color.White;
            this.listChapters.BackgroundImageTiled = true;
            this.listChapters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ChapterNumber,
            this.ChapterName,
            this.NumberOfParagraph,
            this.NumOfCharacter});
            this.listChapters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listChapters.FullRowSelect = true;
            this.listChapters.GridLines = true;
            this.listChapters.HideSelection = false;
            this.listChapters.Location = new System.Drawing.Point(12, 55);
            this.listChapters.Name = "listChapters";
            this.listChapters.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listChapters.Size = new System.Drawing.Size(924, 296);
            this.listChapters.TabIndex = 1;
            this.listChapters.UseCompatibleStateImageBehavior = false;
            this.listChapters.View = System.Windows.Forms.View.Details;
            this.listChapters.SelectedIndexChanged += new System.EventHandler(this.listChapters_SelectedIndexChanged);
            // 
            // ChapterNumber
            // 
            this.ChapterNumber.Text = "Номер главы";
            this.ChapterNumber.Width = 120;
            // 
            // ChapterName
            // 
            this.ChapterName.Text = "Название главы";
            this.ChapterName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ChapterName.Width = 400;
            // 
            // NumberOfParagraph
            // 
            this.NumberOfParagraph.Text = "Количество параграфов";
            this.NumberOfParagraph.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumberOfParagraph.Width = 200;
            // 
            // NumOfCharacter
            // 
            this.NumOfCharacter.Text = "Количество символов";
            this.NumOfCharacter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumOfCharacter.Width = 200;
            // 
            // chapterTextBox
            // 
            this.chapterTextBox.Location = new System.Drawing.Point(951, 55);
            this.chapterTextBox.Name = "chapterTextBox";
            this.chapterTextBox.Size = new System.Drawing.Size(569, 595);
            this.chapterTextBox.TabIndex = 2;
            this.chapterTextBox.Text = "";
            // 
            // btnSaveXMLReport
            // 
            this.btnSaveXMLReport.Location = new System.Drawing.Point(27, 378);
            this.btnSaveXMLReport.Name = "btnSaveXMLReport";
            this.btnSaveXMLReport.Size = new System.Drawing.Size(136, 33);
            this.btnSaveXMLReport.TabIndex = 3;
            this.btnSaveXMLReport.Text = "Save report in XML";
            this.btnSaveXMLReport.UseVisualStyleBackColor = true;
            this.btnSaveXMLReport.Click += new System.EventHandler(this.btnSaveXMLReport_Click);
            // 
            // btnSaveHTMLReport
            // 
            this.btnSaveHTMLReport.Location = new System.Drawing.Point(27, 418);
            this.btnSaveHTMLReport.Name = "btnSaveHTMLReport";
            this.btnSaveHTMLReport.Size = new System.Drawing.Size(136, 34);
            this.btnSaveHTMLReport.TabIndex = 4;
            this.btnSaveHTMLReport.Text = "Save report in HTML";
            this.btnSaveHTMLReport.UseVisualStyleBackColor = true;
            this.btnSaveHTMLReport.Click += new System.EventHandler(this.btnSaveHTMLReport_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(27, 471);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(136, 32);
            this.btnSendEmail.TabIndex = 5;
            this.btnSendEmail.Text = "Send report on email:";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(205, 477);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(221, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 508);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // TextAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 662);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.btnSaveHTMLReport);
            this.Controls.Add(this.btnSaveXMLReport);
            this.Controls.Add(this.chapterTextBox);
            this.Controls.Add(this.listChapters);
            this.Controls.Add(this.label1);
            this.Name = "TextAnalysis";
            this.Text = "TextAnalysis";
            this.Load += new System.EventHandler(this.TextAnalysis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listChapters;
        private System.Windows.Forms.ColumnHeader ChapterNumber;
        private System.Windows.Forms.ColumnHeader ChapterName;
        private System.Windows.Forms.ColumnHeader NumberOfParagraph;
        private System.Windows.Forms.ColumnHeader NumOfCharacter;
        private System.Windows.Forms.RichTextBox chapterTextBox;
        private System.Windows.Forms.Button btnSaveXMLReport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnSaveHTMLReport;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}