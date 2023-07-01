using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextAnalizer
{
    public class Chapter
    {
        public Chapter(int number)
        {
            Number = number;
            Title = "";
            Content = new List<Paragraph>();
        }

        public int? Number { get; set; }
        public string Title { get; set; }
        public List<Paragraph> Content { get; set; }

        public string ChapterText
        {
            get { return "      "+string.Join(Environment.NewLine+"      ", Content.Select(x => x.InnerText).ToArray()); }
        }

        public int NumberOfParagraphs { get { return Content.Count; } }
        public int NumberOfCharacters { get { return ChapterText.Length; } }

        public static string GetChapterTitlte(Paragraph paragraph)
        {
            var stringPattern = "^[гГ]лава[ [0-9]*[.!?\\\\-]";
            if (paragraph.ParagraphProperties.NumberingProperties != null)
                return paragraph.InnerText;
            else
                return Regex.Replace(paragraph.InnerText, stringPattern, "").ToString().Trim();
        }
    }
}
