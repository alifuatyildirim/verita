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

            
            string fromAddress = "iletisimverita@hotmail.com";
            string fromPassword = "Iletisim.Verita!2024";
            MailAddress from = new MailAddress(fromAddress); 

            using (SmtpClient client = new SmtpClient("outlook.office365.com", 587) { DeliveryMethod = SmtpDeliveryMethod.Network, EnableSsl = true, UseDefaultCredentials = false })
            {
                client.Credentials = new System.Net.NetworkCredential(fromAddress, fromPassword);

                MailAddress to = new MailAddress("iletisim@verita.com.tr");

                using (MailMessage message = new MailMessage(from, to) { IsBodyHtml = true })
                {
                    message.Subject = Subject;
                    message.Body = $@"
                        <html>
                        <body>
                            <h2>Verita İletişim Mesajı</h2>
                            <p><strong>Gönderen:</strong> {FullName}</p>
                            <p><strong>Email:</strong> {Email}</p>
                            <p><strong>Konu:</strong> {Subject}</p>
                            <p><strong>Mesaj:</strong> {Enquiry}</p>
                            <br/>
                            <h3><i># Bu mail, <u>verita.com.tr</u> web sitesinden gönderilmiştir. #</i></h3>
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
