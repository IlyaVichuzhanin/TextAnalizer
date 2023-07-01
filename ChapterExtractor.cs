using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextAnalizer
{
    public class ChapterExtractor
    {
        public ChapterExtractor(WordprocessingDocument wordDocument)
        {
            this.WordDocument = wordDocument;
        }
        public WordprocessingDocument WordDocument { get; set; }

        public List<Chapter> DocumentChapters { get; set; }

        public List<Paragraph> GetParagraphs()
        {
            return WordDocument.MainDocumentPart.Document.Body
                .OfType<Paragraph>()
                .Where(p => p.ParagraphProperties != null)
                .ToList();
        }

        public int GetNumberOfChapters()
        {
            var paragraphs = GetParagraphs();
            var chapterCounter = 0;
            foreach (Paragraph paragraph in paragraphs)
            {
                if (IsChapterParagraph(paragraph))
                    chapterCounter++;
            }
            return chapterCounter;
        }

        public static bool IsChapterParagraph(Paragraph paragraph)
        {
            var stringPattern = "^[гГ]лава[ [0-9]*.*";
            var numberingProperties = paragraph.ParagraphProperties.NumberingProperties;
            if (numberingProperties != null && numberingProperties.NumberingLevelReference.Val == 0)
                return true;
            else
            {
                if (Regex.IsMatch(paragraph.InnerText, stringPattern))
                    return true;
            }
            return false;
        }

        public List<Chapter> GetChapters()
        {
            var chapters= new List<Chapter>();
            var paragraphs = GetParagraphs();
            var chapterCounter = 0;

            foreach (Paragraph paragraph in paragraphs)
            {
                if (IsChapterParagraph(paragraph))
                {
                    chapterCounter++;
                    var newChapter = new Chapter(chapterCounter);
                    newChapter.Title = Chapter.GetChapterTitlte(paragraph);
                    chapters.Add(newChapter);
                }
                else
                {
                    chapters.Last().Content.Add(paragraph);
                }
            }
            return chapters;
        }
        public List<ChapterVM> GetChapterVMs()
        {
            var chapters = GetChapters();
            return chapters
                .Select(chapter => new ChapterVM { 
                    Number = chapter.Number.ToString(), 
                    Title = chapter.Title.ToString(), 
                    ChapterText = chapter.ChapterText.ToString(),
                    NumberOfParagraphs = chapter.NumberOfParagraphs.ToString(),
                    NumberOfCharacters = chapter.NumberOfCharacters.ToString(),
                })
                .ToList();
        }
        public string GetChapterDiscription()
        {
            var numberOfChapters = GetNumberOfChapters();
            var correctNoun = WordDecliner.Decline(numberOfChapters, "главу", "главы", "глав");
            return $"Анализируемый файл содержит {numberOfChapters} {correctNoun}.";
        }

    }
}
