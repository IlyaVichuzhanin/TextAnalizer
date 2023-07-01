using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalizer
{
    public class ChapterVM
    {
        public string Number { get; set; }
        public string Title { get; set; }
        public string ChapterText { get; set; }
        public string NumberOfParagraphs { get; set; }
        public string NumberOfCharacters { get; set; }
    }
}
