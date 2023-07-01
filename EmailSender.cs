﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAnalizer
{
    public class EmailSender
    {
        public static void SendEmail()
        { 

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Port = 25;
            client.EnableSsl = true;
            client.DeliveryFormat = SmtpDeliveryFormat.International;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Host = "smtp.mail.ru";
            client.Timeout = 300000;
            client.Credentials = new NetworkCredential("testemailpmi@mail.ru", "uh5eEnELhmNQjemDHmWz");
            //82.yc2RbN-diPQ_
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("testemailpmi@mail.ru");
            mailMessage.To.Add("vichuzhanin.ilya@gmail.com");
            mailMessage.Body = "Разметка";
            mailMessage.Subject = "Отчет о главах в файле";
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.BodyTransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            client.Send(mailMessage);
        }
        public static bool EmailIsValid(string emaildress)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(emaildress, expression))
            {
                if (Regex.Replace(emaildress, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}