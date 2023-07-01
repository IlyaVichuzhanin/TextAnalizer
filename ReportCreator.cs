using DocumentFormat.OpenXml.Linq;
using DocumentFormat.OpenXml.Office2019.Excel.RichData2;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.ListViewItem;

namespace TextAnalizer
{
    public class ReportCreator
    {
        public static XmlDocument GetXMLReport(ListView listView)
        {
            StringWriter stringwriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringwriter);
            xmlTextWriter.Formatting = Formatting.Indented;

            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Indent = true;
            //settings.IndentChars = ("\t");
            //settings.OmitXmlDeclaration = true;
            //settings.Encoding = Encoding.UTF8;

            //writer = XmlWriter.Create(fileName, settings);
            // Запись комментария:

            //var x = XmlWriter.Create(fileName, settings);

            xmlTextWriter.WriteStartElement("table");
            xmlTextWriter.WriteStartElement("tbody");
            // Запись заголовка таблицы HTML:
            xmlTextWriter.WriteStartElement("tr");


            xmlTextWriter.WriteElementString("th", "Номер главы");
            xmlTextWriter.WriteElementString("th", "Название главы");
            xmlTextWriter.WriteElementString("th", "Количество параграфов");
            xmlTextWriter.WriteElementString("th", "Количество символов");

            xmlTextWriter.WriteEndElement();  // закрытие тега tr
                                              // Запись всех строк:
            foreach (ListViewItem item in listView.Items)
            {
                xmlTextWriter.WriteStartElement("tr");
                foreach (ListViewSubItem value in item.SubItems)
                {
                    if (value.Text != null)
                        xmlTextWriter.WriteElementString("td", value.Text.ToString());
                    else
                        xmlTextWriter.WriteElementString("td", " ");
                }
                xmlTextWriter.WriteEndElement();  // закрытие тега tr
            }
            xmlTextWriter.WriteEndElement();  // закрытие тега tbody
            xmlTextWriter.WriteEndElement();  // закрытие тега table
            xmlTextWriter.Flush();


            XmlDocument document = new XmlDocument();
            document.LoadXml(stringwriter.ToString());


            return document;
        }
        public static string GetHTMLReport(ListView listView)
        {
            string htmlReport = "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:arial'>";
            //Adding HeaderRow.
            htmlReport += "<tr>";

            htmlReport += "<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + "Номер главы" + "</th>";
            htmlReport += "<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + "Название главы" + "</th>";
            htmlReport += "<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + "Количество параграфов" + "</th>";
            htmlReport += "<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + "Количество символов" + "</th>";

            htmlReport += "</tr>";
            //Adding DataRow.
            foreach (ListViewItem item in listView.Items)
            {
                htmlReport += "<tr>";
                foreach (ListViewSubItem value in item.SubItems)
                {
                    htmlReport += "<td style='width:120px;border: 1px solid #ccc'>" + value.Text.ToString() + "</td>";
                }
                htmlReport += "</tr>";
            }
            //Table end.
            htmlReport += "</table>";
            return htmlReport;
            
        }
    }
}
