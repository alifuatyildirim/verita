using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Verita.Application.MailService
{
    public class MailService : IMailService
    {
        public void SendMail(string FullName, string Email, string Subject, string Enquiry)
        {
            try
            {

            
            string fromAddress = "iletisim@verita.com.tr";
            string fromPassword = "ZCfk23Q1";
            MailAddress from = new MailAddress(fromAddress); 

            using (SmtpClient client = new SmtpClient("mail.verita.com.tr", 465) { DeliveryMethod = SmtpDeliveryMethod.Network, EnableSsl = true, UseDefaultCredentials = false })
            {
                client.Credentials = new System.Net.NetworkCredential(fromAddress, fromPassword);

                MailAddress to = new MailAddress(fromAddress);

                using (MailMessage message = new MailMessage(from, to) { IsBodyHtml = true })
                {
                    message.Subject = Subject;
                    message.Body = $@"
                        <html>
                        <body>
                            <h2>İletişim Formu Mesajı</h2>
                            <p><strong>Ad Soyad:</strong> {FullName}</p>
                            <p><strong>Email:</strong> {Email}</p>
                            <p><strong>Mesaj:</strong> {Enquiry}</p>
                        </body>
                        </html>";

                    client.Send(message);
                }
            }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
