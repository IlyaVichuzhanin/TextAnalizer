//using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Packaging;
using NUnit.Framework.Internal;
using System.Reflection;
using TextAnalizer;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var wordFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\Tests\\TestFiles\\TestFile.docx";
            WordDocument = WordprocessingDocument.Open(wordFilePath, false);
            ChapterExtractor = new ChapterExtractor(WordDocument);
        }

        WordprocessingDocument WordDocument { get; set; }
        ChapterExtractor ChapterExtractor { get; set; }

        [Test]
        public void DeclineTest()
        {
            Assert.AreEqual("�����", WordDecliner.Decline(2, "�����", "�����", "����"));
            Assert.AreEqual("������", WordDecliner.Decline(1, "������", "������", "�����"));
            Assert.AreEqual("���", WordDecliner.Decline(21, "���", "����", "�����"));
            Assert.AreEqual("������", WordDecliner.Decline(9, "������", "������", "������"));
        }

        [Test]
        public void GetChapterTitlteTest()
        {
            var paragraphs = ChapterExtractor.GetParagraphs();
            var testParagraph1 = paragraphs[0];
            var testParagraph2 = paragraphs[28];
            var testParagraph3 = paragraphs[141];
            var testParagraph4 = paragraphs[173];

            var correctChapterName1 = "���������� � ������� �������������";
            var correctChapterName2 = "���� �������� ������ �����";
            var correctChapterName3 = "���� �������� ���������� �������";
            var correctChapterName4 = "���� �������� ������";

            Assert.AreEqual(correctChapterName1, Chapter.GetChapterTitlte(testParagraph1));
            Assert.AreEqual(correctChapterName2, Chapter.GetChapterTitlte(testParagraph2));
            Assert.AreEqual(correctChapterName3, Chapter.GetChapterTitlte(testParagraph3));
            Assert.AreEqual(correctChapterName4, Chapter.GetChapterTitlte(testParagraph4));
        }
        [Test]
        public void GetNumberOfChaptersTest()
        {
            var wordFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\Tests\\TestFiles\\TestFile2.docx";
            var wordDocument2 = WordprocessingDocument.Open(wordFilePath, false);
            var chapterExtractor2 = new ChapterExtractor(wordDocument2);

            Assert.AreEqual(7, ChapterExtractor.GetNumberOfChapters());
            Assert.AreEqual(3, chapterExtractor2.GetNumberOfChapters());
        }
        [Test]
        public void IsChapterParagraphTest()
        {
            var paragraphs = ChapterExtractor.GetParagraphs();
            var testParagraph1 = paragraphs[0];
            var testParagraph2 = paragraphs[35];
            var testParagraph3 = paragraphs[141];
            var testParagraph4 = paragraphs[180];

            Assert.AreEqual(true, ChapterExtractor.IsChapterParagraph(testParagraph1));
            Assert.AreEqual(false, ChapterExtractor.IsChapterParagraph(testParagraph2));
            Assert.AreEqual(true, ChapterExtractor.IsChapterParagraph(testParagraph3));
            Assert.AreEqual(false, ChapterExtractor.IsChapterParagraph(testParagraph4));
        }
        [Test]
        public void GetChapterDiscriptionTest()
        {
            var correctDescription = $"������������� ���� �������� 7 ����.";
            Assert.AreEqual(correctDescription, ChapterExtractor.GetChapterDiscription());
        }
        [Test]
        public void EmailIsValidTest()
        {
            Assert.AreEqual(true, EmailSender.EmailIsValid("123@mail.ru"));
            Assert.AreEqual(false, EmailSender.EmailIsValid("@dsfsd."));
            Assert.AreEqual(false, EmailSender.EmailIsValid("adasd.asdsa"));
            Assert.AreEqual(false, EmailSender.EmailIsValid("dfggf"));
            Assert.AreEqual(true, EmailSender.EmailIsValid("1asdas.asdasd.23@mail.ru"));
            Assert.AreEqual(false, EmailSender.EmailIsValid("sadsad.asd123@@mail.ru"));
            Assert.AreEqual(false, EmailSender.EmailIsValid("sss@@@"));
            Assert.AreEqual(false, EmailSender.EmailIsValid("@d"));
            Assert.AreEqual(true, EmailSender.EmailIsValid("123d@gmail.ru"));
        }

    }
}