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
        public static void ExportListItemToXML(ListView listView, string fileName)
        {
            XmlWriter writer = null;

            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = ("\t");
                settings.OmitXmlDeclaration = true;
                settings.Encoding = Encoding.UTF8;

                writer = XmlWriter.Create(fileName, settings);
                // Запись комментария:
                writer.WriteComment(" Пример генерации файла " + fileName + " из таблицы DataGridView ");
                writer.WriteStartElement("table");
                writer.WriteStartElement("tbody");
                // Запись заголовка таблицы HTML:
                writer.WriteStartElement("tr");


                writer.WriteElementString("th", "Номер главы");
                writer.WriteElementString("th", "Название главы");
                writer.WriteElementString("th", "Количество параграфов");
                writer.WriteElementString("th", "Количество символов");

                writer.WriteEndElement();  // закрытие тега tr
                                           // Запись всех строк:
                foreach (ListViewItem item in listView.Items)
                {
                    writer.WriteStartElement("tr");
                    foreach (ListViewSubItem value in item.SubItems)
                    {
                        if (value.Text != null)
                            writer.WriteElementString("td", value.Text.ToString());
                        else
                            writer.WriteElementString("td", " ");
                    }
                    writer.WriteEndElement();  // закрытие тега tr
                }
                writer.WriteEndElement();  // закрытие тега tbody
                writer.WriteEndElement();  // закрытие тега table
                writer.Flush();
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        public static void ExportListItemToHTML(ListView listView, string fileName)
        {
            string html = "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:arial'>";
            //Adding HeaderRow.
            html += "<tr>";

            html += "<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + "Номер главы" + "</th>";
            html += "<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + "Название главы" + "</th>";
            html += "<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + "Количество параграфов" + "</th>";
            html += "<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + "Количество символов" + "</th>";

            html += "</tr>";
            //Adding DataRow.
            foreach (ListViewItem item in listView.Items)
            {
                html += "<tr>";
                foreach (ListViewSubItem value in item.SubItems)
                {
                    html += "<td style='width:120px;border: 1px solid #ccc'>" + value.Text.ToString() + "</td>";
                }
                html += "</tr>";
            }
            //Table end.
            html += "</table>";
        }
    }
}
